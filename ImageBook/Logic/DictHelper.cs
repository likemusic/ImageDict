using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImageBook.Entity;
using System.IO;

namespace ImageBook.Logic
{
    public class DictHelper
    {
        public DictData OpenFromDir(string Directory)
        {
            var DefaultSettings = Properties.Settings.Default;
            string ContentFilename = Path.Combine(Directory, DefaultSettings.DefaultContentsListFilename);

            var ContentsList = LoadContentsListFromTxtFile(ContentFilename);
            DictDataSettings DictDataSettings = GetDictDataSettings(Directory);
            var Ret = new DictData()
            {
                Contents = ContentsList,
                FileFormatString = DictDataSettings.FileFormatString,
                SourceDir = Directory,
                StartOffset = DictDataSettings.StartOffset,
                MinPage = DictDataSettings.MinPage,
                MaxPage = (DictDataSettings.MaxPage == 0) ? (DictDataSettings.MinPage + ContentsList.Count) : DictDataSettings.MaxPage
            };
            return Ret;
        }

        public Dictionary<string, int> LoadContentsListFromTxtFile(string Filename)
        {
            var FileLines = File.ReadLines(Filename);
            var Ret = FileLines.Select((value, index) => new { value, index })
                .ToDictionary(pair => pair.value, pair => pair.index);
            return Ret;
        }

        public string GetFilenameBySearchString(string SearchString, DictData DictData, out int PageNumber)
        {
            SearchString = SearchString.Trim().ToUpper();
            Dictionary<string, int> Content = DictData.Contents;

            bool StopSearch = false;
            string CurrentSearchString = String.Empty;
            int SearchStringLength = SearchString.Length;
            int SaveNumber = 0;
            int NewNumber = 0;
            for (var i = 0; (i < SearchStringLength) && (!StopSearch); i++)
            {
                CurrentSearchString = SearchString.Substring(0, i + 1);
                NewNumber = Content.Skip(SaveNumber).FirstOrDefault(item => item.Key.StartsWith(CurrentSearchString)).Value;
                if (NewNumber == 0) StopSearch = true;
                else SaveNumber = NewNumber;
            }
            SaveNumber += DictData.StartOffset;

            string Filename = GetFilenameByPageNumber(SaveNumber, DictData);
            PageNumber = SaveNumber;
            return Filename;
        }

        public string GetFilenameByPageNumber(int PageNumber, DictData DictData)
        {
            string Filename = PageNumber.ToString(DictData.FileFormatString) + ".jpg";
            Filename = Path.Combine(DictData.SourceDir, Filename);
            return Filename;
        }

        protected DictDataSettings GetDictDataSettings(string Directory)
        {
            DictDataSettings Ret;
            string Filename = Path.Combine(Directory, Properties.Settings.Default.DefaultSettingsFilename);
            if (File.Exists(Filename))
            {
                Ret = JsonSerializer.Deserialize<DictDataSettings>(Filename);
            }
            else
            {
                var DefultSettings = Properties.Settings.Default;
                Ret = new DictDataSettings
                {
                    FileFormatString = DefultSettings.DefaultFileFormatString,
                    StartOffset = DefultSettings.DefaultStartOffset
                };
                //JsonSerializer.Serialize<DictDataSettings>(Ret, Filename);
            }
            return Ret;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImageDict.Entity;
using System.IO;

namespace ImageDict.Logic
{
    public class DictHelper
    {
        public DictData OpenFromDir(string Directory)
        {
            var DefaultSettings = Properties.Settings.Default;
            string ContentFilename = Path.Combine(Directory, DefaultSettings.DefaultContentsListFilename);

            var ContentsList = LoadContentsListFromTxtFile(ContentFilename);
            DictDataSettings DictDataSettings = GetDictDataSettings(Directory);
          
            int FilesCountForContent = (int) Math.Ceiling((double) (ContentsList.Count / DictDataSettings.WordsPerFile));
            
            int MaxPageByContent =  FilesCountForContent * DictDataSettings.PagesPerFile + DictDataSettings.StartDictPage;
            int MaxPage = MaxPageByContent;
            int MaxFileNumberByMaxPageByContent = (int) Math.Ceiling((double) (MaxPageByContent - DictDataSettings.MinPage) / DictDataSettings.PagesPerFile) + DictDataSettings.MinFileNumber;

            if ((DictDataSettings.MaxFileNumber > MaxFileNumberByMaxPageByContent) || (DictDataSettings.MaxFileNumber == 0)) DictDataSettings.MaxFileNumber = MaxFileNumberByMaxPageByContent;
            else
            {
                MaxPage = (DictDataSettings.MaxFileNumber - DictDataSettings.MinFileNumber + 1) * DictDataSettings.PagesPerFile + DictDataSettings.MinPage - 1;
            }

            DictDataSettings.MaxPage = MaxPage;

            var Ret = new DictData()
            {
                Contents = ContentsList,
                Settings = DictDataSettings,
                SourceDir = Directory
            };
            return Ret;
        }

        public Dictionary<string, int> LoadContentsListFromTxtFile(string Filename)
        {
            var FileLines = File.ReadLines(Filename);
            var Ret = FileLines.Select((pvalue, index) => new { value = pvalue.ToUpper(), index })
                .ToDictionary(pair => pair.value, pair => pair.index);
            return Ret;
        }

        public string GetFilenameBySearchString(string SearchString, DictData DictData, out int PageNumber, out int ImageNumber, out int ImagePart)
        {
            SearchString = SearchString.Trim().ToUpper();
            Dictionary<string, int> Content = DictData.Contents;

            bool StopSearch = false;
            string CurrentSearchString = String.Empty;
            int SearchStringLength = SearchString.Length;
            int SaveNumber = 0;
            for (var i = 0; (i < SearchStringLength) && (!StopSearch); i++)
            {
                CurrentSearchString = SearchString.Substring(0, i + 1);
                var Find = Content.Skip(SaveNumber).FirstOrDefault(item => item.Key.StartsWith(CurrentSearchString));
                if (Find.Key == null) StopSearch = true;
                else SaveNumber = Find.Value;
            }
            
            var Settings = DictData.Settings;
            int StringIndex = SaveNumber;//номер найденной строки в списке строк

            float FileOffset = StringIndex / Settings.WordsPerFile; //смещение строки в файлах (относительно первого файла с контентом из списка)
            int PageOffset = (int)(FileOffset * Settings.PagesPerFile); //смещение строки в страницах (относительно первой страницы с контентом из списка)
            PageNumber = Settings.StartDictPage + PageOffset;//номер страницы
            string Filename = GetFilenameByPageNumber(PageNumber, DictData, out ImageNumber, out ImagePart);
            return Filename;
        }

        public string GetFilenameByPageNumber(int PageNumber, DictData DictData, out int ImageNumber, out int ImagePart)
        {
            var Settings = DictData.Settings;
            
            int OffsetInPages = PageNumber - Settings.MinPage;//смещение в страницах (относительно первой имеющейся страницы)
            float OffsetInFiles = OffsetInPages / Settings.PagesPerFile;//смещение в файлах (относительно первого имеющегося файла)
            float FloatImageNumber = OffsetInFiles + Settings.MinFileNumber;//номер файла с дробной частью.
            ImageNumber = (int)FloatImageNumber;//целочисленный номер файла
            float FloatPart = FloatImageNumber - ImageNumber;//дробный остаток от номера страницы
            ImagePart = (int)(FloatPart * Settings.PagesPerFile);//номер части страницы

            string Filename = GetFilenameByFileNumber(ImageNumber, DictData);
            return Filename;
        }

        public string GetFilenameByFileNumber(int PageNumber, DictData DictData)
        {
            string Filename = PageNumber.ToString(DictData.Settings.FileFormatString) + ".jpg";
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
                    StartDictPage = DefultSettings.DefaultStartOffset
                };
                //JsonSerializer.Serialize<DictDataSettings>(Ret, Filename);
            }
            return Ret;
        }
    }
}

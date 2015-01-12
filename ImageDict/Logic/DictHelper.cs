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

            DictDataSettings DictDataSettings = GetDictDataSettings(Directory);

            var Dicts = LoadContentsListFromTxtFile(ContentFilename,DictDataSettings.ContentHaveEnds,DictDataSettings.ContentColumnSeparator);
            var ContentsList = Dicts[0];
            var ContentsListEnds = Dicts[1];

          
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
                ContentsEnds = ContentsListEnds,
                Settings = DictDataSettings,
                SourceDir = Directory
            };
            return Ret;
        }

        public Dictionary<string, int>[] LoadContentsListFromTxtFile(string Filename, bool HaveEnds = false, string Separator = ";" )
        {
            Dictionary<string, int> FirstDict,LastDict;
            FirstDict = LastDict = null;
            var FileLines = File.ReadLines(Filename);
            if (!HaveEnds)
            {
                FirstDict = FileLines.Select((pvalue, index) => new { value = pvalue.ToUpper(), index })
                    .ToDictionary(pair => pair.value, pair => pair.index);
            }
            else
            {
                FirstDict = new Dictionary<string, int>();
                LastDict = new Dictionary<string, int>();

                int i = 0;
                foreach (var Line in FileLines)
                {
                    string LineUpper = Line.ToUpper();
                    var Chunks = LineUpper.Split(new string[] { Separator }, StringSplitOptions.RemoveEmptyEntries);
                    FirstDict.Add(Chunks[0].Trim(),i);
                    LastDict.Add(Chunks[1].Trim(), i);
                    i++;
                }
            }

            var Ret = new Dictionary<string, int>[2]
            {
                FirstDict,
                LastDict
            };
                        
            return Ret;
        }

        public string GetFilenameBySearchString(string SearchString, DictData DictData, out int PageNumber, out int ImageNumber, out int ImagePart)
        {
            SearchString = SearchString.Trim().ToUpper();
            Dictionary<string, int> Content = DictData.Contents;
            Dictionary<string, int> ContentEnds = DictData.ContentsEnds;
            bool HaveContentHaveEnds = DictData.Settings.ContentHaveEnds;

            string CurrentSearchString = String.Empty;
            string MatchedString = String.Empty;
            string FindedString = String.Empty;

            int SearchStringLength = SearchString.Length;
            int MatchedIndex = -1;
            var Find = Content.FirstOrDefault(item => (String.Compare(item.Key, SearchString, StringComparison.OrdinalIgnoreCase) >= 0));
            if (Find.Key != null)
            {
                MatchedIndex = Find.Value;
                FindedString = Find.Key;

                if (!HaveContentHaveEnds) MatchedIndex--;
                else if(MatchedIndex > 0)
                {
                    string PrevEndsStr = ContentEnds.ElementAt(MatchedIndex - 1).Key;
                    if (String.Compare(SearchString, PrevEndsStr, StringComparison.OrdinalIgnoreCase) <= 0) MatchedIndex--;
                }
            }
                
            if (MatchedIndex < 0) MatchedIndex = 0;//нету совпадения ни одной буквы
           
            var Settings = DictData.Settings;
            int StringIndex = MatchedIndex;//номер найденной строки в списке строк

            float FileOffset = (float)StringIndex / Settings.WordsPerFile; //смещение строки в файлах (относительно первого файла с контентом из списка)
            int PageOffset = (int)(FileOffset * Settings.PagesPerFile); //смещение строки в страницах (относительно первой страницы с контентом из списка)
            PageNumber = Settings.StartDictPage + PageOffset;//номер страницы
            string Filename = GetFilenameByPageNumber(PageNumber, DictData, out ImageNumber, out ImagePart);
            return Filename;
        }

        public string GetFilenameByPageNumber(int PageNumber, DictData DictData, out int ImageNumber, out int ImagePart)
        {
            var Settings = DictData.Settings;
            
            int OffsetInPages = PageNumber - Settings.MinPage;//смещение в страницах (относительно первой имеющейся страницы)
            float OffsetInFiles = (float) OffsetInPages / Settings.PagesPerFile;//смещение в файлах (относительно первого имеющегося файла)
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
                    StartDictPage = DefultSettings.DefaultStartOffset,
                    ContentColumnSeparator = DefultSettings.DefaultContentColumnSeparator,
                    ContentHaveEnds = DefultSettings.DefaultContentHaveEnds
                };
                //JsonSerializer.Serialize<DictDataSettings>(Ret, Filename);
            }
            return Ret;
        }
    }
}

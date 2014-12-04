using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImageBook.Entity;
using System.IO;

namespace ImageBook.Logic
{
    public class ContentsListHelper
    {
        public Dictionary<string,int> LoadFromTxtFile(string Filename)
        {
            var FileLines = File.ReadLines(Filename);
            var Ret = FileLines.Select((value, index) => new { value, index })
                .ToDictionary(pair => pair.value, pair => pair.index);
            return Ret;
        }

        public string GetFilenameBySearchString(string SearchString, Dictionary<string,int> Content)
        {
            SearchString = SearchString.Trim().ToUpper();

            bool StopSearch = false;
            string CurrentSearchString = String.Empty;
            int SearchStringLength = SearchString.Length;
            int SaveNumber = 0;
            int NewNumber = 0;
            for (var i = 0; (i < SearchStringLength) && (!StopSearch); i++)
            {
                CurrentSearchString = SearchString.Substring(0, i+1);
                NewNumber = Content.Skip(SaveNumber).FirstOrDefault(item => item.Key.StartsWith(CurrentSearchString)).Value;
                if (NewNumber == 0) StopSearch = true;
                else SaveNumber = NewNumber;
            }

            string Filename = SaveNumber.ToString("0000") + ".jpg";
            return Filename;
        }
    }
}

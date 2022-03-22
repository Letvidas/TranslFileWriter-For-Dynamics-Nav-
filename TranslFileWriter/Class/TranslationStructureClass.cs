using System;
using System.Collections.Generic;

namespace TranslFileWriter.Class
{
    public class TranslationStructureClass
    {
        public List<string> StartLine = new();
        public List<string> Source = new();
        public List<string> Target = new();
        public List<string> Note1 = new();
        public List<string> Note2 = new();
        public List<string> EndLine = new();
        public List<string> FileStart = new();
        public List<string> FileEnd = new();
        public List<string> SearchNote2Parameters = new();
        public Boolean Full;

        //gets splited lines
        public void GetNote2Value()
        {
            SearchNote2Parameters.Clear();
            Boolean a;
            foreach (string item in Note2)
            {
                a = false;
                if (containsExtension(item) && item.Contains('-'))
                {
                    string[] itemSplit = item.Split("<note from=\"Xliff Generator\" annotates=\"general\" priority=\"3\">");
                    string[] itemSplit2 = itemSplit[1].Split("</");
                    if (containsExtension(itemSplit2[0]) && itemSplit2[0].Contains('-'))
                    {
                        itemSplit2[0] = SplitExtension(itemSplit2);
                    }
                    SearchNote2Parameters.Add(itemSplit2[0]);
                    a = true;
                }
                if (a == false)
                {
                    SearchNote2Parameters.Add(item);
                }
            }
        }

        private Boolean containsExtension(string item)
        {
            Boolean answer = item.Contains("TableExtension") || item.Contains("EnumExtension") ||
                          item.Contains("ReportExtension") || item.Contains("PageExtension");
            return answer;
        }


        //returns splited line
        public string ReturnSplitedLine(string lineToSplit)
        {
            if (containsExtension(lineToSplit) && lineToSplit.Contains('-'))
            {
                string[] itemSplit = lineToSplit.Split("<note from=\"Xliff Generator\" annotates=\"general\" priority=\"3\">");
                string[] itemSplit2 = itemSplit[1].Split("</");
                if (containsExtension(itemSplit2[0]) && itemSplit2[0].Contains('-'))
                {
                    itemSplit2[0] = SplitExtension(itemSplit2);
                    lineToSplit = itemSplit2[0];
                }
            }
            return lineToSplit;
        }

        // Splits Note2 to dispose of extension id
        public string SplitExtension(string[] itemSplit)
        {
            string[] splitedLines;
            string returnValue = "";
            string[] extensiontype;
            splitedLines = itemSplit[0].Split('-');
            if (Full == false)
            {
                extensiontype = splitedLines[0].Split(' ');
            }
            else
            {
                extensiontype = splitedLines;
            }
            int count = 0;
            foreach (string line in splitedLines)
            {
                if (count > 0)
                {
                    if (count == 1)
                    {
                        returnValue = returnValue + line;
                    }
                    else
                    {
                        returnValue = returnValue + "-" + line;
                    }
                }
                count++;
            }
            returnValue = returnValue + extensiontype[0];
            return returnValue;
        }
    }


}

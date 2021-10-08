using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void GetNote2Value()
        {      
            foreach (string item in Note2)
            {
                string[] itemSplit = item.Split("<note from=\"Xliff Generator\" annotates=\"general\" priority=\"3\">");
                string[] itemSplit2 = itemSplit[1].Split("</");
                SearchNote2Parameters.Add(itemSplit2[0]);
            }
        }

        public string ReturnSplitedLine(string lineToSplit)
        {
            string[] itemSplit = lineToSplit.Split("<note from=\"Xliff Generator\" annotates=\"general\" priority=\"3\">");
            string[] itemSplit2 = itemSplit[1].Split("</");
            return itemSplit2[0];
        }
    }

    
}

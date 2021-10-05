using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslFileWriter.Class
{
    public class TranslationStructureClass
    {
        public List<string> StartLine = new List<string>();
        public List<string> Source = new List<string>();
        public List<string> Target = new List<string>();
        public List<string> Note1 = new List<string>();
        public List<string> Note2 = new List<string>();
        public List<string> EndLine = new List<string>();
        public List<string> FileStart = new List<string>();
        public List<string> FileEnd = new List<string>();
        public List<string> SearchNote2Parameters = new List<string>();

        public void getNote2Value()
        {      
            foreach (string item in Note2)
            {
                string[] itemSplit = item.Split("<note from=\"Xliff Generator\" annotates=\"general\" priority=\"3\">");
                string[] itemSplit2 = itemSplit[1].Split("</");
                SearchNote2Parameters.Add(itemSplit2[0]);
            }
        }

    }

    
}

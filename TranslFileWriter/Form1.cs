﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TranslFileWriter.Class;
using System.IO;
using System.Threading;


namespace TranslFileWriter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            checkBox2.Enabled = false;
        }

        public string path;
        public bool read1Path = false;
        public bool read2Path = false;
        public TranslationStructureClass WriteTo = new();
        public TranslationStructureClass WriteFrom = new();

        private void WhereToWriteButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new())
            {
                ofd.Filter = "XLIFF (*.xlf)|*.xlf|All files (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    writeToTextBox.Text = ofd.FileName;
                    ReadPathBox1File();
                }
            }
        }

        private void WhereToReadFromButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new())
            {
                ofd.Filter = "XLIFF (*.xlf)|*.xlf|All files (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    readFromTextBox.Text = ofd.FileName;
                    ReadPathBox2File();
                }
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WriteButton_Click(object sender, EventArgs e)
        {

            //Check if file exists
            if (File.Exists(readFromTextBox.Text) && File.Exists(writeToTextBox.Text))
            {
                //Read just in case user didint press
                if (read1Path == false)
                ReadPathBox1File();
                if (read1Path == false)
                ReadPathBox2File();
                //read Document if checked with trans ID/ If not checked Note2
                if (checkBox1.Checked)
                {
                    ReadFromTranslationFile();
                }
                else
                {
                    ReadFromTranslationFileNote2();
                }
                //Write option Translations
                if (checkBox2.Checked)
                {
                    WriteOptionToEnum();
                }
                //Write to new File 
                //CreateNewFile(WriteTo,readFromTextBox.Text);
            }
            //If both files are written, but path is incorrect
            else
            {
                if (readFromTextBox.Text == "" || writeToTextBox.Text == "")
                {
                    MessageBox.Show("Please enter paths");
                }
                else if (!File.Exists(readFromTextBox.Text) && !File.Exists(writeToTextBox.Text))
                {
                    MessageBox.Show("Both paths doesn't exist");
                    readFromTextBox.Text = "";
                    writeToTextBox.Text = "";
                }
                else if (!File.Exists(writeToTextBox.Text))
                {
                    MessageBox.Show("File to write to path doesnt exist");
                    writeToTextBox.Text = "";
                }
                else
                {
                    MessageBox.Show("File to read from path doesnt exist");
                    readFromTextBox.Text = "";
                }
            }
        }


        private void ReadPathBox1File()
        {
            //Read File which you want to change
            int Iteration = 0;
            WriteTo = new TranslationStructureClass();
            if (File.ReadAllLines(writeToTextBox.Text, Encoding.Default).Length > 16)
            {
                checkBox2.Enabled = false;
                checkBox2.Checked = false;
                foreach (string line in File.ReadAllLines(writeToTextBox.Text))
                {
                    if (line.Contains("EnumValue"))
                    {
                        checkBox2.Enabled = true;
                        checkBox2.Checked = true;
                    }
                    if (line.Contains("<trans-unit"))
                       {
                        WriteTo.Target.Add("          <target state=\"needs-translation\"/>");
                        WriteTo.StartLine.Add(line);
                    }
                    //If starting file has <target then save value
                    else if (line.Contains("<target"))
                    {
                        WriteTo.Target[WriteTo.Target.Count - 1] = line;
                    }
                    else if (line.Contains("<source>"))
                    {
                        WriteTo.Source.Add(line);
                    }
                    else if (line.Contains("<note") && Iteration == 0)
                    {
                        WriteTo.Note1.Add(line.Replace("\"></note>", "\"/>"));
                        Iteration = 1;
                    }
                    else if (line.Contains("<note") && Iteration == 1)
                    {
                        WriteTo.Note2.Add(line);
                        if (WriteTo.Note2[WriteTo.Note2.Count-1].Contains("Enum"))
                        {
                            WriteTo.Note1[WriteTo.Note1.Count - 1] = WriteTo.Note1[WriteTo.Note1.Count - 1].Replace("\"/>","\"></note>");
                        }
                        Iteration = 0;
                    }
                    else if (line.Contains("</trans-unit"))
                    {
                        WriteTo.EndLine.Add(line);
                    }
                    else
                    {
                        MessageBox.Show(line);
                    }
                }
                MessageBox.Show("Translation File Uploaded");
                WriteTo.GetNote2Value();
                read1Path = true;
            }
            else
            {
                MessageBox.Show("Empty file");
                writeToTextBox.ResetText();
            }
        }

        private void ReadPathBox2File()
        {
            //Read File which you want to change
            int Iteration = 0;
            WriteFrom = new TranslationStructureClass();
            if (File.ReadAllLines(readFromTextBox.Text).Length > 16)
            {
                foreach (string line in File.ReadAllLines(readFromTextBox.Text, Encoding.Default))
                {
                    if (line.Contains("<trans-unit"))
                    {
                        WriteFrom.StartLine.Add(line);
                    }
                    //If starting file has <target then save value
                    else if (line.Contains("<target"))
                    {
                        WriteFrom.Target.Add(line);
                    }
                    else if (line.Contains("<source>"))
                    {
                        WriteFrom.Source.Add(line);
                    }
                    else if (line.Contains("<note") && Iteration == 0)
                    {
                        WriteFrom.Note1.Add(line);
                        Iteration = 1;
                    }
                    else if (line.Contains("<note") && Iteration == 1)
                    {
                        WriteFrom.Note2.Add(line);
                        Iteration = 0;
                    }
                    else if (line.Contains("</trans-unit"))
                    {
                        WriteFrom.EndLine.Add(line);
                    }
                }
                WriteFrom.GetNote2Value();
                MessageBox.Show("Translation Upload File Uploaded");
                read2Path = true;
            }
            else
            {
                MessageBox.Show("Empty file");
                writeToTextBox.ResetText();
            }
        }

        static private void CreateNewFile(TranslationStructureClass WriteTo, string readpath)
        {
            MessageBox.Show("Create translated file");
            string FileName = Path.GetFileName(readpath);
            SaveFileDialog saveFileDialog1 = new();
            saveFileDialog1.FileName = FileName;
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new(saveFileDialog1.OpenFile(),  Encoding.Default);
                int iter = 0;
                foreach (string item in WriteTo.FileStart)
                {
                    writer.WriteLine(item);
                }
                foreach (string s in WriteTo.StartLine)
                {
                    writer.WriteLine(WriteTo.StartLine[iter]);
                    writer.WriteLine(WriteTo.Source[iter]);
                    writer.WriteLine(WriteTo.Target[iter]);
                    writer.WriteLine(WriteTo.Note1[iter]);
                    writer.WriteLine(WriteTo.Note2[iter]);
                    writer.WriteLine(WriteTo.EndLine[iter]);
                    iter++;
                }
                foreach (string item in WriteTo.FileEnd)
                {
                    writer.WriteLine(item);
                }

                writer.Dispose();
                writer.Close();
            }

        }

        //Reads with note2 (Default)
        private void ReadFromTranslationFileNote2()
        {
            File.Delete("log.txt");
            string TempLine = "";
            string SearchLine;
            int a = 0;
            int IterationStart = 0;
            WriteTo.FileEnd.Clear();
            WriteTo.FileStart.Clear();
            //int LineCount = File.ReadAllLines(readFromTextBox.Text).Length;
            foreach (string line in File.ReadAllLines(readFromTextBox.Text))
            {
                if (line.Contains("<target"))
                {
                    TempLine = line;
                }
                else if (line.Contains("<note from=\"Xliff Generator\""))
                {
                    SearchLine = line;
                    foreach (string SrcLine in WriteTo.SearchNote2Parameters)
                    {
                        if (SearchLine.Contains(SrcLine))
                        {
                            if (WriteTo.ReturnSplitedLine(SearchLine).Equals(SrcLine))
                            {
                                if (TempLine.Contains("state=\"translated\""))
                                {
                                    WriteTo.Target[a] = TempLine;
                                    break;
                                }
                                else if (TempLine.Contains("state=\"needs-translation\""))
                                {
                                    WriteTo.Target[a] = TempLine;
                                    break;
                                }
                                else
                                {
                                    WriteTo.Target[a] = TempLine.Insert(17, " state=\"translated\"");
                                    break;
                                }
                            }
                        }
                        a++;
                        if (a == WriteTo.SearchNote2Parameters.Count)
                        {
                                File.AppendAllText("log.txt", SearchLine + System.Environment.NewLine);
                            //MessageBox.Show("This entry is not found:= " + TempLine);
                        }
                    }
                    a = 0;
                }
                else if (IterationStart < 5)
                {
                    if (line.Contains("<file datatype"))
                    {
                        WriteTo.FileStart.Add(GetFileDataType(line));
                    }
                    else if (line.Contains("utf"))
                    {
                        WriteTo.FileStart.Add(line.Replace("utf", "UTF"));
                    }
                    else
                    {
                        WriteTo.FileStart.Add(line);
                    }
                    IterationStart++;
                }
                else if (line.Contains("</group>") || line.Contains("</body>") || line.Contains("</file>") || line.Contains("</xliff>"))
                {
                    WriteTo.FileEnd.Add(line);
                }
            }
            if (File.Exists("log.txt"))
            {
                MessageBox.Show("There are some translations that missed the target. Please save Log file");
                SaveFileDialog newlog = new();
                newlog.FileName= "log.txt";
                newlog.Filter = "(*.txt)|*.txt";
                newlog.FilterIndex = 2;
                if (newlog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter writer = new(newlog.OpenFile(), Encoding.Default);
                    writer.Write(File.ReadAllText("log.txt"));
                    writer.Dispose();
                    writer.Close();
                }
            }
        }

        //Reads from transunit ID
        private void ReadFromTranslationFile()
        {
            File.Delete("log.txt");
            string TempLine = "";
            int a = 0;
            int IterationStart = 0;
            WriteTo.FileEnd.Clear();
            WriteTo.FileStart.Clear();
            //int LineCount = File.ReadAllLines(readFromTextBox.Text).Length;
            foreach (string line in File.ReadAllLines(readFromTextBox.Text, Encoding.Default))
            {
                if (line.Contains("<trans-unit"))
                {
                    TempLine = line;
                }
                else if (line.Contains("<target"))
                {
                    foreach (string StartLine in WriteTo.StartLine)
                    {
                        if (TempLine == StartLine)
                        {
                            if (line.Contains("state=\"translated\""))
                            {
                                WriteTo.Target[a] = line;
                                break;
                            }
                            else if (line.Contains("state=\"needs-translation\""))
                            {
                                WriteTo.Target[a] = line;
                                break;
                            }
                            else
                            {
                                WriteTo.Target[a] = line.Insert(17, " state=\"translated\"");
                                break;
                            }
                        }
                        a++;
                        if (a == WriteTo.Target.Count)
                        {
                            File.AppendAllText("log.txt", TempLine.TrimStart() + System.Environment.NewLine);
                            //MessageBox.Show("This entry is not found:= " + TempLine);
                        }
                    }
                    a = 0;
                }
                else if (IterationStart < 5)
                {
                    if (line.Contains("<file datatype"))
                    {
                        WriteTo.FileStart.Add(GetFileDataType(line));
                    }
                    else if (line.Contains("utf"))
                    {          
                        WriteTo.FileStart.Add(line.Replace("utf", "UTF"));
                    }
                    else
                    {
                        WriteTo.FileStart.Add(line);
                    } 
                    IterationStart++;
                }
                else if (line.Contains("</group>") || line.Contains("</body>") || line.Contains("</file>") || line.Contains("</xliff>"))
                {
                    WriteTo.FileEnd.Add(line);
                }
            }

            if (File.Exists("log.txt"))
            {
                MessageBox.Show("Translations which missed the target (log.txt file located in bin/debug folder): " + System.Environment.NewLine + File.ReadAllText("log.txt"));
            }
        }

        private string GetFileDataType(string line)
        {
            string temp1;
            string[] temp = new string [9];
            //randa, line kuriame datatype ir replacina "Please update this value" į tinkamą
            foreach (string tLine in File.ReadAllLines(writeToTextBox.Text))
            {
                if (tLine.Contains("<file datatype"))
                {
                    temp1 = tLine;
                    temp = temp1.Split("\"");
                    break;
                }
            }
            temp1 = temp[7];
            line = line.Replace("Please update this value", temp1);
            return line;
        }

        private void WriteOptionToEnum()
        {
            int linePos = 0;
            string targetString;
            string sourceString;
            foreach (string line in WriteFrom.Note2)
            {

                if (line.Contains("OptionCaption"))
                { 
                    targetString = WriteFrom.Target[linePos];
                    targetString = targetString.Trim();
                    targetString = targetString.Replace("<target>", "");
                    targetString = targetString.Replace("</target>", "");
                    //targetString = targetString.TrimStart();
                    string[] subTargetStrings = targetString.Split(",");

                    sourceString = WriteFrom.Source[linePos];
                    sourceString = sourceString.Trim();
                    sourceString = sourceString.Replace("<source>", "");
                    sourceString = sourceString.Replace("</source>", "");
                    string[] subSourceStrings = sourceString.Split(",");
                    if (subTargetStrings.Length == subSourceStrings.Length)
                    {
                        int sourceValuePos = 0;
                        foreach (string sourceValue in subSourceStrings)
                        {
                            int linePos2 = 0;
                            foreach (string line2 in WriteTo.StartLine)
                            {
                                if (line2.Contains("EnumValue"))
                                {
                                    if (subSourceStrings[sourceValuePos] == " ")
                                    {

                                    }
                                    else if (WriteTo.Source[linePos2].Contains(sourceValue))
                                    {
                                        //MessageBox.Show(subTargetStrings[sourceValuePos]);
                                        //MessageBox.Show(WriteTo.Target[linePos2]);
                                        //subTargetStrings[sourceValuePos].TrimStart()

                                        if (subSourceStrings[sourceValuePos] == " ")
                                        {
                                            WriteTo.Target[linePos2] = WriteTo.Target[linePos2].Replace("\"needs-translation\"/>", "\"translated\">" + " " + "</target>");
                                        }
                                        else if (subSourceStrings[sourceValuePos] == "")
                                        {
                                            WriteTo.Target[linePos2] = WriteTo.Target[linePos2];
                                            //WriteTo.Target[linePos2] = WriteTo.Target[linePos2].Replace("\"needs-translation\"/>", "\"translated\">" + " " + "</target>");
                                        }
                                        else
                                        {
                                            WriteTo.Target[linePos2] = WriteTo.Target[linePos2].Replace("\"needs-translation\"/>", "\"translated\">" + subTargetStrings[sourceValuePos].TrimStart() + "</target>");
                                        }

                                        WriteTo.Note1[linePos2] = WriteTo.Note1[linePos2].Replace("\"/>", "\"></note>");
                                        break;
                                    }
                                }

                                linePos2++;
                            }
                            sourceValuePos++;
                        }
                    }
                }

                linePos++;
            }
        }

        private void WriteToTextBox_TextChanged(object sender, EventArgs e)
        {
            //Saves memory by not performing upload to class two times (false = need to upload data to class)
            read1Path = false;
        }

        private void ReadFromTextBox_TextChanged(object sender, EventArgs e)
        {
            //Saves memory by not performing upload to class two times (false = need to upload data to class)
            read2Path = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateNewFile(WriteTo, readFromTextBox.Text);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

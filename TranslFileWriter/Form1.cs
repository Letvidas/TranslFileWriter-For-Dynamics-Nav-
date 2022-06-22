using System;
using System.Text;
using System.Windows.Forms;
using TranslFileWriter.Class;
using System.IO;
using System.Threading;
using System.Diagnostics;


namespace TranslFileWriter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            checkBox2.Enabled = false;
        }

        private bool _read1Path;
        private bool _read2Path;
        private TranslationStructureClass _writeTo = new();
        private TranslationStructureClass _writeFrom = new();
        private int _count;
        private Stopwatch _st;

        private void WhereToWriteButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new())
            {
                ofd.Filter = @"XLIFF (*.xlf)|*.xlf|All files (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    writeToTextBox.Text = ofd.FileName;
                    ReadPathBox1File();
                }
            }
        }

        private void SetProgressBar()
        {
            progressBar1.Maximum = _count;
            progressBar1.Minimum = 0;
            progressBar1.Value = 0;
            progressBar1.Visible = true;
        }
        private void WhereToReadFromButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new())
            {
                ofd.Filter = @"XLIFF (*.xlf)|*.xlf|All files (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    readFromTextBox.Text = ofd.FileName;
                    ReadPathBox2File();
                }
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void WriteButton_Click(object sender, EventArgs e)
        {
            //Check if file exists
            if (File.Exists(readFromTextBox.Text) && File.Exists(writeToTextBox.Text))
            {
                //Read just in case user didint press
                if (_read1Path == false)
                    ReadPathBox1File();
                if (_read2Path == false)
                    ReadPathBox2File();
                //read Document if checked with trans ID/ If not checked Note2
                if (checkBox1.Checked)
                {
                    label5.Text = @"00s 00m";
                    SetProgressBar();
                    timer1.Interval = 1000;
                    timer1.Enabled = true;
                    timer1.Tick += timer1_Tick;
                    timer1.Start();
                    Thread thread = new Thread(ReadFromTranslationFile);
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                }
                else
                {
                    label5.Text = @"00s 00m";
                    SetProgressBar();
                    timer1.Interval = 1000;
                    timer1.Enabled = true;
                    timer1.Tick += timer1_Tick;
                    timer1.Start();
                    Thread thread = new Thread(ReadFromTranslationFileNote2);
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                    //ReadFromTranslationFileNote2();
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
                    MessageBox.Show(@"Please enter paths");
                }
                else if (!File.Exists(readFromTextBox.Text) && !File.Exists(writeToTextBox.Text))
                {
                    MessageBox.Show(@"Both paths doesn't exist");
                    readFromTextBox.Text = "";
                    writeToTextBox.Text = "";
                }
                else if (!File.Exists(writeToTextBox.Text))
                {
                    MessageBox.Show(@"File to write to path doesn't exist");
                    writeToTextBox.Text = "";
                }
                else
                {
                    MessageBox.Show(@"File to read from path doesn't exist");
                    readFromTextBox.Text = "";
                }
            }
        }


        private void ReadPathBox1File()
        {
            //Read File which you want to change
            int iteration = 0;
            _writeTo = new TranslationStructureClass();
            if (File.ReadAllLines(writeToTextBox.Text, Encoding.Default).Length > 13)
            {
                checkBox2.Enabled = false;
                checkBox2.Checked = false;
                foreach (string line in File.ReadAllLines(writeToTextBox.Text, Encoding.Default))
                {
                    if (line.Contains("EnumValue"))
                    {
                        checkBox2.Enabled = true;
                        checkBox2.Checked = true;
                    }
                    if (line.Contains("<trans-unit"))
                    {
                        _writeTo.Target.Add("          <target state=\"needs-translation\"/>");
                        _writeTo.StartLine.Add(line);
                    }
                    //If starting file has <target then save value
                    else if (line.Contains("<target"))
                    {
                        _writeTo.Target[_writeTo.Target.Count - 1] = line;
                    }
                    else if (line.Contains("<source>"))
                    {
                        _writeTo.Source.Add(line);
                    }
                    else if (line.Contains("<note") && iteration == 0)
                    {
                        _writeTo.Note1.Add(line.Replace("\"></note>", "\"/>"));
                        iteration = 1;
                    }
                    else if (line.Contains("<note") && iteration == 1)
                    {
                        _writeTo.Note2.Add(line);
                        if (_writeTo.Note2[_writeTo.Note2.Count - 1].Contains("Enum"))
                        {
                            _writeTo.Note1[_writeTo.Note1.Count - 1] = _writeTo.Note1[_writeTo.Note1.Count - 1].Replace("\"/>", "\"></note>");
                        }
                        iteration = 0;
                    }
                    else if (line.Contains("</trans-unit"))
                    {
                        _writeTo.EndLine.Add(line);
                    }
                    else
                    {
                        //MessageBox.Show(line);
                    }
                }
                MessageBox.Show(@"Translation File Uploaded");
                _writeTo.GetNote2Value();
                _read1Path = true;
            }
            else
            {
                MessageBox.Show(@"Empty file");
                writeToTextBox.ResetText();
            }
        }

        private void ReadPathBox2File()
        {
            //Read File which you want to change
            _count = 0;
            int iteration = 0;
            _writeFrom = new TranslationStructureClass();
            if (File.ReadAllLines(readFromTextBox.Text).Length > 13)
            {
                foreach (string line in File.ReadAllLines(readFromTextBox.Text, Encoding.Default))
                {
                    if (line.Contains("<trans-unit"))
                    {
                        _writeFrom.StartLine.Add(line);
                    }
                    //If starting file has <target then save value
                    else if (line.Contains("<target"))
                    {
                        _writeFrom.Target.Add(line);
                    }
                    else if (line.Contains("<source>"))
                    {
                        _writeFrom.Source.Add(line);
                    }
                    else if (line.Contains("<note") && iteration == 0)
                    {
                        _writeFrom.Note1.Add(line);
                        iteration = 1;
                    }
                    else if (line.Contains("<note") && iteration == 1)
                    {

                        _writeFrom.Note2.Add(line);
                        iteration = 0;

                        if (_writeFrom.Note2.Count > _writeFrom.Target.Count)
                        {
                            _writeFrom.Target.Add("          <target state=\"needs-translation\"");
                        }
                    }
                    else if (line.Contains("</trans-unit"))
                    {
                        _writeFrom.EndLine.Add(line);
                    }
                    _count++;
                }
                _writeFrom.GetNote2Value();
                MessageBox.Show(@"Translation Upload File Uploaded");
                _read2Path = true;
            }
            else
            {
                MessageBox.Show(@"Empty file");
                readFromTextBox.ResetText();
            }
        }

        private static void CreateNewFile(TranslationStructureClass writeTo, string readPath)
        {
            MessageBox.Show(@"Create translated file");
            string fileName = Path.GetFileName(readPath);
            SaveFileDialog saveFileDialog1 = new();
            saveFileDialog1.FileName = fileName;
            saveFileDialog1.Filter = @"txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new(saveFileDialog1.OpenFile(), Encoding.Default);
                int iter = 0;
                foreach (string item in writeTo.FileStart)
                {
                    writer.WriteLine(item);
                }
                foreach (string unused in writeTo.StartLine)
                {
                    writer.WriteLine(writeTo.StartLine[iter]);
                    writer.WriteLine(writeTo.Source[iter]);
                    writer.WriteLine(writeTo.Target[iter]);
                    writer.WriteLine(writeTo.Note1[iter]);
                    writer.WriteLine(writeTo.Note2[iter]);
                    writer.WriteLine(writeTo.EndLine[iter]);
                    iter++;
                }
                foreach (string item in writeTo.FileEnd)
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
            string tempLine = "";
            string searchLine;
            int a = 0;
            int iterationStart = 0;
            string sourceline = "";
                _writeTo.FileEnd.Clear();
            _writeTo.FileStart.Clear();
            //int LineCount = File.ReadAllLines(readFromTextBox.Text).Length;
            //int LineCount = File.ReadAllLines(readFromTextBox.Text).Length;
            _st = new Stopwatch();
            _st.Start();
            MethodInvoker labelShow5 = () => label5.Visible = true;
            MethodInvoker labelShow4 = () => label4.Visible = true;
            label4.Invoke(labelShow4);
            label5.Invoke(labelShow5);
            var countLinesForLog = 0;
            foreach (string line in File.ReadAllLines(readFromTextBox.Text, Encoding.Default))
            {
                if (line.Contains("<source"))
                {
                    sourceline = line;
                }
                if (line.Contains("<target"))
                {
                    tempLine = line;
                }
                else if (line.Contains("<note from=\"Xliff Generator\""))
                {
                    countLinesForLog++;
                    searchLine = line;
                    searchLine = _writeTo.ReturnSplitedLine(searchLine);
                    int counter = 0;
                    foreach (string srcLine in _writeTo.SearchNote2Parameters)
                    {
                        
                        //if (SearchLine.Contains(SrcLine))
                        //{
                        //    MessageBox.Show(WriteTo.ReturnSplitedLine(SearchLine));
                        //    MessageBox.Show(SrcLine);
                        if (searchLine.Equals(srcLine))
                        {
                            if (_writeTo.Source[counter] == sourceline)
                            {
                                if (tempLine.Contains("state=\"translated\""))
                                {
                                    _writeTo.Target[a] = tempLine;
                                    break;
                                }
                                else if (tempLine.Contains("state=\"needs-translation\""))
                                {
                                    _writeTo.Target[a] = tempLine;
                                    break;
                                }
                                else
                                {
                                    _writeTo.Target[a] = tempLine.Insert(17, " state=\"translated\"");
                                    break;
                                }
                                // }
                            }
                        }
                        a++;
                        if (a == _writeTo.SearchNote2Parameters.Count)
                        {
                            File.AppendAllText("log.txt", _writeFrom.StartLine[countLinesForLog-1] + Environment.NewLine +
                                                          _writeFrom.Source[countLinesForLog-1] + Environment.NewLine +
                                                          _writeFrom.Target[countLinesForLog-1] + Environment.NewLine +
                                                          line + Environment.NewLine + Environment.NewLine);
                            //MessageBox.Show("This entry is not found:= " + TempLine);
                        }
                        counter++;
                    }
                    a = 0;
                }
                else if (iterationStart < 5)
                {
                    if (line.Contains("<file datatype"))
                    {
                        _writeTo.FileStart.Add(GetFileDataType(line));
                    }
                    else if (line.Contains("utf"))
                    {
                        _writeTo.FileStart.Add(line.Replace("utf", "UTF"));
                    }
                    else
                    {
                        _writeTo.FileStart.Add(line);
                    }
                    iterationStart++;
                }
                else if (line.Contains("</group>") || line.Contains("</body>") || line.Contains("</file>") || line.Contains("</xliff>"))
                {
                    _writeTo.FileEnd.Add(line);
                }
                MethodInvoker up = () => progressBar1.Value++;
                progressBar1.Invoke(up);
            }
            MethodInvoker labelHide5 = () => label5.Visible = false;
            MethodInvoker labelHide4 = () => label4.Visible = false;
            MethodInvoker vis = () => progressBar1.Visible = false;
            progressBar1.Invoke(vis);
            label4.Invoke(labelHide4);
            label5.Invoke(labelHide5);
            _st.Stop();
            _st.Reset();
            timer1.Stop();
            if (File.Exists("log.txt"))
            {
                MessageBox.Show(@"There are some translations that missed the target. Please save Log file");
                SaveFileDialog newLog = new();
                newLog.FileName = "log.txt";
                newLog.Filter = @"(*.txt)|*.txt";
                newLog.FilterIndex = 2;
                if (newLog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter writer = new(newLog.OpenFile(), Encoding.Default);
                    writer.Write(File.ReadAllText("log.txt"));
                    writer.Dispose();
                    writer.Close();
                }
            }
            else
            {
                MessageBox.Show(@"Translations transferred");
            }

        }

        //Reads from transunit ID
        private void ReadFromTranslationFile()
        {
            File.Delete("log.txt");
            string tempLine = "";
            int a = 0;
            int iterationStart = 0;
            _writeTo.FileEnd.Clear();
            _writeTo.FileStart.Clear();
            //int LineCount = File.ReadAllLines(readFromTextBox.Text).Length;
            _st = new Stopwatch();
            _st.Start();
            MethodInvoker labelShow5 = () => label5.Visible = true;
            MethodInvoker labelShow4 = () => label4.Visible = true;
            label4.Invoke(labelShow4);
            label5.Invoke(labelShow5);

            foreach (string line in File.ReadAllLines(readFromTextBox.Text, Encoding.Default))
            {
                if (line.Contains("<trans-unit"))
                {
                    tempLine = line;
                }
                else if (line.Contains("<target"))
                {
                    foreach (string startLine in _writeTo.StartLine)
                    {
                        if (tempLine == startLine)
                        {
                            if (line.Contains("state=\"translated\""))
                            {
                                _writeTo.Target[a] = line;
                                break;
                            }
                            else if (line.Contains("state=\"needs-translation\""))
                            {
                                _writeTo.Target[a] = line;
                                break;
                            }
                            else
                            {
                                _writeTo.Target[a] = line.Insert(17, " state=\"translated\"");
                                break;
                            }
                        }
                        a++;
                        if (a == _writeTo.Target.Count)
                        {
                            File.AppendAllText("log.txt", tempLine.TrimStart() + Environment.NewLine);
                            //MessageBox.Show("This entry is not found:= " + TempLine);
                        }
                    }
                    a = 0;
                }
                else if (iterationStart < 5)
                {
                    if (line.Contains("<file datatype"))
                    {
                        _writeTo.FileStart.Add(GetFileDataType(line));
                    }
                    else if (line.Contains("utf"))
                    {
                        _writeTo.FileStart.Add(line.Replace("utf", "UTF"));
                    }
                    else
                    {
                        _writeTo.FileStart.Add(line);
                    }
                    iterationStart++;
                }
                else if (line.Contains("</group>") || line.Contains("</body>") || line.Contains("</file>") || line.Contains("</xliff>"))
                {
                    _writeTo.FileEnd.Add(line);
                }
                MethodInvoker up = () => progressBar1.Value++;
                progressBar1.Invoke(up);
            }

            MethodInvoker labelHide5 = () => label5.Visible = false;
            MethodInvoker labelHide4 = () => label4.Visible = false;
            MethodInvoker vis = () => progressBar1.Visible = false;
            progressBar1.Invoke(vis);
            label4.Invoke(labelHide4);
            label5.Invoke(labelHide5);
            _st.Stop();
            _st.Reset();
            timer1.Stop();

            if (File.Exists("log.txt"))
            {
                MessageBox.Show(@"Translations which missed the target (log.txt file located in bin/debug folder): " + Environment.NewLine + File.ReadAllText("log.txt"));
            }
        }

        private string GetFileDataType(string line)
        {
            string temp1;
            string[] temp = new string[9];
            //randa, line kuriame datatype ir pakeičia "Please update this value" į tinkamą
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
            foreach (string line in _writeFrom.Note2)
            {

                if (line.Contains("OptionCaption"))
                {
                    targetString = _writeFrom.Target[linePos];
                    targetString = targetString.Trim();
                    targetString = targetString.Replace("<target>", "");
                    targetString = targetString.Replace("</target>", "");
                    //targetString = targetString.TrimStart();
                    string[] subTargetStrings = targetString.Split(",");

                    sourceString = _writeFrom.Source[linePos];
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
                            foreach (string line2 in _writeTo.StartLine)
                            {
                                if (line2.Contains("EnumValue"))
                                {
                                    if (subSourceStrings[sourceValuePos] == " ")
                                    {

                                    }
                                    else if (_writeTo.Source[linePos2].Contains(sourceValue))
                                    {
                                        //MessageBox.Show(subTargetStrings[sourceValuePos]);
                                        //MessageBox.Show(WriteTo.Target[linePos2]);
                                        //subTargetStrings[sourceValuePos].TrimStart()

                                        if (subSourceStrings[sourceValuePos] == " ")
                                        {
                                            _writeTo.Target[linePos2] = _writeTo.Target[linePos2].Replace("\"needs-translation\"/>", "\"translated\">" + " " + "</target>");
                                        }
                                        else if (subSourceStrings[sourceValuePos] == "")
                                        {
                                            _writeTo.Target[linePos2] = _writeTo.Target[linePos2];
                                            //WriteTo.Target[linePos2] = WriteTo.Target[linePos2].Replace("\"needs-translation\"/>", "\"translated\">" + " " + "</target>");
                                        }
                                        else
                                        {
                                            _writeTo.Target[linePos2] = _writeTo.Target[linePos2].Replace("\"needs-translation\"/>", "\"translated\">" + subTargetStrings[sourceValuePos].TrimStart() + "</target>");
                                        }

                                        _writeTo.Note1[linePos2] = _writeTo.Note1[linePos2].Replace("\"/>", "\"></note>");
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
            _read1Path = false;
        }

        private void ReadFromTextBox_TextChanged(object sender, EventArgs e)
        {
            //Saves memory by not performing upload to class two times (false = need to upload data to class)
            _read2Path = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateNewFile(_writeTo, readFromTextBox.Text);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            _writeFrom.Full = checkBox3.Checked;
            _writeTo.Full = checkBox3.Checked;
            _writeFrom.GetNote2Value();
            _writeTo.GetNote2Value();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MethodInvoker lblupd = () => label5.Text = _st.Elapsed.Minutes.ToString() + @"m " + _st.Elapsed.Seconds.ToString() + @"s";
            label5.Invoke(lblupd);
            Application.DoEvents();
        }

    }
}

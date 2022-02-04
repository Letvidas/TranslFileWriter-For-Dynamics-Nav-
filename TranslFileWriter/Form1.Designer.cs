
namespace TranslFileWriter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.writeToTextBox = new System.Windows.Forms.TextBox();
            this.readFromTextBox = new System.Windows.Forms.TextBox();
            this.whereToWriteButton = new System.Windows.Forms.Button();
            this.WhereToReadFromButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.writeButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(271, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "File to write to";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "File to read from";
            // 
            // writeToTextBox
            // 
            this.writeToTextBox.Location = new System.Drawing.Point(271, 145);
            this.writeToTextBox.Name = "writeToTextBox";
            this.writeToTextBox.Size = new System.Drawing.Size(402, 27);
            this.writeToTextBox.TabIndex = 2;
            this.writeToTextBox.TextChanged += new System.EventHandler(this.WriteToTextBox_TextChanged);
            // 
            // readFromTextBox
            // 
            this.readFromTextBox.Location = new System.Drawing.Point(271, 264);
            this.readFromTextBox.Name = "readFromTextBox";
            this.readFromTextBox.Size = new System.Drawing.Size(402, 27);
            this.readFromTextBox.TabIndex = 3;
            this.readFromTextBox.TextChanged += new System.EventHandler(this.ReadFromTextBox_TextChanged);
            // 
            // whereToWriteButton
            // 
            this.whereToWriteButton.Location = new System.Drawing.Point(75, 143);
            this.whereToWriteButton.Name = "whereToWriteButton";
            this.whereToWriteButton.Size = new System.Drawing.Size(180, 29);
            this.whereToWriteButton.TabIndex = 4;
            this.whereToWriteButton.Text = "Select (.xlf) file path:";
            this.whereToWriteButton.UseVisualStyleBackColor = true;
            this.whereToWriteButton.Click += new System.EventHandler(this.WhereToWriteButton_Click);
            // 
            // WhereToReadFromButton
            // 
            this.WhereToReadFromButton.Location = new System.Drawing.Point(75, 262);
            this.WhereToReadFromButton.Name = "WhereToReadFromButton";
            this.WhereToReadFromButton.Size = new System.Drawing.Size(180, 29);
            this.WhereToReadFromButton.TabIndex = 5;
            this.WhereToReadFromButton.Text = "Select (.xlf) file path:";
            this.WhereToReadFromButton.UseVisualStyleBackColor = true;
            this.WhereToReadFromButton.Click += new System.EventHandler(this.WhereToReadFromButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(75, 408);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(122, 29);
            this.exitButton.TabIndex = 6;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // writeButton
            // 
            this.writeButton.Location = new System.Drawing.Point(513, 297);
            this.writeButton.Name = "writeButton";
            this.writeButton.Size = new System.Drawing.Size(160, 29);
            this.writeButton.TabIndex = 7;
            this.writeButton.Text = "Write";
            this.writeButton.UseVisualStyleBackColor = true;
            this.writeButton.Click += new System.EventHandler(this.WriteButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Broadway", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(75, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(560, 32);
            this.label3.TabIndex = 8;
            this.label3.Text = "Simplanova Translation File Merger";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(75, 320);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(251, 24);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Check by trans ID (default Note2)";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(75, 351);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(226, 24);
            this.checkBox2.TabIndex = 10;
            this.checkBox2.Text = "Write From Options to Enums";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(513, 332);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 29);
            this.button1.TabIndex = 11;
            this.button1.Text = "Create Trans. File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(75, 381);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(208, 24);
            this.checkBox3.TabIndex = 12;
            this.checkBox3.Text = "Use if Extension ID\'s match";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(374, 398);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(299, 26);
            this.progressBar1.TabIndex = 13;
            this.progressBar1.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(374, 367);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Time Passed";
            this.label4.Visible = false;
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(470, 367);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "00:00";
            this.label5.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TranslFileWriter.Properties.Resources.Sharethrough_District_M_1024x1024;
            this.ClientSize = new System.Drawing.Size(699, 449);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.writeButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.WhereToReadFromButton);
            this.Controls.Add(this.whereToWriteButton);
            this.Controls.Add(this.readFromTextBox);
            this.Controls.Add(this.writeToTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Translation File Creator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox writeToTextBox;
        private System.Windows.Forms.TextBox readFromTextBox;
        private System.Windows.Forms.Button whereToWriteButton;
        private System.Windows.Forms.Button WhereToReadFromButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button writeButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}


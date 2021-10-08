﻿
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
            this.exitButton.Location = new System.Drawing.Point(75, 389);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TranslFileWriter.Properties.Resources.Sharethrough_District_M_1024x1024;
            this.ClientSize = new System.Drawing.Size(699, 458);
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
    }
}


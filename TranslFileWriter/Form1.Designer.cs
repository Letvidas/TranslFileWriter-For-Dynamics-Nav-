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
            this.whereToReadFromButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.writeButton = new System.Windows.Forms.Button();
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
            // 
            // readFromTextBox
            // 
            this.readFromTextBox.Location = new System.Drawing.Point(271, 264);
            this.readFromTextBox.Name = "readFromTextBox";
            this.readFromTextBox.Size = new System.Drawing.Size(402, 27);
            this.readFromTextBox.TabIndex = 3;
            // 
            // whereToWriteButton
            // 
            this.whereToWriteButton.Location = new System.Drawing.Point(75, 143);
            this.whereToWriteButton.Name = "whereToWriteButton";
            this.whereToWriteButton.Size = new System.Drawing.Size(180, 29);
            this.whereToWriteButton.TabIndex = 4;
            this.whereToWriteButton.Text = "Select (.xlf) file path:";
            this.whereToWriteButton.UseVisualStyleBackColor = true;
            this.whereToWriteButton.Click += new System.EventHandler(this.whereToWriteButton_Click);
            // 
            // whereToReadFromButton
            // 
            this.whereToReadFromButton.Location = new System.Drawing.Point(75, 262);
            this.whereToReadFromButton.Name = "whereToReadFromButton";
            this.whereToReadFromButton.Size = new System.Drawing.Size(180, 29);
            this.whereToReadFromButton.TabIndex = 5;
            this.whereToReadFromButton.Text = "Select (.xlf) file path:";
            this.whereToReadFromButton.UseVisualStyleBackColor = true;
            this.whereToReadFromButton.Click += new System.EventHandler(this.whereToReadFromButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(75, 389);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(122, 29);
            this.exitButton.TabIndex = 6;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // writeButton
            // 
            this.writeButton.Location = new System.Drawing.Point(513, 297);
            this.writeButton.Name = "writeButton";
            this.writeButton.Size = new System.Drawing.Size(160, 29);
            this.writeButton.TabIndex = 7;
            this.writeButton.Text = "Write";
            this.writeButton.UseVisualStyleBackColor = true;
            this.writeButton.Click += new System.EventHandler(this.writeButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.writeButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.whereToReadFromButton);
            this.Controls.Add(this.whereToWriteButton);
            this.Controls.Add(this.readFromTextBox);
            this.Controls.Add(this.writeToTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Translation File Creator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox writeToTextBox;
        private System.Windows.Forms.TextBox readFromTextBox;
        private System.Windows.Forms.Button whereToWriteButton;
        private System.Windows.Forms.Button whereToReadFromButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button writeButton;
    }
}


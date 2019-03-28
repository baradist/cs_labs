namespace lab4
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBoxQuickFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.textBoxWords = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listBoxQuizResults = new System.Windows.Forms.ListBox();
            this.buttonStartQuiz = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.labelWordsAmount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelNounsAmount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelVerbsAmount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelAdjectivesAmount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelAverageLenght = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(381, 436);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(373, 410);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dictionary";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBoxQuickFilter);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.listBox1);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSave);
            this.splitContainer1.Panel1.Controls.Add(this.buttonOpen);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBoxWords);
            this.splitContainer1.Size = new System.Drawing.Size(367, 404);
            this.splitContainer1.SplitterDistance = 258;
            this.splitContainer1.TabIndex = 0;
            // 
            // textBoxQuickFilter
            // 
            this.textBoxQuickFilter.Location = new System.Drawing.Point(257, 4);
            this.textBoxQuickFilter.Name = "textBoxQuickFilter";
            this.textBoxQuickFilter.Size = new System.Drawing.Size(100, 20);
            this.textBoxQuickFilter.TabIndex = 4;
            this.textBoxQuickFilter.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Quick filter";
            this.label1.Visible = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(4, 34);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(360, 225);
            this.listBox1.TabIndex = 2;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(85, 4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(4, 4);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 0;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            // 
            // textBoxWords
            // 
            this.textBoxWords.Location = new System.Drawing.Point(4, 4);
            this.textBoxWords.Multiline = true;
            this.textBoxWords.Name = "textBoxWords";
            this.textBoxWords.Size = new System.Drawing.Size(360, 135);
            this.textBoxWords.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBoxQuizResults);
            this.tabPage2.Controls.Add(this.buttonStartQuiz);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(373, 410);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Quiz";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listBoxQuizResults
            // 
            this.listBoxQuizResults.FormattingEnabled = true;
            this.listBoxQuizResults.Location = new System.Drawing.Point(7, 37);
            this.listBoxQuizResults.Name = "listBoxQuizResults";
            this.listBoxQuizResults.Size = new System.Drawing.Size(360, 368);
            this.listBoxQuizResults.TabIndex = 1;
            // 
            // buttonStartQuiz
            // 
            this.buttonStartQuiz.Location = new System.Drawing.Point(7, 7);
            this.buttonStartQuiz.Name = "buttonStartQuiz";
            this.buttonStartQuiz.Size = new System.Drawing.Size(75, 23);
            this.buttonStartQuiz.TabIndex = 0;
            this.buttonStartQuiz.Text = "Start";
            this.buttonStartQuiz.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.labelAverageLenght);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.labelAdjectivesAmount);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.labelVerbsAmount);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.labelNounsAmount);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.labelWordsAmount);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(373, 410);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Statistics";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Word\'s amount";
            // 
            // labelWordsAmount
            // 
            this.labelWordsAmount.AutoSize = true;
            this.labelWordsAmount.Location = new System.Drawing.Point(158, 3);
            this.labelWordsAmount.Name = "labelWordsAmount";
            this.labelWordsAmount.Size = new System.Drawing.Size(35, 13);
            this.labelWordsAmount.TabIndex = 1;
            this.labelWordsAmount.Text = "label3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nouns";
            // 
            // labelNounsAmount
            // 
            this.labelNounsAmount.AutoSize = true;
            this.labelNounsAmount.Location = new System.Drawing.Point(158, 20);
            this.labelNounsAmount.Name = "labelNounsAmount";
            this.labelNounsAmount.Size = new System.Drawing.Size(35, 13);
            this.labelNounsAmount.TabIndex = 3;
            this.labelNounsAmount.Text = "label4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Verbs";
            // 
            // labelVerbsAmount
            // 
            this.labelVerbsAmount.AutoSize = true;
            this.labelVerbsAmount.Location = new System.Drawing.Point(158, 37);
            this.labelVerbsAmount.Name = "labelVerbsAmount";
            this.labelVerbsAmount.Size = new System.Drawing.Size(35, 13);
            this.labelVerbsAmount.TabIndex = 5;
            this.labelVerbsAmount.Text = "label5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Adjectives";
            // 
            // labelAdjectivesAmount
            // 
            this.labelAdjectivesAmount.AutoSize = true;
            this.labelAdjectivesAmount.Location = new System.Drawing.Point(158, 54);
            this.labelAdjectivesAmount.Name = "labelAdjectivesAmount";
            this.labelAdjectivesAmount.Size = new System.Drawing.Size(35, 13);
            this.labelAdjectivesAmount.TabIndex = 7;
            this.labelAdjectivesAmount.Text = "label6";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Average length";
            // 
            // labelAverageLenght
            // 
            this.labelAverageLenght.AutoSize = true;
            this.labelAverageLenght.Location = new System.Drawing.Point(158, 71);
            this.labelAverageLenght.Name = "labelAverageLenght";
            this.labelAverageLenght.Size = new System.Drawing.Size(35, 13);
            this.labelAverageLenght.TabIndex = 9;
            this.labelAverageLenght.Text = "label7";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form2";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.TextBox textBoxWords;
        private System.Windows.Forms.Button buttonStartQuiz;
        private System.Windows.Forms.ListBox listBoxQuizResults;
        private System.Windows.Forms.TextBox textBoxQuickFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label labelNounsAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelWordsAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelAverageLenght;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelAdjectivesAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelVerbsAmount;
        private System.Windows.Forms.Label label4;
    }
}

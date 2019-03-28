using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lab4
{
    public partial class FormQuestion : Form
    {
        List<Word> words;
        int count = 0;
        QuizResult result;

        public FormQuestion(List<Word> words)
        {
            InitializeComponent();

            buttonNext.Click += ButtonNext_Click;

            this.words = words;
            result = new QuizResult() { Questions = words.Count() };

            Ask();
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            if (!Correct())
            {
                result.Fails++;
            }
            count++;
            if (count == words.Count)
            {
                (Owner as Form1).bsResults.Add(result);
                this.Close();
                return;
            }
            Ask();
        }

        private bool Correct()
        {
            return words[count].translations.Contains(textBoxTranslation.Text.Trim());
        }

        private void Ask()
        {
            Text = "" + (count + 1) + " / " + words.Count();
            labelWord.Text = words[count].word;
            textBoxTranslation.Text = "";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                ButtonNext_Click(null, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

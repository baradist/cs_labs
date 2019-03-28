using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    public partial class FormAddWord : Form
    {
        public FormAddWord()
        {
            InitializeComponent();

            comboBoxType.DataSource = Enum.GetValues(typeof(Word.Type));
            comboBoxType.SelectedItem = Word.Type.Noun;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string word = this.textBoxWord.Text;
            string[] strings = this.textBoxTranslations.Lines;
            Word w = new Word((Word.Type) comboBoxType.SelectedItem, word, strings);
            (this.Owner as Form1).AddWord(w);
            this.Close();
        }
    }
}

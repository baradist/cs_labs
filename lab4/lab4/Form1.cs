using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace lab4
{
    public partial class Form1 : Form
    {
        List<Word> words = new List<Word>();
        BindingSource bs = new BindingSource();

        List<QuizResult> results = new List<QuizResult>();
        internal BindingSource bsResults = new BindingSource();

        public Form1()
        {
            InitializeComponent();

            bs.DataSource = words;
            listBox1.DataSource = bs;
            //listBox1.DisplayMember = "word";
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;

            bsResults.DataSource = results;
            listBoxQuizResults.DataSource = bsResults;

            buttonOpen.Click += ButtonOpen_Click;
            buttonSave.Click += ButtonSave_Click;
            buttonStartQuiz.Click += ButtonStartQuiz_Click;

            tabControl1.Selected += TabControl1_Selected;
        }

        private void TabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage3)
            {
                labelWordsAmount.Text = "" + words.Count;
                labelNounsAmount.Text = "" + words.Count(w => w.type == Word.Type.Noun);
                labelVerbsAmount.Text = "" + words.Count(w => w.type == Word.Type.Verb);
                labelAdjectivesAmount.Text = "" + words.Count(w => w.type == Word.Type.Adjective);
                labelAverageLenght.Text = "" +
                     (double) (from w in words select w.word.Length).Sum() / words.Count();
            }
        }

        private void ButtonStartQuiz_Click(object sender, EventArgs e)
        {
            var q = new FormQuestion(words);
            q.Show(this);
        }

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            var f = new OpenFileDialog();
            f.Filter += "Xml-files (*.xml) | *.xml|Binary-files (*.bin) | *.bin";
            if (f.ShowDialog() == DialogResult.OK)
            {
                if (f.FileName.ToLower().EndsWith("xml"))
                {
                    StandardXmlUnmarshal(f.FileName);
                }
                else
                {
                    BinDeser(f.FileName);
                }
                listBox1.SelectedIndex = 0;
                ListBox1_SelectedIndexChanged(null, null);
            }
        }

        private void StandardXmlUnmarshal(string fileName)
        {
            Stream sr = new FileStream(fileName, FileMode.Open);
            XmlSerializer xmlSer = new XmlSerializer(typeof(SaveContainer));
            SaveContainer container = (SaveContainer)xmlSer.Deserialize(sr);
            bs.DataSource = words = container.Words;
            bsResults.DataSource = results = container.QuizResults;
            sr.Close();
        }

        private void BinDeser(string fileName)
        {
            Stream stream = new FileStream(fileName, FileMode.Open);
            IFormatter fmt = new BinaryFormatter();
            SaveContainer container = (SaveContainer)fmt.Deserialize(stream);
            bs.DataSource = words = container.Words;
            bsResults.DataSource = results = container.QuizResults;
            stream.Close();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            var f = new SaveFileDialog();
            f.Filter += "Xml-files (*.xml) | *.xml|Binary-files (*.bin) | *.bin";
            if (f.ShowDialog() == DialogResult.OK)
            {
                if (f.FileName.ToLower().EndsWith("xml"))
                {
                    StandardXmlMarshal(f.FileName);
                }
                else
                {
                    BinSer(f.FileName);
                }
            }
        }

        void BinSer(string fileName)
        {
            BinaryFormatter fmt = new BinaryFormatter();
            using (var str = new FileStream(fileName, FileMode.Create))
            {
                fmt.Serialize(str, new SaveContainer() { Words = words, QuizResults = results });
            }
        }

        void StandardXmlMarshal(string fileName)
        {
            XmlSerializer ser = new XmlSerializer(typeof(SaveContainer));
            TextWriter stream = new StreamWriter(fileName);
            ser.Serialize(stream, new SaveContainer() { Words = words, QuizResults = results });
            stream.Close();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                textBoxWords.Text = "";
                return;
            }
            textBoxWords.Text = string.Join("\r\n", ((Word)listBox1.SelectedItem).translations);
        }

        internal void AddWord(Word w)
        {
            bs.Add(w);
            listBox1.SelectedItem = w;
            ListBox1_SelectedIndexChanged(null, null);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Delete)
            {
                if (listBox1.SelectedItem != null)
                {
                    bs.RemoveAt(listBox1.SelectedIndex);
                    return true;
                }
            }
            else if (keyData == Keys.Insert)
            {
                FormAddWord f = new FormAddWord();
                f.Show(this);
                return true;
            }
            else if (keyData == Keys.Up)
            {
                if (listBox1.SelectedIndex > 0)
                {
                    listBox1.SelectedIndex--;
                }
                ListBox1_SelectedIndexChanged(null, null);
                return true;
            }
            else if (keyData == Keys.Down)
            {
                if (listBox1.SelectedIndex + 1 < listBox1.Items.Count)
                {
                    listBox1.SelectedIndex++;
                }
                ListBox1_SelectedIndexChanged(null, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

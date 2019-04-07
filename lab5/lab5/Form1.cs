using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace lab5
{
    public partial class Form1 : Form
    {
        const string FILE_LOCATION_PREFIX = "../../resources/";
        const string FILE_MASKS = "Xml-files (*.xml) | *.xml|All files (*) | *";

        List<Country> countries;
        BindingSource bs;

        public Form1()
        {
            InitializeComponent();

            toolStripTextBoxFilter.TextChanged += ToolStripTextBoxFilter_TextChanged;
            grid.CellValidating += Grid_CellValidating;
            openToolStripButton.Click += OpenToolStripButton_Click;
            saveToolStripButton.Click += SaveToolStripButton_Click;

            countries = new List<Country>();
            bs = new BindingSource();
            bs.DataSource = countries;
            bs.Add(new Country() { ImageFileName = "berlin.jpg", Name = "Germany", Population = 81, Capital = "Berlin", Size = 357021 });

            grid.DataSource = bs;
            
            nav.BindingSource = bs;
            propGrid.DataBindings.Add("SelectedObject", bs, "");
            
            TunePic();
            TuneChart();
        }

        private void OpenToolStripButton_Click(object sender, EventArgs e)
        {
            var f = new OpenFileDialog();
            f.Filter += FILE_MASKS;
            if (f.ShowDialog() == DialogResult.OK)
            {
                StandardXmlUnmarshal(f.FileName);
            }
        }

        private void StandardXmlUnmarshal(string fileName)
        {
            Stream sr = new FileStream(fileName, FileMode.Open);
            XmlSerializer xmlSer = new XmlSerializer(typeof(List<Country>));
            countries = (List<Country>)xmlSer.Deserialize(sr);
            bs.DataSource = countries;
            bs.ResetBindings(false);
            sr.Close();
        }

        private void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            var f = new SaveFileDialog();
            f.Filter += FILE_MASKS;
            if (f.ShowDialog() == DialogResult.OK)
            {
                StandardXmlMarshal(f.FileName);
            }
        }

        void StandardXmlMarshal(string fileName)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Country>));
            TextWriter stream = new StreamWriter(fileName);
            ser.Serialize(stream, countries);
            stream.Close();
        }

        private void Grid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 3: // Population
                case 4: // Size
                    int val;
                    if (!int.TryParse(e.FormattedValue.ToString(), out val))
                    {
                        e.Cancel = true;
                    }
                    break;
            }
        }

        private void ToolStripTextBoxFilter_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBoxFilter.Text == "")
            {
                bs.DataSource = countries;
            }
            else
            {
                bs.DataSource = countries.Where(c => c.Name.ToLower().StartsWith(toolStripTextBoxFilter.Text.ToLower())).ToList();
            }
            bs.ResetBindings(false);
        }

        private void TunePic()
        {
            Binding bind = new Binding("ImageLocation", bs, "ImageFileName");
            bind.Format += (o, e) => e.Value = FILE_LOCATION_PREFIX + e.Value;
            bind.Parse += (o, e) => e.Value = (e.Value as string).Replace(FILE_LOCATION_PREFIX, "");
            picBox.DataBindings.Add(bind);
        }

        private void TuneChart()
        {
            chart1.DataSource = bs;
            chart1.Series[0].XValueMember = "Name";
            chart1.Series[0].YValueMembers = "Population";
            chart1.Legends.Clear();
            chart1.Titles.Add("Population");
           bs.CurrentChanged += (o, e) => chart1.DataBind();
        }
    }
}

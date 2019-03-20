using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace lab3
{
    public partial class FormParams : Form
    {
        internal Brush dotBrush;
        internal Brush lineBrush;

        public FormParams()
        {
            InitializeComponent();

            buttonDotColor.Click += ButtonDotColor_Click;
            SetDotColor(Color.Black);
            buttonLineColor.Click += ButtonLineColor_Click;
            SetLineColor(Color.Blue);

            comboBoxMoveType.DataSource = Enum.GetValues(typeof(MoveType));
            comboBoxMoveType.SelectedIndexChanged += (s, e) =>
                {
                    MoveType type;
                    Enum.TryParse<MoveType>(comboBoxMoveType.SelectedItem.ToString(), out type);
                    (Owner as Form1).bMooveType = type;
                    (Owner as Form1).MoveTypeChanged();
                };
        }

        private void ButtonLineColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            var res = cd.ShowDialog();
            if (res == DialogResult.OK)
            {
                SetLineColor(cd.Color);
            }
        }

        private void SetLineColor(Color color)
        {
            lineBrush = new SolidBrush(color);
            buttonLineColor.BackColor = color;
        }

        private void ButtonDotColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            var res = cd.ShowDialog();
            if (res == DialogResult.OK)
            {
                SetDotColor(cd.Color);
            }
        }

        private void SetDotColor(Color color)
        {
            dotBrush = new SolidBrush(color);
            buttonDotColor.BackColor = color;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}

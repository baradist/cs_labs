namespace lab3
{
    partial class FormParams
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LineWidth = new System.Windows.Forms.NumericUpDown();
            this.buttonOk = new System.Windows.Forms.Button();
            this.DotRadius = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxMoveType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Speed = new System.Windows.Forms.NumericUpDown();
            this.buttonDotColor = new System.Windows.Forms.Button();
            this.buttonLineColor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LineWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DotRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Speed)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dot radius";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Line width";
            // 
            // LineWidth
            // 
            this.LineWidth.Location = new System.Drawing.Point(144, 36);
            this.LineWidth.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.LineWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LineWidth.Name = "LineWidth";
            this.LineWidth.Size = new System.Drawing.Size(120, 20);
            this.LineWidth.TabIndex = 4;
            this.LineWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(188, 171);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 5;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // DotRadius
            // 
            this.DotRadius.Location = new System.Drawing.Point(144, 9);
            this.DotRadius.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.DotRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DotRadius.Name = "DotRadius";
            this.DotRadius.Size = new System.Drawing.Size(120, 20);
            this.DotRadius.TabIndex = 6;
            this.DotRadius.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Moving type";
            // 
            // comboBoxMoveType
            // 
            this.comboBoxMoveType.FormattingEnabled = true;
            this.comboBoxMoveType.Location = new System.Drawing.Point(144, 91);
            this.comboBoxMoveType.Name = "comboBoxMoveType";
            this.comboBoxMoveType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMoveType.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Speed";
            // 
            // Speed
            // 
            this.Speed.Location = new System.Drawing.Point(144, 118);
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(120, 20);
            this.Speed.TabIndex = 14;
            this.Speed.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // buttonDotColor
            // 
            this.buttonDotColor.Location = new System.Drawing.Point(15, 62);
            this.buttonDotColor.Name = "buttonDotColor";
            this.buttonDotColor.Size = new System.Drawing.Size(75, 23);
            this.buttonDotColor.TabIndex = 15;
            this.buttonDotColor.Text = "Dot color";
            this.buttonDotColor.UseVisualStyleBackColor = true;
            // 
            // buttonLineColor
            // 
            this.buttonLineColor.Location = new System.Drawing.Point(144, 62);
            this.buttonLineColor.Name = "buttonLineColor";
            this.buttonLineColor.Size = new System.Drawing.Size(75, 23);
            this.buttonLineColor.TabIndex = 16;
            this.buttonLineColor.Text = "Line color";
            this.buttonLineColor.UseVisualStyleBackColor = true;
            // 
            // FormParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 206);
            this.Controls.Add(this.buttonLineColor);
            this.Controls.Add(this.buttonDotColor);
            this.Controls.Add(this.Speed);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxMoveType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DotRadius);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.LineWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormParams";
            this.Text = "FormParams";
            ((System.ComponentModel.ISupportInitialize)(this.LineWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DotRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Speed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonOk;
        internal System.Windows.Forms.NumericUpDown DotRadius;
        internal System.Windows.Forms.NumericUpDown LineWidth;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox comboBoxMoveType;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.NumericUpDown Speed;
        private System.Windows.Forms.Button buttonLineColor;
        internal System.Windows.Forms.Button buttonDotColor;
    }
}

namespace lab3
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
            this.buttonDots = new System.Windows.Forms.Button();
            this.buttonParams = new System.Windows.Forms.Button();
            this.buttonMove = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonCurved = new System.Windows.Forms.Button();
            this.buttonPolygone = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.buttonFilled = new System.Windows.Forms.Button();
            this.buttonBezier = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonDots
            // 
            this.buttonDots.Location = new System.Drawing.Point(12, 12);
            this.buttonDots.Name = "buttonDots";
            this.buttonDots.Size = new System.Drawing.Size(75, 23);
            this.buttonDots.TabIndex = 0;
            this.buttonDots.Text = "Точки";
            this.buttonDots.UseVisualStyleBackColor = true;
            // 
            // buttonParams
            // 
            this.buttonParams.Location = new System.Drawing.Point(12, 41);
            this.buttonParams.Name = "buttonParams";
            this.buttonParams.Size = new System.Drawing.Size(75, 23);
            this.buttonParams.TabIndex = 1;
            this.buttonParams.Text = "Параметры";
            this.buttonParams.UseVisualStyleBackColor = true;
            // 
            // buttonMove
            // 
            this.buttonMove.Location = new System.Drawing.Point(12, 70);
            this.buttonMove.Name = "buttonMove";
            this.buttonMove.Size = new System.Drawing.Size(75, 23);
            this.buttonMove.TabIndex = 2;
            this.buttonMove.Text = "Движение";
            this.buttonMove.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(12, 99);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 3;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            // 
            // buttonCurved
            // 
            this.buttonCurved.Location = new System.Drawing.Point(12, 128);
            this.buttonCurved.Name = "buttonCurved";
            this.buttonCurved.Size = new System.Drawing.Size(75, 23);
            this.buttonCurved.TabIndex = 4;
            this.buttonCurved.Text = "Кривая";
            this.buttonCurved.UseVisualStyleBackColor = true;
            // 
            // buttonPolygone
            // 
            this.buttonPolygone.Location = new System.Drawing.Point(12, 157);
            this.buttonPolygone.Name = "buttonPolygone";
            this.buttonPolygone.Size = new System.Drawing.Size(75, 23);
            this.buttonPolygone.TabIndex = 5;
            this.buttonPolygone.Text = "Ломанная";
            this.buttonPolygone.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(12, 186);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 6;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // buttonFilled
            // 
            this.buttonFilled.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonFilled.Location = new System.Drawing.Point(12, 186);
            this.buttonFilled.Name = "buttonFilled";
            this.buttonFilled.Size = new System.Drawing.Size(75, 23);
            this.buttonFilled.TabIndex = 6;
            this.buttonFilled.Text = "Закрашенная";
            this.buttonFilled.UseVisualStyleBackColor = true;
            // 
            // buttonBezier
            // 
            this.buttonBezier.Location = new System.Drawing.Point(12, 215);
            this.buttonBezier.Name = "buttonBezier";
            this.buttonBezier.Size = new System.Drawing.Size(75, 23);
            this.buttonBezier.TabIndex = 7;
            this.buttonBezier.Text = "Безье";
            this.buttonBezier.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 366);
            this.Controls.Add(this.buttonBezier);
            this.Controls.Add(this.buttonFilled);
            this.Controls.Add(this.buttonPolygone);
            this.Controls.Add(this.buttonCurved);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonMove);
            this.Controls.Add(this.buttonParams);
            this.Controls.Add(this.buttonDots);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDots;
        private System.Windows.Forms.Button buttonParams;
        private System.Windows.Forms.Button buttonMove;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonCurved;
        private System.Windows.Forms.Button buttonPolygone;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button buttonFilled;
        private System.Windows.Forms.Button buttonBezier;
    }
}


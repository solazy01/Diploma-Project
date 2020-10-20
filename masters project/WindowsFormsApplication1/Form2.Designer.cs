namespace WindowsFormsApplication1
{
    partial class Form2
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
            this.Lm1 = new System.Windows.Forms.Label();
            this.hm1 = new System.Windows.Forms.HScrollBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.hy0 = new System.Windows.Forms.HScrollBar();
            this.Ly0 = new System.Windows.Forms.Label();
            this.hc = new System.Windows.Forms.HScrollBar();
            this.Lc = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.hm4 = new System.Windows.Forms.HScrollBar();
            this.Lm4 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.hm2 = new System.Windows.Forms.HScrollBar();
            this.Lm2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Масса груза:";
            // 
            // Lm1
            // 
            this.Lm1.AutoSize = true;
            this.Lm1.Location = new System.Drawing.Point(128, 26);
            this.Lm1.Name = "Lm1";
            this.Lm1.Size = new System.Drawing.Size(0, 13);
            this.Lm1.TabIndex = 1;
            // 
            // hm1
            // 
            this.hm1.LargeChange = 1;
            this.hm1.Location = new System.Drawing.Point(14, 49);
            this.hm1.Minimum = 1;
            this.hm1.Name = "hm1";
            this.hm1.Size = new System.Drawing.Size(194, 21);
            this.hm1.TabIndex = 2;
            this.hm1.Value = 10;
            this.hm1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hm1_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.hy0);
            this.groupBox1.Controls.Add(this.Ly0);
            this.groupBox1.Controls.Add(this.hc);
            this.groupBox1.Controls.Add(this.Lc);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.hm4);
            this.groupBox1.Controls.Add(this.Lm4);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.hm2);
            this.groupBox1.Controls.Add(this.Lm2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.hm1);
            this.groupBox1.Controls.Add(this.Lm1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(19, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 220);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Входящие параметры задачи";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Высота падения груза:";
            // 
            // hy0
            // 
            this.hy0.LargeChange = 1;
            this.hy0.Location = new System.Drawing.Point(14, 182);
            this.hy0.Name = "hy0";
            this.hy0.Size = new System.Drawing.Size(194, 21);
            this.hy0.TabIndex = 14;
            this.hy0.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hm1_Scroll);
            // 
            // Ly0
            // 
            this.Ly0.AutoSize = true;
            this.Ly0.Location = new System.Drawing.Point(184, 159);
            this.Ly0.Name = "Ly0";
            this.Ly0.Size = new System.Drawing.Size(0, 13);
            this.Ly0.TabIndex = 13;
            // 
            // hc
            // 
            this.hc.LargeChange = 1;
            this.hc.Location = new System.Drawing.Point(246, 114);
            this.hc.Minimum = 1;
            this.hc.Name = "hc";
            this.hc.Size = new System.Drawing.Size(194, 21);
            this.hc.TabIndex = 11;
            this.hc.Value = 40;
            this.hc.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hm1_Scroll);
            // 
            // Lc
            // 
            this.Lc.AutoSize = true;
            this.Lc.Location = new System.Drawing.Point(399, 91);
            this.Lc.Name = "Lc";
            this.Lc.Size = new System.Drawing.Size(0, 13);
            this.Lc.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(243, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Жесткость пружины:";
            // 
            // hm4
            // 
            this.hm4.LargeChange = 1;
            this.hm4.Location = new System.Drawing.Point(14, 114);
            this.hm4.Minimum = 1;
            this.hm4.Name = "hm4";
            this.hm4.Size = new System.Drawing.Size(194, 21);
            this.hm4.TabIndex = 8;
            this.hm4.Value = 10;
            this.hm4.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hm1_Scroll);
            // 
            // Lm4
            // 
            this.Lm4.AutoSize = true;
            this.Lm4.Location = new System.Drawing.Point(128, 91);
            this.Lm4.Name = "Lm4";
            this.Lm4.Size = new System.Drawing.Size(0, 13);
            this.Lm4.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Длина балки:";
            // 
            // hm2
            // 
            this.hm2.LargeChange = 1;
            this.hm2.Location = new System.Drawing.Point(246, 49);
            this.hm2.Minimum = 1;
            this.hm2.Name = "hm2";
            this.hm2.Size = new System.Drawing.Size(194, 21);
            this.hm2.TabIndex = 5;
            this.hm2.Value = 20;
            this.hm2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hm1_Scroll);
            // 
            // Lm2
            // 
            this.Lm2.AutoSize = true;
            this.Lm2.Location = new System.Drawing.Point(360, 26);
            this.Lm2.Name = "Lm2";
            this.Lm2.Size = new System.Drawing.Size(0, 13);
            this.Lm2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Масса балки:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WindowsFormsApplication1.Properties.Resources.Cancel;
            this.pictureBox2.Location = new System.Drawing.Point(508, 155);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(99, 79);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Image = global::WindowsFormsApplication1.Properties.Resources.ok;
            this.pictureBox1.Location = new System.Drawing.Point(508, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 244);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form2";
            this.Text = "Параметры задачи";
            this.Shown += new System.EventHandler(this.Form2_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Lm1;
        private System.Windows.Forms.HScrollBar hm1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.HScrollBar hm2;
        private System.Windows.Forms.Label Lm2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.HScrollBar hy0;
        private System.Windows.Forms.Label Ly0;
        private System.Windows.Forms.HScrollBar hc;
        private System.Windows.Forms.Label Lc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.HScrollBar hm4;
        private System.Windows.Forms.Label Lm4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
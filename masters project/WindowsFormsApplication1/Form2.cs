using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        float m1 = 5000, m2 = 400;
        float c = 4000;
        float h=1.2f;
        float l=3;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
             Metki();
            hm1.Value = Convert.ToInt32(m2/100);
            hm2.Value = Convert.ToInt32(m1/1000);
            hm4.Value = Convert.ToInt32(l);
            hc.Value = Convert.ToInt32(c/1000);
            hy0.Value = Convert.ToInt32(h);
           
           
        }

        private void hm1_Scroll(object sender, ScrollEventArgs e)
        {

            m2 = hm1.Value * 100.0f;
            m1 = hm2.Value * 1000.0f;
            l = hm4.Value;
            c = hc.Value * 1000f;
            h = hy0.Value;



         
            Metki();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            m2 = hm1.Value * 100.0f;
            m1 = hm2.Value * 1000.0f;
            l = hm4.Value;
            c = hc.Value * 1000f;
            h = hy0.Value;
            if (Tag == "1")
            {
                Form1 fG = Owner as Form1;
                fG.m1 = m1/5000;
                fG.m2 = m2/800;
                fG.l = l;
                fG.c = c/80;
                fG.hh = h;
            }
            else
            {
                Form4 fG = Owner as Form4;
                fG.m1 = m1 / 5000;
                fG.m2 = m2 / 800;
                fG.l = l;
                fG.c = c / 80;
                fG.hh = h;
            }
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            m1 = 5000;
            m2 = 400;
            c = 4000;
            h = 1.2f;
            l = 3;
            hm1.Value = Convert.ToInt32(m2 / 100);
            hm2.Value = Convert.ToInt32(m1 / 1000);
            hm4.Value = Convert.ToInt32(l);
            hc.Value = Convert.ToInt32(c / 1000);
            hy0.Value = Convert.ToInt32(h);

            double k = 2 * h / 3 * Math.Sqrt(3 * c / m1);

         

            double A = 3 * 9.81 * m2 / m1 / l;
            double omega0 = Math.Sqrt(2 * 9.81 * h) / l;
           
           
           
            Metki();
        }
        void Metki()
        {
            Lm1.Text = Convert.ToString(m2);
            Lm2.Text = Convert.ToString(m1);
            Lm4.Text = Convert.ToString(l);
            Lc.Text = Convert.ToString(c);
            Ly0.Text = Convert.ToString(h);
            
        }

        
    }
}

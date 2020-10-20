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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Owner = this;
            f1.Show();
            Application.Idle += new EventHandler(f1.OnIdle);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form4 f1 = new Form4();
            f1.Owner = this;
            f1.Show();
            Application.Idle += new EventHandler(f1.OnIdle);
        }
    }
}

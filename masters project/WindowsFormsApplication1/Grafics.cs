using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace WindowsFormsApplication1 
{
    public partial class Grafics : Form
    {
        GraphPane myPane = null;
        PointPairList list;
        

        public Grafics()
        {
            InitializeComponent();
            // Создадим списoк точек угол
            list = new PointPairList();
 
            
        }
       public void Grafic()
        {
           

            if (Tag=="1")
            {   Form1 fG = Owner as Form1;
                for(int i=0;i<fG.list.Count;i++)
                {
                    list.Add(fG.tT[i],fG.list[i]);
                }
            }
            else
            {Form4 fG = Owner as Form4;
            for (int i = 0; i < fG.list.Count; i++)
            {
                list.Add(fG.tT[i], fG.list[i]);
            }
            }
            // Задаем название графика и осей
            myPane.Title.Text = "";
            myPane.XAxis.Title.Text = "Ось t";
            myPane.YAxis.Title.Text = "Ось x";
   
            LineItem myCurve1 = myPane.AddCurve("", list, Color.Black);
                myCurve1.Symbol.IsVisible = false;
           
            //что-то вроде автомасштабирования осей
            zedGraphControl1.AxisChange();
            // Обновляем график
            zedGraphControl1.Invalidate();
        }

        private void Grafics_Load(object sender, EventArgs e)
        {
            myPane = zedGraphControl1.GraphPane;
            
        }

        private void Grafics_Shown(object sender, EventArgs e)
        {
            Grafic();
        }

       
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System.IO;


namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {
        Device d3d;

        float sdvig_x = -2.6f;
        float sdvig_y = -0.5f;
        float sdvig_z = 7.5f;

        Mesh cyl;
        Mesh cyl2;
        Mesh cyl3;

        //подшипник
        Mesh podshipnik1, tor_krep;
        float r_p = 0.15f;
        float t_tor = 0.03f;
              
        //толщина
        float delta = 0.1f;

        //тело
        float a = 0.10f;
        float h = 3f;
        Mesh box,plux;
        float r_plux = 0.1f;
        float t_plux = 0.05f; 

        //стенка
        float a_s = 0.5f, b_s = 15.0f, c_s = 3.5f;
        Mesh stenka;
        Texture sfera_texture;

        //балка
        float a_b = 5.0f, c_b = 0.05f, konec=0.5f;
        Mesh  balka;

        //подставка
        Mesh podstavka;
        float h_pod = 0.2f;

        //пружина
        Mesh sf;
        int n = 23;
        float hsp = 0.2f;
        float ymax = 4.5f;
        float dlina;
        float ykrep=0,ykrep1=0;
  
        //крепление пружины
        Mesh krep, korob, krep_up;
        float asp = 0.2f;
        float r_krep = 0.05f;
        float a_krep = 0.5f, c_krep = 0.5f;



        Material balkaMaterial, verevkaMaterial, boxMaterial;

        bool dv = false, nach=true;
        float koor = 0;
        bool zadacha = false;


        Runge rashet;
        float eps = 0.0001f;
        Runge.myF[] masF;
        float[] y;

        public float m1 = 1f, m2 = 0.5f;
        public float c = 75;
        public float y0=0,ys0=0;
        public float l = 3, hh = 1.2f;
        float t = 0,t1=0;
        float g = 9.81f;
        public float mu = 3f;


        float deltaT = 0.0015f;


        //float mm1 = 5000, mm2 = 400;

        public List<double> tT, list;

        public Form4()
        {
            InitializeComponent();
            SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);

        }
        public void OnIdle(object sender, EventArgs e)
        {
            Invalidate(); // Помечаем главное окно (this) как требующее перерисовки
        }


        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                PresentParameters d3dpp = new PresentParameters();
                d3dpp.BackBufferCount = 1;
                d3dpp.SwapEffect = SwapEffect.Discard;
                d3dpp.Windowed = true; // Выводим графику в окно
                d3dpp.MultiSample = MultiSampleType.None; // Выключаем антиалиасинг
                d3dpp.EnableAutoDepthStencil = true; // Разрешаем создание z-буфера
                d3dpp.AutoDepthStencilFormat = DepthFormat.D16; // Z-буфер в 16 бит
                d3d = new Device(0, // D3D_ADAPTER_DEFAULT - видеоадаптер по 
                    // умолчанию
                      DeviceType.Hardware, // Тип устройства - аппаратный ускоритель
                      this, // Окно для вывода графики
                      CreateFlags.SoftwareVertexProcessing,
                      d3dpp);
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message, "Ошибка инициализации");
                Close(); // Закрываем окно            

            }

            podshipnik1 = Mesh.Sphere(d3d, r_p, 10, 10);
            balka = Mesh.Box(d3d, a_b+konec, c_b, 2 * r_p);
            podstavka = Mesh.Cylinder(d3d, 0.3f*r_p, r_p+t_tor, h_pod, 50, 20);
            stenka = Mesh.Box(d3d, a_s, b_s, c_s);
            tor_krep = Mesh.Torus(d3d, t_tor, r_p, 50, 50);
            box = Mesh.Sphere(d3d, a, 50, 50);
            plux = Mesh.Torus(d3d, t_plux, r_plux, 50, 50);
            cyl = Mesh.Cylinder(d3d, 0.25f, 0.25f, 0.9f, 10, 10);
            cyl2 = Mesh.Cylinder(d3d, 0.2f, 0.2f, 1.5f, 10, 10);
            cyl3 = Mesh.Cylinder(d3d, 0.05f, 0.05f, 2.2f, 10, 10);
            

           FileStream textureFile = new FileStream("i.jpg", FileMode.Open);
            sfera_texture = Texture.FromStream(d3d,
                    textureFile,   // Поток данных с текстурой
                    0,             // Будем использовать как обычную текстуру
                    Pool.Managed); // Область памяти для размещения текстуры
            textureFile.Close();

            //пружина
            sf = Mesh.Sphere(d3d, 0.01f, 10, 10);

            //крепление пружины                  
            krep = Mesh.Sphere(d3d, 0.07f, 10, 10);
            krep_up = Mesh.Sphere(d3d, 0.07f, 10, 10);
            korob = Mesh.Box(d3d, a_krep, delta, c_krep);  
                            
            verevkaMaterial = new Material();
            verevkaMaterial.Diffuse = Color.DarkGray; 
            verevkaMaterial.Specular = Color.White;      

            balkaMaterial = new Material();
            balkaMaterial.Diffuse = Color.DarkSlateGray; 
            balkaMaterial.Specular = Color.White;            

            boxMaterial = new Material();
            boxMaterial.Diffuse = Color.BlueViolet;
            boxMaterial.Specular = Color.White;

            rashet = new Runge();
            masF = new Runge.myF[2];
            masF[0] = f1;
            masF[1] = f2;
            y = new float[2];
            y[0] = 0;
            y[1] = Convert.ToSingle(3*m2*Math.Sqrt(2*g*hh)/(m1+m2)/2/l);
            list = new List<double>();
            tT = new List<double>();
        }

        float f1(float x, float[] y, int n)
        {
            return y[1];
        }

        float f2(float x, float[] y, int n)
        {
          
            return (((m1 * g * l) / 2) + m2 * g * l - 4 * c * y[0] * l * l / 9-4*mu*y[1]*l/9); 
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
                Dvig();
        }
        
        private void SetupProekcii()
        {
           
            d3d.Lights[0].Enabled = true;   // Включаем нулевой источник освещения
            d3d.Lights[0].Diffuse = Color.White;         // Цвет источника освещения
            d3d.Lights[0].Position = new Vector3(0, 0, 0); // Задаем координаты
            d3d.Transform.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4, this.Width / this.Height, 1.0f, 50.0f);
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.Invalidate();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dv = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            dv = false;
            zadacha = false;
            t=0;
            t1 = 0;
            koor = func(t);            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Owner = this;
            f2.Show();
        }
        float func(float t)
        {
            return Convert.ToSingle(h-9.81*t/2);
        }
        float func_balka(float t)
        {
            if (t != 0)
            {
                y = rashet.RungeR(t, y, masF, 2, deltaT);
                return y[0];
            }
            else
                return 0;


        }
        void Dvig()
        {
            
            float x = 0, y = 0, z = 0;
            koor = func(t);
            ykrep = -func_balka(t1) * 2 * a_b / 3;
            if (Math.Abs(koor) < 0.05f)
            {
                dv = false;
                zadacha = true;
                
                
            }
            dlina = ymax - func_balka(t1) * 2 * a_b / 3;
            if(zadacha)
                dlina=2*(ykrep1- func_balka(t1) * 2 * a_b / 3);
            hsp = dlina / n;

            d3d.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.White, 1.0f, 0);
            SetupProekcii();
            d3d.BeginScene();
            
            //подшипник
            d3d.Material = verevkaMaterial;
            d3d.Transform.World = Matrix.Translation(0+sdvig_x, 0 + sdvig_y, 0)*Matrix.RotationY((float)((hScrollBar1.Value - 90) * Math.PI / 180)) * Matrix.Translation(0, 0, sdvig_z);
            podshipnik1.DrawSubset(0);

            d3d.Transform.World = Matrix.RotationY(((float)Math.PI) / 2) * Matrix.Translation(0 + sdvig_x, 0 + sdvig_y, 0) * Matrix.RotationY((float)((hScrollBar1.Value - 90) * Math.PI / 180)) * Matrix.Translation(0, 0, sdvig_z);
            tor_krep.DrawSubset(0);

            d3d.Transform.World = Matrix.RotationY(((float)Math.PI) / 2) * Matrix.Translation(0 + sdvig_x- h_pod / 2, 0 + sdvig_y, 0) * Matrix.RotationY((float)((hScrollBar1.Value - 90) * Math.PI / 180)) * Matrix.Translation(0, 0, sdvig_z);
            podstavka.DrawSubset(0);

            d3d.Material = balkaMaterial;
            if (nach)
                d3d.Transform.World = Matrix.RotationX((float)Math.PI / 2) * Matrix.Translation(sdvig_x + 2 * a_b / 3 - x, sdvig_y - ymax / 4 + y, z) * Matrix.RotationY((float)((hScrollBar1.Value - 90) * Math.PI / 180)) * Matrix.Translation(0, 0, sdvig_z);
            else
            cyl.Dispose();
            cyl = Mesh.Cylinder(d3d, 0.25f, 0.25f, 0.9f, 10, 10);
            d3d.Transform.World = Matrix.RotationX((float)Math.PI / 2) * Matrix.Translation(sdvig_x + 2 * a_b / 3 - x, (sdvig_y - ymax / 4 + y) - func_balka(t1) * 2, z) * Matrix.RotationY((float)((hScrollBar1.Value - 90) * Math.PI / 180)) * Matrix.Translation(0, 0, sdvig_z);
            cyl.DrawSubset(0);

            d3d.Material = balkaMaterial;
            if (nach)
                d3d.Transform.World = Matrix.RotationX((float)Math.PI / 2) * Matrix.Translation(sdvig_x + 2 * a_b / 3 - x, sdvig_y - ymax / 4 + y, z) * Matrix.RotationY((float)((hScrollBar1.Value - 90) * Math.PI / 180)) * Matrix.Translation(0, 0, sdvig_z);
            else
            {
                cyl2.Dispose();
                cyl2 = Mesh.Cylinder(d3d, 0.2f, 0.2f, 1.5f - func_balka(t1) * 2, 10, 10);
                d3d.Transform.World = Matrix.RotationX((float)Math.PI / 2) * Matrix.Translation(sdvig_x + 2 * a_b / 3 - x,(sdvig_y - ymax / 4 + y) - func_balka(t1)*2, z) * Matrix.RotationY((float)((hScrollBar1.Value - 90) * Math.PI / 180)) * Matrix.Translation(0, 0, sdvig_z);

            }
            cyl2.DrawSubset(0);

            d3d.Material = balkaMaterial;
            if (nach)
                d3d.Transform.World = Matrix.RotationX((float)Math.PI / 2) * Matrix.Translation(sdvig_x + 2 * a_b / 3 - x, sdvig_y - ymax / 4 + y, z) * Matrix.RotationY((float)((hScrollBar1.Value - 90) * Math.PI / 180)) * Matrix.Translation(0, 0, sdvig_z);
            else
            {
                cyl3.Dispose();
                cyl3 = Mesh.Cylinder(d3d, 0.05f, 0.05f, 2.2f - func_balka(t1) * 2, 10, 10);
                d3d.Transform.World = Matrix.RotationX((float)Math.PI / 2) * Matrix.Translation(sdvig_x + 2 * a_b / 3 - x, (sdvig_y - ymax / 4 + y) - func_balka(t1) * 2, z) * Matrix.RotationY((float)((hScrollBar1.Value - 90) * Math.PI / 180)) * Matrix.Translation(0, 0, sdvig_z);

            }
           cyl3.DrawSubset(0);

            //балка
            d3d.Material = balkaMaterial;
            d3d.Transform.World = Matrix.Translation(0 +(a_b+konec)/2, 0, 0)*Matrix.RotationZ(-func_balka(t1))*Matrix.Translation(0+ sdvig_x, 0 + sdvig_y, 0)* Matrix.RotationY((float)((hScrollBar1.Value - 90) * Math.PI / 180)) * Matrix.Translation(0, 0, sdvig_z);
            balka.DrawSubset(0);

            //тело
            d3d.Material = boxMaterial;
            if (!zadacha)
            {
                d3d.Transform.World = Matrix.Translation(0 + sdvig_x + a_b, 0 + sdvig_y + koor, 0) * Matrix.RotationY((float)((hScrollBar1.Value - 90) * Math.PI / 180)) * Matrix.Translation(0, 0, sdvig_z);
                box.DrawSubset(0);
            }
            else
            {
                d3d.Transform.World = Matrix.RotationX(Convert.ToSingle(Math.PI / 2)) * Matrix.Translation(0 + a_b, 0 + koor, 0) * Matrix.RotationZ(-func_balka(t1)) * Matrix.Translation(0 + sdvig_x, 0 + sdvig_y, 0) * Matrix.RotationY((float)((hScrollBar1.Value - 90) * Math.PI / 180)) * Matrix.Translation(0, 0, sdvig_z);
                plux.DrawSubset(0);
            }

            //пружина
            for (float fi = 0; fi <= n * Math.PI; fi += 0.1f)
            {
                x = Convert.ToSingle(asp * Math.Cos(fi));
                z = Convert.ToSingle(asp * Math.Sin(fi));
                y = Convert.ToSingle(0.5f * hsp * fi / Math.PI);
                if (nach)
                    d3d.Transform.World = Matrix.Translation(sdvig_x + 2 * a_b / 3 - x, sdvig_y -ymax/2+ y, z) * Matrix.RotationY((float)((hScrollBar1.Value - 90) * Math.PI / 180)) * Matrix.Translation(0, 0, sdvig_z);
                else
                    d3d.Transform.World = Matrix.Translation(sdvig_x + 2 * a_b / 3 - x, sdvig_y -ykrep1+ y, z) * Matrix.RotationY((float)((hScrollBar1.Value - 90) * Math.PI / 180)) * Matrix.Translation(0, 0, sdvig_z);
            }

            ////нижняя часть пружины
            for (int i = 0; i < 10; i++)
            {
                if(nach)
                d3d.Transform.World = Matrix.Translation(sdvig_x + 2 * a_b / 3 + x + i * 0.1f * asp, sdvig_y - y, z) * Matrix.RotationY((float)((hScrollBar1.Value - 90) * Math.PI / 180)) * Matrix.Translation(0, 0, sdvig_z);
                else
                    d3d.Transform.World = Matrix.Translation(sdvig_x + 2 * a_b / 3 + x + i * 0.1f * asp, sdvig_y - ykrep1, z) * Matrix.RotationY((float)((hScrollBar1.Value - 90) * Math.PI / 180)) * Matrix.Translation(0, 0, sdvig_z);
            }
            
            ////нижний шарик пружины
            if (nach)
                d3d.Transform.World = Matrix.Translation(sdvig_x + 2 * a_b / 3 - x - asp, sdvig_y - y, z) * Matrix.RotationY((float)((hScrollBar1.Value - 90) * Math.PI / 180)) * Matrix.Translation(0, 0, sdvig_z);
            else
                d3d.Transform.World = Matrix.Translation(sdvig_x + 2 * a_b / 3 - x - asp, sdvig_y - ykrep1, z) * Matrix.RotationY((float)((hScrollBar1.Value - 90) * Math.PI / 180)) * Matrix.Translation(0, 0, sdvig_z);


                        if (nach)
                d3d.Transform.World = Matrix.Translation(sdvig_x + 2 * a_b / 3 - x - asp, sdvig_y -0.1f , z) * Matrix.RotationY((float)((hScrollBar1.Value - 90) * Math.PI / 180)) * Matrix.Translation(0, 0, sdvig_z);
            else
                d3d.Transform.World = Matrix.Translation(sdvig_x + 2 * a_b / 3 - x - asp, sdvig_y - ykrep1, z) * Matrix.RotationY((float)((hScrollBar1.Value - 90) * Math.PI / 180)) * Matrix.Translation(0, 0, sdvig_z);


            //поверхность крепления
            if (nach)
            {
                d3d.Transform.World = Matrix.Translation(sdvig_x + 2 * a_b / 3 - x - asp, sdvig_y - y - r_krep, z) * Matrix.RotationY((float)((hScrollBar1.Value - 90) * Math.PI / 180)) * Matrix.Translation(0, 0, sdvig_z);
                ykrep1 = y;
                
            }
            else
                d3d.Transform.World = Matrix.Translation(sdvig_x + 2 * a_b / 3 - x - asp, sdvig_y - ykrep1 - r_krep, z) * Matrix.RotationY((float)((hScrollBar1.Value - 90) * Math.PI / 180)) * Matrix.Translation(0, 0, sdvig_z);
            korob.DrawSubset(0);
            

            d3d.Transform.World = Matrix.Translation(0 + sdvig_x - h_pod / 2 - a_s / 2, 0 + sdvig_y, 0) * Matrix.RotationY((float)((hScrollBar1.Value - 90) * Math.PI / 180)) * Matrix.Translation(0, 0, sdvig_z);
            stenka.DrawSubset(0);

            d3d.EndScene();
            //Показываем содержимое дублирующего буфера
            d3d.Present();
            if (dv)
            {
                nach = false;
                t = t + 5*deltaT;
            }
            if (zadacha)
                t1 += deltaT;


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            list.Clear();
            tT.Clear();
            y[0] = 0;
            y[1] = Convert.ToSingle(3 * m2 * Math.Sqrt(2 * g * hh) / (m1 + m2) / 2 / l);
            for (float t = 0; t <= 100; t += 0.1f)
            {
                y = rashet.RungeR(t, y, masF, 2, deltaT);
                list.Add(y[0]);
                tT.Add(t);
            }
            Grafics fp = new Grafics();
            fp.Owner = this;
            fp.Tag = "4";
            fp.ShowDialog();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            // Создаем объект-окно
            Form3 mainForm = new Form3();
            // Cвязываем метод OnIdle с событием Application.Idle

            // Показываем окно и запускаем цикл обработки сообщений
            Application.Run(mainForm);

        }
    }
}

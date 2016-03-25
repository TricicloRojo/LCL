using LCL.Vistas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LCL
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Si es la 2 vez que entra a la app (el . es convencion)
            if (File.Exists(".Inmobiliaria.json"))
            {

                //  Application.Run(new CharlyWindow());

            }
            else {

                //Si es la primera vez va a poder configurar
                Application.Run(new ventanaConfiguracion());

            }
        }
    }
}

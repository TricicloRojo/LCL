using LCL.Clases.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LCL.Vistas
{

    //CUANDO SE DE ACEPTAR A LA VENTANA DE CONFIGURACION
    //DEBE MOSTRARSE LA DE ALTA

    public partial class ventanaConfiguracion : Form
    {
        
        private string rutaArchivo,rutaCarpeta;
        private DialogResult result, result2;

        public ventanaConfiguracion(){

            InitializeComponent();

        }


        //Selecciona el path en donde estan todos los archivos Excel de los distintoes meses
        private void botonExaminar_Click(object sender, EventArgs e)
        {
            //Para hacer un boton examinar que permita seleccionar una ruta 
            //se usa el objeto folderBrowserDialog
            //desde la parte de diseño se agrego un objeto de tipo
            //folderBrowserDialog llamado fileRute y un boton Examinar
            //al dar click en examinar se muestra la ventana de seleccion
            //de ruta en donde se desea guardar
            this.result = fileHistorialExcel.ShowDialog();


            //Si se eligio una ruta
            if (this.result == DialogResult.OK)
            {

                //Obtengo la ruta en donde fue guardado el archivo
                rutaCarpeta = fileHistorialExcel.SelectedPath;

                //Seteo la ruta en el TextBox
                //Si se cambia de ruta automaticamente se actualiza
                rutaHistorialExcel.Text = rutaCarpeta;

            //Si no se eligio una ruta (No haria falta este control)
            }else {

                MessageBox.Show("Seleccione Una Ruta");

            }

        }

        //Busca el archivo Excel
        private void botonHistorialExcel_Click(object sender, EventArgs e)
        {
            //Se selecciona la ruta en donde esta el archivo Excel guardado

            this.result2 = fileExcel.ShowDialog();

            //Si se eligio una ruta
            if (this.result2 == DialogResult.OK)
            {

                //Obtengo la ruta en donde fue guardado el archivo
                rutaArchivo = Path.GetFullPath(fileExcel.FileName);

                //Seteo la ruta en el TextBox
                //Si se cambia de ruta automaticamente se actualiza
                rutaArchivoExcel.Text = rutaArchivo;

            //Si no se eligio una ruta (No haria falta este control)
            }else {

                MessageBox.Show("Seleccione Una Ruta");

            }

        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
          
            //CREO UN ARCHIVO JSON QUE VA A TENER 2 VALORES, 1 ES EL PATH
            //COMPLETO EN DONDE SE GUARDO EL ARCHIVO Y EL OTRO EL PATH
            //EN DONDE SE ENCUENTRA LA CARPETA EN DONDE ESTAN TODOS LOS EXCELS

            //VOY A NECESITAR OTRA CLASE QUE TIENE 2 ATRIBUTOS, rutaArchivo (busca el Excel de ese mes),
            //rutaCarpeta (busca la carpeta en donde estan todos los Excel de los distintos meses)

            //Si se selecciono una ruta en todos los TextBox
            if (this.result == DialogResult.OK && this.result2 == DialogResult.OK)
            {

                Excel excel = new Excel();

                //Guardo las rutas de los TextBox en la clase
                excel.rutaCarpeta = rutaHistorialExcel.Text;
                excel.rutaArchivo = rutaArchivoExcel.Text;

                //Convierto el objeto a un formato de tipo JSON
                string json = JsonConvert.SerializeObject(excel,Formatting.Indented);

                //Creo el archivo JSON

                try {
/*
                    byte[] bytes = new byte[json.Length * sizeof(char)];

                    FileStream fs = File.Create("c:\\Users\\Zeta\\Desktop\\Excel.json");
                    fs.Write(bytes, 0, json.Length);
                    fs.Close();
*/                  
                    //Se reescrbe la ruta si ya fue creado el archivo
                    StreamWriter escribir = new StreamWriter("c:\\Users\\Zeta\\Desktop\\Excel.json");
                    escribir.WriteLine(json);
                    escribir.Close();
                    
                    //Voy a la ventana de alta
                    ventanaAlta va = new ventanaAlta();

                    //Muestro la ventana
                    va.Show();

                    //Hago que la ventana de configuracion no se vea
                    this.Visible = false;


                }catch (Exception j){

                    MessageBox.Show(j.Message);

                }
                

            }
            else
            {

                MessageBox.Show("Seleccione Una Ruta");

            }
            
        }
       
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using Newtonsoft.Json;
using LCL.Clases.model;

namespace LCL.Vistas
{

    public partial class ventanaAlta : Form
    {

       

        public ventanaAlta()
        {
            InitializeComponent();
        }

        //Si le da click a Cancelar se vuelve al menu principal
        private void botonCancelar_Click(object sender, EventArgs e)
        {
            //ALGO HAY QUE HACER PEOPLE
        }

        private void botonAceptar_Click(object sender, EventArgs e){

            //Si le da a Aceptar tengo que comprobar que lo ingresado
            //sea correcto (email tiene estructura de email)
            //Si alguno de los campos esta vacio o no es un mail valido muestra el error

            if (nombre.Text == "" || mail.Text == "" ||  !mailValido(mail)){

                MessageBox.Show("ERROR");

                //Borro todos los campos
                nombre.Clear();
                mail.Clear();

                //Hago que se posicione en el primer campo que debe ingresar
                //Foco en el nombre
                nombre.Focus();

            }else {

                //Si todo es correcto debo generar un JSON con lo que ingreso y guardarlo
                //en un archivo el cual, estara en la ruta que se especifica en la ventana
                //de configuracion

                Cliente c = new Cliente();
                c.nombre = nombre.Text;
                c.email = mail.Text;

                //Convierto el objeto a un formato de tipo JSON
                string json = JsonConvert.SerializeObject(c);

                //Guardo la informacion en el archivo
                

            }

        }

        
        //Metodos
        private Boolean mailValido(TextBox mail){

            //Estructura de un email
            String expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            //Si lo que se ingreso como email coincide con la estructura
            //de un email
            if (Regex.IsMatch(mail.Text,expresion)){

                if (Regex.Replace(mail.Text, expresion, String.Empty).Length == 0){
                    
                    return true;
                
                }else{

                    return false;
                }
            
            }else{

                return false;
            }

        }

    }
}


/* COMO AGREGAR DATOS DE UN TEXTBOX A UN TXT

private void Guardar_Click(object sender, EventArgs e){
    
    //fijamos dondevamos a crear el archivo (ACA TENDRIA QUE IR LA RUTA DEFINIDA DE LA PANTALLA CONFIGURACION)
    StreamWriter escrito = File.CreateText("c:\\Prueba.txt"); // en el
    
    //para agregar datos al archivo existente
    //StreamWriter escrito = File.AppendText("c:\\file.txt"); // en el
    
    //En una variable tipo string ubicamos el contenido del Textbox
    //Se podría hacer directamente.
    String contenido = textBox1.Text;
    
    //escribimos.
    escrito.Write(contenido.ToString());
    escrito.Flush();
    
    //Cerramos
    escrito.Close();
    
    //Vaciamos
    textBox1.Text = "";

}

private void Cargar_Click(object sender, EventArgs e){
    
    //Vaciamos el receptor
    textBox1.Text = "";

    //Utilizamos este constructor
    StreamReader leido = File.OpenText("C:\\Prueba.txt");
    
    //Variable que contendrá el archivo
    string contenido = null;
    
    //Leemos todo el archivo
    contenido = leido.ReadToEnd();
    
    //Lo mostramos
    textBox1.Text = contenido.ToString();
   
    //Cerramos
    leido.Close();

}

private void Cargar1_Click(object sender, EventArgs e){
    
    //Vaciamos el receptor
    textBox1.Text = "";
    
    //Utilizamos este constructor
    StreamReader leido = File.OpenText("C:\\Prueba.txt");
    
    //Variable que contendrá el archivo
    string contenido = null;
   
    //Leemos linea a linea hasta el final.
    while ((contenido = leido.ReadLine()) != null){
        
        //Lo vamos cargando al TextBox
        textBox1.Text += contenido.ToString();
   
    }

    leido.Close();
    
} 

*/

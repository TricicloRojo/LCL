using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Net.Mail;

namespace LCL
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            cmbMes.Items.Add("Enero");
            cmbMes.Items.Add("Febrero");
            cmbMes.Items.Add("Marzo");
            cmbMes.Items.Add("Abril");
            cmbMes.Items.Add("Mayo");
            cmbMes.Items.Add("Junio");
            cmbMes.Items.Add("Julio");
            cmbMes.Items.Add("Agosto");
            cmbMes.Items.Add("Septiembre");
            cmbMes.Items.Add("Octubre");
            cmbMes.Items.Add("Noviembre");
            cmbMes.Items.Add("Diciembre");
        }

        private void cmbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMain();
        }

        private void ShowMain()
        {
            cmbMes.Enabled = false;
            cmdStart.Visible = true;
            listBox1.Visible = true;
            cmdCancel.Visible = true;
            listBox1.Text = "";
        }

        private void Restart()
        {
            cmbMes.Enabled = true;
            cmdStart.Visible = false;
            listBox1.Visible = false;
            cmdCancel.Visible = false;
            listBox1.Text = "";
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Restart();
        }

        public static void OnTimerEvent(object source, EventArgs e)
        {
            Application.Exit();
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            Boolean found=false;
            if (!File.Exists(@"C:\Users\Carmen\Documents\Historial Locales\" + cmbMes.SelectedItem.ToString() + " " + DateTime.Today.Year + ".xlsx"))
            {
                MessageBox.Show("El archivo " + cmbMes.SelectedItem.ToString() + " " + DateTime.Today.Year + ".xlsx" + " no fue encontrado", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Restart();
            }
            else
            {
                File.Copy(@"C:\Users\Carmen\Documents\Historial Locales\" + cmbMes.SelectedItem.ToString() + " " + DateTime.Today.Year + ".xlsx", @"C:\Users\Carmen\Desktop\Giampaolo.xlsx", true);
                listBox1.Items.Add("Se creo el archivo Giampaolo.xlsx");
                File.Copy(@"C:\Users\Carmen\Documents\Historial Locales\" + cmbMes.SelectedItem.ToString() + " " + DateTime.Today.Year + ".xlsx", @"C:\Users\Carmen\Desktop\Uniti.xlsx", true);
                listBox1.Items.Add("Se creo el archivo Uniti.xlsx");
                //Process Giam
                Process_Giampaolo();
                listBox1.Items.Add("Archivo Giampaolo.xlsx ha sido configurado");
                //Process Uniti
                Process_Uniti();
                listBox1.Items.Add("Archivo Uniti.xlsx ha sido configurado");
                //Send Email
                listBox1.Items.Add("Preparando email para ser enviado..");
                Giam_Send_Email();
                Uniti_Send_Email();
                
                listBox1.Items.Add("Ejectuando copia de Seguridad");
                while (!found)
                { 
                    foreach (DriveInfo drive in DriveInfo.GetDrives())
                    {
                        if (drive.DriveType.ToString() == "Removable")
                            if (File.Exists(String.Format(@"{0}Historial Locales\Septiembre 2012.xlsx", drive.Name)))
                                found = true;
                    }
                    if (!found)
                        MessageBox.Show("Ingrese Pendrive", "Pendrive no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                System.Diagnostics.Process.Start(@"C:\Users\Carmen\Desktop\Copia-Seguridad Locales.bat");
                listBox1.Items.Add("TERMINAMOS!! El programa se cerrara automaticamente..");
                Timer timer1 = new Timer();
                timer1.Interval = 5000;
                timer1.Enabled = true;
                timer1.Tick += new System.EventHandler(OnTimerEvent);
                //File.Delete(@"C:\Users\Massivez\Desktop\Giampaolo.xls");
                //File.Delete(@"C:\Users\Massivez\Desktop\Uniti.xls");
            }
        }

        private void Process_Giampaolo()
        {
            Excel.Application MyApp = new Excel.Application();
            Excel.Workbook MyBook = null;
            Excel.Worksheet MySheet = null;
            Excel.Workbooks WorkBooks = null;

            WorkBooks = MyApp.Workbooks;
            MyApp.Visible = false;
            //MyBook = WorkBooks.Open(@"C:\Users\Massivez\Desktop\Giampaolo.xlsx");
            MyBook = MyApp.Workbooks.Open(@"C:\Users\Carmen\Desktop\Giampaolo.xlsx");
            //Activated
            MySheet = MyBook.Worksheets[3];
            MyApp.DisplayAlerts = false;
            MySheet.Delete();
            MyApp.DisplayAlerts = false;

            MySheet = MyBook.Worksheets[3];
            MySheet.Visible = Excel.XlSheetVisibility.xlSheetHidden;
            MyBook.SaveAs(@"C:\Users\Carmen\Desktop\Giampaolo.xls", Excel.XlFileFormat.xlExcel8);

            MyBook.Close();
            WorkBooks.Close();
            MyApp.Quit();
            File.Delete(@"C:\Users\Carmen\Desktop\Giampaolo.xlsx");
        }

        private void Process_Uniti()
        {
            Excel.Application MyApp = new Excel.Application();
            Excel.Workbook MyBook = null;
            Excel.Worksheet MySheet = null;
            Excel.Workbooks WorkBooks = null;

            WorkBooks = MyApp.Workbooks;
            MyApp.Visible = false;
            MyBook = WorkBooks.Open(@"C:\Users\Carmen\Desktop\Uniti.xlsx");
            //Activated
            MySheet = MyBook.Worksheets[4];
            MySheet.Visible = Excel.XlSheetVisibility.xlSheetHidden;

            MyApp.DisplayAlerts = false;
            MyBook.Sheets[1].Delete();
            MyApp.DisplayAlerts = false;
            MyBook.Sheets[1].Delete();
            MyApp.DisplayAlerts = false;

            MyBook.SaveAs(@"C:\Users\Carmen\Desktop\Uniti.xls", Excel.XlFileFormat.xlExcel8);
            MyBook.Close();
            WorkBooks.Close();
            MyApp.Quit();
            File.Delete(@"C:\Users\Carmen\Desktop\Uniti.xlsx");
        }

        private void Uniti_Send_Email()
        {
            SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
            var mail = new MailMessage();
            mail.From = new MailAddress("Empty");
            mail.To.Add("Empty");
            mail.Subject = "Resumen Alquileres " + cmbMes.SelectedItem.ToString();
            mail.Body = "Te envio los detalles de este mes. Saludos";
            Attachment data = new Attachment(@"C:\Users\Carmen\Desktop\Uniti.xls");
            mail.Attachments.Add(data);
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("Empty", "Empty");
            SmtpServer.EnableSsl = true;
            try
            {
                SmtpServer.Send(mail);
                listBox1.Items.Add("Email a Uniti ha sido enviado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay conexión a Internet", "Email no enviado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            SmtpServer.Dispose();
        }

        private void Giam_Send_Email()
        {
            SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
            var mail = new MailMessage();
            mail.From = new MailAddress("Empty");
            mail.To.Add("Empty");
            mail.Subject = "Resumen Alquileres " + cmbMes.SelectedItem.ToString();
            mail.Body = "Te envio los detalles de este mes. Saludos";
            Attachment data = new Attachment(@"C:\Users\Carmen\Desktop\Giampaolo.xls");
            mail.Attachments.Add(data);
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("Empty", "Empty");
            SmtpServer.EnableSsl = true;
            try
            {
                SmtpServer.Send(mail);
                listBox1.Items.Add("Email a Giampaolo ha sido enviado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay conexión a Internet", "Email no enviado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            SmtpServer.Dispose();
        }
    }
}

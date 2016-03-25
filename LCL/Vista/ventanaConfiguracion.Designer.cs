namespace LCL.Vistas
{
    partial class ventanaConfiguracion
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
            this.rutaHistorialExcel = new System.Windows.Forms.TextBox();
            this.botonAceptar = new System.Windows.Forms.Button();
            this.botonHistorialExcel = new System.Windows.Forms.Button();
            this.fileHistorialExcel = new System.Windows.Forms.FolderBrowserDialog();
            this.botonBuscarExcel = new System.Windows.Forms.Button();
            this.rutaArchivoExcel = new System.Windows.Forms.TextBox();
            this.fileExcel = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rutaHistorialExcel
            // 
            this.rutaHistorialExcel.Enabled = false;
            this.rutaHistorialExcel.Location = new System.Drawing.Point(18, 89);
            this.rutaHistorialExcel.Margin = new System.Windows.Forms.Padding(4);
            this.rutaHistorialExcel.Name = "rutaHistorialExcel";
            this.rutaHistorialExcel.Size = new System.Drawing.Size(210, 22);
            this.rutaHistorialExcel.TabIndex = 0;
            // 
            // botonAceptar
            // 
            this.botonAceptar.Location = new System.Drawing.Point(116, 137);
            this.botonAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(112, 28);
            this.botonAceptar.TabIndex = 2;
            this.botonAceptar.Text = "Aceptar";
            this.botonAceptar.UseVisualStyleBackColor = true;
            this.botonAceptar.Click += new System.EventHandler(this.botonAceptar_Click);
            // 
            // botonHistorialExcel
            // 
            this.botonHistorialExcel.Location = new System.Drawing.Point(248, 88);
            this.botonHistorialExcel.Name = "botonHistorialExcel";
            this.botonHistorialExcel.Size = new System.Drawing.Size(90, 23);
            this.botonHistorialExcel.TabIndex = 3;
            this.botonHistorialExcel.Text = "Examinar";
            this.botonHistorialExcel.UseVisualStyleBackColor = true;
            this.botonHistorialExcel.Click += new System.EventHandler(this.botonExaminar_Click);
            // 
            // botonBuscarExcel
            // 
            this.botonBuscarExcel.Location = new System.Drawing.Point(248, 31);
            this.botonBuscarExcel.Name = "botonBuscarExcel";
            this.botonBuscarExcel.Size = new System.Drawing.Size(90, 23);
            this.botonBuscarExcel.TabIndex = 4;
            this.botonBuscarExcel.Text = "Examinar";
            this.botonBuscarExcel.UseVisualStyleBackColor = true;
            this.botonBuscarExcel.Click += new System.EventHandler(this.botonHistorialExcel_Click);
            // 
            // rutaArchivoExcel
            // 
            this.rutaArchivoExcel.Enabled = false;
            this.rutaArchivoExcel.Location = new System.Drawing.Point(18, 32);
            this.rutaArchivoExcel.Name = "rutaArchivoExcel";
            this.rutaArchivoExcel.Size = new System.Drawing.Size(210, 22);
            this.rutaArchivoExcel.TabIndex = 5;
            // 
            // fileExcel
            // 
            this.fileExcel.FileName = "fileExcel";
            this.fileExcel.Filter = "Excel |*.xlsx";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "ArchivoExcel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "HistorialExcel";
            // 
            // ventanaConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 202);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rutaArchivoExcel);
            this.Controls.Add(this.botonBuscarExcel);
            this.Controls.Add(this.botonHistorialExcel);
            this.Controls.Add(this.botonAceptar);
            this.Controls.Add(this.rutaHistorialExcel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ventanaConfiguracion";
            this.Text = "Configuracion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox rutaHistorialExcel;
        private System.Windows.Forms.Button botonAceptar;
        private System.Windows.Forms.Button botonHistorialExcel;
        private System.Windows.Forms.FolderBrowserDialog fileHistorialExcel;
        private System.Windows.Forms.Button botonBuscarExcel;
        private System.Windows.Forms.TextBox rutaArchivoExcel;
        private System.Windows.Forms.OpenFileDialog fileExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
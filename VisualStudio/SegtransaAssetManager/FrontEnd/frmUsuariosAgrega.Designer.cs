namespace FrontEnd
{
    partial class frmUsuariosAgrega
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
            this.grpBoxDatosPersonales = new System.Windows.Forms.GroupBox();
            this.lblNombreUsu = new System.Windows.Forms.Label();
            this.grpBoxDatosPersonales.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxDatosPersonales
            // 
            this.grpBoxDatosPersonales.Controls.Add(this.lblNombreUsu);
            this.grpBoxDatosPersonales.Location = new System.Drawing.Point(30, 27);
            this.grpBoxDatosPersonales.Name = "grpBoxDatosPersonales";
            this.grpBoxDatosPersonales.Size = new System.Drawing.Size(294, 184);
            this.grpBoxDatosPersonales.TabIndex = 0;
            this.grpBoxDatosPersonales.TabStop = false;
            this.grpBoxDatosPersonales.Text = "Datos Personales";
            // 
            // lblNombreUsu
            // 
            this.lblNombreUsu.AutoSize = true;
            this.lblNombreUsu.Location = new System.Drawing.Point(25, 32);
            this.lblNombreUsu.Name = "lblNombreUsu";
            this.lblNombreUsu.Size = new System.Drawing.Size(35, 13);
            this.lblNombreUsu.TabIndex = 0;
            this.lblNombreUsu.Text = "label1";
            // 
            // frmUsuariosAgrega
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grpBoxDatosPersonales);
            this.Name = "frmUsuariosAgrega";
            this.Text = "Agregar Nuevo Usuario";
            this.grpBoxDatosPersonales.ResumeLayout(false);
            this.grpBoxDatosPersonales.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxDatosPersonales;
        private System.Windows.Forms.Label lblNombreUsu;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Backend.DAL;
using Backend.Entities;

namespace FrontEnd
{
    public partial class frmActivos : Form
    {
        public frmActivos()
        {
            IActivosDAL lista= new ActivosImplDAL();
            listBox1.DataSource = lista.GetActivos();
            InitializeComponent();
        }

        public frmActivos(Form prevForm)
        {
            InitializeComponent();
            previousForm = prevForm;
        }

        Form previousForm;
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            previousForm.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddActivo frm_AddActivo = new frmAddActivo(this);
            frm_AddActivo.Show(this);
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmUpdateActivo frm_UpdateActivo = new frmUpdateActivo(this);
            frm_UpdateActivo.Show(this);
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarActivo frm_GetActivo = new frmBuscarActivo(this);
        }
    }
}

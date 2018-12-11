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
            
            InitializeComponent();
        }
        private IActivosDAL activosDAL;
        
        public frmActivos(Form prevForm)
        {
            activosDAL = new ActivosImplDAL();
            List<Activos> listaActivos = activosDAL.GetActivos();
            listBox1.ValueMember = "idActivo";
            listBox1.DisplayMember = "nombreActivo";
            listBox1.DataSource = listaActivos;
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
            frmActivosAdd frm_AddActivo = new frmActivosAdd(this);
            frm_AddActivo.Show(this);
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmActivosUpdate frm_UpdateActivo = new frmActivosUpdate(this,listBox1.SelectedItem as Activos);
            frm_UpdateActivo.Show(this);
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmActivosBuscar frm_GetActivo = new frmActivosBuscar(this);
        }
    }
}

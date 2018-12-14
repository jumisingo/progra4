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
        IActivosDAL lista;
        public frmActivos()
        {
            lista= new ActivosImplDAL();
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
            frmActivosAdd frm_AddActivo = new frmActivosAdd(this);
            frm_AddActivo.Show(this);
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Activos parametroActivos = new Activos();
            parametroActivos = listBox1.SelectedItem as Activos;
            frmActivosUpdate frm_UpdateActivo = new frmActivosUpdate(this, parametroActivos);
            frm_UpdateActivo.Show(this);
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmActivosSearch frm_GetActivo = new frmActivosSearch(this);
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
           //Agregar llamada a dal para cambiar EstadosActivo a desactivado (listBox1.SelectedItem as Activos);
        }
    }
}

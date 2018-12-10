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
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }
        public frmUsuarios(Form prevForm)
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

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmUsuariosAgrega frm_UsuariosAgrega = new frmUsuariosAgrega();
            frm_UsuariosAgrega.Show(this);
            this.Hide();
        }
    }
}

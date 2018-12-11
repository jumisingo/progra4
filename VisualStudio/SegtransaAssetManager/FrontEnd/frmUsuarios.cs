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
        private IUsuariosDAL usuariosDAL;
        private List<Usuarios> Usuarios;

        public frmUsuarios()
        {
            InitializeComponent();
            usuariosDAL = new UsuariosImplDAL();
        }
        public frmUsuarios(Form prevForm)
        {
            InitializeComponent();
            previousForm = prevForm;
            usuariosDAL = new UsuariosImplDAL();
        }

        static Form previousForm;
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            //frmMenu frm_Menu = new frmMenu();
            //frm_Menu.Show();
            previousForm.Show();
        }

        public void CargarLista()
        {
            lstUsuarios.Items.Clear();
            Usuarios = usuariosDAL.GetUsuarios();
           
            //lstUsuarios.DisplayMember = "apellido1";

            foreach(var item in Usuarios)
            {
                item.nombre = item.nombre.PadRight(20) + item.apellido1.PadRight(20) +
                    item.apellido2.PadRight(20);
            }

            lstUsuarios.DisplayMember = "nombre";
            lstUsuarios.ValueMember = "idUsuario";

            lstUsuarios.DataSource = Usuarios;

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmUsuariosAgrega frm_UsuariosAgrega = new frmUsuariosAgrega(this);
            frm_UsuariosAgrega.Show();
            this.Hide();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            Usuarios Usuario = (Usuarios)lstUsuarios.SelectedItem;
            frmUsuariosModifica frm_UsuariosModifica = new frmUsuariosModifica(this);
            frm_UsuariosModifica.Show();
            this.Hide();
        }
    }
}

using Backend.DAL;
using Backend.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEnd
{
    public partial class frmUsuariosAgrega : Form
    {
        private IUsuariosDAL usuariosDAL;
        private IRolUsuariosDAL rolUsuariosDAL;
        private Usuarios usuario;
        
        public frmUsuariosAgrega()
        {
            InitializeComponent();
            rolUsuariosDAL = new RolUsuariosImplDAL();
        }

        private void CargaComboRoles()
        {
            cmbBoxRol.DisplayMember = "nombreRol";
            cmbBoxRol.ValueMember = "idRol";
            List<Rol_Usuarios> rol_Usuarios = rolUsuariosDAL.GetRols();

            cmbBoxRol.DataSource = rol_Usuarios;
        }

        private void frmUsuariosAgrega_Load(object sender, EventArgs e)
        {
            CargaComboRoles();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            // Let the default behavior to happen.
            base.OnClosing(e);
            // Do not allow cancellation of the close operation.
            e.Cancel = false;
            frmUsuariosAgrega frmUsuarios = new frmUsuariosAgrega();

            frmUsuarios.Show();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                usuario = new Usuarios();
                usuario.nombre = txtNombre.Text;
                usuario.apellido1 = txtApellido1.Text;
                usuario.apellido2 = txtApellido2.Text;
                usuario.genero = (String)cmbBoxGeneros.SelectedItem;
                usuario.telefono = txtTelefono.Text;
                usuario.email = txtEmail.Text;
                usuario.direccion = txtDireccion.Text;
                usuario.idRol = (int)cmbBoxRol.SelectedValue;
                usuario.Rol_Usuarios = (Rol_Usuarios)cmbBoxRol.SelectedItem;
                usuario.contrasena = txtContrasena.Text;
                usuario.fechaCreacion = DateTime.Now;

                usuariosDAL.Add(usuario);
                MessageBox.Show("Producto agregado");

                frmUsuariosAgrega frmUsuarios = new frmUsuariosAgrega();

                this.Hide();
                frmUsuarios.Show();







            }
            catch (Exception ex)
            {

                MessageBox.Show("Error " + ex.Message);
            }
        }
    }
}

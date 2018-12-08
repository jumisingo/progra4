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
    public partial class Menu : Form
    {
        private Usuarios usuario;
        public Menu()
        {
            InitializeComponent();

        }
        public Menu(Usuarios user)
        {
            InitializeComponent();
            if (user.idRol != 1)
            {
                btnActivos.Enabled = false;
                btnUsuarios.Enabled = false;
            }

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}

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

namespace FrontEnd
{
    public partial class frmAddActivo : Form
    {
        IProveedoresDAL proveedores = new ProveedoresImplDAL();
        public frmAddActivo(Form prevForm)
        {
            previousForm = prevForm;
            cmbBoxPrvdr.DataSource = proveedores.GetProveedores();
            InitializeComponent();
        }

        Form previousForm;
        private void frmAddActivo_Load(object sender, EventArgs e)
        {

        }
    }
}

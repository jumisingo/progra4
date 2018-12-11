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
    public partial class frmActivosBuscar : Form
    {
        IActivosDAL activosDAL = new ActivosImplDAL();
        IProveedoresDAL proveedoresDAL = new ProveedoresImplDAL();
        Activos esteActivo;
        public frmActivosBuscar(Form prvForm)
        {
            InitializeComponent();
            previousForm = prvForm;
        }
        Form previousForm;

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
            previousForm.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            populateFields(activosDAL.GetActivo(Int32.Parse(txtIdActivo.Text)));
        }

        private void populateFields(Activos activo)
        {
            lblValNombre.Text = activo.nombreActivo;
            lblValPrcIni.Text = activo.precioInicial.ToString();
            //lblValProveedor.Text = proveedoresDAL.GetProveedor(activo.idProveedor);
            //activo.idProveedor int? to int, look for method to parse
        }
    }
}

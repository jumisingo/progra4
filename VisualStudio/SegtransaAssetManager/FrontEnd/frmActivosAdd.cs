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
    public partial class frmActivosAdd : Form
    {
        private IActivosDAL activosDAL = new ActivosImplDAL();
        private IProveedoresDAL proveedores = new ProveedoresImplDAL();
        private IEstadoActivosDAL estadoDAL = new EstadoActivosImplDAL();
        Activos activo = new Activos();

        private List<Proveedores> listaP;
        List<EstadoActivos> listaE;
        public frmActivosAdd(Form prevForm)
        {
            previousForm = prevForm;
            listaP = proveedores.GetProveedores(); ;
            cmbBoxPrvdr.DataSource = listaP;
            cmbBoxPrvdr.DisplayMember = "nombre";
            cmbBoxPrvdr.ValueMember = "idProveedor";

            listaE = estadoDAL.GetEstadoActivos();
            cmbBoxStt.DataSource = listaE;
            cmbBoxStt.DisplayMember = "nombreEstado";
            cmbBoxStt.ValueMember = "idEstadoActivo";

            InitializeComponent();
        }

        Form previousForm;

        private void btnBack_click(object sender, EventArgs e)
        {
            this.Close();
            previousForm.Show();
        }

        private void btnAddActivo_Click(object sender, EventArgs e)
        {
            try
            {
                activo.nombreActivo = txtNmbr.Text;
                activo.descripcion = txtBxDesc.Text;
                activo.precioInicial = decimal.Parse(txtPrc.Text);
                activo.fechaCompra = dateCompra.Value.Date;
                activo.idProveedor = Convert.ToInt32(cmbBoxPrvdr.SelectedValue.ToString());
                activo.idEstadoActivo = Convert.ToInt32(cmbBoxStt.SelectedValue.ToString());
                activosDAL.Add(activo);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        } 
    }
}

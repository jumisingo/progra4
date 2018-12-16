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
        IActivosDAL activosDAL = new ActivosImplDAL();
        IProveedoresDAL proveedoresDAL;
        IEstadoActivosDAL estadosDAL;
        Activos activo = new Activos();

        public frmActivosAdd(Form prevForm)
        {
            previousForm = prevForm;
            proveedoresDAL= new ProveedoresImplDAL();
            estadosDAL = new EstadoActivosImplDAL();
            InitializeComponent();
        }

        Form previousForm;

        private void btnBack_click(object sender, EventArgs e)
        {
            this.Close();
            previousForm.Show();
        }

        private void cargaCombo()
        {
            cmbBoxPrvdr.DisplayMember = "nombre";
            cmbBoxPrvdr.ValueMember = "idRol";
            List<Proveedores> proveedor = proveedoresDAL.GetProveedores();

            cmbBoxStt.DisplayMember = "nombreEstado";
            cmbBoxStt.ValueMember = "idEstadoActivo";
            List<EstadoActivos> estadosActivos = estadosDAL.GetEstadoActivos();

            cmbBoxPrvdr.DataSource = proveedor;
            cmbBoxStt.DataSource = estadosActivos;
        }

        private void btnAddActivo_Click(object sender, EventArgs e)
        {
            try
            {
                activo.nombreActivo = txtNmbr.Text;
                activo.descripcion = txtBxDesc.Text;
                activo.precioInicial = decimal.Parse(txtPrc.Text);
                activo.fechaCompra = dateCompra.Value.Date;
                activo.idProveedor = (int)cmbBoxPrvdr.SelectedValue;
                activo.idEstadoActivo = (int)cmbBoxStt.SelectedValue;
                activo.EstadoActivos = (EstadoActivos)cmbBoxPrvdr.SelectedItem;
                activo.Proveedores = (Proveedores)cmbBoxPrvdr.SelectedItem;
                activosDAL.Add(activo);
            }catch(Exception ex)
            {
                MessageBox.Show("Error"+ex.ToString());
            }
        }

        private void frmActivosAdd_Load(object sender, EventArgs e)
        {
            cargaCombo();
        }
    }
}

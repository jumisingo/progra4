﻿using System;
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
    public partial class frmBuscarActivo : Form
    {
        IActivosDAL activosDAL = new ActivosImplDAL();
        IProveedoresDAL proveedoresDAL = new ProveedoresImplDAL();
        IEstadoActivosDAL estadoActivosDAL = new EstadoActivosImplDAL();
        Activos esteActivo;

        public frmBuscarActivo(Form prvForm)
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
            int valProveedor = activo.idProveedor.Value;
            lblValNombre.Text = activo.nombreActivo;
            lblValPrcIni.Text = activo.precioInicial.ToString();
            lblValProveedor.Text = proveedoresDAL.GetProveedor(valProveedor).ToString();
            lblValDesc.Text = activo.descripcion;
            valProveedor = activo.idEstadoActivo.Value;
            lblValStt.Text = estadoActivosDAL.GetEstadoActivo(valProveedor).ToString();
            //activo.idProveedor int? to int, look for method to parse
        }
    }
}
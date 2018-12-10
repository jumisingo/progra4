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
    public partial class frmUpdateActivo : Form
    {
        Form previousForm;

        public frmUpdateActivo(frmActivos prevFrm)
        {
            InitializeComponent();
            previousForm = prevFrm;
        }
    }
}

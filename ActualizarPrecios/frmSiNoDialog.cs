using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExpandCollapsePanelDemo.GUIs
{
    public partial class frmSiNoDialog : Form
    {
        string mensaje;
        public frmSiNoDialog()
        {
            InitializeComponent();
        }

        public frmSiNoDialog(string msj)
        {
            InitializeComponent();
            mensaje = msj;
        }

        private void frmSiNoDialog_Load(object sender, EventArgs e)
        {
            if (mensaje != "")
                txtMsj.Text = mensaje + " \n\n\t\t\n";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

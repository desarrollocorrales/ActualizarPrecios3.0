using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ActualizarPrecios.Clases;

namespace ActualizarPrecios
{
    public partial class Frm_NoActualizados : Form
    {
        public Frm_NoActualizados(List<ArticuloBascula> lstNoActualizados)
        {
            InitializeComponent();
            gvArticulos.DataSource = lstNoActualizados;
        }

        private void Frm_NoActualizados_Load(object sender, EventArgs e)
        {

        }
    }
}

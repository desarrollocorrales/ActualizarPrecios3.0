using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using firmas.Modelo;
using ActualizarPrecios.Clases;
using ExpandCollapsePanelDemo.GUIs;

namespace ActualizarPrecios
{
    public partial class frm_Articulos : Form
    {
        #region Variables
        string tabla = string.Empty; string ClaveMicrosip = string.Empty;
        int codigoSeleccionado = 0; int tipoPlu = 0; int editable = 0;
        Consultas obj_consultas = new Consultas(); Generales obj_limpiar = new Generales();
        List<ArticuloPrecios> ArticulosPrecios; List<ArticuloBascula> ArticulosBascula; List<ArticuloBascula> ArticulosRelacionados = new List<ArticuloBascula>(); List<PLUS> lst_plus = new List<PLUS>();
        frmSiNoDialog frmSiNo;
        #endregion

        #region Constructor
        public frm_Articulos()
        {
            InitializeComponent();
        }

        public frm_Articulos(string tb)
        {
            InitializeComponent();
            tabla = tb;
        }

        #endregion

        #region Eventos

            #region Efectos
            private void pbGuardar_MouseLeave(object sender, EventArgs e)
            {
                try
                {
                    obj_limpiar.MouseLeaveEfecto(pbGuardar, ActualizarPrecios.Properties.Resources.guardar1);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            private void pbGuardar_MouseMove(object sender, MouseEventArgs e)
            {
                try
                {
                    obj_limpiar.MouseLeaveEfecto(pbGuardar, ActualizarPrecios.Properties.Resources.guardar2);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            private void pbActualiza_MouseLeave(object sender, EventArgs e)
            {
                try
                {
                    obj_limpiar.MouseLeaveEfecto(pbActualiza, ActualizarPrecios.Properties.Resources.guardar1);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            private void pbActualiza_MouseMove(object sender, MouseEventArgs e)
            {
                try
                {
                    obj_limpiar.MouseLeaveEfecto(pbActualiza, ActualizarPrecios.Properties.Resources.guardar2);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            #endregion

        //************Menú******************//
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                btnBuscar.ForeColor = Color.Green; btnNuevo.ForeColor = btnActualiza.ForeColor = btnEliminar.ForeColor = System.Drawing.Color.Black;
                Generales obj_limpiar = new Generales();
                obj_limpiar.limpiaControles(pnBuscar);
                obj_limpiar.limpiaControles(pnNuevo);
                pnNuevo.Visible = false;
                pnBuscar.Visible = true;

                ArticulosBascula = obj_consultas.LeerArticulosBascula();
                if (ArticulosBascula.Count > 0)
                {
                    dgvArticulosB.DataSource = ArticulosBascula.ToList();
                    formatoGridBascula(dgvArticulosB);
                }
                if (Properties.Settings.Default.NombreTabla == "LSQ40")
                {
                    pnDatosArticuloss.Visible = true;
                    pnDatosProductoss.Visible = false;
                }
                else
                {
                    pnDatosArticuloss.Visible = false;
                    pnDatosProductoss.Visible = true;
                }
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnActualiza_Click(object sender, EventArgs e)
        {
            try
            {
                btnActualiza.ForeColor =  Color.Green;  btnBuscar.ForeColor = btnEliminar.ForeColor = btnNuevo.ForeColor = System.Drawing.Color.Black;
                btnNuevo.Enabled = btnBuscar.Enabled = btnEliminar.Enabled = false;
                pnDatosA.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                btnNuevo.ForeColor = Color.Green; btnBuscar.ForeColor = btnEliminar.ForeColor = btnActualiza.ForeColor = System.Drawing.Color.Black;

                LlenaComboTiposPlus(cmbTiposPlus);
                obj_limpiar.limpiaControles(pnBuscar); obj_limpiar.limpiaControles(pnNuevo);
                pnNuevo.Visible = true; pnBuscar.Visible = false;
                ArticulosPrecios = obj_consultas.LeerPreciosMicrosip();
                if (ArticulosPrecios.Count > 0)
                {
                    dgvArticulosMS.DataSource = ArticulosPrecios;
                    formatoGridMicrosip(dgvArticulosMS);
                }

                if (Properties.Settings.Default.NombreTabla == "LSQ40")
                {
                    pnTiposArt.Visible = true; 
                    pnTiposProd.Visible = false;
                }
                else
                {
                    pnTiposArt.Visible = false; 
                    pnTiposProd.Visible = true;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try{
                if (dgvArticulosB.CurrentRow == null) return;

                ArticuloBascula Datos = (ArticuloBascula)dgvArticulosB.CurrentRow.DataBoundItem;
                codigoSeleccionado = Datos.codigo;
                string mensaje = "Se van a Eliminar los Datos del Articulo: " + Datos.codigo + " - " + Datos.nombre;
                frmSiNo = new frmSiNoDialog(mensaje);
                frmSiNo.FormClosed += new FormClosedEventHandler(confirmaE);
                frmSiNo.ShowDialog();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                btnEliminar.ForeColor = btnActualiza.ForeColor = btnBuscar.ForeColor = btnNuevo.ForeColor = System.Drawing.Color.Black;
                obj_limpiar.limpiaControles(pnBuscar);
                obj_limpiar.limpiaControles(pnNuevo);

                pnBuscar.Visible = pnNuevo.Visible = btnActualiza.Enabled = btnEliminar.Enabled = false;
                btnNuevo.Enabled = btnBuscar.Enabled = true;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //************Menú******************//

        private void rnPesableMS_CheckedChanged(object sender, EventArgs e)
        {
            if (rnPesableMS.Checked) tipoPlu = 1;
            else tipoPlu = 0;
        }
        private void rbEditableMS_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEditableMS.Checked) editable = 1;
            else editable = 0;
        }
        private void rbPesable_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPesable.Checked) tipoPlu = 1;
            else tipoPlu = 0;
        }
        private void rbEditable_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEditable.Checked) editable = 1;
            else editable = 0;
        }

        private void dgvArticulosMS_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvArticulosMS.CurrentRow != null)
                {
                    ArticuloPrecios DatosMS = (ArticuloPrecios)dgvArticulosMS.CurrentRow.DataBoundItem;
                    ClaveMicrosip = DatosMS.Clave_Articulo;
                    txtArticuloN.Text = DatosMS.Nombre;
                    int codigo = obj_consultas.generaCodigoArticulo() + 1;
                    txtNoPluN.Text = txtCodigoN.Text = codigo.ToString();
                    txtPrecioN.Text = DatosMS.Precio.ToString();
                    txtCaducidadN.Text = "21";
                    txtImpuestoN.Text = "0";
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void dgvArticulosB_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void txtBuscaMS_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtBuscaArticulos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<ArticuloPrecios> lstAuxiliar = new List<ArticuloPrecios>();
                lstAuxiliar = ArticulosPrecios.FindAll(o => o.Nombre.ToUpper().Contains(txtBuscaArticulos.Text.ToUpper())
                                       || o.Clave_Articulo.Contains(txtBuscaArticulos.Text.ToUpper()));

                if (lstAuxiliar.Count > 0)
                {
                    dgvArticulosMS.DataSource = lstAuxiliar;
                    formatoGridMicrosip(dgvArticulosMS);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void txtPrecioN_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = obj_limpiar.teclapresiondaPesos(e);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void frm_Articulos_Load(object sender, EventArgs e)
        {
            try
            {



            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void dgvArticulosB_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvArticulosB.CurrentRow != null)
                {
                    ArticuloBascula Datos = (ArticuloBascula)dgvArticulosB.CurrentRow.DataBoundItem;
                    ArticuloEnBascula obj_ArticuloB = obj_consultas.ObtenerArticuloSel(Datos.codigo);
                    txtArticuloMS.Text = obj_ArticuloB.nombre;
                    txtNoPluMS.Text = txtCodigoMS.Text = obj_ArticuloB.codigo.ToString();
                    txtPrecioMS.Text = Math.Round(obj_ArticuloB.precio, 2).ToString();
                    txtCaducidadMS.Text = obj_ArticuloB.caducidad.ToString();
                    txtImpuestoMS.Text = Math.Round(obj_ArticuloB.impuesto, 2).ToString();
                    txtclvMS.Text = obj_ArticuloB.clave_microsip;

                    if (Properties.Settings.Default.NombreTabla == "LSQ40")
                    {
                        pnTiposArt.Visible = true;
                        pnTiposProd.Visible = false;
                        LlenaComboTiposPlus(cmbTiposPlusA, obj_ArticuloB.tipoplu);
                    }
                    else
                    {
                        pnTiposArt.Visible = false;
                        pnTiposProd.Visible = true;
                        rbNoPesableMS.Checked = obj_ArticuloB.tipoplu == 0 ? true : false;
                        rnPesableMS.Checked = obj_ArticuloB.tipoplu == 1 ? true : false;
                        rbEditableMS.Checked = obj_ArticuloB.editable == 1 ? true : false;
                        rbNoEditableMS.Checked = obj_ArticuloB.editable == 0 ? true : false;
                    }

                    btnActualiza.Enabled = btnEliminar.Enabled = true;
                    btnNuevo.Enabled = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void txtCaducidadMS_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = obj_limpiar.teclaNumero(e);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void pbGuardar_Click(object sender, EventArgs e)
        {
            try{

                if (dgvArticulosMS.CurrentRow == null) return;
                if (txtArticuloN.Text.Trim() == "") { throw new Exception("No ha seleccionado un Articulo. Por Favor dar Doble click sobre el articulo que desea Agregar"); }

                if (obj_consultas.ArticulosAgregados(txtArticuloN.Text)) throw new Exception("El Articulo " + txtArticuloN.Text + " ya fue Agregado a la Báscula, seleccione otro porfavor");

                int tipoPlu = 0; int editable = 0;
                if (Properties.Settings.Default.NombreTabla == "LSQ40"){
                    tipoPlu = int.Parse(cmbTiposPlus.SelectedValue.ToString());
                    obj_consultas.RegistraArticulo(ClaveMicrosip, int.Parse(txtCodigoN.Text), txtArticuloN.Text, tipoPlu, decimal.Parse(txtPrecioN.Text), decimal.Parse(txtImpuestoN.Text), int.Parse(txtCaducidadN.Text), 0, int.Parse(txtNoPluN.Text), DateTime.Now.Date);
                }
                else
                    obj_consultas.RegistraArticulo(ClaveMicrosip, int.Parse(txtCodigoN.Text), txtArticuloN.Text, tipoPlu, decimal.Parse(txtPrecioN.Text), decimal.Parse(txtImpuestoN.Text), int.Parse(txtCaducidadN.Text), 0, int.Parse(txtNoPluN.Text), DateTime.Now.Date, editable);

                MessageBox.Show("Se Agrego el Articulo: " + txtArticuloN.Text + ", a la Báscula", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnNuevo_Click(null, null);

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void pbActualiza_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (Properties.Settings.Default.NombreTabla == "LSQ40")
                {
                    tipoPlu = int.Parse(cmbTiposPlus.SelectedValue.ToString());
                    obj_consultas.ActualizaArtuculo(int.Parse(txtCodigoMS.Text), decimal.Parse(txtPrecioMS.Text), decimal.Parse(txtImpuestoMS.Text), int.Parse(txtCaducidadMS.Text), tipoPlu);
                }
                else
                    obj_consultas.ActualizaArtuculo(int.Parse(txtCodigoMS.Text), decimal.Parse(txtPrecioMS.Text), decimal.Parse(txtImpuestoMS.Text), int.Parse(txtCaducidadMS.Text), tipoPlu, editable);

                MessageBox.Show("Se actualizaron los datos del Articulo en la Báscula", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBuscar_Click(null, null);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion

        #region Metodos

        private void formatoGridMicrosip(DataGridView dgv)
        {
            try
            {
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    column.Visible = false;
                    column.ReadOnly = true;
                }

                dgv.Columns["Clave_Articulo"].Visible = true;
                dgv.Columns["Clave_Articulo"].DisplayIndex = 0;
                dgv.Columns["Clave_Articulo"].HeaderText = "Clave";
                dgv.Columns["Clave_Articulo"].Width = 80;

                dgv.Columns["Nombre"].Visible = true;
                dgv.Columns["Nombre"].DisplayIndex = 1;
                dgv.Columns["Nombre"].HeaderText = "Articulo Microsip";
                dgv.Columns["Nombre"].Width = 285;

                dgv.CurrentCell = dgv.Rows[0].Cells["Clave_Articulo"];

            }
            catch (Exception x)
            {
                throw x;
            }
        }

        private void formatoGridBascula(DataGridView dgv)
        {
            try
            {
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    column.Visible = false;
                    column.ReadOnly = true;
                }

                dgv.Columns["clave_microsip"].Visible = true;
                dgv.Columns["clave_microsip"].DisplayIndex = 0;
                dgv.Columns["clave_microsip"].HeaderText = "Clave";
                dgv.Columns["clave_microsip"].Width = 80;

                dgv.Columns["Nombre"].Visible = true;
                dgv.Columns["Nombre"].DisplayIndex = 1;
                dgv.Columns["Nombre"].HeaderText = "Articulo Báscula";
                dgv.Columns["Nombre"].Width = 285;

                dgv.CurrentCell = dgv.Rows[0].Cells["clave_microsip"];


                //foreach (DataGridViewRow row in dgv.Rows)
                //{
                //    if (row.Cells["clave_microsip"].Value.ToString() != "")
                //    {
                //        int kia = row.Index;
                //        dgv.Rows[kia].DefaultCellStyle.BackColor = Color.Green;
                //        dgv.Rows[kia].DefaultCellStyle.ForeColor = Color.White;

                //    }
                //}
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        private void LlenaComboTiposPlus(ComboBox cmb, int index = 0)
        {
            try
            {
                lst_plus.Add(new PLUS { id_tp = 1, descripcion = "PESADO, NO EDITABLE" });
                lst_plus.Add(new PLUS { id_tp = 2, descripcion = "PESADO, EDITABLE" });
                lst_plus.Add(new PLUS { id_tp = 3, descripcion = "NO PESADO, NO EDITABLE" });
                lst_plus.Add(new PLUS { id_tp = 4, descripcion = "NO PESADO, EDITABLE" });

                cmb.ValueMember = "id_tp";
                cmb.DisplayMember = "descripcion";
                cmb.DataSource = lst_plus;
                cmb.SelectedIndex = 0;

                if (index > 0)
                {
                    int x = 0;
                    foreach (PLUS elemento in ((List<PLUS>)cmb.DataSource))
                    {
                        if (elemento.id_tp == index)
                        {
                            cmb.SelectedIndex = x;
                            break;
                        }
                        x++;
                    }
                }
            }
            catch (Exception x)
            { throw x; }
        }

        public void confirmaE(object sender, EventArgs e)
        {
            try
            {
                if (frmSiNo.DialogResult.ToString() == "OK")
                {
                    obj_consultas.EliminaArticulo(codigoSeleccionado);
                    MessageBox.Show("Se Elimino el Articulo con codigo = " + codigoSeleccionado.ToString(), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnBuscar_Click(null, null);
                }
            }
            catch (Exception x)
            { throw x; }
        }

        #endregion       

    }
}

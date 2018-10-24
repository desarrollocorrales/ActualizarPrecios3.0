using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ActualizarPrecios.Clases;
using System.Data.OleDb;
using ExpandCollapsePanelDemo.GUIs;
using firmas.Modelo;

namespace ActualizarPrecios
{
    public partial class Relacion : Form
    {
        #region Variables
        List<ArticuloPrecios> ArticulosPrecios; List<ArticuloBascula> ArticulosBascula; List<ArticuloBascula> ArticulosRelacionados = new List<ArticuloBascula>();
        ArticuloBascula articuloRelacion; Consultas obj_consultas = new Consultas(); Generales obj_limpiar = new Generales();
        frmSiNoDialog frmSiNo;
        #endregion

        #region Constructor
        public Relacion()
        {
            InitializeComponent();
        }
        
        public Relacion(List<ArticuloPrecios> listaArticulosPrecios, List<ArticuloBascula> listaArticulosBascula)
        {
            InitializeComponent();
            ArticulosPrecios = listaArticulosPrecios;
            ArticulosBascula = listaArticulosBascula; //.Where(z => z.clave_microsip == "").ToList();
            ArticulosRelacionados = listaArticulosBascula.Where(z => z.clave_microsip != "").ToList();
        }

        private void Relacion_Load(object sender, EventArgs e)
        {
            try
            {
                dgvArticulosB.DataSource = dgvArticulosMS.DataSource = null; dgvArticulosB.Columns.Clear(); dgvArticulosMS.Columns.Clear();

                ArticulosPrecios = obj_consultas.LeerPreciosMicrosip();
                if (ArticulosPrecios.Count > 0)
                {
                    dgvArticulosMS.DataSource = ArticulosPrecios;
                    formatoGridMicrosip(dgvArticulosMS);
                }

                ArticulosBascula = obj_consultas.LeerArticulosBascula();
                if (ArticulosBascula.Count > 0)
                {
                    dgvArticulosB.DataSource = ArticulosBascula.Where(z => z.clave_microsip == "").ToList();
                    formatoGridBascula(dgvArticulosB);
                }
                
                ActualizaLista(ArticulosBascula.Where(z => z.clave_microsip != "").ToList());
                txtArticulo.Text = "";

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion

        #region Eventos

        #region Efectos
        private void pbMas_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                obj_limpiar.MouseLeaveEfecto(pbMas, ActualizarPrecios.Properties.Resources.mas1);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void pbMas_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                obj_limpiar.MouseLeaveEfecto(pbMas, ActualizarPrecios.Properties.Resources.mas2);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void pbCerrar_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                obj_limpiar.MouseLeaveEfecto(pbCerrar, ActualizarPrecios.Properties.Resources.terminar2);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void pbCerrar_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                obj_limpiar.MouseLeaveEfecto(pbCerrar, ActualizarPrecios.Properties.Resources.terminar1);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void pbMenos_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                obj_limpiar.MouseLeaveEfecto(pbMenos, ActualizarPrecios.Properties.Resources.menos1);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void pbMenos_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                obj_limpiar.MouseLeaveEfecto(pbMenos, ActualizarPrecios.Properties.Resources.menos2);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

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

        private void pbQuitarLista_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                obj_limpiar.MouseLeaveEfecto(pbQuitarLista, ActualizarPrecios.Properties.Resources.menos1);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void pbQuitarLista_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                obj_limpiar.MouseLeaveEfecto(pbQuitarLista, ActualizarPrecios.Properties.Resources.menos2);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion

        private void pbMas_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvArticulosB.CurrentRow != null && dgvArticulosMS.CurrentRow != null)
                {
                    ArticuloBascula DatosB = (ArticuloBascula)dgvArticulosB.CurrentRow.DataBoundItem;
                    ArticuloPrecios DatosMS = (ArticuloPrecios)dgvArticulosMS.CurrentRow.DataBoundItem;


                    foreach (DataGridViewRow row in dgvRelacion.Rows)
                    {
                        if (row.Cells["codigo"].Value.ToString() == DatosB.codigo.ToString() || row.Cells["clave_microsip"].Value.ToString() == DatosB.clave_microsip.ToString())
                        {
                            MessageBox.Show("El Articulo " + row.Cells["nombre"].Value.ToString().ToUpper() + " ya fue Relacionado, seleccione otro", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    articuloRelacion = new ArticuloBascula();
                    articuloRelacion.clave_microsip = DatosMS.Clave_Articulo;
                    articuloRelacion.nombre = DatosMS.Nombre;
                    articuloRelacion.codigo = DatosB.codigo;

                    //int contador = 0;
                    //foreach (DataGridViewRow row in dgvArticulosB.Rows)
                    //{
                    //    if (row.Cells["codigo"].Value.ToString() == articuloRelacion.codigo.ToString())
                    //    {
                    //        contador++;
                    //        if (contador > 1)
                    //        {
                    //            MessageBox.Show("El Articulo " + row.Cells["Nombre"].Value.ToString().ToUpper() + " ya fue Relacionado, seleccione otro", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //            return;
                    //        }
                    //    }
                    //}

                    ArticulosRelacionados.Add(articuloRelacion);

                    foreach (DataGridViewRow row in dgvArticulosB.Rows)
                    {
                        if (int.Parse(row.Cells["codigo"].Value.ToString()) == DatosB.codigo)
                        {
                            int kia = row.Index;
                            dgvArticulosB.Rows[kia].DefaultCellStyle.BackColor = Color.Yellow;
                            dgvArticulosB.Rows[kia].DefaultCellStyle.ForeColor = Color.Black;
                            dgvArticulosB.CurrentCell = dgvArticulosB.Rows[0].Cells["Nombre"];
                        }
                    }
                    txtArticulo.Text = "";
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void pbMenos_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvArticulosB.CurrentRow != null && dgvArticulosB.CurrentRow.DefaultCellStyle.BackColor == Color.Yellow)
                {
                    ArticuloBascula Datos = (ArticuloBascula)dgvArticulosB.CurrentRow.DataBoundItem;

                    var itemToRemove = ArticulosRelacionados.Single(r => r.codigo == Datos.codigo);
                    ArticulosRelacionados.Remove(itemToRemove);
                    dgvArticulosB.CurrentRow.DefaultCellStyle.BackColor = Color.White;
                    dgvArticulosB.CurrentCell = dgvArticulosB.Rows[0].Cells["Nombre"];

                    txtArticulo.Text = "";
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void pbGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ArticulosRelacionados.Count > 0)
                {
                    obj_consultas.GuardaRelacion(ArticulosRelacionados);
                    MessageBox.Show("Se actualizaron los datos de los Articulos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Relacion_Load(null, null);
                }
                else MessageBox.Show("No ha relacionado ningun Articulo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void pbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbQuitarLista_Click(object sender, EventArgs e)
        {
            try{
                if (dgvRelacion.CurrentRow != null)
                {
                    ArticuloBascula Datos = (ArticuloBascula)dgvRelacion.CurrentRow.DataBoundItem;
                    string mensaje = "Se Eliminara la relación del Articulo: " + Datos.clave_microsip + " - " + Datos.nombre;
                    frmSiNo = new frmSiNoDialog(mensaje);
                    frmSiNo.FormClosed += new FormClosedEventHandler(confirmaA);
                    frmSiNo.ShowDialog();                    
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void txtArticulo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<ArticuloPrecios> lstAuxiliar = new List<ArticuloPrecios>();
                lstAuxiliar = ArticulosPrecios.FindAll(o => o.Nombre.ToUpper().Contains(txtArticulo.Text.ToUpper())
                                       || o.Clave_Articulo.Contains(txtArticulo.Text.ToUpper()));

                if (lstAuxiliar.Count > 0)
                {
                    dgvArticulosMS.DataSource = lstAuxiliar;
                    formatoGridMicrosip(dgvArticulosMS);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion

        #region Metodos

        private void formatoGridMicrosip(DataGridView dgv)
        {
            try
            {
                if (dgv.RowCount == 0) return;
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    column.Visible = false;
                    column.ReadOnly = true;
                }

                dgv.Columns["Clave_Articulo"].Visible = true;
                dgv.Columns["Clave_Articulo"].DisplayIndex = 0;
                dgv.Columns["Clave_Articulo"].HeaderText = "Clave";
                dgv.Columns["Clave_Articulo"].Width =80;

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
                if (dgv.RowCount == 0) return;

                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    column.Visible = false;
                    column.ReadOnly = true;
                }

                //dgv.Columns["clave_microsip"].Visible = true;
                //dgv.Columns["clave_microsip"].DisplayIndex = 0;
                //dgv.Columns["clave_microsip"].HeaderText = "Clave";
                //dgv.Columns["clave_microsip"].Width = 80;

                dgv.Columns["Nombre"].Visible = true;
                dgv.Columns["Nombre"].DisplayIndex = 1;
                dgv.Columns["Nombre"].HeaderText = "Articulo Báscula";
                dgv.Columns["Nombre"].Width = 365;

                dgv.CurrentCell = dgv.Rows[0].Cells["Nombre"];


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

        private void ActualizaLista(List<ArticuloBascula> lista)
        {
            try
            {
                dgvRelacion.DataSource = null;
                dgvRelacion.DataSource = lista;

                foreach (DataGridViewColumn column in dgvRelacion.Columns)
                {
                    column.Visible = false;
                    column.ReadOnly = true;
                }

                dgvRelacion.Columns["clave_microsip"].Visible = true;
                dgvRelacion.Columns["clave_microsip"].DisplayIndex = 0;
                dgvRelacion.Columns["clave_microsip"].HeaderText = "Clave";
                dgvRelacion.Columns["clave_microsip"].Width = 85;

                dgvRelacion.Columns["Nombre"].Visible = true;
                dgvRelacion.Columns["Nombre"].DisplayIndex = 1;
                dgvRelacion.Columns["Nombre"].HeaderText = "Articulo";
                dgvRelacion.Columns["Nombre"].Width = 280;

                dgvRelacion.Columns["codigo"].Visible = true;
                dgvRelacion.Columns["codigo"].DisplayIndex = 1;
                dgvRelacion.Columns["codigo"].HeaderText = "No PLU";
                dgvRelacion.Columns["codigo"].Width = 60;
                //dgvArtAgregados.Columns["articulo"].DefaultCellStyle.Format = "C2";

                if (dgvRelacion.RowCount > 0)
                    dgvRelacion.CurrentCell = dgvRelacion.Rows[0].Cells["clave_microsip"];
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void confirmaA(object sender, EventArgs e)
        {
            try
            {
                if (frmSiNo.DialogResult.ToString() == "OK")
                {
                    ArticuloBascula Datos = (ArticuloBascula)dgvRelacion.CurrentRow.DataBoundItem;

                    obj_consultas.QuitaRelacionArticulo(Datos);
                    MessageBox.Show("Se actualizaron los datos de los Articulos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Relacion_Load(null, null);
                }
            }
            catch (Exception x)
            { throw x; }
        }

        #endregion     
    }
}

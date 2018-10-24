using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using FirebirdSql.Data.FirebirdClient;
using ActualizarPrecios.Clases;
using AccSettings;
using firmas.GUIs;

namespace ActualizarPrecios
{
    public partial class Frm_Principal : Form
    {
        #region Variables
        private MicroSipSettings MicrosipSettings;
        private List<ArticuloBascula> listaNoActualizados;
        private List<ArticuloBascula> listaArticulosBascula;
        private List<ArticuloPrecios> listaArticulosPrecios;
        Consultas obj_consultas = new Consultas();
        #endregion

        #region Constructor
        public Frm_Principal()
        {
            InitializeComponent();
        }

        private void Frm_Principal_Load(object sender, EventArgs e)
        {
            //obj_consultas.CargarConfiguraciones();
            txbFileDB.Text = Properties.Settings.Default.AccessDB;
            if (Properties.Settings.Default.NombreTabla != "")
                cmbNombreTabla.SelectedIndex = Properties.Settings.Default.NombreTabla == "LSQ40" ? 0 : 1;
            //LeerPreciosMicrosip();
            //LeerArticulosBascula();
        }

        #endregion

        #region Eventos

        private void btnBuscarDB_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = ofdDB.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    txbFileDB.Text = "...\\" + ofdDB.SafeFileName;
                    Properties.Settings.Default.AccessDB = ofdDB.FileName;
                    Properties.Settings.Default.Save();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnCopiarArticulos_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Esta accion borrará todas las claves de microsip en la tabla intermedia.");
                sb.Append("¿Desea Continuar?");
                DialogResult dr = new Frm_Confirmacion().ShowDialog();
                if (dr == DialogResult.OK)
                {
                    string msj = obj_consultas.InicializarArticulos(pictboxLoading);
                    MessageBox.Show(msj, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnActualizarPrecios_Click(object sender, EventArgs e)
        {
            try
            {
                listaArticulosPrecios = obj_consultas.LeerPreciosMicrosip(lblAccion); // LeerPreciosMicrosip();
                listaArticulosBascula = obj_consultas.LeerArticulosBascula(); // LeerArticulosBascula();
                listaNoActualizados = obj_consultas.ActualizarPrecios(lblAccion, lblActualizados); // ActualizarPrecios();
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(ex.Message);
                sb.AppendLine("No se pudo realizar la actualización");

                MessageBox.Show(ex.Message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblAccion.ForeColor = Color.Red;
                lblAccion.Text = "No se pudo realizar la actualización...";
            }
        }

        private void btnArticulos_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbNombreTabla.SelectedIndex > -1)
                {
                    frmAcceso formA = new frmAcceso();
                    var respuesta = formA.ShowDialog();

                    if (respuesta == System.Windows.Forms.DialogResult.OK)
                    {
                        new frm_Articulos().ShowDialog(); //listaArticulosPrecios, listaArticulosBascula
                        Frm_Principal_Load(null, null);
                    }
                }
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void lblActualizados_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Frm_NoActualizados(listaNoActualizados).ShowDialog();
        }

        private void btnRelacionA_Click(object sender, EventArgs e)
        {
            try
            {
                frmAcceso formA = new frmAcceso();
                var respuesta = formA.ShowDialog();

                if (respuesta == System.Windows.Forms.DialogResult.OK)
                {
                    new Relacion().ShowDialog(); //listaArticulosPrecios, listaArticulosBascula
                    Frm_Principal_Load(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbNombreTabla_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbNombreTabla.SelectedIndex > -1)
                {
                    Properties.Settings.Default.NombreTabla = cmbNombreTabla.SelectedItem.ToString();
                    Properties.Settings.Default.Save();
                }
            }
            catch (Exception x)
            { MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion

        #region Metodos

        //private void InicializarArticulos()
        //{
        //    OleDbConnection oConexion = new OleDbConnection();
        //    oConexion.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; " +
        //                                 @"Data source= " + Properties.Settings.Default.AccessDB;

        //    pictboxLoading.BringToFront();
        //    pictboxLoading.Visible = true;
        //    Application.DoEvents();

        //    try
        //    {
        //        crearTablaIntermedia();

        //        /* Abrir la conexion a la base de datos*/
        //        oConexion.Open();

        //        /* Crear comando para leer todos los articulos */
        //        OleDbCommand oComando = new OleDbCommand();
        //        //oComando.CommandText = "SELECT codigo, nombre FROM Articulos";

        //        oComando.CommandText = "SELECT codigo, nombre FROM Productos";
        //        oComando.Connection = oConexion;

        //        /* Crear adapter para mantener los regostros de articulos en memoria */
        //        OleDbDataAdapter oAdapter = new OleDbDataAdapter();
        //        oAdapter.SelectCommand = oComando;

        //        /* Llenar un objeto DataTable con los registros obtenidos por el Adapter*/
        //        DataTable oTabla = new DataTable();
        //        oAdapter.Fill(oTabla);

        //        /* Borrar los registros de la tabla intermedia */
        //        oComando.CommandText = "DELETE FROM Ids_Articulos";
        //        oComando.ExecuteNonQuery();

        //        StringBuilder sbInsert;
        //        foreach (DataRow row in oTabla.Rows)
        //        {
        //            /* Asignar comando para insertar*/
        //            sbInsert = new StringBuilder();
        //            sbInsert.Append("INSERT INTO Ids_Articulos (codigo_articulo, nombre_articulo) VALUES ");
        //            sbInsert.Append(string.Format("({0}, '{1}')", row["codigo"], row["nombre"]));

        //            /*Insertar registro en la tabla intermedia*/
        //            oComando.CommandText = sbInsert.ToString();
        //            oComando.ExecuteNonQuery();
        //            Application.DoEvents();
        //        }

        //        pictboxLoading.Visible = false;
        //        MessageBox.Show("La inicialización ha finalizado con exito!!!");
        //    }
        //    catch (Exception ex)
        //    {
        //        pictboxLoading.Visible = false;
        //        MessageBox.Show("Ocurrio un error: " + ex.Message);
        //    }
        //    finally
        //    {
        //        oConexion.Close();
        //    }

        //}

        //private void crearTablaIntermedia()
        //{
        //    try
        //    {
        //        OleDbConnection oConexion = new OleDbConnection(); OleDbDataAdapter oAdaptador;
        //        oConexion.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; " + @"Data source= " + Properties.Settings.Default.AccessDB;
        //        oConexion.Open();

        //        OleDbCommand oComando = new OleDbCommand();
        //        oComando.Connection = oConexion;

        //        oAdaptador = new OleDbDataAdapter("SELECT * FROM Ids_Articulos", oConexion);
        //        DataTable tabla = new DataTable();
        //        try
        //        {
        //            oAdaptador.Fill(tabla);
        //            oComando.CommandText = "DROP TABLE Ids_Articulos";
        //            oComando.ExecuteNonQuery();
        //        }
        //        catch(OleDbException xx)
        //        {
        //            if (xx.ErrorCode == -2147217865)
        //            { }
        //        }               


        //        oComando.CommandText = "CREATE TABLE Ids_Articulos (codigo_articulo INTEGER, clave_microsip Text(6), nombre_articulo Text(100))";
        //        oComando.ExecuteNonQuery();
        //        oComando.CommandText = "CREATE INDEX Idx1 ON Ids_Articulos(codigo_articulo) WITH PRIMARY";
        //        oComando.ExecuteNonQuery();

        //        oConexion.Close();
        //    }
        //    catch (Exception x)
        //    { throw x; }
        //}

        //private string ObtenerStringConexionFB()
        //{
        //    try
        //    {
        //        ConexionMicrosip oConnMicrosip = MicrosipSettings.Conexiones.FirstOrDefault();

        //        StringBuilder sbStringConn = new StringBuilder();
        //        sbStringConn.Append(string.Format("User={0};", oConnMicrosip.Usuario));
        //        sbStringConn.Append(string.Format("Password={0};", oConnMicrosip.PassWord));
        //        sbStringConn.Append(string.Format("Database={0};", oConnMicrosip.Host));
        //        sbStringConn.Append(string.Format("DataSource={0};", oConnMicrosip.Empresa));
        //        sbStringConn.Append(string.Format("Port={0};", oConnMicrosip.Puerto));

        //        //*********************************************PRUEBAS*******************************************************************
        //        //sbStringConn.Append(string.Format("User={0};", "SYSDBA"));
        //        //sbStringConn.Append(string.Format("Password={0};", "masterkey"));
        //        //sbStringConn.Append(string.Format("Database={0};", @"G:\Microsip datos\Microsip_datos_HEROICO\CARNICERIAC.FDB"));
        //        //sbStringConn.Append(string.Format("DataSource={0};", "AODESARROLLO"));
        //        //sbStringConn.Append(string.Format("Port={0};", 3050));

        //        return sbStringConn.ToString();
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        //private bool ValidarTabla()
        //{
        //    bool bExiste = true;
        //    OleDbConnection oConexion = new OleDbConnection();

        //    try
        //    {
        //        oConexion.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; " + @"Data source= " + Properties.Settings.Default.AccessDB;
        //        oConexion.Open();

        //        OleDbCommand oComando = new OleDbCommand();
        //        oComando.Connection = oConexion;
        //        oComando.CommandText = "SELECT Count(*) FROM Ids_Articulos";
        //        oComando.ExecuteNonQuery();
        //    }
        //    catch
        //    {
        //        bExiste = false;
        //    }
        //    finally
        //    {
        //        oConexion.Close();
        //    }

        //    return bExiste;
        //}

        #endregion
    }
}

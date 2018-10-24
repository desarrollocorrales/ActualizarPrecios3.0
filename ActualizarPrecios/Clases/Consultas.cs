using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using AccSettings;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Data.OleDb;

namespace ActualizarPrecios.Clases
{
    public class Consultas
    {
        #region Variables
        MicroSipSettings MicrosipSettings = new MicroSipSettings();
        List<ArticuloPrecios> listaArticulosPrecios; List<ArticuloBascula> listaArticulosBascula; List<ArticuloBascula> listaNoActualizados;
        #endregion        

        public List<ArticuloPrecios> LeerPreciosMicrosip(Label lbl = null)
        {
            if(lbl != null)
            lbl.ForeColor = Color.Black;
            //lblAccion.Text = "Leyendo precios desde Microsip...";
            Application.DoEvents();

            FbConnection oConexion = new FbConnection();
            CargarConfiguraciones();
            oConexion.ConnectionString = ObtenerStringConexionFB();
            try
            {
                oConexion.Open();

                /* Generar consulta para obtener los precios de todos los articulos */
                StringBuilder sbSelect = new StringBuilder();
                sbSelect.Append(@"SELECT 
                                      CA.CLAVE_ARTICULO AS CLAVE, 
                                      A.NOMBRE, 
                                      PA.PRECIO, 
                                      A.ARTICULO_ID
                                  FROM 
                                    ARTICULOS A
                                      INNER JOIN CLAVES_ARTICULOS CA ON A.ARTICULO_ID=CA.ARTICULO_ID
                                      INNER JOIN PRECIOS_ARTICULOS PA ON PA.ARTICULO_ID=CA.ARTICULO_ID
                                  WHERE 
                                    PA.PRECIO_EMPRESA_ID = 42 AND
                                    CA.ROL_CLAVE_ART_ID = 17 
                                  ORDER BY A.NOMBRE");

                FbCommand oComando = new FbCommand();
                oComando.CommandText = sbSelect.ToString();
                oComando.Connection = oConexion;

                FbDataAdapter oAdapter = new FbDataAdapter();
                oAdapter.SelectCommand = oComando;

                DataTable oTabla = new DataTable();
                oAdapter.Fill(oTabla);

                ArticuloPrecios oArticuloPrecio;
                listaArticulosPrecios = new List<ArticuloPrecios>();
                foreach (DataRow row in oTabla.Rows)
                {
                    oArticuloPrecio = new ArticuloPrecios();
                    oArticuloPrecio.Clave_Articulo = row["CLAVE"].ToString();
                    oArticuloPrecio.Nombre = row["NOMBRE"].ToString();
                    oArticuloPrecio.Precio = float.Parse(row["PRECIO"].ToString());
                    oArticuloPrecio.Articulo_id = row["ARTICULO_ID"].ToString();

                    listaArticulosPrecios.Add(oArticuloPrecio);
                }

                return listaArticulosPrecios;
            }
            catch (Exception ex)
            {
                oConexion.Close();
                throw ex;
            }
        }

        public List<ArticuloBascula> LeerArticulosBascula()
        {
            //lblAccion.Text = "Leyendo articulos de basculas...";
            Application.DoEvents();

            OleDbConnection oConexion = new OleDbConnection();
            oConexion.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; " +
                                         @"Data source= " + Properties.Settings.Default.AccessDB;
            try
            {
                oConexion.Open();

                /* Generar consulta para obtener los precios de todos los articulos */
                StringBuilder sbSelect = new StringBuilder();
                sbSelect.Append("SELECT * FROM Ids_Articulos ORDER BY nombre_articulo ");

                OleDbCommand oComando = new OleDbCommand();
                oComando.CommandText = sbSelect.ToString();
                oComando.Connection = oConexion;

                OleDbDataAdapter oAdapter = new OleDbDataAdapter();
                oAdapter.SelectCommand = oComando;

                DataTable oTabla = new DataTable();
                oAdapter.Fill(oTabla);

                ArticuloBascula oArticuloBascula;
                listaArticulosBascula = new List<ArticuloBascula>();
                foreach (DataRow row in oTabla.Rows)
                {
                    oArticuloBascula = new ArticuloBascula();
                    oArticuloBascula.codigo = Convert.ToInt32(row["codigo_articulo"]);
                    oArticuloBascula.clave_microsip = row["clave_microsip"].ToString();
                    oArticuloBascula.nombre = row["nombre_articulo"].ToString();

                    listaArticulosBascula.Add(oArticuloBascula);
                }

                return listaArticulosBascula;
            }
            catch (Exception ex)
            {
                oConexion.Close();
                throw ex;
            }
        }

        public List<ArticuloBascula> ActualizarPrecios(Label lbl = null, Label lbl2 = null)
        {
            lbl.Text = "Actualizando precios...";
            Application.DoEvents();

            OleDbConnection oConexion = new OleDbConnection();
            oConexion.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; " +
                                         @"Data source= " + Properties.Settings.Default.AccessDB;
            OleDbTransaction Transaccion = null;
            try
            {
                oConexion.Open();
                Transaccion = oConexion.BeginTransaction();

                OleDbCommand oComando = new OleDbCommand();
                oComando.Connection = oConexion;
                oComando.Transaction = Transaccion;

                StringBuilder sbUpdate;
                listaArticulosBascula = listaArticulosBascula.OrderBy(o => o.codigo).ToList();
                listaNoActualizados = new List<ArticuloBascula>();
                foreach (ArticuloBascula oArticuloBascula in listaArticulosBascula)
                {
                    if (oArticuloBascula.clave_microsip.ToString().Trim() != string.Empty)
                    {
                        lbl.Text = "Actualizando precio de " + oArticuloBascula.nombre;
                        Application.DoEvents();

                        ArticuloPrecios oArticuloPrecio =
                            listaArticulosPrecios.FirstOrDefault(o => o.Clave_Articulo == oArticuloBascula.clave_microsip);

                        if (oArticuloPrecio != null)
                        {
                            sbUpdate = new StringBuilder();

                            if (Properties.Settings.Default.NombreTabla == "LSQ40")
                                sbUpdate.Append("UPDATE Articulos SET Precio=" + oArticuloPrecio.Precio);
                            else
                                sbUpdate.Append("UPDATE Productos SET Precio=" + oArticuloPrecio.Precio);

                            sbUpdate.Append(" WHERE codigo = " + oArticuloBascula.codigo);

                            oComando.CommandText = sbUpdate.ToString();
                            oComando.ExecuteNonQuery();
                        }
                        else
                        {
                            listaNoActualizados.Add(oArticuloBascula);
                        }
                    }
                    else
                    {
                        listaNoActualizados.Add(oArticuloBascula);
                    }
                }

                Transaccion.Commit();

                lbl.ForeColor = Color.Green;
                lbl.Text = "La Actualizacion se ha realizado con exito!!!";
                lbl2.Text =
                    string.Format("No se pudieron actualizar {0} articulos",
                                 (listaNoActualizados.Count));

                return listaNoActualizados;
            }
            catch (Exception ex)
            {
                Transaccion.Rollback();
                oConexion.Close();
                throw ex;
            }
        }

        public string ObtenerStringConexionFB()
        {
            try
            {                
                ConexionMicrosip oConnMicrosip = MicrosipSettings.Conexiones.FirstOrDefault();

                StringBuilder sbStringConn = new StringBuilder();
                sbStringConn.Append(string.Format("User={0};", oConnMicrosip.Usuario));
                sbStringConn.Append(string.Format("Password={0};", oConnMicrosip.PassWord));
                sbStringConn.Append(string.Format("Database={0};", oConnMicrosip.Host));
                sbStringConn.Append(string.Format("DataSource={0};", oConnMicrosip.Empresa));
                sbStringConn.Append(string.Format("Port={0};", oConnMicrosip.Puerto));

                //*********************************************PRUEBAS*******************************************************************
                //sbStringConn.Append(string.Format("User={0};", "SYSDBA"));
                //sbStringConn.Append(string.Format("Password={0};", "masterkey"));
                //sbStringConn.Append(string.Format("Database={0};", @"G:\Microsip datos\Microsip_datos_HEROICO\CARNICERIAC.FDB"));
                //sbStringConn.Append(string.Format("DataSource={0};", "AODESARROLLO"));
                //sbStringConn.Append(string.Format("Port={0};", 3050));

                return sbStringConn.ToString();
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void CargarConfiguraciones()
        {
            //Obtener la ruta del archivo de configuraciones de Microsip y la SettingsKey*
            MicrosipSettings = new MicroSipSettings();
            MicrosipSettings.FileName = Environment.CurrentDirectory + "\\microsip.set";
            MicrosipSettings.Key = "C0RR4L35";

            try
            {
                bool ExisteMicrosipSettings = System.IO.File.Exists(MicrosipSettings.FileName);

                if (ExisteMicrosipSettings == false)
                {
                    StringBuilder Mensaje = new StringBuilder();
                    Mensaje.AppendLine("No se encontró el archivo de configuración.");
                    Mensaje.AppendLine("Por favor, ejecute el modulo AdminACC, genere el archivo \"microsip.set\" y peguelo en la ruta:");
                    Mensaje.AppendLine(Environment.CurrentDirectory);
                    MessageBox.Show(Mensaje.ToString());
                    Application.Exit();
                    return;
                }

                MicrosipSettings = MicrosipSettings.Deserialize<MicroSipSettings>(true);
            }
            catch (Exception ex)
            {
                StringBuilder sbMensaje = new StringBuilder();
                sbMensaje.AppendLine("Ocurrio un error al cargar los archivos de configuración.");
                sbMensaje.Append(string.Format("Exception: {0}", ex.Message));

                MessageBox.Show(sbMensaje.ToString());

                Application.Exit();
            }
        }

        public string InicializarArticulos(PictureBox pb)
        {
            OleDbConnection oConexion = new OleDbConnection();
            oConexion.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; " +
                                         @"Data source= " + Properties.Settings.Default.AccessDB;

            pb.BringToFront();
            pb.Visible = true;
            Application.DoEvents();

            try
            {
                crearTablaIntermedia();

                /* Abrir la conexion a la base de datos*/
                oConexion.Open();

                /* Crear comando para leer todos los articulos */
                OleDbCommand oComando = new OleDbCommand();

                if (Properties.Settings.Default.NombreTabla == "LSQ40")
                    oComando.CommandText = "SELECT codigo, nombre FROM Articulos";
                else
                    oComando.CommandText = "SELECT codigo, nombre FROM Productos";

                oComando.Connection = oConexion;

                /* Crear adapter para mantener los regostros de articulos en memoria */
                OleDbDataAdapter oAdapter = new OleDbDataAdapter();
                oAdapter.SelectCommand = oComando;

                /* Llenar un objeto DataTable con los registros obtenidos por el Adapter*/
                DataTable oTabla = new DataTable();
                oAdapter.Fill(oTabla);

                /* Borrar los registros de la tabla intermedia */
                oComando.CommandText = "DELETE FROM Ids_Articulos";
                oComando.ExecuteNonQuery();

                StringBuilder sbInsert;
                foreach (DataRow row in oTabla.Rows)
                {
                    /* Asignar comando para insertar*/
                    sbInsert = new StringBuilder();
                    sbInsert.Append("INSERT INTO Ids_Articulos (codigo_articulo, nombre_articulo) VALUES ");
                    sbInsert.Append(string.Format("({0}, '{1}')", row["codigo"], row["nombre"]));

                    /*Insertar registro en la tabla intermedia*/
                    oComando.CommandText = sbInsert.ToString();
                    oComando.ExecuteNonQuery();
                    Application.DoEvents();
                }

                pb.Visible = false;
            }
            catch (Exception ex)
            {
                pb.Visible = false;
                MessageBox.Show("Ocurrio un error: " + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return "La inicialización ha finalizado con exito!!!";
        }

        public void crearTablaIntermedia()
        {
            try
            {
                OleDbConnection oConexion = new OleDbConnection(); OleDbDataAdapter oAdaptador;
                oConexion.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; " + @"Data source= " + Properties.Settings.Default.AccessDB;
                oConexion.Open();

                OleDbCommand oComando = new OleDbCommand();
                oComando.Connection = oConexion;

                oAdaptador = new OleDbDataAdapter("SELECT * FROM Ids_Articulos", oConexion);
                DataTable tabla = new DataTable();
                try
                {
                    oAdaptador.Fill(tabla);
                    oComando.CommandText = "DROP TABLE Ids_Articulos";
                    oComando.ExecuteNonQuery();
                }
                catch (OleDbException xx)
                {
                    if (xx.ErrorCode == -2147217865)
                    { }
                }


                oComando.CommandText = "CREATE TABLE Ids_Articulos (codigo_articulo INTEGER, clave_microsip Text(6), nombre_articulo Text(100))";
                oComando.ExecuteNonQuery();
                oComando.CommandText = "CREATE INDEX Idx1 ON Ids_Articulos(codigo_articulo) WITH PRIMARY";
                oComando.ExecuteNonQuery();

                oConexion.Close();
            }
            catch (Exception x)
            { throw x; }
        }

        public int generaCodigoArticulo()
        {
            try
            {
                int codigo = 0;
                OleDbConnection oConexion = new OleDbConnection();
                oConexion.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; " +
                                             @"Data source= " + Properties.Settings.Default.AccessDB;
                Application.DoEvents();
                try
                {
                    codigo = 0;
                    /* Abrir la conexion a la base de datos*/
                    oConexion.Open();

                    /* Crear comando para leer todos los articulos */
                    OleDbCommand oComando = new OleDbCommand();
                    OleDbDataReader lecst;

                    if (Properties.Settings.Default.NombreTabla == "LSQ40")
                        oComando.CommandText = "SELECT max(codigo) FROM Articulos";
                    else
                        oComando.CommandText = "SELECT max(codigo) FROM Productos";

                    oComando.Connection = oConexion;

                    lecst = oComando.ExecuteReader();
                    while (lecst.Read())
                    {
                        if (lecst[0].ToString() != "")
                            codigo = int.Parse(lecst[0].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error: " + ex.Message);
                }
                finally
                {
                    oConexion.Close();
                }
                return codigo;
            }
            catch (Exception x)
            { throw x; }
        }

        public void RegistraArticulo(string clave_microsip, int codigo, string nombre, int tipoplu, decimal precio, decimal impuesto, int caducidad, int pnd, int numplu, DateTime fecha, int editable = 0)
        {
            try
            {
                OleDbConnection oConexion = new OleDbConnection();
                oConexion.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; " +
                                             @"Data source= " + Properties.Settings.Default.AccessDB;

                Application.DoEvents();
                try
                {
                    /* Abrir la conexion a la base de datos*/
                    oConexion.Open();

                    /* Crear comando para leer todos los articulos */
                    OleDbCommand oComando = new OleDbCommand();
                    StringBuilder sbInsert;

                    if (Properties.Settings.Default.NombreTabla == "LSQ40")
                    {
                        string dates = fecha.ToString("MM/dd/yyyy");
                        
                        /* Asignar comando para insertar*/
                        sbInsert = new StringBuilder();
                        sbInsert.Append("INSERT INTO Articulos (codigo, nombre, tipoplu, precio, impuesto, fcad, pendiente, numplu, actualizado) VALUES ");
                        sbInsert.Append(string.Format("({0}, '{1}', {2}, {3}, {4}, {5}, {6}, {7}, {8})", codigo, nombre, tipoplu, precio, impuesto, caducidad, pnd, numplu, dates));

                        oComando.Connection = oConexion;

                        /*Insertar registro en la tabla */
                        oComando.CommandText = sbInsert.ToString();
                        oComando.ExecuteNonQuery();
                        Application.DoEvents();

                    }
                    else
                    {
                        /* Asignar comando para insertar*/
                        sbInsert = new StringBuilder();
                        sbInsert.Append("INSERT INTO Productos (id_producto, Codigo, Nombre, TipoId, Precio, Impuesto, CaducidadDias, pendiente, NoPlu, actualizado, PrecioEditable) VALUES ");
                        sbInsert.Append(string.Format("({0}, {1}, '{2}', {3}, {4}, {5}, {6}, {7}, {8}, '{9}', {10})", codigo, codigo, nombre, tipoplu, precio, impuesto, caducidad, pnd, numplu, fecha.ToString("yy-MM-dd"), editable));

                        oComando.Connection = oConexion;

                        /*Insertar registro en la tabla intermedia*/
                        oComando.CommandText = sbInsert.ToString();
                        oComando.ExecuteNonQuery();
                        Application.DoEvents();
                    }

                    /* Asignar comando para insertar*/
                    sbInsert = new StringBuilder();
                    sbInsert.Append("INSERT INTO Ids_Articulos (codigo_articulo, clave_microsip, nombre_articulo) VALUES ");
                    sbInsert.Append(string.Format("({0}, '{1}', '{2}')", codigo, clave_microsip, nombre));

                    /*Insertar registro en la tabla intermedia*/
                    oComando.CommandText = sbInsert.ToString();
                    oComando.ExecuteNonQuery();
                    Application.DoEvents();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error: " + ex.Message);
                }
                finally
                {
                    oConexion.Close();
                }
            }
            catch (Exception x)
            { throw x; }
        }

        public void ActualizaArtuculo(int codigo, decimal precio, decimal impuesto, int caducidad, int tipoplu, int editable = 0)
        {
            try
            {
                OleDbConnection oConexion = new OleDbConnection();
                oConexion.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; " +
                    @"Data source= " + Properties.Settings.Default.AccessDB;
                OleDbTransaction Transaccion = null;
                try
                {
                    oConexion.Open();
                    Transaccion = oConexion.BeginTransaction();

                    OleDbCommand oComando = new OleDbCommand();
                    oComando.Connection = oConexion;
                    oComando.Transaction = Transaccion;

                    StringBuilder sbUpdate;

                    if (Properties.Settings.Default.NombreTabla == "LSQ40")
                    {
                        sbUpdate = new StringBuilder();

                        sbUpdate.Append("UPDATE Articulos SET precio = " + precio + ", impuesto = " + impuesto + ", fcad = " + caducidad + ", tipoplu = " + tipoplu + "  WHERE codigo = " + codigo + ";");

                        oComando.CommandText = sbUpdate.ToString();
                        oComando.ExecuteNonQuery();

                        oComando.Connection = oConexion;
                        Transaccion.Commit();

                    }
                    else
                    {
                        sbUpdate = new StringBuilder();
                        sbUpdate.Append("UPDATE Productos SET Precio = " + precio + ", Impuesto = " + impuesto + ", CaducidadDias = " + caducidad + ", TipoId = " + tipoplu + ", PrecioEditable = " + editable + " WHERE codigo = " + codigo + ";");

                        oComando.CommandText = sbUpdate.ToString();
                        oComando.ExecuteNonQuery();

                        oComando.Connection = oConexion;
                        Transaccion.Commit();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error: " + ex.Message);
                }
                finally
                {
                    oConexion.Close();
                }
            }
            catch (Exception x)
            { throw x; }
        }

        public void EliminaArticulo(int codigoProducto)
        {
            try
            {
                OleDbConnection oConexion = new OleDbConnection();
                oConexion.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; " +
                                             @"Data source= " + Properties.Settings.Default.AccessDB;

                Application.DoEvents();
                try
                {

                    /* Abrir la conexion a la base de datos*/
                    oConexion.Open();

                    /* Crear comando para leer todos los articulos */
                    OleDbCommand oComando = new OleDbCommand();

                    oComando.Connection = oConexion;

                    if (Properties.Settings.Default.NombreTabla == "LSQ40")
                        oComando.CommandText = "DELETE FROM Articulos WHERE codigo = " + codigoProducto;
                    else 
                        oComando.CommandText = "DELETE FROM Productos WHERE Codigo = " + codigoProducto;

                    oComando.ExecuteNonQuery();

                    /* Borrar los registros de la tabla intermedia */
                    oComando.CommandText = "DELETE FROM Ids_Articulos WHERE codigo_articulo = " + codigoProducto;
                    oComando.ExecuteNonQuery();
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error: " + ex.Message);
                }
                finally
                {
                    oConexion.Close();
                }
            }
            catch (Exception x)
            { throw x; }
        }

        public void GuardaRelacion(List<ArticuloBascula> ArticulosRelacionados)
        {
            OleDbConnection oConexion = new OleDbConnection();
            oConexion.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; " +
                @"Data source= " + Properties.Settings.Default.AccessDB;
            OleDbTransaction Transaccion = null;

            try
            {
                oConexion.Open();
                Transaccion = oConexion.BeginTransaction();

                OleDbCommand oComando = new OleDbCommand();
                oComando.Connection = oConexion;
                oComando.Transaction = Transaccion;

                StringBuilder sbUpdate;
                foreach (ArticuloBascula ab in ArticulosRelacionados)
                {
                    sbUpdate = new StringBuilder();

                    sbUpdate.Append("UPDATE Ids_Articulos SET clave_microsip ='" + ab.clave_microsip + "', nombre_articulo ='" + ab.nombre + "' WHERE codigo_articulo = " + ab.codigo + ";");

                    oComando.CommandText = sbUpdate.ToString();
                    oComando.ExecuteNonQuery();
                }

                Transaccion.Commit();
                //this.Close();
            }
            catch (Exception ex)
            {
                Transaccion.Rollback();
                oConexion.Close();
                throw ex;
            }
        }

        public void QuitaRelacionArticulo(ArticuloBascula objeto)
        {
            OleDbConnection oConexion = new OleDbConnection();
            oConexion.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; " +
                                             @"Data source= " + Properties.Settings.Default.AccessDB;
            OleDbTransaction Transaccion = null;
            try
            {
                oConexion.Open();
                Transaccion = oConexion.BeginTransaction();

                OleDbCommand oComando = new OleDbCommand();
                oComando.Connection = oConexion;
                oComando.Transaction = Transaccion;

                /* Borrar los registros de la tabla intermedia */
                oComando.CommandText = "DELETE FROM Ids_Articulos WHERE codigo_articulo = " + objeto.codigo;
                oComando.ExecuteNonQuery();

                StringBuilder sbInsert = new StringBuilder();

                sbInsert.Append("INSERT INTO Ids_Articulos (codigo_articulo, nombre_articulo) VALUES ");
                sbInsert.Append(string.Format("({0}, '{1}')", objeto.codigo, objeto.nombre));

                /*Insertar registro en la tabla intermedia*/
                oComando.CommandText = sbInsert.ToString();
                oComando.ExecuteNonQuery();

                Transaccion.Commit();
            }
            catch (Exception ex)
            {
                Transaccion.Rollback();
                oConexion.Close();
                throw ex;
            }
        }

        public ArticuloEnBascula ObtenerArticuloSel(int codigo)
        {
            try
            {
                ArticuloEnBascula obj_articulo = new ArticuloEnBascula();
                OleDbConnection oConexion = new OleDbConnection();
                oConexion.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; " +
                                             @"Data source= " + Properties.Settings.Default.AccessDB;

                Application.DoEvents();
                try
                {
                    /* Abrir la conexion a la base de datos*/
                    oConexion.Open();

                    /* Crear comando para leer todos los articulos */
                    OleDbCommand oComando = new OleDbCommand();

                    if (Properties.Settings.Default.NombreTabla == "LSQ40")
                        oComando.CommandText = "SELECT Articulos.codigo, Ids_Articulos.clave_microsip, Articulos.nombre, Articulos.precio, Articulos.numplu AS noplu, Articulos.impuesto, Articulos.fcad AS caducidad, Articulos.tipoplu " +
                            " FROM Articulos INNER JOIN Ids_Articulos on Articulos.codigo = Ids_Articulos.codigo_articulo WHERE codigo = " + codigo;
                    else
                        oComando.CommandText = "SELECT Productos.Codigo, Ids_Articulos.clave_microsip, Productos.Nombre, Productos.Precio, Productos.NoPlu, Productos.Impuesto, Productos.CaducidadDias AS caducidad, Productos.TipoId, Productos.PrecioEditable AS editable, Productos.id_producto " +
                            " FROM Productos INNER JOIN Ids_Articulos on Productos.Codigo = Ids_Articulos.codigo_articulo WHERE codigo = " + codigo;

                    oComando.Connection = oConexion;

                    /* Crear adapter para mantener los regostros de articulos en memoria */
                    OleDbDataAdapter oAdapter = new OleDbDataAdapter();
                    oAdapter.SelectCommand = oComando;

                    /* Llenar un objeto DataTable con los registros obtenidos por el Adapter*/
                    DataTable oTabla = new DataTable();
                    oAdapter.Fill(oTabla);

                    foreach (DataRow row in oTabla.Rows)
                    {
                        obj_articulo = new ArticuloEnBascula();
                        obj_articulo.codigo = Convert.ToInt32(row["codigo"]);
                        obj_articulo.clave_microsip = row["clave_microsip"].ToString();
                        obj_articulo.nombre = row["nombre"].ToString();
                        obj_articulo.precio = decimal.Parse(row["precio"].ToString());
                        obj_articulo.noplu = int.Parse(row["noplu"].ToString());
                        obj_articulo.impuesto = decimal.Parse(row["impuesto"].ToString());
                        obj_articulo.caducidad = int.Parse(row["caducidad"].ToString());

                        if (Properties.Settings.Default.NombreTabla == "LSQ40")
                            obj_articulo.tipoplu = int.Parse(row["tipoplu"].ToString());
                        else
                        {
                            obj_articulo.tipoplu = int.Parse(row["tipoid"].ToString());
                            obj_articulo.editable = int.Parse(row["editable"].ToString());
                            obj_articulo.id_producto = int.Parse(row["id_producto"].ToString());
                        }                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error: " + ex.Message);
                }
                finally
                {
                    oConexion.Close();
                }


                return obj_articulo;

            }
            catch (Exception x)
            { throw x; }
        }

        public bool ArticulosAgregados(string nombre)
        {
            try
            {
                bool resultado = false;

                OleDbConnection oConexion = new OleDbConnection();
                oConexion.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; " +
                                             @"Data source= " + Properties.Settings.Default.AccessDB;
                Application.DoEvents();
                try
                {
                    /* Abrir la conexion a la base de datos*/
                    oConexion.Open();

                    /* Crear comando para leer todos los articulos */
                    OleDbCommand oComando = new OleDbCommand();
                    OleDbDataReader lecst;

                    if (Properties.Settings.Default.NombreTabla == "LSQ40")
                        oComando.CommandText = "SELECT nombre FROM Articulos WHERE nombre = '" + nombre + "';";
                    else
                        oComando.CommandText = "SELECT Nombre FROM Productos WHERE Nombre = '" + nombre + "';";

                    oComando.Connection = oConexion;

                    lecst = oComando.ExecuteReader();
                    while (lecst.Read())
                    {
                        if (lecst[0].ToString() != "")
                            resultado = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error: " + ex.Message);
                }
                finally
                {
                    oConexion.Close();
                }

                return resultado;
            }
            catch (Exception x)
            { throw x; }
        }
    }
}

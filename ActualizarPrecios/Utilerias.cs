using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;

namespace firmas.Modelo
{
    public enum Estatus
    {
        OK, ERROR
    }

    public class PLUS
    {
        public int id_tp { get; set; }
        public string descripcion { get; set; }
    }

    public partial class Response
    {
        public Estatus status { get; set; }
        public string resultado { get; set; }
        public string error { get; set; }
    }

    public static class ConectionString
    {
        public static string conn { get; set; }
    }

    public static class Utilerias
    {
        /// <summary>
        /// Performs the ROT13 character rotation.
        /// </summary>
        public static string Transform(string value)
        {
            char[] array = value.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                int number = (int)array[i];

                if (number >= 'a' && number <= 'z')
                {
                    if (number > 'm')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                else if (number >= 'A' && number <= 'Z')
                {
                    if (number > 'M')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                array[i] = (char)number;
            }
            return new string(array);
        }

        // Codificar cadena a Base64
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        // Decodificar cadena a Base64
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

    }

    public class Generales
    {
        Validador validador = new Validador();
        public void limpiaControles(Panel pn)
        {
            try
            {
                foreach (Control ctrl in pn.Controls)
                {
                    if (ctrl.GetType().ToString() == "System.Windows.Forms.ComboBox")
                    {
                        ComboBox cmb = ((ComboBox)ctrl);
                        cmb.SelectedIndex = -1;
                    }
                    if (ctrl.GetType().ToString() == "System.Windows.Forms.TextBox")
                    {
                        TextBox texto = ((TextBox)ctrl);
                        texto.Text = "";
                    }
                    if (ctrl.GetType().ToString() == "System.Windows.Forms.DateTimePicker")
                    {
                        DateTimePicker dtp = ((DateTimePicker)ctrl);
                        dtp.Value = DateTime.Now;
                    }
                    if (ctrl.GetType().ToString() == "System.Windows.Forms.GroupBox")
                    {
                        limpiaControlesG((GroupBox)ctrl);
                    }
                    if (ctrl.GetType().ToString() == "System.Windows.Forms.DataGridView")
                    {
                        DataGridView dgv = ((DataGridView)ctrl);
                        dgv.Columns.Clear();
                        dgv.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public void limpiaControlesG(GroupBox gb)
        {
            try
            {
                foreach (Control ctrl in gb.Controls)
                {
                    if (ctrl.GetType().ToString() == "System.Windows.Forms.ComboBox")
                    {
                        ComboBox cmb = ((ComboBox)ctrl);
                        cmb.SelectedIndex = -1;
                    }
                    if (ctrl.GetType().ToString() == "System.Windows.Forms.TextBox")
                    {
                        TextBox texto = ((TextBox)ctrl);
                        texto.Text = "";
                    }
                    if (ctrl.GetType().ToString() == "System.Windows.Forms.DateTimePicker")
                    {
                        DateTimePicker dtp = ((DateTimePicker)ctrl);
                        dtp.Value = DateTime.Now;
                    }
                    if (ctrl.GetType().ToString() == "System.Windows.Forms.DataGridView")
                    {
                        DataGridView dgv = ((DataGridView)ctrl);
                        dgv.Columns.Clear();
                        dgv.DataSource = null;
                    }
                    if (ctrl.GetType().ToString() == "System.Windows.Forms.GroupBox")
                    {
                        limpiaControlesG((GroupBox)ctrl);
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public void MouseLeaveEfecto(PictureBox pb, Bitmap imagen)
        {
            try
            {
                pb.Image = imagen;
                pb.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            catch (Exception x)
            { throw x; }
        }

        public bool teclapresiondaPesos(KeyPressEventArgs tecla)
        {
            try
            {
                bool resultado = true;
                if (Char.IsLetter(tecla.KeyChar))
                    resultado = true;
                //tecla.Handled = true;
                if ((Char.IsNumber(tecla.KeyChar) || Char.IsPunctuation(tecla.KeyChar)) || tecla.KeyChar.ToString() == "\b")
                    resultado = false;

                return resultado;
            }
            catch (Exception x)
            { throw x; }
        }

        public bool teclaNumero(KeyPressEventArgs tecla)
        {
            try
            {
                bool resultado = false;
                if (!validador.EsNumeroEntero(tecla.KeyChar.ToString()) && tecla.KeyChar.ToString() != "\b")
                {
                    resultado = true;
                }
                return resultado;
            }
            catch (Exception x)
            { throw x; }
        }
    }

    public class Validador
    {
        public bool EsNumeroEntero(string strIn)
        {
            try
            {
                int.Parse(strIn);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EsNumerico(string strIn)
        {
            try
            {
                decimal.Parse(strIn);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EsPunto(string str)
        {
            try
            {
                decimal.Parse(str);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EsNumericoNull(string strIn)
        {
            try
            {
                if (strIn == "") return true;
                double.Parse(strIn);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public double doubleConv(string cantidad)
        {
            try
            {
                if (cantidad.Trim() == "") return 0;
                cantidad = Regex.Replace(cantidad, @"[^\d\.]", "");
                double paso;
                double.TryParse(cantidad, out paso);
                return paso;
            }
            catch (Exception E)
            {
                throw E;
            }
        }
        public decimal decimalConv(string cantidad)
        {
            try
            {
                if (cantidad.Trim() == "") return 0;
                cantidad = Regex.Replace(cantidad, @"[^\d\.]", "");
                decimal paso;
                decimal.TryParse(cantidad, out paso);
                return paso;
            }
            catch (Exception E)
            {
                throw E;
            }
        }
        public int Numerico(string cantidad)
        {
            try
            {
                if (cantidad.Trim() == "") return 0;
                cantidad = Regex.Replace(cantidad, @"[^\d\.]", "");
                int paso;
                int.TryParse(cantidad, out paso);
                return paso;
            }
            catch (Exception E)
            {
                throw E;
            }
        }
        public String CleanInput(string strIn)
        {
            return Regex.Replace(strIn, @"[^\w\.\-\%\s]", "");
        }
        public bool EsAoB(string strIn)
        {
            if (strIn == "A" || strIn == "B")
                return true;
            else
                return false;
        }
    }
}

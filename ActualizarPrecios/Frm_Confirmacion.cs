using System;
using System.Windows.Forms;
using System.IO;
using Seguridad;

namespace ActualizarPrecios
{
    public partial class Frm_Confirmacion : Form
    {
        public Frm_Confirmacion()
        {
            InitializeComponent();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            Continuar();
        }

        private void Continuar()
        {
            string contraseña = txbPass.Text.ToUpper();
            string contraseñaSistema = LeerPasswordArchivo();
            if (contraseña.Equals(contraseñaSistema))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("La contraseña es incorrecta.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string LeerPasswordArchivo()
        {
            StreamReader sr = new StreamReader("Actualizar.pwd");
            string contraseñaSistema = sr.ReadLine();
            sr.Close();
            return Encriptador.Desencriptar(contraseñaSistema);
        }

        private void txbPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Continuar();
            }
        }
    }
}

namespace ActualizarPrecios
{
    partial class Frm_Principal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Principal));
            this.label1 = new System.Windows.Forms.Label();
            this.txbFileDB = new System.Windows.Forms.TextBox();
            this.btnBuscarDB = new System.Windows.Forms.Button();
            this.ofdDB = new System.Windows.Forms.OpenFileDialog();
            this.lblAccion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblActualizados = new System.Windows.Forms.LinkLabel();
            this.btnRelacionA = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNombreTabla = new System.Windows.Forms.ComboBox();
            this.btnArticulos = new System.Windows.Forms.Button();
            this.btnActualizarPrecios = new System.Windows.Forms.Button();
            this.btnInicializarArticulos = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictboxLoading = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictboxLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Access DB:";
            // 
            // txbFileDB
            // 
            this.txbFileDB.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFileDB.Location = new System.Drawing.Point(101, 51);
            this.txbFileDB.Name = "txbFileDB";
            this.txbFileDB.Size = new System.Drawing.Size(458, 22);
            this.txbFileDB.TabIndex = 1;
            // 
            // btnBuscarDB
            // 
            this.btnBuscarDB.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarDB.Location = new System.Drawing.Point(566, 51);
            this.btnBuscarDB.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarDB.Name = "btnBuscarDB";
            this.btnBuscarDB.Size = new System.Drawing.Size(29, 23);
            this.btnBuscarDB.TabIndex = 4;
            this.btnBuscarDB.Text = "...";
            this.btnBuscarDB.UseVisualStyleBackColor = true;
            this.btnBuscarDB.Click += new System.EventHandler(this.btnBuscarDB_Click);
            // 
            // ofdDB
            // 
            this.ofdDB.FileName = "*.mdb";
            this.ofdDB.Filter = "Access|*.mdb";
            // 
            // lblAccion
            // 
            this.lblAccion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAccion.Location = new System.Drawing.Point(0, 398);
            this.lblAccion.Name = "lblAccion";
            this.lblAccion.Size = new System.Drawing.Size(604, 40);
            this.lblAccion.TabIndex = 6;
            this.lblAccion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(604, 30);
            this.label2.TabIndex = 7;
            this.label2.Text = "Actualizar precios de básculas";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblActualizados
            // 
            this.lblActualizados.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblActualizados.Location = new System.Drawing.Point(0, 378);
            this.lblActualizados.Name = "lblActualizados";
            this.lblActualizados.Size = new System.Drawing.Size(604, 20);
            this.lblActualizados.TabIndex = 9;
            this.lblActualizados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblActualizados.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblActualizados_LinkClicked);
            // 
            // btnRelacionA
            // 
            this.btnRelacionA.BackColor = System.Drawing.Color.White;
            this.btnRelacionA.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelacionA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelacionA.Location = new System.Drawing.Point(385, 331);
            this.btnRelacionA.Name = "btnRelacionA";
            this.btnRelacionA.Size = new System.Drawing.Size(165, 44);
            this.btnRelacionA.TabIndex = 4;
            this.btnRelacionA.Text = "Relaciona Articulos";
            this.btnRelacionA.UseVisualStyleBackColor = false;
            this.btnRelacionA.Click += new System.EventHandler(this.btnRelacionA_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "Modelo Báscula:";
            // 
            // cmbNombreTabla
            // 
            this.cmbNombreTabla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNombreTabla.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNombreTabla.FormattingEnabled = true;
            this.cmbNombreTabla.Items.AddRange(new object[] {
            "LSQ40",
            "W LABEL"});
            this.cmbNombreTabla.Location = new System.Drawing.Point(128, 111);
            this.cmbNombreTabla.Name = "cmbNombreTabla";
            this.cmbNombreTabla.Size = new System.Drawing.Size(431, 27);
            this.cmbNombreTabla.TabIndex = 2;
            this.cmbNombreTabla.SelectionChangeCommitted += new System.EventHandler(this.cmbNombreTabla_SelectionChangeCommitted);
            // 
            // btnArticulos
            // 
            this.btnArticulos.BackColor = System.Drawing.Color.White;
            this.btnArticulos.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArticulos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArticulos.Location = new System.Drawing.Point(385, 224);
            this.btnArticulos.Name = "btnArticulos";
            this.btnArticulos.Size = new System.Drawing.Size(165, 44);
            this.btnArticulos.TabIndex = 12;
            this.btnArticulos.Text = "Articulos";
            this.btnArticulos.UseVisualStyleBackColor = false;
            this.btnArticulos.Click += new System.EventHandler(this.btnArticulos_Click);
            // 
            // btnActualizarPrecios
            // 
            this.btnActualizarPrecios.BackColor = System.Drawing.Color.White;
            this.btnActualizarPrecios.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarPrecios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizarPrecios.Location = new System.Drawing.Point(68, 331);
            this.btnActualizarPrecios.Name = "btnActualizarPrecios";
            this.btnActualizarPrecios.Size = new System.Drawing.Size(165, 44);
            this.btnActualizarPrecios.TabIndex = 5;
            this.btnActualizarPrecios.Text = "Actualizar Precios";
            this.btnActualizarPrecios.UseVisualStyleBackColor = false;
            this.btnActualizarPrecios.Click += new System.EventHandler(this.btnActualizarPrecios_Click);
            // 
            // btnInicializarArticulos
            // 
            this.btnInicializarArticulos.BackColor = System.Drawing.Color.White;
            this.btnInicializarArticulos.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicializarArticulos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInicializarArticulos.Location = new System.Drawing.Point(68, 224);
            this.btnInicializarArticulos.Margin = new System.Windows.Forms.Padding(4);
            this.btnInicializarArticulos.Name = "btnInicializarArticulos";
            this.btnInicializarArticulos.Size = new System.Drawing.Size(165, 44);
            this.btnInicializarArticulos.TabIndex = 3;
            this.btnInicializarArticulos.Text = "Inicializar Articulos";
            this.btnInicializarArticulos.UseVisualStyleBackColor = false;
            this.btnInicializarArticulos.Click += new System.EventHandler(this.btnCopiarArticulos_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::ActualizarPrecios.Properties.Resources.relacionar;
            this.pictureBox4.Location = new System.Drawing.Point(449, 268);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(51, 64);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox4.TabIndex = 16;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::ActualizarPrecios.Properties.Resources.product;
            this.pictureBox3.Location = new System.Drawing.Point(436, 164);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(64, 63);
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(123, 274);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 62);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ActualizarPrecios.Properties.Resources.INICIO;
            this.pictureBox1.Location = new System.Drawing.Point(123, 175);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 50);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // pictboxLoading
            // 
            this.pictboxLoading.Image = ((System.Drawing.Image)(resources.GetObject("pictboxLoading.Image")));
            this.pictboxLoading.Location = new System.Drawing.Point(258, 224);
            this.pictboxLoading.Name = "pictboxLoading";
            this.pictboxLoading.Size = new System.Drawing.Size(100, 100);
            this.pictboxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictboxLoading.TabIndex = 5;
            this.pictboxLoading.TabStop = false;
            this.pictboxLoading.Visible = false;
            // 
            // Frm_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(604, 438);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnArticulos);
            this.Controls.Add(this.cmbNombreTabla);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRelacionA);
            this.Controls.Add(this.lblActualizados);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBuscarDB);
            this.Controls.Add(this.txbFileDB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnActualizarPrecios);
            this.Controls.Add(this.btnInicializarArticulos);
            this.Controls.Add(this.pictboxLoading);
            this.Controls.Add(this.lblAccion);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(720, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(520, 300);
            this.Name = "Frm_Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualizar Precios";
            this.Load += new System.EventHandler(this.Frm_Principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictboxLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInicializarArticulos;
        private System.Windows.Forms.Button btnActualizarPrecios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbFileDB;
        private System.Windows.Forms.Button btnBuscarDB;
        private System.Windows.Forms.OpenFileDialog ofdDB;
        private System.Windows.Forms.PictureBox pictboxLoading;
        private System.Windows.Forms.Label lblAccion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lblActualizados;
        private System.Windows.Forms.Button btnRelacionA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbNombreTabla;
        private System.Windows.Forms.Button btnArticulos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}


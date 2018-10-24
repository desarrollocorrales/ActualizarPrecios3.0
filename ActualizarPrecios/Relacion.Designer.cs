namespace ActualizarPrecios
{
    partial class Relacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Relacion));
            this.dgvArticulosB = new System.Windows.Forms.DataGridView();
            this.dgvArticulosMS = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbQuitarLista = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtArticulo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pbCerrar = new System.Windows.Forms.PictureBox();
            this.pbGuardar = new System.Windows.Forms.PictureBox();
            this.dgvRelacion = new System.Windows.Forms.DataGridView();
            this.pbMenos = new System.Windows.Forms.PictureBox();
            this.pbMas = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulosB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulosMS)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuitarLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArticulosB
            // 
            this.dgvArticulosB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulosB.Location = new System.Drawing.Point(559, 72);
            this.dgvArticulosB.MultiSelect = false;
            this.dgvArticulosB.Name = "dgvArticulosB";
            this.dgvArticulosB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulosB.Size = new System.Drawing.Size(429, 553);
            this.dgvArticulosB.TabIndex = 0;
            // 
            // dgvArticulosMS
            // 
            this.dgvArticulosMS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulosMS.Location = new System.Drawing.Point(14, 72);
            this.dgvArticulosMS.Name = "dgvArticulosMS";
            this.dgvArticulosMS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulosMS.Size = new System.Drawing.Size(429, 557);
            this.dgvArticulosMS.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(559, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(429, 30);
            this.label1.TabIndex = 9;
            this.label1.Text = "Articulos Básculas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(429, 30);
            this.label3.TabIndex = 10;
            this.label3.Text = "Articulos de Microsip";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbQuitarLista);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtArticulo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.pbCerrar);
            this.panel1.Controls.Add(this.pbGuardar);
            this.panel1.Controls.Add(this.dgvRelacion);
            this.panel1.Controls.Add(this.pbMenos);
            this.panel1.Controls.Add(this.pbMas);
            this.panel1.Controls.Add(this.dgvArticulosMS);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dgvArticulosB);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1579, 638);
            this.panel1.TabIndex = 11;
            // 
            // pbQuitarLista
            // 
            this.pbQuitarLista.Image = global::ActualizarPrecios.Properties.Resources.menos1;
            this.pbQuitarLista.Location = new System.Drawing.Point(1487, 98);
            this.pbQuitarLista.Name = "pbQuitarLista";
            this.pbQuitarLista.Size = new System.Drawing.Size(69, 49);
            this.pbQuitarLista.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbQuitarLista.TabIndex = 19;
            this.pbQuitarLista.TabStop = false;
            this.pbQuitarLista.Tag = "2";
            this.toolTip1.SetToolTip(this.pbQuitarLista, "Quitar de lista Relación");
            this.pbQuitarLista.Click += new System.EventHandler(this.pbQuitarLista_Click);
            this.pbQuitarLista.MouseLeave += new System.EventHandler(this.pbQuitarLista_MouseLeave);
            this.pbQuitarLista.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbQuitarLista_MouseMove);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1012, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(469, 30);
            this.label5.TabIndex = 18;
            this.label5.Text = "Lista Relacionados";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtArticulo
            // 
            this.txtArticulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtArticulo.Location = new System.Drawing.Point(136, 46);
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.Size = new System.Drawing.Size(307, 20);
            this.txtArticulo.TabIndex = 17;
            this.txtArticulo.TextChanged += new System.EventHandler(this.txtArticulo_TextChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 30);
            this.label4.TabIndex = 16;
            this.label4.Text = "Busca Articulo:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbCerrar
            // 
            this.pbCerrar.Image = ((System.Drawing.Image)(resources.GetObject("pbCerrar.Image")));
            this.pbCerrar.Location = new System.Drawing.Point(448, 565);
            this.pbCerrar.Name = "pbCerrar";
            this.pbCerrar.Size = new System.Drawing.Size(104, 60);
            this.pbCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbCerrar.TabIndex = 15;
            this.pbCerrar.TabStop = false;
            this.toolTip1.SetToolTip(this.pbCerrar, "Salir");
            this.pbCerrar.Click += new System.EventHandler(this.pbCerrar_Click);
            this.pbCerrar.MouseLeave += new System.EventHandler(this.pbCerrar_MouseLeave);
            this.pbCerrar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbCerrar_MouseMove);
            // 
            // pbGuardar
            // 
            this.pbGuardar.Image = ((System.Drawing.Image)(resources.GetObject("pbGuardar.Image")));
            this.pbGuardar.Location = new System.Drawing.Point(448, 480);
            this.pbGuardar.Name = "pbGuardar";
            this.pbGuardar.Size = new System.Drawing.Size(104, 60);
            this.pbGuardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbGuardar.TabIndex = 14;
            this.pbGuardar.TabStop = false;
            this.toolTip1.SetToolTip(this.pbGuardar, "Guardar Lista Relaciones");
            this.pbGuardar.Click += new System.EventHandler(this.pbGuardar_Click);
            this.pbGuardar.MouseLeave += new System.EventHandler(this.pbGuardar_MouseLeave);
            this.pbGuardar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbGuardar_MouseMove);
            // 
            // dgvRelacion
            // 
            this.dgvRelacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRelacion.Location = new System.Drawing.Point(1012, 72);
            this.dgvRelacion.Name = "dgvRelacion";
            this.dgvRelacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRelacion.Size = new System.Drawing.Size(469, 553);
            this.dgvRelacion.TabIndex = 13;
            // 
            // pbMenos
            // 
            this.pbMenos.Image = global::ActualizarPrecios.Properties.Resources.menos1;
            this.pbMenos.Location = new System.Drawing.Point(466, 316);
            this.pbMenos.Name = "pbMenos";
            this.pbMenos.Size = new System.Drawing.Size(69, 49);
            this.pbMenos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbMenos.TabIndex = 12;
            this.pbMenos.TabStop = false;
            this.pbMenos.Tag = "1";
            this.toolTip1.SetToolTip(this.pbMenos, "Desmarcar en Lista");
            this.pbMenos.Click += new System.EventHandler(this.pbMenos_Click);
            this.pbMenos.MouseLeave += new System.EventHandler(this.pbMenos_MouseLeave);
            this.pbMenos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbMenos_MouseMove);
            // 
            // pbMas
            // 
            this.pbMas.Image = global::ActualizarPrecios.Properties.Resources.mas1;
            this.pbMas.Location = new System.Drawing.Point(466, 98);
            this.pbMas.Name = "pbMas";
            this.pbMas.Size = new System.Drawing.Size(69, 49);
            this.pbMas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbMas.TabIndex = 11;
            this.pbMas.TabStop = false;
            this.toolTip1.SetToolTip(this.pbMas, "Marcar en Lista");
            this.pbMas.Click += new System.EventHandler(this.pbMas_Click);
            this.pbMas.MouseLeave += new System.EventHandler(this.pbMas_MouseLeave);
            this.pbMas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbMas_MouseMove);
            // 
            // Relacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1579, 641);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Relacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relacionar Articulos de Báscula";
            this.Load += new System.EventHandler(this.Relacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulosB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulosMS)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuitarLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArticulosB;
        private System.Windows.Forms.DataGridView dgvArticulosMS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbMas;
        private System.Windows.Forms.PictureBox pbMenos;
        private System.Windows.Forms.DataGridView dgvRelacion;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pbCerrar;
        private System.Windows.Forms.PictureBox pbGuardar;
        private System.Windows.Forms.TextBox txtArticulo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pbQuitarLista;
    }
}
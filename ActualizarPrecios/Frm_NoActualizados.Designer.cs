namespace ActualizarPrecios
{
    partial class Frm_NoActualizados
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gvArticulos = new System.Windows.Forms.DataGridView();
            this.codigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clavemicrosipDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.articuloBasculaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gvArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.articuloBasculaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gvArticulos
            // 
            this.gvArticulos.AllowUserToAddRows = false;
            this.gvArticulos.AllowUserToDeleteRows = false;
            this.gvArticulos.AutoGenerateColumns = false;
            this.gvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvArticulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoDataGridViewTextBoxColumn,
            this.clavemicrosipDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn});
            this.gvArticulos.DataSource = this.articuloBasculaBindingSource;
            this.gvArticulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvArticulos.Location = new System.Drawing.Point(0, 0);
            this.gvArticulos.Name = "gvArticulos";
            this.gvArticulos.ReadOnly = true;
            this.gvArticulos.Size = new System.Drawing.Size(558, 386);
            this.gvArticulos.TabIndex = 0;
            // 
            // codigoDataGridViewTextBoxColumn
            // 
            this.codigoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.codigoDataGridViewTextBoxColumn.DataPropertyName = "codigo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.codigoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.codigoDataGridViewTextBoxColumn.HeaderText = "Codigo";
            this.codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
            this.codigoDataGridViewTextBoxColumn.ReadOnly = true;
            this.codigoDataGridViewTextBoxColumn.Width = 69;
            // 
            // clavemicrosipDataGridViewTextBoxColumn
            // 
            this.clavemicrosipDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clavemicrosipDataGridViewTextBoxColumn.DataPropertyName = "clave_microsip";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.clavemicrosipDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.clavemicrosipDataGridViewTextBoxColumn.HeaderText = "Clave Microsip";
            this.clavemicrosipDataGridViewTextBoxColumn.Name = "clavemicrosipDataGridViewTextBoxColumn";
            this.clavemicrosipDataGridViewTextBoxColumn.ReadOnly = true;
            this.clavemicrosipDataGridViewTextBoxColumn.Width = 106;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "nombre";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nombreDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // articuloBasculaBindingSource
            // 
            this.articuloBasculaBindingSource.DataSource = typeof(ActualizarPrecios.Clases.ArticuloBascula);
            // 
            // Frm_NoActualizados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 386);
            this.Controls.Add(this.gvArticulos);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Frm_NoActualizados";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Articulos No Actualizados";
            this.Load += new System.EventHandler(this.Frm_NoActualizados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.articuloBasculaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvArticulos;
        private System.Windows.Forms.BindingSource articuloBasculaBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clavemicrosipDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;

    }
}
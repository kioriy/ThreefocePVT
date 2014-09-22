namespace PvTerrenos
{
    partial class frmConsulta
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
            this.controlDatos = new System.Windows.Forms.TabControl();
            this.tabVenta = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbLotes = new System.Windows.Forms.ComboBox();
            this.dgvDatosVenta = new System.Windows.Forms.DataGridView();
            this.btnModificar = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.predioDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manzanaDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loteDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mensualidadDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpFechaCompra = new System.Windows.Forms.DateTimePicker();
            this.dtpProximoPago = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.controlDatos.SuspendLayout();
            this.tabVenta.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // controlDatos
            // 
            this.controlDatos.Controls.Add(this.tabVenta);
            this.controlDatos.Controls.Add(this.tabPage3);
            this.controlDatos.Controls.Add(this.tabPage4);
            this.controlDatos.Location = new System.Drawing.Point(12, 33);
            this.controlDatos.Name = "controlDatos";
            this.controlDatos.SelectedIndex = 0;
            this.controlDatos.Size = new System.Drawing.Size(928, 422);
            this.controlDatos.TabIndex = 0;
            // 
            // tabVenta
            // 
            this.tabVenta.Controls.Add(this.groupBox3);
            this.tabVenta.Controls.Add(this.groupBox2);
            this.tabVenta.Controls.Add(this.groupBox1);
            this.tabVenta.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tabVenta.Location = new System.Drawing.Point(4, 22);
            this.tabVenta.Name = "tabVenta";
            this.tabVenta.Padding = new System.Windows.Forms.Padding(3);
            this.tabVenta.Size = new System.Drawing.Size(920, 396);
            this.tabVenta.TabIndex = 0;
            this.tabVenta.Text = "Venta";
            this.tabVenta.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.LightGray;
            this.groupBox3.Location = new System.Drawing.Point(6, 291);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(908, 100);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Traspaso";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox2.Location = new System.Drawing.Point(3, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(911, 106);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Restructuracion";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightGray;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpProximoPago);
            this.groupBox1.Controls.Add(this.dtpFechaCompra);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbLotes);
            this.groupBox1.Controls.Add(this.dgvDatosVenta);
            this.groupBox1.Controls.Add(this.btnModificar);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(908, 167);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos venta";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(795, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "No Lote:";
            this.label3.Visible = false;
            // 
            // cmbLotes
            // 
            this.cmbLotes.FormattingEnabled = true;
            this.cmbLotes.Location = new System.Drawing.Point(849, 19);
            this.cmbLotes.Name = "cmbLotes";
            this.cmbLotes.Size = new System.Drawing.Size(53, 21);
            this.cmbLotes.TabIndex = 15;
            this.cmbLotes.Visible = false;
            this.cmbLotes.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dgvDatosVenta
            // 
            this.dgvDatosVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.predioDGV,
            this.manzanaDGV,
            this.loteDGV,
            this.montoDGV,
            this.mensualidadDGV});
            this.dgvDatosVenta.Location = new System.Drawing.Point(6, 19);
            this.dgvDatosVenta.Name = "dgvDatosVenta";
            this.dgvDatosVenta.Size = new System.Drawing.Size(471, 101);
            this.dgvDatosVenta.TabIndex = 14;
            this.dgvDatosVenta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatosVenta_CellContentClick);
            this.dgvDatosVenta.RowDefaultCellStyleChanged += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvDatosVenta_RowDefaultCellStyleChanged);
            this.dgvDatosVenta.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatosVenta_RowEnter);
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(787, 93);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(115, 27);
            this.btnModificar.TabIndex = 13;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Visible = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(920, 396);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Predios";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(920, 396);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Pagos";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // cmbClientes
            // 
            this.cmbClientes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbClientes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(100, 6);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(355, 21);
            this.cmbClientes.TabIndex = 1;
            this.cmbClientes.SelectedIndexChanged += new System.EventHandler(this.cmbClientes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre cliente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(461, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "ID cliente:";
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Location = new System.Drawing.Point(522, 6);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(77, 20);
            this.txtIdCliente.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(605, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Status:";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(651, 7);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(77, 20);
            this.textBox7.TabIndex = 6;
            // 
            // predioDGV
            // 
            this.predioDGV.HeaderText = "Predio";
            this.predioDGV.Name = "predioDGV";
            this.predioDGV.ReadOnly = true;
            this.predioDGV.Width = 130;
            // 
            // manzanaDGV
            // 
            this.manzanaDGV.HeaderText = "Manzana";
            this.manzanaDGV.Name = "manzanaDGV";
            this.manzanaDGV.ReadOnly = true;
            this.manzanaDGV.Width = 75;
            // 
            // loteDGV
            // 
            this.loteDGV.HeaderText = "No. Lote";
            this.loteDGV.Name = "loteDGV";
            this.loteDGV.ReadOnly = true;
            this.loteDGV.Width = 45;
            // 
            // montoDGV
            // 
            this.montoDGV.HeaderText = "Monto";
            this.montoDGV.Name = "montoDGV";
            // 
            // mensualidadDGV
            // 
            this.mensualidadDGV.HeaderText = "Mensualidad";
            this.mensualidadDGV.Name = "mensualidadDGV";
            this.mensualidadDGV.Width = 75;
            // 
            // dtpFechaCompra
            // 
            this.dtpFechaCompra.Location = new System.Drawing.Point(517, 43);
            this.dtpFechaCompra.Name = "dtpFechaCompra";
            this.dtpFechaCompra.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaCompra.TabIndex = 17;
            this.dtpFechaCompra.Visible = false;
            // 
            // dtpProximoPago
            // 
            this.dtpProximoPago.Location = new System.Drawing.Point(517, 93);
            this.dtpProximoPago.Name = "dtpProximoPago";
            this.dtpProximoPago.Size = new System.Drawing.Size(200, 20);
            this.dtpProximoPago.TabIndex = 18;
            this.dtpProximoPago.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(514, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Fecha Compra:";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(514, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Proximo Pago:";
            this.label5.Visible = false;
            // 
            // frmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 466);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtIdCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbClientes);
            this.Controls.Add(this.controlDatos);
            this.Name = "frmConsulta";
            this.Text = "frmConsulta";
            this.controlDatos.ResumeLayout(false);
            this.tabVenta.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl controlDatos;
        private System.Windows.Forms.TabPage tabVenta;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.DataGridView dgvDatosVenta;
        private System.Windows.Forms.ComboBox cmbLotes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpProximoPago;
        private System.Windows.Forms.DateTimePicker dtpFechaCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn predioDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn manzanaDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn loteDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn mensualidadDGV;
    }
}
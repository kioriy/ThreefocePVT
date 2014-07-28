namespace PvTerrenos
{
    partial class borrar
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
            this.cbComprador = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtPagoFinal = new System.Windows.Forms.TextBox();
            this.txtFechaDeCompra = new System.Windows.Forms.TextBox();
            this.txtPagoActual = new System.Windows.Forms.TextBox();
            this.txtManzana = new System.Windows.Forms.TextBox();
            this.txtPredio = new System.Windows.Forms.TextBox();
            this.txtProximoPago = new System.Windows.Forms.TextBox();
            this.cmdGeneraProximoPago = new System.Windows.Forms.Button();
            this.cbLote = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbComprador
            // 
            this.cbComprador.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbComprador.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbComprador.FormattingEnabled = true;
            this.cbComprador.Location = new System.Drawing.Point(12, 12);
            this.cbComprador.Name = "cbComprador";
            this.cbComprador.Size = new System.Drawing.Size(286, 21);
            this.cbComprador.TabIndex = 0;
            this.cbComprador.SelectedIndexChanged += new System.EventHandler(this.cbComprador_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbLote);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.txtPagoFinal);
            this.groupBox1.Controls.Add(this.txtFechaDeCompra);
            this.groupBox1.Controls.Add(this.txtPagoActual);
            this.groupBox1.Controls.Add(this.txtManzana);
            this.groupBox1.Controls.Add(this.txtPredio);
            this.groupBox1.Location = new System.Drawing.Point(12, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 143);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos para generar proximo pago";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(664, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Pago Final";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(547, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Pago Actual";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(546, 91);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(223, 20);
            this.dtpFecha.TabIndex = 6;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // txtPagoFinal
            // 
            this.txtPagoFinal.Location = new System.Drawing.Point(665, 30);
            this.txtPagoFinal.Name = "txtPagoFinal";
            this.txtPagoFinal.Size = new System.Drawing.Size(100, 20);
            this.txtPagoFinal.TabIndex = 5;
            // 
            // txtFechaDeCompra
            // 
            this.txtFechaDeCompra.Location = new System.Drawing.Point(363, 30);
            this.txtFechaDeCompra.Name = "txtFechaDeCompra";
            this.txtFechaDeCompra.Size = new System.Drawing.Size(164, 20);
            this.txtFechaDeCompra.TabIndex = 3;
            this.txtFechaDeCompra.Text = "fecha de compra";
            // 
            // txtPagoActual
            // 
            this.txtPagoActual.Location = new System.Drawing.Point(546, 30);
            this.txtPagoActual.Name = "txtPagoActual";
            this.txtPagoActual.Size = new System.Drawing.Size(100, 20);
            this.txtPagoActual.TabIndex = 4;
            // 
            // txtManzana
            // 
            this.txtManzana.Location = new System.Drawing.Point(125, 30);
            this.txtManzana.Name = "txtManzana";
            this.txtManzana.Size = new System.Drawing.Size(100, 20);
            this.txtManzana.TabIndex = 1;
            this.txtManzana.Text = "manzana";
            // 
            // txtPredio
            // 
            this.txtPredio.Location = new System.Drawing.Point(6, 30);
            this.txtPredio.Name = "txtPredio";
            this.txtPredio.Size = new System.Drawing.Size(100, 20);
            this.txtPredio.TabIndex = 0;
            this.txtPredio.Text = "predio";
            // 
            // txtProximoPago
            // 
            this.txtProximoPago.Location = new System.Drawing.Point(558, 245);
            this.txtProximoPago.Name = "txtProximoPago";
            this.txtProximoPago.Size = new System.Drawing.Size(223, 20);
            this.txtProximoPago.TabIndex = 7;
            this.txtProximoPago.Text = "Proxima fecha de pago";
            // 
            // cmdGeneraProximoPago
            // 
            this.cmdGeneraProximoPago.Location = new System.Drawing.Point(654, 325);
            this.cmdGeneraProximoPago.Name = "cmdGeneraProximoPago";
            this.cmdGeneraProximoPago.Size = new System.Drawing.Size(123, 49);
            this.cmdGeneraProximoPago.TabIndex = 3;
            this.cmdGeneraProximoPago.Text = "REGISTRAR FECHA PROXIMO PAGO";
            this.cmdGeneraProximoPago.UseVisualStyleBackColor = true;
            this.cmdGeneraProximoPago.Click += new System.EventHandler(this.cmdGeneraProximoPago_Click);
            // 
            // cbLote
            // 
            this.cbLote.FormattingEnabled = true;
            this.cbLote.Location = new System.Drawing.Point(243, 30);
            this.cbLote.Name = "cbLote";
            this.cbLote.Size = new System.Drawing.Size(100, 21);
            this.cbLote.TabIndex = 9;
            this.cbLote.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // borrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 395);
            this.Controls.Add(this.cmdGeneraProximoPago);
            this.Controls.Add(this.txtProximoPago);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbComprador);
            this.Name = "borrar";
            this.Text = "borrar";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbComprador;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPredio;
        private System.Windows.Forms.TextBox txtPagoFinal;
        private System.Windows.Forms.TextBox txtFechaDeCompra;
        private System.Windows.Forms.TextBox txtPagoActual;
        private System.Windows.Forms.TextBox txtManzana;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtProximoPago;
        private System.Windows.Forms.Button cmdGeneraProximoPago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbLote;
    }
}
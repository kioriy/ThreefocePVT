namespace PvTerrenos
{
    partial class ModificaVenta
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.d = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.cmbDatosModificar = new System.Windows.Forms.ComboBox();
            this.cmbLote = new System.Windows.Forms.ComboBox();
            this.txtNuevoDato = new System.Windows.Forms.TextBox();
            this.txtManzana = new System.Windows.Forms.TextBox();
            this.txtDatoActual = new System.Windows.Forms.TextBox();
            this.txtPredio = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnReestructurar = new System.Windows.Forms.Button();
            this.btnTraspasar = new System.Windows.Forms.Button();
            this.panelCancelacion = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.textMotivoCancelacion = new System.Windows.Forms.RichTextBox();
            this.btnConfirmarCancelacion = new System.Windows.Forms.Button();
            this.grpTraspaso = new System.Windows.Forms.GroupBox();
            this.btnTrapasar = new System.Windows.Forms.Button();
            this.cmbNuevoPropietario = new System.Windows.Forms.ComboBox();
            this.txtPropietarioActual = new System.Windows.Forms.TextBox();
            this.btnConfirmarCan = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panelCancelacion.SuspendLayout();
            this.grpTraspaso.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.d);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label);
            this.groupBox1.Controls.Add(this.cmbDatosModificar);
            this.groupBox1.Controls.Add(this.cmbLote);
            this.groupBox1.Controls.Add(this.txtNuevoDato);
            this.groupBox1.Controls.Add(this.txtManzana);
            this.groupBox1.Controls.Add(this.txtDatoActual);
            this.groupBox1.Controls.Add(this.txtPredio);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(34, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(708, 186);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la venta";
            // 
            // d
            // 
            this.d.AutoSize = true;
            this.d.Location = new System.Drawing.Point(565, 98);
            this.d.Name = "d";
            this.d.Size = new System.Drawing.Size(65, 13);
            this.d.TabIndex = 12;
            this.d.Text = "Nuevo Dato";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(94, 34);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(94, 13);
            this.label33.TabIndex = 11;
            this.label33.Text = "Nombre del Predio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(334, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "No. Manzana";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(338, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Dato Actual";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(573, 34);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(48, 13);
            this.label.TabIndex = 8;
            this.label.Text = "No. Lote";
            // 
            // cmbDatosModificar
            // 
            this.cmbDatosModificar.FormattingEnabled = true;
            this.cmbDatosModificar.Items.AddRange(new object[] {
            "Mensualidad",
            "Monto",
            "Fecha de corte"});
            this.cmbDatosModificar.Location = new System.Drawing.Point(80, 114);
            this.cmbDatosModificar.Name = "cmbDatosModificar";
            this.cmbDatosModificar.Size = new System.Drawing.Size(123, 21);
            this.cmbDatosModificar.TabIndex = 7;
            this.cmbDatosModificar.SelectedIndexChanged += new System.EventHandler(this.cmbDatosModificar_SelectedIndexChanged);
            // 
            // cmbLote
            // 
            this.cmbLote.FormattingEnabled = true;
            this.cmbLote.Location = new System.Drawing.Point(576, 50);
            this.cmbLote.Name = "cmbLote";
            this.cmbLote.Size = new System.Drawing.Size(43, 21);
            this.cmbLote.TabIndex = 6;
            this.cmbLote.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txtNuevoDato
            // 
            this.txtNuevoDato.Location = new System.Drawing.Point(562, 114);
            this.txtNuevoDato.Name = "txtNuevoDato";
            this.txtNuevoDato.Size = new System.Drawing.Size(71, 20);
            this.txtNuevoDato.TabIndex = 5;
            this.txtNuevoDato.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtManzana
            // 
            this.txtManzana.Location = new System.Drawing.Point(335, 53);
            this.txtManzana.Name = "txtManzana";
            this.txtManzana.ReadOnly = true;
            this.txtManzana.Size = new System.Drawing.Size(68, 20);
            this.txtManzana.TabIndex = 4;
            this.txtManzana.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtManzana.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // txtDatoActual
            // 
            this.txtDatoActual.Location = new System.Drawing.Point(324, 114);
            this.txtDatoActual.Name = "txtDatoActual";
            this.txtDatoActual.ReadOnly = true;
            this.txtDatoActual.Size = new System.Drawing.Size(90, 20);
            this.txtDatoActual.TabIndex = 2;
            this.txtDatoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDatoActual.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txtPredio
            // 
            this.txtPredio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPredio.Location = new System.Drawing.Point(27, 51);
            this.txtPredio.Name = "txtPredio";
            this.txtPredio.ReadOnly = true;
            this.txtPredio.Size = new System.Drawing.Size(228, 20);
            this.txtPredio.TabIndex = 1;
            this.txtPredio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(590, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "Modificar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(576, 237);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(91, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnReestructurar
            // 
            this.btnReestructurar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReestructurar.Location = new System.Drawing.Point(61, 237);
            this.btnReestructurar.Name = "btnReestructurar";
            this.btnReestructurar.Size = new System.Drawing.Size(91, 23);
            this.btnReestructurar.TabIndex = 2;
            this.btnReestructurar.Text = "Reestructurar";
            this.btnReestructurar.UseVisualStyleBackColor = true;
            // 
            // btnTraspasar
            // 
            this.btnTraspasar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraspasar.Location = new System.Drawing.Point(321, 237);
            this.btnTraspasar.Name = "btnTraspasar";
            this.btnTraspasar.Size = new System.Drawing.Size(91, 23);
            this.btnTraspasar.TabIndex = 3;
            this.btnTraspasar.Text = "Traspasar";
            this.btnTraspasar.UseVisualStyleBackColor = true;
            this.btnTraspasar.Click += new System.EventHandler(this.btnTraspasar_Click);
            // 
            // panelCancelacion
            // 
            this.panelCancelacion.Controls.Add(this.btnConfirmarCan);
            this.panelCancelacion.Controls.Add(this.label3);
            this.panelCancelacion.Controls.Add(this.textMotivoCancelacion);
            this.panelCancelacion.Controls.Add(this.btnConfirmarCancelacion);
            this.panelCancelacion.Location = new System.Drawing.Point(0, 0);
            this.panelCancelacion.Name = "panelCancelacion";
            this.panelCancelacion.Size = new System.Drawing.Size(708, 199);
            this.panelCancelacion.TabIndex = 4;
            this.panelCancelacion.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Motivos de la cancelacion:";
            // 
            // textMotivoCancelacion
            // 
            this.textMotivoCancelacion.Location = new System.Drawing.Point(16, 42);
            this.textMotivoCancelacion.Name = "textMotivoCancelacion";
            this.textMotivoCancelacion.Size = new System.Drawing.Size(674, 107);
            this.textMotivoCancelacion.TabIndex = 1;
            this.textMotivoCancelacion.Text = "";
            this.textMotivoCancelacion.TextChanged += new System.EventHandler(this.textMotivoCancelacion_TextChanged);
            // 
            // btnConfirmarCancelacion
            // 
            this.btnConfirmarCancelacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmarCancelacion.Location = new System.Drawing.Point(96, 210);
            this.btnConfirmarCancelacion.Name = "btnConfirmarCancelacion";
            this.btnConfirmarCancelacion.Size = new System.Drawing.Size(143, 23);
            this.btnConfirmarCancelacion.TabIndex = 0;
            this.btnConfirmarCancelacion.Text = "Confirmar Cancelación";
            this.btnConfirmarCancelacion.UseVisualStyleBackColor = true;
            // 
            // grpTraspaso
            // 
            this.grpTraspaso.Controls.Add(this.panelCancelacion);
            this.grpTraspaso.Controls.Add(this.btnTrapasar);
            this.grpTraspaso.Controls.Add(this.cmbNuevoPropietario);
            this.grpTraspaso.Controls.Add(this.txtPropietarioActual);
            this.grpTraspaso.Location = new System.Drawing.Point(34, 281);
            this.grpTraspaso.Name = "grpTraspaso";
            this.grpTraspaso.Size = new System.Drawing.Size(690, 199);
            this.grpTraspaso.TabIndex = 4;
            this.grpTraspaso.TabStop = false;
            this.grpTraspaso.Text = "Traspaso";
            this.grpTraspaso.Visible = false;
            this.grpTraspaso.Enter += new System.EventHandler(this.grpTraspaso_Enter);
            // 
            // btnTrapasar
            // 
            this.btnTrapasar.Location = new System.Drawing.Point(599, 155);
            this.btnTrapasar.Name = "btnTrapasar";
            this.btnTrapasar.Size = new System.Drawing.Size(75, 23);
            this.btnTrapasar.TabIndex = 2;
            this.btnTrapasar.Text = "Traspasar";
            this.btnTrapasar.UseVisualStyleBackColor = true;
            // 
            // cmbNuevoPropietario
            // 
            this.cmbNuevoPropietario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbNuevoPropietario.FormattingEnabled = true;
            this.cmbNuevoPropietario.Location = new System.Drawing.Point(22, 105);
            this.cmbNuevoPropietario.Name = "cmbNuevoPropietario";
            this.cmbNuevoPropietario.Size = new System.Drawing.Size(583, 21);
            this.cmbNuevoPropietario.TabIndex = 1;
            // 
            // txtPropietarioActual
            // 
            this.txtPropietarioActual.Enabled = false;
            this.txtPropietarioActual.Location = new System.Drawing.Point(21, 42);
            this.txtPropietarioActual.Name = "txtPropietarioActual";
            this.txtPropietarioActual.Size = new System.Drawing.Size(584, 20);
            this.txtPropietarioActual.TabIndex = 0;
            // 
            // btnConfirmarCan
            // 
            this.btnConfirmarCan.Location = new System.Drawing.Point(548, 161);
            this.btnConfirmarCan.Name = "btnConfirmarCan";
            this.btnConfirmarCan.Size = new System.Drawing.Size(142, 35);
            this.btnConfirmarCan.TabIndex = 3;
            this.btnConfirmarCan.Text = "Confirmar Cancelacion";
            this.btnConfirmarCan.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Selecciona el dato";
            // 
            // ModificaVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 483);
            this.Controls.Add(this.grpTraspaso);
            this.Controls.Add(this.btnTraspasar);
            this.Controls.Add(this.btnReestructurar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox1);
            this.Name = "ModificaVenta";
            this.Text = "Modificar Venta";
            this.Load += new System.EventHandler(this.frmModificaVenta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelCancelacion.ResumeLayout(false);
            this.panelCancelacion.PerformLayout();
            this.grpTraspaso.ResumeLayout(false);
            this.grpTraspaso.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtManzana;
        private System.Windows.Forms.TextBox txtDatoActual;
        private System.Windows.Forms.TextBox txtPredio;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbDatosModificar;
        private System.Windows.Forms.ComboBox cmbLote;
        private System.Windows.Forms.TextBox txtNuevoDato;
        private System.Windows.Forms.Label d;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnReestructurar;
        private System.Windows.Forms.Button btnTraspasar;
        private System.Windows.Forms.Panel panelCancelacion;
        private System.Windows.Forms.Button btnConfirmarCancelacion;
        private System.Windows.Forms.RichTextBox textMotivoCancelacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpTraspaso;
        private System.Windows.Forms.TextBox txtPropietarioActual;
        private System.Windows.Forms.ComboBox cmbNuevoPropietario;
        private System.Windows.Forms.Button btnTrapasar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnConfirmarCan;
    }
}
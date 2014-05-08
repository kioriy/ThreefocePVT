namespace PvTerrenos
{
    partial class frmModificaVenta
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtPredio = new System.Windows.Forms.TextBox();
            this.txtDatoActual = new System.Windows.Forms.TextBox();
            this.txtManzana = new System.Windows.Forms.TextBox();
            this.txtNuevoDato = new System.Windows.Forms.TextBox();
            this.cmbLote = new System.Windows.Forms.ComboBox();
            this.cmbDatosModificar = new System.Windows.Forms.ComboBox();
            this.label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.d = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnReestructurar = new System.Windows.Forms.Button();
            this.btnTraspasar = new System.Windows.Forms.Button();
            this.panelCancelacion = new System.Windows.Forms.Panel();
            this.btnConfirmarCancelacion = new System.Windows.Forms.Button();
            this.textMotivoCancelacion = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panelCancelacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
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
            this.groupBox1.Location = new System.Drawing.Point(12, 285);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 186);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la venta";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(273, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Modificar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtPredio
            // 
            this.txtPredio.Location = new System.Drawing.Point(21, 51);
            this.txtPredio.Name = "txtPredio";
            this.txtPredio.Size = new System.Drawing.Size(100, 20);
            this.txtPredio.TabIndex = 1;
            // 
            // txtDatoActual
            // 
            this.txtDatoActual.Location = new System.Drawing.Point(149, 114);
            this.txtDatoActual.Name = "txtDatoActual";
            this.txtDatoActual.Size = new System.Drawing.Size(81, 20);
            this.txtDatoActual.TabIndex = 2;
            this.txtDatoActual.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txtManzana
            // 
            this.txtManzana.Location = new System.Drawing.Point(163, 52);
            this.txtManzana.Name = "txtManzana";
            this.txtManzana.Size = new System.Drawing.Size(53, 20);
            this.txtManzana.TabIndex = 4;
            this.txtManzana.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // txtNuevoDato
            // 
            this.txtNuevoDato.Location = new System.Drawing.Point(287, 114);
            this.txtNuevoDato.Name = "txtNuevoDato";
            this.txtNuevoDato.Size = new System.Drawing.Size(62, 20);
            this.txtNuevoDato.TabIndex = 5;
            // 
            // cmbLote
            // 
            this.cmbLote.FormattingEnabled = true;
            this.cmbLote.Location = new System.Drawing.Point(297, 51);
            this.cmbLote.Name = "cmbLote";
            this.cmbLote.Size = new System.Drawing.Size(43, 21);
            this.cmbLote.TabIndex = 6;
            this.cmbLote.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cmbDatosModificar
            // 
            this.cmbDatosModificar.FormattingEnabled = true;
            this.cmbDatosModificar.Location = new System.Drawing.Point(22, 113);
            this.cmbDatosModificar.Name = "cmbDatosModificar";
            this.cmbDatosModificar.Size = new System.Drawing.Size(99, 21);
            this.cmbDatosModificar.TabIndex = 7;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(294, 34);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(48, 13);
            this.label.TabIndex = 8;
            this.label.Text = "No. Lote";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Dato Actual";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "No. Manzana";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(24, 34);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(94, 13);
            this.label33.TabIndex = 11;
            this.label33.Text = "Nombre del Predio";
            // 
            // d
            // 
            this.d.AutoSize = true;
            this.d.Location = new System.Drawing.Point(284, 98);
            this.d.Name = "d";
            this.d.Size = new System.Drawing.Size(65, 13);
            this.d.TabIndex = 12;
            this.d.Text = "Nuevo Dato";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(24, 32);
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
            this.btnReestructurar.Location = new System.Drawing.Point(24, 187);
            this.btnReestructurar.Name = "btnReestructurar";
            this.btnReestructurar.Size = new System.Drawing.Size(91, 23);
            this.btnReestructurar.TabIndex = 2;
            this.btnReestructurar.Text = "Reestructurar";
            this.btnReestructurar.UseVisualStyleBackColor = true;
            // 
            // btnTraspasar
            // 
            this.btnTraspasar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraspasar.Location = new System.Drawing.Point(24, 112);
            this.btnTraspasar.Name = "btnTraspasar";
            this.btnTraspasar.Size = new System.Drawing.Size(91, 23);
            this.btnTraspasar.TabIndex = 3;
            this.btnTraspasar.Text = "Traspasar";
            this.btnTraspasar.UseVisualStyleBackColor = true;
            // 
            // panelCancelacion
            // 
            this.panelCancelacion.Controls.Add(this.label3);
            this.panelCancelacion.Controls.Add(this.textMotivoCancelacion);
            this.panelCancelacion.Controls.Add(this.btnConfirmarCancelacion);
            this.panelCancelacion.Location = new System.Drawing.Point(144, 24);
            this.panelCancelacion.Name = "panelCancelacion";
            this.panelCancelacion.Size = new System.Drawing.Size(242, 245);
            this.panelCancelacion.TabIndex = 4;
            this.panelCancelacion.Visible = false;
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
            // textMotivoCancelacion
            // 
            this.textMotivoCancelacion.Location = new System.Drawing.Point(3, 36);
            this.textMotivoCancelacion.Name = "textMotivoCancelacion";
            this.textMotivoCancelacion.Size = new System.Drawing.Size(236, 168);
            this.textMotivoCancelacion.TabIndex = 1;
            this.textMotivoCancelacion.Text = "";
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
            // frmModificaVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 483);
            this.Controls.Add(this.panelCancelacion);
            this.Controls.Add(this.btnTraspasar);
            this.Controls.Add(this.btnReestructurar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmModificaVenta";
            this.Text = "Modificar Venta";
            this.Load += new System.EventHandler(this.frmModificaVenta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelCancelacion.ResumeLayout(false);
            this.panelCancelacion.PerformLayout();
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
    }
}
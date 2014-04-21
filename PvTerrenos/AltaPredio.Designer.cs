namespace PvTerrenos
{
    partial class FrmAltaPredio
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
            this.gbMazanaLote = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdGeneraManzanas = new System.Windows.Forms.Button();
            this.cmdGenerarLotes = new System.Windows.Forms.Button();
            this.lNumeroLotes = new System.Windows.Forms.Label();
            this.gbRegistrarLotes = new System.Windows.Forms.GroupBox();
            this.txtNumeroLote = new System.Windows.Forms.TextBox();
            this.cbNumeroManzana = new System.Windows.Forms.ComboBox();
            this.lLotes = new System.Windows.Forms.Label();
            this.lManzana = new System.Windows.Forms.Label();
            this.txtNumManzanaLote = new System.Windows.Forms.TextBox();
            this.lNumeroManzana = new System.Windows.Forms.Label();
            this.cbSeleccionaManzanaLote = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdGenerarPredio = new System.Windows.Forms.Button();
            this.txtIdPredio = new System.Windows.Forms.TextBox();
            this.txtNombrePredio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnModificaLote = new System.Windows.Forms.Button();
            this.gbMazanaLote.SuspendLayout();
            this.gbRegistrarLotes.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbMazanaLote
            // 
            this.gbMazanaLote.Controls.Add(this.btnModificaLote);
            this.gbMazanaLote.Controls.Add(this.btnModificar);
            this.gbMazanaLote.Controls.Add(this.label2);
            this.gbMazanaLote.Controls.Add(this.cmdGeneraManzanas);
            this.gbMazanaLote.Controls.Add(this.cmdGenerarLotes);
            this.gbMazanaLote.Controls.Add(this.lNumeroLotes);
            this.gbMazanaLote.Controls.Add(this.gbRegistrarLotes);
            this.gbMazanaLote.Controls.Add(this.txtNumManzanaLote);
            this.gbMazanaLote.Controls.Add(this.lNumeroManzana);
            this.gbMazanaLote.Controls.Add(this.cbSeleccionaManzanaLote);
            this.gbMazanaLote.Controls.Add(this.label6);
            this.gbMazanaLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMazanaLote.Location = new System.Drawing.Point(12, 122);
            this.gbMazanaLote.Name = "gbMazanaLote";
            this.gbMazanaLote.Size = new System.Drawing.Size(529, 87);
            this.gbMazanaLote.TabIndex = 17;
            this.gbMazanaLote.TabStop = false;
            this.gbMazanaLote.Text = "Datos Mazana/Lote";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Modificar:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cmdGeneraManzanas
            // 
            this.cmdGeneraManzanas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGeneraManzanas.Location = new System.Drawing.Point(375, 61);
            this.cmdGeneraManzanas.Name = "cmdGeneraManzanas";
            this.cmdGeneraManzanas.Size = new System.Drawing.Size(148, 23);
            this.cmdGeneraManzanas.TabIndex = 4;
            this.cmdGeneraManzanas.Text = "Generar Manzanas";
            this.cmdGeneraManzanas.UseVisualStyleBackColor = true;
            this.cmdGeneraManzanas.Visible = false;
            this.cmdGeneraManzanas.Click += new System.EventHandler(this.cmdGeneraManzanas_Click);
            // 
            // cmdGenerarLotes
            // 
            this.cmdGenerarLotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGenerarLotes.Location = new System.Drawing.Point(375, 60);
            this.cmdGenerarLotes.Name = "cmdGenerarLotes";
            this.cmdGenerarLotes.Size = new System.Drawing.Size(148, 23);
            this.cmdGenerarLotes.TabIndex = 5;
            this.cmdGenerarLotes.Text = "Generar Lotes";
            this.cmdGenerarLotes.UseVisualStyleBackColor = true;
            this.cmdGenerarLotes.Visible = false;
            this.cmdGenerarLotes.Click += new System.EventHandler(this.cmdGenerarLotes_Click);
            // 
            // lNumeroLotes
            // 
            this.lNumeroLotes.AutoSize = true;
            this.lNumeroLotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNumeroLotes.Location = new System.Drawing.Point(202, 32);
            this.lNumeroLotes.Name = "lNumeroLotes";
            this.lNumeroLotes.Size = new System.Drawing.Size(46, 13);
            this.lNumeroLotes.TabIndex = 4;
            this.lNumeroLotes.Text = "# Lotes:";
            this.lNumeroLotes.Visible = false;
            // 
            // gbRegistrarLotes
            // 
            this.gbRegistrarLotes.CausesValidation = false;
            this.gbRegistrarLotes.Controls.Add(this.txtNumeroLote);
            this.gbRegistrarLotes.Controls.Add(this.cbNumeroManzana);
            this.gbRegistrarLotes.Controls.Add(this.lLotes);
            this.gbRegistrarLotes.Controls.Add(this.lManzana);
            this.gbRegistrarLotes.Location = new System.Drawing.Point(297, 0);
            this.gbRegistrarLotes.Name = "gbRegistrarLotes";
            this.gbRegistrarLotes.Size = new System.Drawing.Size(232, 54);
            this.gbRegistrarLotes.TabIndex = 20;
            this.gbRegistrarLotes.TabStop = false;
            this.gbRegistrarLotes.Text = "Registrar Lotes";
            this.gbRegistrarLotes.Visible = false;
            // 
            // txtNumeroLote
            // 
            this.txtNumeroLote.Location = new System.Drawing.Point(176, 30);
            this.txtNumeroLote.Name = "txtNumeroLote";
            this.txtNumeroLote.Size = new System.Drawing.Size(44, 18);
            this.txtNumeroLote.TabIndex = 3;
            // 
            // cbNumeroManzana
            // 
            this.cbNumeroManzana.FormattingEnabled = true;
            this.cbNumeroManzana.Location = new System.Drawing.Point(72, 30);
            this.cbNumeroManzana.Name = "cbNumeroManzana";
            this.cbNumeroManzana.Size = new System.Drawing.Size(44, 20);
            this.cbNumeroManzana.TabIndex = 2;
            // 
            // lLotes
            // 
            this.lLotes.AutoSize = true;
            this.lLotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lLotes.Location = new System.Drawing.Point(134, 32);
            this.lLotes.Name = "lLotes";
            this.lLotes.Size = new System.Drawing.Size(36, 13);
            this.lLotes.TabIndex = 1;
            this.lLotes.Text = "Lotes:";
            // 
            // lManzana
            // 
            this.lManzana.AutoSize = true;
            this.lManzana.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lManzana.Location = new System.Drawing.Point(12, 32);
            this.lManzana.Name = "lManzana";
            this.lManzana.Size = new System.Drawing.Size(54, 13);
            this.lManzana.TabIndex = 0;
            this.lManzana.Text = "Manzana:";
            // 
            // txtNumManzanaLote
            // 
            this.txtNumManzanaLote.CausesValidation = false;
            this.txtNumManzanaLote.Location = new System.Drawing.Point(254, 30);
            this.txtNumManzanaLote.Name = "txtNumManzanaLote";
            this.txtNumManzanaLote.Size = new System.Drawing.Size(37, 18);
            this.txtNumManzanaLote.TabIndex = 19;
            this.txtNumManzanaLote.Visible = false;
            // 
            // lNumeroManzana
            // 
            this.lNumeroManzana.AutoSize = true;
            this.lNumeroManzana.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNumeroManzana.Location = new System.Drawing.Point(179, 32);
            this.lNumeroManzana.Name = "lNumeroManzana";
            this.lNumeroManzana.Size = new System.Drawing.Size(69, 13);
            this.lNumeroManzana.TabIndex = 18;
            this.lNumeroManzana.Text = "# Manzanas:";
            this.lNumeroManzana.Visible = false;
            // 
            // cbSeleccionaManzanaLote
            // 
            this.cbSeleccionaManzanaLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSeleccionaManzanaLote.FormattingEnabled = true;
            this.cbSeleccionaManzanaLote.Location = new System.Drawing.Point(64, 29);
            this.cbSeleccionaManzanaLote.Name = "cbSeleccionaManzanaLote";
            this.cbSeleccionaManzanaLote.Size = new System.Drawing.Size(100, 21);
            this.cbSeleccionaManzanaLote.TabIndex = 17;
            this.cbSeleccionaManzanaLote.SelectedIndexChanged += new System.EventHandler(this.cbSeleccionaManzanaLote_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Registrar:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdGenerarPredio);
            this.groupBox1.Controls.Add(this.txtIdPredio);
            this.groupBox1.Controls.Add(this.txtNombrePredio);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(529, 92);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Predio";
            // 
            // cmdGenerarPredio
            // 
            this.cmdGenerarPredio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGenerarPredio.Location = new System.Drawing.Point(418, 51);
            this.cmdGenerarPredio.Name = "cmdGenerarPredio";
            this.cmdGenerarPredio.Size = new System.Drawing.Size(105, 35);
            this.cmdGenerarPredio.TabIndex = 16;
            this.cmdGenerarPredio.Text = "Generar Predio";
            this.cmdGenerarPredio.UseVisualStyleBackColor = true;
            this.cmdGenerarPredio.Click += new System.EventHandler(this.cmdGenerarPredio_Click);
            // 
            // txtIdPredio
            // 
            this.txtIdPredio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdPredio.Location = new System.Drawing.Point(319, 21);
            this.txtIdPredio.Name = "txtIdPredio";
            this.txtIdPredio.Size = new System.Drawing.Size(204, 20);
            this.txtIdPredio.TabIndex = 14;
            // 
            // txtNombrePredio
            // 
            this.txtNombrePredio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtNombrePredio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombrePredio.Location = new System.Drawing.Point(69, 23);
            this.txtNombrePredio.Name = "txtNombrePredio";
            this.txtNombrePredio.Size = new System.Drawing.Size(179, 20);
            this.txtNombrePredio.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(264, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "ID predio:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 215);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(529, 219);
            this.dataGridView1.TabIndex = 15;
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(369, 61);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(158, 23);
            this.btnModificar.TabIndex = 22;
            this.btnModificar.Text = "Modificar Manzanas";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Visible = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnModificaLote
            // 
            this.btnModificaLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificaLote.Location = new System.Drawing.Point(396, 61);
            this.btnModificaLote.Name = "btnModificaLote";
            this.btnModificaLote.Size = new System.Drawing.Size(109, 23);
            this.btnModificaLote.TabIndex = 23;
            this.btnModificaLote.Text = "Modificar Lotes";
            this.btnModificaLote.UseVisualStyleBackColor = true;
            this.btnModificaLote.Visible = false;
            this.btnModificaLote.Click += new System.EventHandler(this.btnModificaLote_Click);
            // 
            // FrmAltaPredio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 444);
            this.Controls.Add(this.gbMazanaLote);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmAltaPredio";
            this.Text = "Alta - Predio";
            this.gbMazanaLote.ResumeLayout(false);
            this.gbMazanaLote.PerformLayout();
            this.gbRegistrarLotes.ResumeLayout(false);
            this.gbRegistrarLotes.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMazanaLote;
        private System.Windows.Forms.ComboBox cbSeleccionaManzanaLote;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtIdPredio;
        private System.Windows.Forms.TextBox txtNombrePredio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button cmdGenerarPredio;
        private System.Windows.Forms.GroupBox gbRegistrarLotes;
        private System.Windows.Forms.TextBox txtNumeroLote;
        private System.Windows.Forms.ComboBox cbNumeroManzana;
        private System.Windows.Forms.Label lLotes;
        private System.Windows.Forms.Label lManzana;
        private System.Windows.Forms.TextBox txtNumManzanaLote;
        private System.Windows.Forms.Label lNumeroManzana;
        private System.Windows.Forms.Label lNumeroLotes;
        private System.Windows.Forms.Button cmdGenerarLotes;
        private System.Windows.Forms.Button cmdGeneraManzanas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnModificaLote;
    }
}
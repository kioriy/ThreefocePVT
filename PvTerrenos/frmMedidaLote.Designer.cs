namespace PvTerrenos
{
    partial class frmMedidaLote
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
            this.cmbMedida1 = new System.Windows.Forms.ComboBox();
            this.cmbMedida2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMedidas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbMedida1
            // 
            this.cmbMedida1.FormattingEnabled = true;
            this.cmbMedida1.Location = new System.Drawing.Point(73, 38);
            this.cmbMedida1.Name = "cmbMedida1";
            this.cmbMedida1.Size = new System.Drawing.Size(67, 21);
            this.cmbMedida1.TabIndex = 0;
            this.cmbMedida1.SelectedIndexChanged += new System.EventHandler(this.cmbMedida1_SelectedIndexChanged);
            // 
            // cmbMedida2
            // 
            this.cmbMedida2.FormattingEnabled = true;
            this.cmbMedida2.Location = new System.Drawing.Point(183, 38);
            this.cmbMedida2.Name = "cmbMedida2";
            this.cmbMedida2.Size = new System.Drawing.Size(65, 21);
            this.cmbMedida2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Medidas:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "por";
            // 
            // btnMedidas
            // 
            this.btnMedidas.Location = new System.Drawing.Point(183, 93);
            this.btnMedidas.Name = "btnMedidas";
            this.btnMedidas.Size = new System.Drawing.Size(75, 23);
            this.btnMedidas.TabIndex = 4;
            this.btnMedidas.Text = "Aceptar";
            this.btnMedidas.UseVisualStyleBackColor = true;
            // 
            // frmMedidaLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 128);
            this.Controls.Add(this.btnMedidas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbMedida2);
            this.Controls.Add(this.cmbMedida1);
            this.Name = "frmMedidaLote";
            this.Text = "Medidas Lote";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbMedida1;
        private System.Windows.Forms.ComboBox cmbMedida2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMedidas;
    }
}
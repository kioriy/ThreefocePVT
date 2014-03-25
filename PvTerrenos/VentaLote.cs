using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PvTerrenos
{
    public partial class FrmVentaLote : Form
    {
        public FrmVentaLote()
        {
            InitializeComponent();
            cbFormaPago.Items.Add("Abonos");
            cbFormaPago.Items.Add("Contado");
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAltaCliente abrirCliente = new FrmAltaCliente();
            abrirCliente.Show();
        }

        private void predioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmAltaPredio abrirPredio = new FrmAltaPredio();
            abrirPredio.Show();
        }

        private void predioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPago abrirPago = new FrmPago();
            abrirPago.Show();
        }

        private void txtId_Enter(object sender, EventArgs e)
        {
            WSpvt.PVT ws = new WSpvt.PVT();

            string idCliente = txtId.Text;
            DataSet ds = new DataSet();
            
            string cargaPredio = ws.updatePredio();
            
        }

        

        

       
       

       

        

        
       

        

       
    }
}

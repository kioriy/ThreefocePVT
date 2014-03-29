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
            cbPredio.Items.Add("Prueba");
            cbManzana.Items.Add("1");
            cbLotes.Items.Add("1");
       
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

        private void txtId_ChangeUICues(object sender, UICuesEventArgs e)
        {
            WSpvt.PVT ws = new WSpvt.PVT();
            string id = txtId.Text;
            string respuestaGetUsuario = ws.getComprador(id);

            txtNombre.Text = respuestaGetUsuario;
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            WSpvt.PVT ws = new WSpvt.PVT();

            string id_comprador = txtId.Text;
            string lote = cbLotes.SelectedItem.ToString();
            string tipo_pago = cbFormaPago.SelectedItem.ToString();
            string monto = txtCostoTerreno.Text;
            string plazo = txtPlazo.Text;
            string fechaCompra = dtpFecha.Value.ToString();
            string fechaCorte = txtFechaCorte.Text;

            MessageBox.Show(id_comprador + " " + lote + " " + tipo_pago + " " + monto + " " + plazo + " " + fechaCompra + " " + fechaCorte);

            string respuestaAltaVenta = ws.registraVenta(id_comprador, lote, tipo_pago, monto, plazo, fechaCompra, fechaCorte);

            MessageBox.Show(respuestaAltaVenta);
        }
    }
}

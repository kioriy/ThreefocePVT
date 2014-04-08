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
        DateTime? proximoPago = DateTime.Today;

        public FrmVentaLote()
        {
            InitializeComponent();
            cbFormaPago.Items.Add("Abonos");
            cbFormaPago.Items.Add("Contado");
            cbPredio.Items.Add("SANTA ANITA");
            cbManzana.Items.Add("1");
            cbLotes.Items.Add("5");
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

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                WSpvt.PVT ws = new WSpvt.PVT();
                string id = txtId.Text;
                string respuestaGetUsuario = ws.getComprador(id);
                txtNombre.Text = respuestaGetUsuario;
            }
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            WSpvt.PVT ws = new WSpvt.PVT();
        
            string id_comprador = txtId.Text;
            string idLote = ws.getIdLote(ws.getIdManzana(cbManzana.SelectedItem.ToString(),ws.getIdPredio(cbPredio.SelectedItem.ToString())), cbLotes.SelectedItem.ToString());
            string tipo_pago = cbFormaPago.SelectedItem.ToString();
            string monto = txtCostoTerreno.Text;
            string abono = txtAbono.Text;
            string mensualidad = txtMensualidad.Text;
            string fechaCompra = dtpFecha.Value.ToString();
            string fechaCorte = dtpFecha.Value.Day.ToString();
            //MessageBox.Show(fechaCorte);
            string respuestaAltaVenta = ws.registraVenta(id_comprador, idLote, tipo_pago, monto, mensualidad, fechaCompra, fechaCorte);
            MessageBox.Show(respuestaAltaVenta);

            string respuestaStatus = ws.updateStatusLote(idLote);

            string idVenta = ws.getIdVentaPkLote(idLote);

            int pagoActualMasUno = Convert.ToInt32(txtPagoActual.Text) + 1;
           
            //MessageBox.Show(Convert.ToString(pagoActualMasUno));
            //MessageBox.Show(idVenta+" "+proximoPago.Value.ToString()+" "+txtPagoActual.Text+" "+txtPagoFinal.Text);
            
            string registraProximoPago = ws.registraProximoPago(idVenta,proximoPago.Value.ToString(),Convert.ToString(pagoActualMasUno),txtPagoFinal.Text);
            //MessageBox.Show(registraProximoPago);
            string registraAbono = ws.registraAbono(id_comprador, abono);
            //MessageBox.Show(registraAbono);

        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (txtPagoActual.Text != "" && txtPagoFinal.Text !="") {

                Fecha obtenerProximoPago = new Fecha();

                proximoPago =  obtenerProximoPago.setProximoPago(dtpFecha.Value, txtPagoActual.Text);

                //MessageBox.Show(resultado.ToString());

            }else{
                MessageBox.Show("es necesario ingresar pagos:   /    ");
            }
        }
    }
}

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
        WSpvt.PVT ws = new WSpvt.PVT();
        string idPredio;
        string idLote;
        string respuestaCargaManzana;
        string[] splitIdManzana;
        string[] splitId;
        
        public FrmVentaLote()
        {
            InitializeComponent();
            cbFormaPago.Items.Add("Abonos");
            cbFormaPago.Items.Add("Contado");

            llenarComboPredio();
            llenaComboComprador();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVentaLote ventaLote = new FrmVentaLote();
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
                string id = txtId.Text;
                string respuestaGetUsuario = ws.getComprador(id);
                cbNombre.Text = respuestaGetUsuario;
            }
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            ///llamamos a la funcion que nos valida que el formulario no tenga campos nulos

            //mostramos una ventana que le pregunte al usuario si en verdad quiere reistrar la venta
            string mensaje = "¿Estas seguro de que quieres registrar esta venta?";
            string caption = "Registro de venta";
            MessageBoxButtons botones = MessageBoxButtons.OKCancel;
            DialogResult resultado;

            if (validar())   
            {   
                resultado = MessageBox.Show(mensaje, caption, botones);

                
                    string idComprador = splitId[cbNombre.SelectedIndex];
                    string tipo_pago = cbFormaPago.SelectedItem.ToString();
                    string monto = txtCostoTerreno.Text;
                    string abono = txtAbono.Text;
                    string mensualidad = txtMensualidad.Text;
                    string fechaCompra = dtpFecha.Value.ToString();
                    string diaCorte = dtpFecha.Value.Day.ToString();
                    
                if (resultado == System.Windows.Forms.DialogResult.OK && cbFormaPago.Text == "Abonos")
                {
                    ///////////  REGISTRO VENTA /////////////////////////////
                    string respuestaAltaVenta = ws.registraVenta(idComprador, // id comprador
                                                                 idLote,      // id lote
                                                                 tipo_pago,   // forma de pago
                                                                 monto,       // costo del terreno
                                                                 mensualidad, // mesualidad 
                                                                 fechaCompra, // fecha de compra
                                                                 diaCorte,    // dia de corte
                                                                 "ACTIVO");   // status de la venta

                    MessageBox.Show(respuestaAltaVenta+"\n\n Su dias de corte son "+diaCorte+" de cada mes");
                    ////////////////////////////////////////////////////////

                    ws.updateStatusLote(idLote); //cambio del status de lote de 0 a 1

                    string idVenta = ws.getIdVentaPkLote(idLote); // obtengo el id de venta para el registro de proximo pago

                    int pagoActualMasUno = Convert.ToInt32(txtPagoActual.Text) + 1; // se genera el numero del siguiente pago

                    ///////////////// registro del proximo pago  //////////////
                    string respuestaProximoPago = ws.registraProximoPago(idVenta,     // id de venta
                                                                         mensualidad,             // costo de la mensualidad
                                                                         proximoPago.Value.ToString(),   // fecha proximo pago
                                                                         Convert.ToString(pagoActualMasUno), // pago actual 
                                                                         txtPagoFinal.Text);                 //ultimo pago
                    
                    MessageBox.Show(respuestaProximoPago+"\n\nsu proxima fecha de pago es "+proximoPago.Value.ToString());
                    ///////////////////////////////////////////////////////////
                
                    string registraAbono = ws.registraAbono(idComprador, abono);

                    cargaVentaDvg(cbNombre.SelectedItem.ToString(), 
                                  idComprador, 
                                  monto, 
                                  mensualidad, 
                                  cbPredio.Text, 
                                  cbManzana.Text, 
                                  cbLotes.Text);
                    limpiar();
            }
                else if (resultado == System.Windows.Forms.DialogResult.OK && cbFormaPago.Text == "Contado") 
                {
                    
                    ///////////////   REGISTRO DEL PAGO DE CONTADO  ////////////
                    string respuestaRegistraVenta = ws.registraVenta(idComprador, // id comprador
                                                                     idLote,      // id lote
                                                                     tipo_pago,   // forma de pago
                                                                     monto,       // costo del terreno
                                                                     "NG",        // mensualidad
                                                                     fechaCompra, // fecha de la compra
                                                                     "NG",        // dia de corte
                                                                     "PAGADO");   // status de la venta
                    MessageBox.Show(respuestaRegistraVenta);
                    ///////////////////////////////////////////////////////////

                    ws.updateStatusLote(idLote); //cambio del status de lote de 0 a 1 
                    
                    string idVenta = ws.getIdVentaPkLote(idLote); //obtengo el id de la venta para el registro de pago
                    
                    ws.registraPago(idVenta,monto,DateTime.Today.ToString(),"",cbFormaPago.Text,""); //registro el pago unico -
                                                                                                     //de la compra 
                    cargaVentaDvg(cbNombre.SelectedItem.ToString(),
                                  idComprador,
                                  monto,
                                  mensualidad,
                                  cbPredio.Text,
                                  cbManzana.Text,
                                  cbLotes.Text);
                    limpiar();
                }
          }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificaVenta modificarVenta = new ModificaVenta();
            modificarVenta.Show();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (txtPagoActual.Text != "" && txtPagoFinal.Text != "")
            {
                Fecha obtenerProximoPago = new Fecha();

                proximoPago = obtenerProximoPago.setProximoPago(dtpFecha.Value, txtPagoActual.Text);
            }
            else
            {
                MessageBox.Show("es necesario ingresar pagos:   /    ");
            }
        }

        public void llenaComboComprador() {

            cbNombre.Items.Clear();
            string respuestaNombreComprador = ws.cargaComprador();
            string[] splitDatosComprador = respuestaNombreComprador.Split(new char[] { '|' });
            string[] splitComprador = splitDatosComprador[0].Split(new char[] { ',' });
            splitId = splitDatosComprador[1].Split(new char[] { ',' });
            
            foreach(string comprador in splitComprador)
            {
                cbNombre.Items.Add(comprador);
            }
            
            /*Dictionary<string, string> NombreIdComprador = new Dictionary<string, string>();

            foreach (string datos in splitDatosComprador)
            {
                string[] desgloseIdNombre = datos.Split(new char[] { '|' });
                cbNombre.Items.Add(desgloseIdNombre[0]);
               // NombreIdComprador.Add(desgloseIdNombre[0], desgloseIdNombre[1]);

            }
           MessageBox.Show("el comprador que esta en el index10 "+splitDatosComprador[4]);*/
        }

        public void llenarComboPredio(){
            
            string respuestaCargaPredio = ws.cargaColumnaTablaPredio("nombre_predio");
            
            string[] splitPredios = respuestaCargaPredio.Split(new char[] {','});

            foreach (string cargaCombo in splitPredios) {

                cbPredio.Items.Add(cargaCombo);
            }
        }

        void cargaVentaDvg(string nombre, 
                           string id, 
                           string costo,
                           string mensualidad, 
                           string predio, 
                           string manzana, 
                           string lote)
        {
            this.dataGridView1.Rows.Insert(0, nombre, id, costo, mensualidad, predio, manzana, lote);
        }

        private void cbNombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNombre.SelectedIndex != -1)
            {
                txtId.Text = splitId[cbNombre.SelectedIndex];
            }

        }

        private void cbPredio_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbManzana.Items.Clear();

            idPredio = ws.getIdPredio(cbPredio.SelectedItem.ToString());

            respuestaCargaManzana = ws.cargaColumnaTablaManzana(idPredio,"n_manzana");
            
            if (respuestaCargaManzana != "")
            {
                string respuestaIdManzana = ws.cargaColumnaTablaManzana(idPredio, "id_manzana");

                splitIdManzana = respuestaIdManzana.Split(new char[] { ',' });

                string[] splitCargaManzana = respuestaCargaManzana.Split(new char[] { ',' });

                foreach (string cargaCombo in splitCargaManzana)
                {

                    cbManzana.Items.Add(cargaCombo);
                }
            }
            else 
            {
                cbManzana.Items.Clear();
                cbLotes.Items.Clear();

                // string idPredio = ws.getIdPredio((string)cbPredio.SelectedItem);
                //string idManzana = ws.getIdManzana((string)cbManzana.SelectedItem, idPredio);
                string respuestaCargaLote = ws.cargaLotesDePredio(idPredio);

                string[] splitCargaLotes = respuestaCargaLote.Split(new char[] { ',' });
                int tamaño = splitCargaLotes.Length;
                foreach (string cargaLotes in splitCargaLotes)
                {
                    cbLotes.Items.Add(cargaLotes);
                }
            }
        }

        private void cbManzana_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbLotes.Items.Clear();

           // string idPredio = ws.getIdPredio((string)cbPredio.SelectedItem);
           //string idManzana = ws.getIdManzana((string)cbManzana.SelectedItem, idPredio);
            string respuestaCargaLote = ws.cargaLotes(splitIdManzana[cbManzana.SelectedIndex]);

            string[] splitCargaLotes = respuestaCargaLote.Split(new char[] { ',' });
            int tamaño = splitCargaLotes.Length;
            foreach (string cargaLotes in splitCargaLotes) {
          
            cbLotes.Items.Add(cargaLotes);
            }
        }

        private void cbLotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (respuestaCargaManzana != "")
            {
                idLote = ws.getIdLote(splitIdManzana[cbManzana.SelectedIndex], cbLotes.SelectedItem.ToString(), "pk_manzana");
            }
            else 
            {
                idLote = ws.getIdLote(idPredio, cbLotes.SelectedItem.ToString(), "pk_predio");
            }

            MedidaLote MedidaLote = new MedidaLote();
            MedidaLote.idLote = idLote;
            MedidaLote.Show();
        }

        public void limpiar()
        {
            txtId.Text = "";
            cbFormaPago.Text = "";
            txtCostoTerreno.Text = "";
            txtAbono.Text = "";
            txtMensualidad.Text = "";
            txtPagoActual.Text = "";
            txtPagoFinal.Text = "";
            cbPredio.Text = "";
            cbLotes.Text = "";
            cbManzana.Text = "";
            cbNombre.SelectedIndex = -1;
        }

        private bool validar()
        {
            //String id = txtId.Text;
            String pago = cbFormaPago.Text;
            String terreno = txtCostoTerreno.Text;
            String abono = txtAbono.Text;
            String mensaulidad = txtMensualidad.Text;
            String pagoActual = txtPagoActual.Text;
            String pagoFinal = txtPagoFinal.Text;
            String predio = cbPredio.Text;
            String lote = cbLotes.Text;
            String manzana = cbManzana.Text;

            if (/*id.Length == 0 || */pago.Length == 0 || terreno.Length == 0 || abono.Length == 0 || mensaulidad.Length == 0 || pagoFinal.Length == 0 || pagoActual.Length == 0 || predio.Length == 0 || lote.Length == 0 || manzana.Length == 0)
            {
                MessageBox.Show("Para poder realizar una venta, favor de llenar todos los campos");

                return false;
            }
            else
            {
                return true;
            }
        }

        private void cbFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFormaPago.SelectedItem.ToString() == "Contado") {
                txtPagoActual.Text = "1";
                txtPagoFinal.Text = "1";
                txtMensualidad.Text = "0";
                txtAbono.Text = "0";
            }
        } 
    }
}

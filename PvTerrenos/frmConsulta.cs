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
    public partial class frmConsulta : Form
    {
        WSpvt.PVT ws = new WSpvt.PVT();
        string[] splitId;
        string datosVentaCliente;
        List<string> datosParaMostrar = new List<string>();

        public frmConsulta()
        {
            InitializeComponent();
            
            //TabControl1.TabPages(2).Enabled = False
        }

        public void llenaComboClientes(String respuestaNombreComprador)
        {
            //respuestaNombreComprador = ws.cargaComprador();
            string[] splitDatosComprador = respuestaNombreComprador.Split(new char[] { '|' });
            string[] splitComprador = splitDatosComprador[0].Split(new char[] { ',' });
            splitId = splitDatosComprador[1].Split(new char[] { ',' });

            foreach (string comprador in splitComprador)
            {
                cmbClientes.Items.Add(comprador);
            }
        
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmbLote_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbHelp.Visible = false;
            btnModificar.Visible = true;
            cmbDato.Enabled = true;

            int index = cmbLote.SelectedIndex;
            string[] datosParaLlenar = datosParaMostrar[index].Split(new char[] { ',' });

            
            txtDatoActual.Clear();//en caso de haber un dato en el combo de dato actual lo limpio
            cmbDato.Text = "";
            txtNuevoDato.Text = "";
            txtPredio.Text = datosParaLlenar[1];
            txtManzana.Text = datosParaLlenar[2];/// y lleno los textBox con sus datos
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdCliente.Text = splitId[cmbClientes.SelectedIndex];
            string idCliente = txtIdCliente.Text;
            string[] separaVenta;
            string[] splitVenta;
            datosVentaCliente = ws.getVentasCliente(idCliente);
            MessageBox.Show("las ventas; "+datosVentaCliente );

            if (datosVentaCliente.Length > 6)
            {
                cmbLote.Visible = true;

                separaVenta = datosVentaCliente.Split(new char[] { '|' });/// primero separamos venta a venta, en caso de q haya mas de una
                foreach (string datos in separaVenta)
                {

                    splitVenta = datos.Split(new char[] { ',' });/// separamos los datos que estamos reciviendo de la venta para ponerlo

                    /* splitVenta[0] -> IdVenta
                     * splitVenta[1] -> idLote 
                     * splitVenta[2] -> Mensualidad
                     * splitVenta[3] -> Monto
                     * splitVenta[4] -> FechaCompra
                     * splitVenta[5] -> diaCorte
                     */
                    string idLote = splitVenta[0];


                    string datosLote = ws.getInfoLotes(idLote);
                    MessageBox.Show("datos idLote: " + idLote + " datos: " + datosLote);
                    string[]  desgloseDatosLote = datosLote.Split(new char[] { ',' });
                    cmbLote.Items.Add(desgloseDatosLote[0]);// aqui cargo el combo con el numero del lote

                    /*cosa del chivo*/
                    datosParaMostrar.Add(datosLote + "," + splitVenta[1] + "," + splitVenta[2] + "," +
                                         splitVenta[3] + "," + splitVenta[5] + "," + splitVenta[0] + "," +
                                         splitVenta[4]);// agrego al array los datos del lote y a base de como
                    //se agrega en el index del combo lo guardo como index


                }
            }
            else
            {
                cmbLote.Visible = false;
                MessageBox.Show("Este cliente no tiene compras registradas!");

            }
            

        }

        
    }
}

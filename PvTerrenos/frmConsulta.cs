using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace PvTerrenos
{
    public partial class frmConsulta : Form
    {
        WSpvt.PVT ws = new WSpvt.PVT();
        string[] splitId;
        string datosVentaCliente;
        List<string> datosParaMostrar = new List<string>();
        string predio;
        string manzana;
        string noLote;
        string idVenta;
        string idLote;
        string mensualidad;
        string monto;
        string fechaCompra;
        string proximoPago;
       

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

        public void llenaVentas()
        {
            txtIdCliente.Text = splitId[cmbClientes.SelectedIndex];
            string idCliente = txtIdCliente.Text;
            string[] separaVenta;
            string[] splitVenta;
            

            datosVentaCliente = ws.getVentasCliente(idCliente);

            if (datosVentaCliente.Length > 6)
            {
                cmbLotes.Visible = true;
                label3.Visible = true;
                MessageBox.Show("Selecciona un lote para ver sus datos");

                separaVenta = datosVentaCliente.Split(new char[] { '|' });/// primero separamos venta a venta, en caso de q haya mas de una
                foreach (string datos in separaVenta)
                {

                    splitVenta = datos.Split(new char[] { ',' });/// separamos los datos que estamos reciviendo de la venta para ponerlo

                    idLote = splitVenta[1];

                    string datosLote = ws.getInfoLotes(idLote);
                    string[] desgloseDatosLote = datosLote.Split(new char[] { ',' });

                    //datosLote -> numero Lote, Predio, numero manzana
                    string[] splitLote = datosLote.Split(new char[] { ',' });

                    idVenta = splitVenta[0];
                    mensualidad = splitVenta[2];
                    monto = splitVenta[3];
                    fechaCompra = splitVenta[4];

                    noLote = splitLote[0];
                    predio = splitLote[1];
                    manzana = splitLote[2];


                    string proximoPagoValues = ws.getProximoPago(idVenta);
                    string[] splitPago = proximoPagoValues.Split(new char[] { ',' });
                    proximoPago = splitPago[1];
                    cmbLotes.Items.Add(desgloseDatosLote[0]);
                    datosParaMostrar.Add(predio + "," + manzana + "," + noLote + "," + monto + "," + mensualidad + "," + fechaCompra + "," + proximoPago + "," + idLote + "," + idVenta);




                }
            }
            else {
                MessageBox.Show("Este cliente no tiene ventas registradas");
            }

        }

       

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

  

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdCliente.Text = splitId[cmbClientes.SelectedIndex];
            string idCliente = txtIdCliente.Text;
            datosVentaCliente = ws.getVentasCliente(idCliente);
            cmbLotes.Visible = false;
            label3.Visible = false;
            btnModificar.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            dtpFechaCompra.Visible = false;
            dtpProximoPago.Visible = false;
            cmbLotes.Items.Clear();
            cmbLotes.Text = "";
            dgvDatosVenta.Rows.Clear();
            llenaVentas();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string respuesta;
            string[] datosModificacion;
            string monto;
            string mensualidad;
            string fechaCompra;
            string proximoPago;
            datosModificacion = datosParaMostrar[cmbLotes.SelectedIndex].Split(new char[] { ',' });
            idLote = datosModificacion[7];
            idVenta = datosModificacion[8];
           

            string mensaje = "¿Estas seguro de que quieres modificar esta venta?";
            string caption = "Modificación de venta";
            MessageBoxButtons botones = MessageBoxButtons.OKCancel;
            DialogResult resultado;
           
           
       

          if (valida())
            {
                resultado = MessageBox.Show(mensaje, caption, botones);
                if (resultado == System.Windows.Forms.DialogResult.OK)
                {
                    monto = dgvDatosVenta[3, 0].Value.ToString();
                    mensualidad = dgvDatosVenta[4, 0].Value.ToString();
                    fechaCompra = dtpFechaCompra.Value.ToString();
                    proximoPago = dtpProximoPago.Value.ToString();

                    respuesta = ws.modificaVenta(monto, mensualidad, fechaCompra, proximoPago, idLote, idVenta);
                    MessageBox.Show(respuesta);
                }
               
            }





        }

        private void dgvDatosVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDatosVenta_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvDatosVenta_RowDefaultCellStyleChanged(object sender, DataGridViewRowEventArgs e)
        {
        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] datosDGV;
            //limpiamos el dataGridview
            this.dgvDatosVenta.Rows.Clear();
            btnModificar.Visible = true;
            string fechaCompra;
            string fechaProximoPago;
            DateTime dateCompra;
            DateTime dateProximoPago;
            label4.Visible = true;
            label5.Visible = true;
            dtpFechaCompra.Visible = true;
            dtpProximoPago.Visible = true;


            int index = cmbLotes.SelectedIndex;
            datosDGV  = datosParaMostrar[index].Split(new char[] { ',' });
            //llenamos el dataGridView
            this.dgvDatosVenta.Rows.Insert(0, datosDGV[0], datosDGV[1], datosDGV[2], datosDGV[3],datosDGV[4]);
            fechaCompra = datosDGV[5]+".";
            fechaProximoPago = datosDGV[6]+".";
            //lleno la fecha de compra
            dateCompra = Convert.ToDateTime(fechaCompra);
            dtpFechaCompra.Value = dateCompra;
            //lleno la fecha de corte
            dateProximoPago = Convert.ToDateTime(fechaProximoPago);
            dtpProximoPago.Value = dateProximoPago;
            
            
           
        }

        public bool valida() {

            if (dgvDatosVenta[3, 0].Value.ToString() == null || dgvDatosVenta[3, 0].Value.ToString() == " ")
            {
           
                MessageBox.Show("El campo monto está vacío!");
                return false;
            }

            if (dgvDatosVenta[4, 0].Value.ToString() == null || dgvDatosVenta[4, 0].Value.ToString() == " ")
            {

                MessageBox.Show("El campo mensualidad está vacío!");
                return false;
            }
            else
            {
                return true;
            }

        }



        
    }
}

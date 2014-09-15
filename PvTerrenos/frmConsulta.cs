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
        string[] datosaModificar;
        string fecha;

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
            label10.Visible = true;
            dtpFecha.Visible = true;
            btnModificar.Visible = true;
            cmbDato.Enabled = true;

            int index = cmbLote.SelectedIndex;
            string[] datosParaLlenar = datosParaMostrar[index].Split(new char[] { ',' });

            
            txtDatoActual.Clear();//en caso de haber un dato en el combo de dato actual lo limpio
            cmbDato.Text = "";
            txtNuevoDato.Text = "";
            txtPredio.Text = datosParaLlenar[1];
            txtManzana.Text = datosParaLlenar[2];/// y lleno los textBox con sus datos

            fecha = datosParaLlenar[8] + ".";
            dtpFecha.Value = Convert.ToDateTime(fecha);

            
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdCliente.Text = splitId[cmbClientes.SelectedIndex];
            string idCliente = txtIdCliente.Text;
            string[] separaVenta;
            string[] splitVenta;
            datosVentaCliente = ws.getVentasCliente(idCliente);
            //MessageBox.Show("las ventas; "+datosVentaCliente );
            cmbLote.Items.Clear();

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
                    string idLote = splitVenta[1];

                   
                    string datosLote = ws.getInfoLotes(idLote);
                    //MessageBox.Show("datos idLote: " + idLote + " datos: " + datosLote);
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

        private void cmbDato_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbLote.SelectedIndex;
            datosaModificar = datosParaMostrar[index].Split(new char[] { ',' });

            txtDatoActual.Text = datosaModificar[cmbDato.SelectedIndex + 4];
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            string datoModificar = cmbDato.Text;
            string nuevoDato = txtNuevoDato.Text;
            string mensaje = "¿Estas seguro de que quieres modificar esta venta?";
            string caption = "Registro de venta";
            string idLote = datosaModificar[6];
            string idVenta = datosaModificar[8];
            string respuesta = "";
            string nuevaFecha = "";
            MessageBoxButtons botones = MessageBoxButtons.OKCancel;
            DialogResult resultado;
            string columna = "";



            int seleccion = cmbDato.SelectedIndex;

            switch (seleccion)
            {

                case 0:
                    columna = "mensualidad";
                    break;

                case 1:
                    columna = "monto";
                    break;

                case 2:
                    columna = "fecha_corte";
                    //string fecha = datosaModificar[7];
                    string[] desgloseFecha = datosaModificar[7].Split(new char[] { '/' });
                    nuevaFecha = txtNuevoDato.Text + "/" + desgloseFecha[1] + "/" + desgloseFecha[2];
                    break;

            }

           
           /* if (fecha != dtpFecha.Text)
            {
                columna = "fecha_compra";
                MessageBox.Show("la fecha es diferente");

            }*/


            if (valida())
            {
                resultado = MessageBox.Show(mensaje, caption, botones);
                if (resultado == System.Windows.Forms.DialogResult.OK)
                {
                    if (columna == "fecha_corte")
                    {
                        MessageBox.Show("modificaras la fecha de corte");
                        respuesta = ws.modificaDato(columna, nuevoDato, nuevaFecha, idLote, idVenta);

                    }
                    else
                        if (columna == "fecha_compra")
                        {


                        }
                        else
                        {
                            respuesta = ws.modificaDato(columna, nuevoDato, "", idLote, idVenta);
                        }
                    MessageBox.Show(respuesta);
                    txtNuevoDato.Text = "";
                }
            }





        }

        public bool valida() {

            bool tieneError = false;
            bool modificaFechaCompra = false;

            //if (!fecha.CompareTo(dtpFecha.ToString()))
            {
                modificaFechaCompra = true;

            }

            if (cmbDato.Text == "" && modificaFechaCompra == false)
            {
                MessageBox.Show("Selecciona el Campo que deseas modificar!");
                return false;
            }
            else if (txtNuevoDato.Text == "" && modificaFechaCompra == false)
            {
                MessageBox.Show("Por favor ingresa el nuevo valor que deseas ingresar");
                return false;
            }
            else if (dtpFecha.Text == "")
            {
                MessageBox.Show("El campo de la fecha de compra no puede estar vacio!");
                return false;
            }
            else if (cmbDato.Text == "Fecha de corte")
            {

                string[] desgloseFecha = datosaModificar[7].Split(new char[] { '/' });
                int dia = Convert.ToInt32(txtNuevoDato.Text);

                switch (desgloseFecha[1])
                {
                    case "01":
                    case "03":
                    case "07":
                    case "08":
                    case "10":
                    case "12":
                        if (dia > 30)
                        {
                            MessageBox.Show("El dia excede el rango permitido para el mes de registro de venta!");
                            tieneError = true;
                        }
                        break;

                    case "04":
                    case "09":
                    case "11":
                        if (dia > 30)
                        {
                            MessageBox.Show("El dia excede el rango permitido para el mes de registro de venta!");
                            tieneError = true;
                        }
                        break;

                    case "02":

                        if (DateTime.IsLeapYear(Convert.ToInt32(desgloseFecha[2])))
                        {
                            if (dia > 29)
                            {
                                MessageBox.Show("El dia excede el rango permitido para el mes de registro de venta!");
                                tieneError = true;
                            }
                        }
                        else
                        {
                            if (dia > 28)
                            {
                                MessageBox.Show("El dia excede el rango permitido para el mes de registro de venta!");
                                tieneError = true;
                            }
                        }
                        break;
                }
                if (tieneError == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            else
            {

                return true;
            }
        
        }



        
    }
}

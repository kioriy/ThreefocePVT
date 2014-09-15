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
    public partial class ModificaVenta : Form
    {
        WSpvt.PVT ws = new WSpvt.PVT();
        public string idCliente;
        string[] desgloseDatosLote;
        string[] splitVenta;
        string[] datosaModificar;
        string datosLote;
        List<string>datosParaMostrar = new List<string>();//arreglo para que me ayude a almacenar los datos del lote q recivo del webservice
        string[] separaVenta;
       // string datosDeVenta;
        public ModificaVenta()
        {
            InitializeComponent();
           
        }


        public void llenaDatos(string datosVenta, string respuestaNombreComprador, string nombrePropietario)
        {

            
            separaVenta = datosVenta.Split(new char[] { '|' });/// primero separamos venta a venta, en caso de q haya mas de una
            foreach (string datos in separaVenta)
            {
                splitVenta = datos.Split(new char[] { ',' });/// separamos los datos que estamos reciviendo de la venta para ponerlo

                string id = splitVenta[0];
               
                
                datosLote = ws.infoLote(id);
                desgloseDatosLote = datosLote.Split(new char[] { ',' });
                cmbLote.Items.Add(desgloseDatosLote[0]);// aqui cargo el combo con el numero del lote
                /*cosa del chivo*/
               // datosParaMostrar.Add(datosLote + "," + splitVenta[1] + "," + splitVenta[2] + "," + splitVenta[4] + "," + splitVenta[0] + "," + splitVenta[3] + "," + splitVenta[5]);// agrego al array los datos del lote y a base de como se agrega en el index del combo lo guardo como idex
                datosParaMostrar.Add(datosLote + "," + splitVenta[1] + "," + splitVenta[2] + "," +
                                         splitVenta[3] + "," + splitVenta[5] + "," + splitVenta[0] + "," +
                                         splitVenta[4]);
            }

            string[] splitDatosComprador = respuestaNombreComprador.Split(new char[] { '|' });
            string[] splitComprador = splitDatosComprador[0].Split(new char[] { ',' });
            string[] splitId = splitDatosComprador[1].Split(new char[] { ',' });

            foreach (string comprador in splitComprador)
            {
               cmbNuevoPropietario.Items.Add(comprador);
            }

            txtPropietarioActual.Text = nombrePropietario;
            
            

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string numeroLote = cmbLote.Text;
            int index = cmbLote.SelectedIndex;
            string[] datosParaLlenar = datosParaMostrar[index].Split(new char[] { ',' });// separo los datos del array index[0 ]= numero lote
                                                                                           //index[1]= nombre predio, index[2]= numero manzana
           // MessageBox.Show("datos: " + datosParaMostrar[index]);
            txtDatoActual.Clear();//en caso de haber un dato en el combo de dato actual lo limpio
            cmbDatosModificar.Text = "";
            txtNuevoDato.Text = "";
            txtPredio.Text = datosParaLlenar[1];
            txtManzana.Text = datosParaLlenar[2];/// y lleno los textBox con sus datos
           
        }

        private void frmModificaVenta_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelCancelacion.Visible = true;
            grpTraspaso.Visible = false;

        }

        private void cmbDatosModificar_SelectedIndexChanged(object sender, EventArgs e)
        {
          int index = cmbLote.SelectedIndex;
          datosaModificar = datosParaMostrar[index].Split(new char[] { ',' });

          txtDatoActual.Text = datosaModificar[cmbDatosModificar.SelectedIndex + 4];
        //  MessageBox.Show("id lote: " + datosaModificar[3] + " id venta: " + datosaModificar[2] + "," + datosaModificar[1] + "," + datosaModificar[4] + "," + datosaModificar[5] + "," + datosaModificar[6] + "," + datosaModificar[7] );
          MessageBox.Show(datosaModificar[8]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string datoModificar = cmbDatosModificar.Text;
            string nuevoDato = txtNuevoDato.Text;
            string mensaje = "¿Estas seguro de que quieres modificar " + datoModificar + " de esta venta?";
            string caption = "Registro de venta";
            string idLote = datosaModificar[3];
            string idVenta = datosaModificar[7];
            string respuesta = "";
            string nuevaFecha = "";
            MessageBoxButtons botones = MessageBoxButtons.OKCancel;
            DialogResult resultado;
           string columna ="";

            if (cmbDatosModificar.SelectedIndex == 0){
                columna = "mensualidad";
            }
            if (cmbDatosModificar.SelectedIndex == 1)
            {
                columna = "monto";
            }
            if(cmbDatosModificar.SelectedIndex == 2)
            {
                columna = "fecha_corte";
                //string fecha = datosaModificar[7];
                string [] desgloseFecha = datosaModificar[8].Split(new char[] { '/' });
                nuevaFecha = txtNuevoDato.Text+"/"+desgloseFecha[1]+"/"+desgloseFecha[2];
            }

           

           

           // fechaCompra

           
            

            if (valida())
            {
                resultado = MessageBox.Show(mensaje, caption, botones);
                if (resultado == System.Windows.Forms.DialogResult.OK)
                {
                    if (columna == "fecha_corte")
                    {
                        respuesta = ws.modificaDato(columna, nuevoDato, nuevaFecha, idLote, idVenta);

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

        public bool valida()
        {
            bool tieneError = false;

            if (cmbDatosModificar.Text == "")
            {
                MessageBox.Show("Selecciona el Campo que deseas modificar!");
                return false;
            }
            else if (txtNuevoDato.Text == "")
            {
                MessageBox.Show("Por favor ingresa el nuevo valor que deseas ingresar");
                return false;
            }
            else if (cmbDatosModificar.Text == "Fecha de corte")
            {

            string[] desgloseFecha = datosaModificar[8].Split(new char[] { '/' });
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
                        if (dia > 28 )
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
            else {
                return false;
            }
               
            }
         
            else {
                
                 return true;
            }


        }

        private void btnTraspasar_Click(object sender, EventArgs e)
        {
            grpTraspaso.Visible = true;
            panelCancelacion.Visible = false;
        }

        private void textMotivoCancelacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void grpTraspaso_Enter(object sender, EventArgs e)
        {
            txtPropietarioActual.Text = "";

        }
    }
}

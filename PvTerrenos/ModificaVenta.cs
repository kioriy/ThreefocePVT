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
        List<string> datosParaMostrar = new List<string>();//arreglo para que me ayude a almacenar los datos del lote q recivo del webservice
        string[] separaVenta;
       // string datosDeVenta;
        public ModificaVenta()
        {
            InitializeComponent();
           
        }
        

        public void llenaDatos(string datosVenta)
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
                datosParaMostrar.Add(datosLote+","+splitVenta[1]+","+splitVenta[2]+","+splitVenta[4]+","+splitVenta[0]+","+splitVenta[3]);// agrego al array los datos del lote y a base de como se agrega en el index del combo lo guardo como idex
               
            }
            

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
            MessageBox.Show("datos: " + datosParaMostrar[index]);
            txtDatoActual.Clear();//en caso de haber un dato en el combo de dato actual lo limpio
            cmbDatosModificar.Text = "";
            txtPredio.Text = datosParaLlenar[1];
            txtManzana.Text = datosParaLlenar[2];/// y lleno los textBox con sus datos
            
            
           
        }

        private void frmModificaVenta_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelCancelacion.Visible = true;
        }

        private void cmbDatosModificar_SelectedIndexChanged(object sender, EventArgs e)
        {
          int index = cmbLote.SelectedIndex;
          datosaModificar = datosParaMostrar[index].Split(new char[] { ',' });

          txtDatoActual.Text = datosaModificar[cmbDatosModificar.SelectedIndex + 3];


          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string datoModificar = cmbDatosModificar.Text;
            string nuevoDato = txtNuevoDato.Text;
            string mensaje = "¿Estas seguro de que quieres modificar " + datoModificar + " de esta venta?";
            string caption = "Registro de venta";
            string idLote = datosaModificar[6];
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
            }

           //DateTime fechaCompra =  Convert.ToDateTime(datosaModificar[7]).AddDays = Convert.ToInt32(txtNuevoDato.Text);

           // fechaCompra

            MessageBox.Show("la fecha..."+datoModificar[7]);

            if (valida())
            {
                resultado = MessageBox.Show(mensaje, caption, botones);
                if (resultado == System.Windows.Forms.DialogResult.OK)
                {
                    string respuesta = ws.modificaDato(columna, nuevoDato, idLote);
                    MessageBox.Show(respuesta);
                }
            }

        }

        public bool valida()
        {
         

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
            else {
                return true;
            }
        }
    }
}

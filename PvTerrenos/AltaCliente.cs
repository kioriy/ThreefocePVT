using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using MySql.Data.MySqlClient;


namespace PvTerrenos
{
    public partial class FrmAltaCliente : Form
    {
        WSpvt.PVT ws = new WSpvt.PVT();
        public string nombre;
        public string domicilio;
        public string beneficiario;
        public string residencia;
        public string ocupacion;
        public string ecivil;
        public string telefono;
        public string telefono2;
        public string nombreComprador;
        public string idComprador;
        FrmVentaLote ventaLote = new FrmVentaLote();

        public FrmAltaCliente()
        {
            InitializeComponent();
            llenarComboComprador();
          
        }

        void llenarComboComprador() {

            cbNombre.Items.Clear();
            string respuestaCargaComprador = ws.cargaComprador();
            string[] splitComprador = respuestaCargaComprador.Split(new char[] { '|' });
            string[] nombreComprador = splitComprador[0].Split(new char[] { ',' });  
            
            foreach (string comprador in nombreComprador)
            {
                cbNombre.Items.Add(comprador);
            }
        }

        public void cargaDatosCliente(string nombre,string idComprador) {
            MessageBox.Show(idComprador);
            string respuestaCliente = ws.getComprador(nombre);
            string[] splitDatosComprador = respuestaCliente.Split(new char[] { ',' });

            nombreComprador = nombre;
            cbNombre.Text = nombre;
            txtDireccion.Text = splitDatosComprador[0];
            txtBeneficiario.Text = splitDatosComprador[1];
            txtResidencia.Text = splitDatosComprador[2];
            txtOcupacion.Text = splitDatosComprador[3];
            txtEc.Text = splitDatosComprador[4];
            txtTelefono2.Text = splitDatosComprador[5];
            txtTelefono.Text = splitDatosComprador[6];
        }
        void agregarCliente()
        {
            //guardo la variable que seran enviadas en la consulta insertar

            
            
            string domicilio = txtDireccion.Text;
            string beneficiario = txtBeneficiario.Text;
            string residencia = txtResidencia.Text;
            string ocupacion = txtOcupacion.Text;
            string ecivil = txtEc.Text;
            string telefono = txtTelefono.Text;
            string telefono2 = txtTelefono2.Text;
         
            if (cbNombre.Text == "")
            {
                MessageBox.Show("Debes proporcionar por lo menos los siguientes datos " + ".:: Nombre ::.");
                
            }
           
                try
                {
                    string idComprador = generaId(cbNombre.Text);
                    string nombre = cbNombre.Text.ToUpper();

                    string respuetaAgregarComprador = ws.registraComprador(idComprador, nombre, domicilio, beneficiario, residencia, ocupacion, ecivil, telefono, telefono2);
                    MessageBox.Show(respuetaAgregarComprador+"\n\nEl id de usario es "+idComprador);
                    ventaLote.llenaComboComprador();
                    llenarComboComprador();
                    cbNombre.Text = "";
                    txtDireccion.Text = "";
                    txtBeneficiario.Text = "";
                    txtResidencia.Text = "";
                    txtOcupacion.Text = "";
                    txtEc.Text = "";
                    txtTelefono.Text = "";
                    txtTelefono2.Text = "";
                    
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            
        }

          void modificarCliente(string idcomprador)
          {
              string nombreNuevo = cbNombre.Text.ToUpper();
              string respuestaActulizaCliente = ws.updateComprador(idcomprador, nombreNuevo, txtDireccion.Text, txtBeneficiario.Text, txtResidencia.Text, txtOcupacion.Text, txtEc.Text, txtTelefono.Text, txtTelefono2.Text);
              ventaLote.llenaComboComprador();
              llenarComboComprador();
              MessageBox.Show(respuestaActulizaCliente);
          }

          private string generaId(string nombreComprador)
          {

              string idComprador = "";
              string iniciales = "";

              string[] splitComprador = nombreComprador.Split(new char[] { ' ' });

              for (int i = 0; i < splitComprador.Length; i++)
              {

                  iniciales += splitComprador[i].Substring(0, 2);
              }
              idComprador = iniciales;
              return idComprador;
          }



          private void cbNombre_KeyDown(object sender, KeyEventArgs e)
          {
              

              if (e.KeyCode == Keys.Enter) {
          
                  if (cbNombre.FindString(cbNombre.Text) != -1)
                  {
                      btnActualizar.Visible = true;
                      cmdAgregar.Enabled = false;
                      cargaCliente();
                  }
                  else
                  {
                      btnActualizar.Visible = false;
                      cmdAgregar.Enabled = true;
                  }
                  
              }
          }

          private void btnActualizar_Click(object sender, EventArgs e)
          {     
             
                  string mensaje = "¿Estas seguro de que quieres actualizar a este cliente?";
                  string caption = "Actualizar Cliente";
                  MessageBoxButtons botones = MessageBoxButtons.OKCancel;
                  DialogResult resultado;


                  resultado = MessageBox.Show(mensaje, caption, botones);

                  if (resultado == System.Windows.Forms.DialogResult.OK)
                  {
                      modificarCliente(idComprador);
                  }
              
          }


          private void cmdAgregar_Click(object sender, EventArgs e)
          {
              if (cbNombre.FindString(cbNombre.Text) == -1)
              {
                  agregarCliente();
                  llenarComboComprador();
               }
              else
              {
                  MessageBox.Show("El usuario ingresado ya existe");
              }

          }

          public void cargaCliente() {
              string nombre = cbNombre.Text;
              string respuestaCliente = ws.getComprador(nombre);
              idComprador = ws.getIdComprador(nombre);
              string[] splitDatosComprador = respuestaCliente.Split(new char[] { ',' });


              txtDireccion.Text = splitDatosComprador[0];
              txtBeneficiario.Text = splitDatosComprador[1];
              txtResidencia.Text = splitDatosComprador[2];
              txtOcupacion.Text = splitDatosComprador[3];
              txtEc.Text = splitDatosComprador[4];
              txtTelefono2.Text = splitDatosComprador[5];
              txtTelefono.Text = splitDatosComprador[6];
              
          
          }

          private void cbNombre_SelectedIndexChanged(object sender, EventArgs e)
          {
              if (cbNombre.FindString(cbNombre.Text) != -1)
              {
                  btnActualizar.Visible = true;
                  cmdAgregar.Enabled = false;
                  cargaCliente();
              }
              else
              {
                  btnActualizar.Visible = false;
                  cmdAgregar.Enabled = true;
              }

          }

        
      }
}

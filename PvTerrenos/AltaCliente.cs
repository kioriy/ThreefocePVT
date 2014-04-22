using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
        public FrmAltaCliente()
        {
            InitializeComponent();
           string respuestaCargaComprador =  ws.cargaComprador();
           string[] splitComprador = respuestaCargaComprador.Split(new char[] { ',' });


           foreach (string comprador in splitComprador) {

               cbNombre.Items.Add(comprador);
           }
        }

         /* variable que guarda la informacion de la conexion a la base de datos        
          private string ruta = "Server=db4free.net; Database=dbterrenos; Uid=kioriy; Pwd=yagami;";
          instancia de la conexion 
          private MySqlConnection conexion;
          instancia para el buffer de datos
          private DataSet ds;
          instacia para el buffer que carga los datos al grid
          private MySqlDataAdapter adaptador;*/
         
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
            bool bandera = false;

             string respuestaCargaComprador =  ws.cargaComprador();
            string[] splitComprador = respuestaCargaComprador.Split(new char[] { ',' });

           foreach (string comprador in splitComprador)
           {
               if (comprador == cbNombre.Text) {
                   bandera = true;
                   nombre = comprador;
                   break;
               }
           }

            //verifico que por lo menos haya un nombre y un id.. el id quedo manual
            if (cbNombre.Text == "")
            {
                MessageBox.Show("Debes proporcionar por lo menos los siguientes datos " + ".:: Nombre ::.");
                
            }
            else if (bandera == true)
                {
                    string respuestaCliente = ws.getComprador(nombre);
                    string[] splitDatosComprador = respuestaCliente.Split(new char[] { ',' });

                    cbNombre.Text = nombre;
                    txtDireccion.Text = splitDatosComprador[0];
                    txtBeneficiario.Text = splitDatosComprador[1];
                    txtResidencia.Text = splitDatosComprador[2];
                    txtOcupacion.Text = splitDatosComprador[3];
                    txtEc.Text = splitDatosComprador[4];
                    txtTelefono2.Text = splitDatosComprador[5];
                    txtTelefono.Text = splitDatosComprador[6];
                    
                    string mensaje = "Este cliente ya se encuentra registrado,¿Deseas modificarlo?";
                    string caption = "Modificar Usuario";
                    MessageBoxButtons botones = MessageBoxButtons.OKCancel;
                    DialogResult resultado;

                    resultado = MessageBox.Show(mensaje, caption, botones);

                    if (resultado == System.Windows.Forms.DialogResult.OK)
                    {
                        
                        cmdAgregar.Visible = false;
                        btnActualizar.Visible = true;

                    }
                } 
            else
                {
                try
                {
                    string idComprador = generaId(cbNombre.Text);
                    string nombre = cbNombre.Text;

                    string respuetaAgregarComprador = ws.registraComprador(idComprador, nombre, domicilio, beneficiario, residencia, ocupacion, ecivil, telefono, telefono2);
                    MessageBox.Show(respuetaAgregarComprador+"\n\nEl id de usario es "+idComprador);
                    cbNombre.Text = "";
                    txtDireccion.Text = "";
                    txtBeneficiario.Text = "";
                    txtResidencia.Text = "";
                    txtOcupacion.Text = "";
                    txtEc.Text = "";
                    txtTelefono.Text = "";
                    txtTelefono2.Text = "";
                    //establesco la conexion
                    //            conexion = new MySqlConnection(ruta);
                    //            conexion.Open();
                    //            MessageBox.Show("Conexion exitosa");
                    //            //instancia para el comando de consultas
                    //            MySqlCommand comando = new MySqlCommand();
                    //            comando.CommandText = "Insert into cliente values ('" + id + "','" + nombre + "','" + domicilio + "','" + beneficiario + "','" + residencia + "','" + ocupacion + "','" + ecivil + "','" + telefono + "','" + telefono2 + "');";
                    //            comando.Connection = conexion;
                    //            comando.ExecuteNonQuery();
                    //            MessageBox.Show("datos agregados con exito");
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }

          private void cmdAgregar_Click(object sender, EventArgs e)
          {
              agregarCliente();
             
              //cargarAltaCliente();
          }
       
    /*      //carga el datagridview en la venta alta clientes
          private void cargarAltaCliente() {

              conexion = new MySqlConnection(ruta);
              conexion.Open();
              DataTable dtDatos = new DataTable();
              adaptador = new MySqlDataAdapter("SELECT * FROM cliente", conexion);
              adaptador.Fill(dtDatos);
              dgvAltaCliente.DataSource = dtDatos;
              conexion.Close();
          }*/

         


          void modificarCliente()
          {
              
              string respuestaCargaComprador = ws.cargaComprador();
              string[] splitComprador = respuestaCargaComprador.Split(new char[] { ',' });
              nombre = cbNombre.Text;
             

              foreach (string comprador in splitComprador)
              {

                  if (comprador == nombre)
                  {

                      string respuestaCliente = ws.getComprador(nombre);
                      string[] splitDatosComprador = respuestaCliente.Split(new char[] { ',' });

                      
                      txtDireccion.Text = splitDatosComprador[0];
                      txtBeneficiario.Text = splitDatosComprador[1];
                      txtResidencia.Text = splitDatosComprador[2];
                      txtOcupacion.Text = splitDatosComprador[3];
                      txtEc.Text = splitDatosComprador[4];
                      txtTelefono2.Text = splitDatosComprador[5];
                      txtTelefono.Text = splitDatosComprador[6];

                      string mensaje = "Este cliente ya se encuentra registrado,¿Deseas modificarlo?";
                      string caption = "Modificar Usuario";
                      MessageBoxButtons botones = MessageBoxButtons.OKCancel;
                      DialogResult resultado;

                      resultado = MessageBox.Show(mensaje, caption, botones);

                      if (resultado == System.Windows.Forms.DialogResult.OK)
                      {

                          cmdAgregar.Visible = false;
                          btnActualizar.Visible = true;
                         
                      }

                      break;

                  }


              }

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

          private void cbNombre_KeyPress(object sender, KeyPressEventArgs e)
          {
              
          }

          private void cbNombre_SelectedIndexChanged(object sender, EventArgs e)
          {

          }

          private void cbNombre_KeyDown(object sender, KeyEventArgs e)
          {
              if (e.KeyCode == Keys.Enter) {
                  modificarCliente();
              }
          }

          private void btnActualizar_Click(object sender, EventArgs e)
          {
             string mensaje = "¿Estas seguro de que quieres actualizar a este cliente?";
            string caption = "Actualizar Cliente";
            MessageBoxButtons botones = MessageBoxButtons.OKCancel;
            DialogResult resultado;
            
             
            
            
                resultado = MessageBox.Show(mensaje, caption, botones);

                if (resultado == System.Windows.Forms.DialogResult.OK) {
                   string respuestaActulizaCliente = ws.updateComprador(cbNombre.Text, txtDireccion.Text, txtBeneficiario.Text, txtResidencia.Text, txtOcupacion.Text, txtEc.Text, txtTelefono.Text, txtTelefono2.Text);
                   MessageBox.Show(respuestaActulizaCliente);
                }
          }
      }
}

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
            //verifico que por lo menos haya un nombre y un id.. el id quedo manual
            if (cbNombre.Text == "")
            {
                MessageBox.Show("Debes proporcionar por lo menos los siguientes datos " + ".:: Nombre ::.");
                
            }
            else
            {
                try
                {
                    string idComprador = generaId(cbNombre.Text);
                    string nombre = cbNombre.Text;

                    string respuetaAgregarComprador = ws.registraComprador(idComprador, nombre, domicilio, beneficiario, residencia, ocupacion, ecivil, telefono, telefono2);
                    MessageBox.Show(respuetaAgregarComprador+"\n\nEl id de usario es "+idComprador);
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
              cbNombre.Text = "";
              txtDireccion.Text = "";
              txtBeneficiario.Text= "";
              txtResidencia.Text = "";
              txtOcupacion.Text = "";
              txtEc.Text = "";
              txtTelefono.Text = "";
              txtTelefono2.Text = "";
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
      }
}

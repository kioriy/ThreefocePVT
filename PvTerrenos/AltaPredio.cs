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
    public partial class FrmAltaPredio : Form
    {
        public Boolean predio = false;
        public Boolean predioExiste = false;
        public String numeroManzanas;
        public string idPredio;

        WSpvt.PVT ws = new WSpvt.PVT();

        public FrmAltaPredio()
        {
            InitializeComponent();
            cbSeleccionaManzanaLote.Items.Add("Manzanas");
            cbSeleccionaManzanaLote.Items.Add("Lotes");
            label2.Visible = false;
           
        }

        private void cbSeleccionaManzanaLote_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)cbSeleccionaManzanaLote.SelectedItem == "Manzanas")
            {
                lNumeroManzana.Visible = true;
                lNumeroLotes.Visible = false;
                txtNumManzanaLote.Visible = true;
                txtNumeroLote.Visible = false;
                cmdGenerarLotes.Visible = false;
                cmdGeneraManzanas.Visible = true;
            }
            if ((string)cbSeleccionaManzanaLote.SelectedItem == "Lotes")
            {

                lNumeroLotes.Visible = true;
                lNumeroManzana.Visible = false;

                if(predioExiste == false ) cmdGenerarLotes.Visible = true;
                cmdGeneraManzanas.Visible = false;
                gbRegistrarLotes.Visible = false;

            }
        }

        private void cmdGenerarPredio_Click(object sender, EventArgs e)//boton generar predio
        {
            idPredio = txtIdPredio.Text.ToUpper();
            ///en caso de que el nombre del predio este en minusculas lo cambiamos a mayusculas para que no haya error al comparar
            string nombrePredio = txtNombrePredio.Text.ToUpper();
            cmdGenerarLotes.Visible = false;

            

            if (idPredio != "" && nombrePredio != "")
            {
                //validacion en caso de que el predio ya este registrado
                string mensaje = "El predio que ingresaste ya esta registrado, ¿Deseas modificarlo?";
                string caption = "Modificar Predio";
                bool bandera = false;
                MessageBoxButtons modificaPredio = MessageBoxButtons.OKCancel;
                DialogResult resultado;
                string nombres = ws.cargaColumnaTablaPredio("nombre_predio");
                string[] splitPredios = nombres.Split(new char[] {','});
                
               
                foreach (string nombreP in splitPredios)
                {

                    if (nombreP == nombrePredio)
                    {
                        bandera = true;
                        resultado = MessageBox.Show(mensaje, caption, modificaPredio);
                        if (resultado == System.Windows.Forms.DialogResult.OK) {

                            label6.Visible = false;
                            label2.Visible = true;
                            String id_predio = ws.getIdPredio(nombrePredio);
                            numeroManzanas = ws.contarManzanas(id_predio);
                            predioExiste = true;
                            
                            string hayManzana = ws.contarLotes("0", idPredio);
                            if (Convert.ToInt32(hayManzana) != 0)
                            {
                                
                                cmdGeneraManzanas.Visible = false;
                                btnModificaLote.Visible = true;
                                btnModificar.Visible = false;
                                txtNumManzanaLote.Visible = true;
                                cbSeleccionaManzanaLote.Text = "Lotes";
                                txtNumManzanaLote.Text = hayManzana;
                                lNumeroLotes.Visible = true;
                               

                            }
                            else
                            {
                                btnModificar.Visible = true;
                                txtNumManzanaLote.Visible = true;
                                cbSeleccionaManzanaLote.Text = "Manzanas";
                                lNumeroManzana.Visible = true;
                                txtNumManzanaLote.Text = numeroManzanas;

                            }
                            
                        }
                       
                    }

                }

                if (bandera == false)
                {

                    string respuesta = ws.registraPredio(idPredio, nombrePredio);
                    MessageBox.Show(respuesta);
                    predio = true;
                    cmdGenerarPredio.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Debes llenar 'Nombre' y 'ID predio'");
            }
        }

        public void cargarManzanas(string opcion){
            lManzana.Visible = true;
            lLotes.Visible = true;
            txtNumManzanaLote.Visible = true;
            cbNumeroManzana.Visible = true;

            //en caso de que  estemos modificando el predio
            if (opcion == "modificar"){
               
                string idManzana = Convert.ToString(txtNumManzanaLote.Text);
                int x = Convert.ToInt32(txtNumManzanaLote.Text);
                int manzanasRegistradas = Convert.ToInt32(numeroManzanas);
                if (manzanasRegistradas == x) {
                    MessageBox.Show("Ingresa el nuevo numero de manzanas que quieres que tenga este predio");
                }
                int comienza = manzanasRegistradas + 1;
                string banderaRegistroManzanas = "";

                for (int i = comienza; i <= x; i++)
                {
                    string j = Convert.ToString(i);
                    banderaRegistroManzanas = ws.registraManzana(j, idPredio);
                }
                if (banderaRegistroManzanas == "1")
                {
                    MessageBox.Show("Manzanas modificadas con EXITO");
                    btnModificar.Visible = false;
                    cmdGeneraManzanas.Visible = false;
                    cmdGenerarLotes.Visible = true;
                    gbRegistrarLotes.Visible = true;
                    txtNumeroLote.Visible = true;
                    for (int a = 0; a < x; a++)
                    {
                        cbNumeroManzana.Items.Add(a + 1);
                    }
                }


            }

            if (opcion == "generar")
            {

                if (txtNumManzanaLote.Text != "")
                {
                    gbRegistrarLotes.Visible = true;
                    txtNumeroLote.Visible = true;
                    cmdGenerarLotes.Visible = true;
                    cmdGeneraManzanas.Visible = false;

                    int i = Convert.ToInt32(txtNumManzanaLote.Text);
                    for (int x = 0; x < i; x++)
                    {
                        cbNumeroManzana.Items.Add(x + 1);
                    }
                }
                else
                {
                    MessageBox.Show("Debes ingresar un numero de manzana");
                }

                if (predio == false)
                {
                    MessageBox.Show("Primero debes dar de alta un predio");
                }
                else
                {

                    string idPredio = Convert.ToString(txtIdPredio.Text);
                    string idManzana = Convert.ToString(txtNumManzanaLote.Text);
                    int x = Convert.ToInt32(txtNumManzanaLote.Text);
                    string banderaRegistroManzanas = "";
                    for (int i = 0; i < x; i++)
                    {
                        string j = Convert.ToString(i + 1);
                        banderaRegistroManzanas = ws.registraManzana(j, idPredio);
                    }
                    if (banderaRegistroManzanas == "1")
                    {
                        MessageBox.Show("Manzanas registradas con EXITO");
                    }
                }
            }
        
        
        }
        public void cargaLotes(string opcion) {
            bool bandera = false;
            string numeroLote;
            
            if (opcion == "modificar") {

                string hayManzana = ws.contarLotes("0", idPredio);
                int numeroTotalM = Convert.ToInt32(hayManzana);
                if (numeroTotalM > 0)
                {
                    numeroLote = txtNumManzanaLote.Text;
                   int enviar = numeroTotalM + 1;
                   string numeroM = Convert.ToString(enviar);
                    string resgitraLotes = ws.registraLote(numeroM, idPredio, "", numeroLote);
                    if (resgitraLotes == "1")
                    {
                        MessageBox.Show("Lotes modificados con EXITO");

                        int items = cbNumeroManzana.Items.Count;

                        if (cbNumeroManzana.SelectedIndex < (items - 1))
                        {
                            cbNumeroManzana.SelectedIndex += 1;
                        }
                        else
                        {
                            bandera = true;
                        }

                    }

                }

                else
                {
                    numeroLote = txtNumeroLote.Text;
                   string registrarLote = ws.registraLote(numeroLote, idPredio, "", "");
                   if (registrarLote == "1")
                   {
                       MessageBox.Show("Lotes modificados con EXITO");

                       
                           bandera = true;
                   }
                }
            }


            if (opcion == "generar")
            {
                if (predio == false && predioExiste == false)
                {
                    MessageBox.Show("Primero debes dar de alta el predio");
                }
                else
                {


                    //  string idPredio = txtIdPredio.Text;
                    
                    string banderaRegistroLote = "";

                    if (txtNumManzanaLote.Text == "")
                    {
                        MessageBox.Show("Debes ingresar un numero de lote");
                    }
                    else
                    {
                        if ((string)cbSeleccionaManzanaLote.SelectedItem == "Lotes")
                        {
                            numeroLote = txtNumManzanaLote.Text;
                        }
                        else
                        {
                            numeroLote = txtNumeroLote.Text;
                        }

                        //for (int i = 0; i < x; i++)
                        //{
                        //  string j = Convert.ToString(i + 1);

                        if ((string)cbSeleccionaManzanaLote.SelectedItem == "Lotes")
                        {
                            banderaRegistroLote = ws.registraLote(numeroLote, idPredio, "","");
                        }
                        else
                        {
                            string numeroManzana = Convert.ToString(cbNumeroManzana.SelectedItem);
                            string idManzana = ws.getIdManzana(numeroManzana, idPredio);
                            /*string respuestaLotes = ws.contarLotes(idManzana);
                            if (Convert.ToInt32(respuestaLotes) != 0) { 
                            
                            }*/
                            banderaRegistroLote = ws.registraLote(numeroLote, idPredio, idManzana,"");
                        }
                        //}//cierre for
                        if (banderaRegistroLote == "1")
                        {
                            MessageBox.Show("Lotes registrados con EXITO");

                            int items = cbNumeroManzana.Items.Count;

                            if (cbNumeroManzana.SelectedIndex < (items - 1))
                            {
                                cbNumeroManzana.SelectedIndex += 1;
                            }
                            else
                            {
                                bandera = true;
                            }

                        }

                    }//cierre de else en condicion de if cuando txtNumeroManzanaLote esta vacio
                }//cierre de else

            }


            if (bandera/*cbNumeroManzana.SelectedIndex == Convert.ToInt32(txtNumManzanaLote.Text) */ || cbSeleccionaManzanaLote.SelectedIndex == 1)
            {
                txtNombrePredio.Text = "";
                txtIdPredio.Text = "";
                txtNumeroLote.Text = "";
                txtNumManzanaLote.Text = "";
                txtNumManzanaLote.Visible = false;
                gbRegistrarLotes.Visible = false;
                lNumeroLotes.Visible = false;
                lNumeroManzana.Visible = false;
                cmdGenerarPredio.Enabled = true;
                cmdGenerarLotes.Visible = false;
                cmdGeneraManzanas.Visible = false;
                cbSeleccionaManzanaLote.SelectedIndex = -1;

            }
        }

        private void cmdGeneraManzanas_Click(object sender, EventArgs e)//boton generar manzana
        {
            cargarManzanas("generar");
        }

        
        private void cmdGenerarLotes_Click(object sender, EventArgs e)//boton generar lote
        {
            cargaLotes("generar");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            cargarManzanas("modificar");
        }

        private void btnModificaLote_Click(object sender, EventArgs e)
        {
            cargaLotes("modificar");
        }
    }//cierre clase frmAltaPredio
}
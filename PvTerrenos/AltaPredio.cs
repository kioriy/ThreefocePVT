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
        

        public FrmAltaPredio()
        {
            InitializeComponent();
            cbSeleccionaManzanaLote.Items.Add("Manzanas");
            cbSeleccionaManzanaLote.Items.Add("Lotes");
        }

        private void cbSeleccionaManzanaLote_SelectedIndexChanged(object sender, EventArgs e)//combo box manzana lote
        {
            if ((string)cbSeleccionaManzanaLote.SelectedItem == "Manzanas"){
                
                lNumeroManzana.Visible = true;
                lNumeroLotes.Visible = false;
                txtNumManzanaLote.Visible = true;
                txtNumeroLote.Visible = false;
                cmdGenerarLotes.Visible = false;
                cmdGeneraManzanas.Visible = true;
                }
            if ((string)cbSeleccionaManzanaLote.SelectedItem == "Lotes"){

                lNumeroLotes.Visible = true;
                lNumeroManzana.Visible = false;
                txtNumManzanaLote.Visible = true;
                cmdGenerarLotes.Visible = true;
                cmdGeneraManzanas.Visible = false;
                gbRegistrarLotes.Visible = false;

            }
        }//combo box seleccionar Lote manzana

        private void cmdGeneraManzanas_Click(object sender, EventArgs e)//boton generar manzana
        {
            lManzana.Visible = true;
            lLotes.Visible = true;
            txtNumManzanaLote.Visible = true;
            cbNumeroManzana.Visible = true;

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
                WSpvt.PVT altaManzana = new WSpvt.PVT();
                string idPredio = Convert.ToString(txtIdPredio.Text);
                string idManzana = Convert.ToString(txtNumManzanaLote.Text);
                int x = Convert.ToInt32(txtNumManzanaLote.Text);
                string banderaRegistroManzanas = "";
                for (int i = 0; i < x; i++)
                {
                    string j = Convert.ToString(i + 1);
                    banderaRegistroManzanas = altaManzana.registraManzana(j, idPredio);
                }
                if (banderaRegistroManzanas == "1") {
                    MessageBox.Show("Manzanas registradas con EXITO");
                }
            }
        }

        private void cmdGenerarPredio_Click(object sender, EventArgs e)//boton generar predio
        {
            string idPredio = txtIdPredio.Text;
            string nombrePredio = txtNombrePredio.Text;

            if (idPredio != ""  && nombrePredio != ""){//validacion para no registrar un predio si no hay datos
                
                WSpvt.PVT altaPredio = new WSpvt.PVT();
                string respuesta = altaPredio.registraPredio(idPredio, nombrePredio);
                MessageBox.Show(respuesta);
                predio = true;
                cmdGenerarPredio.Enabled = false;
            }
            else {
                MessageBox.Show("Debes llenar 'Nombre' y 'ID predio'");
            }
        }

        private void cmdGenerarLotes_Click(object sender, EventArgs e)//boton generar lote
        {
            if (predio == false)
            {
                MessageBox.Show("Primero debes dar de alta el predio");
            }
            else
            {
                WSpvt.PVT altaLote = new WSpvt.PVT();

                string idPredio = txtIdPredio.Text;
                int x;
                string banderaRegistroLote = "";

                if (txtNumManzanaLote.Text == "")
                {
                    MessageBox.Show("Debes ingresar un numero de lote");
                }
                else
                {
                    if ((string)cbSeleccionaManzanaLote.SelectedItem == "Lotes")
                    {
                        x = Convert.ToInt32(txtNumManzanaLote.Text);
                    }
                    else
                    {
                        x = Convert.ToInt32(txtNumeroLote.Text);
                    }

                    for (int i = 0; i < x; i++)
                    {
                        string j = Convert.ToString(i + 1);

                        if ((string)cbSeleccionaManzanaLote.SelectedItem == "Lotes")
                        {
                            banderaRegistroLote = altaLote.registraLote(j, idPredio, "");
                        }
                        else
                        {
                            string numeroManzana = Convert.ToString(cbNumeroManzana.SelectedItem);
                            string idManzana = altaLote.getManzana(numeroManzana, idPredio);
                            banderaRegistroLote = altaLote.registraLote(j, idPredio, idManzana);
                        }
                    }//cierre for
                    if (banderaRegistroLote == "1")
                    {
                        MessageBox.Show("Lotes registrados con EXITO");
                    }
                    int control = 0;

                    if ((String)cbSeleccionaManzanaLote.SelectedItem == "Manzanas" || (String)cbSeleccionaManzanaLote.SelectedItem == "Lotes")
                    {
                      control = Convert.ToInt32(txtNumManzanaLote.Text);
                    } 
                       
                    
                   // String hayLotes = cbSeleccionaManzanaLote.SelectedItem == "Lotes";

                    if ((Int32)cbNumeroManzana.SelectedItem == control)
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
                    }
                }//cierre de else en condicion de if cuando txtNumeroManzanaLote esta vacio
            }//cierre de else
        }//cierre genera lotes
    }//cierre clase frmAltaPredio
}

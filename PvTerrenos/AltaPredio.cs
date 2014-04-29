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
        public Boolean modificar = false;
        public String numeroManzanas;
        public Boolean manzanaPredio = false;
        public string idPredio;
        

        WSpvt.PVT ws = new WSpvt.PVT();

        public FrmAltaPredio()
        {
            InitializeComponent();
            cargarPredios();
            cbSeleccionaManzanaLote.Items.Add("Manzanas");
            cbSeleccionaManzanaLote.Items.Add("Lotes");
            cmbModificar.Items.Add("Manzanas");
            cmbModificar.Items.Add("Lotes");
            label2.Visible = false;
        }

        public void cargarPredios() {

            string nombrePredio = ws.cargaColumnaTablaPredio("nombre_predio");
            string[] splitPredio = nombrePredio.Split(new char[] { ',' });

            foreach (string nombre in splitPredio) {
                string idP = ws.getIdPredio(nombre);
                string manzanas = ws.contarManzanas(idP);
                string lotes = ws.contarLotes("", idP);
                dataGridView1.Rows.Add(nombre, manzanas, lotes);

            }
            
            

        
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
            string nombrePredio = txtNombrePredio.Text;
            idPredio = txtIdPredio.Text;
            cmdGenerarLotes.Visible = false;
            bool idP = false;
            string  comparaId = ws.cargaColumnaTablaPredio("id_predio");
            string[] splitIdPredio = comparaId.Split(new char[] { ',' });
           
           
            if (idPredio != "" && nombrePredio != "")
            {
                //validacion en caso de que el predio ya este registrado
                string mensaje = "El predio que ingresaste ya esta registrado, ¿Deseas modificarlo?";
                string caption = "Modificar Predio";
                bool bandera = false;
                bool namepredio = false;
                MessageBoxButtons modificaPredio = MessageBoxButtons.OKCancel;
                DialogResult resultado;
                string nombres = ws.cargaColumnaTablaPredio("nombre_predio");
                string[] splitPredios = nombres.Split(new char[] {','});

               

                foreach (string nombreP in splitPredios)
                {
                    if (nombreP == nombrePredio)
                    {
                        namepredio = true;
                        bandera = true;
                        resultado = MessageBox.Show(mensaje, caption, modificaPredio);
                        if (resultado == System.Windows.Forms.DialogResult.OK)
                        {
                            cbSeleccionaManzanaLote.Visible = false;
                            cmbModificar.Visible = true;
                            label6.Visible = false;
                            label2.Visible = true;
                            String id_predio = ws.getIdPredio(nombrePredio);
                            numeroManzanas = ws.contarManzanas(id_predio);
                            predioExiste = true;

                            

                            if (Convert.ToInt32(numeroManzanas) != 0)
                            {
                                btnModificar.Visible = true;
                                txtNumManzanaLote.Visible = true;
                                cmbModificar.Text = "Manzanas";
                                lNumeroManzana.Visible = true;
                                txtNumManzanaLote.Text = numeroManzanas;

                                if ((string)cmbModificar.SelectedItem == "Lotes")
                                {
                                    MessageBox.Show("cambio");
                                }

                            }
                            else
                            {

                                cmdGeneraManzanas.Visible = false;
                                btnModificaLote.Visible = true;
                                btnModificar.Visible = false;
                                txtNumManzanaLote.Visible = true;
                                cmbModificar.Text = "Lotes";
                                string numeroLots = ws.contarLotes("0", id_predio);
                                txtNumManzanaLote.Text = numeroLots;
                                lNumeroLotes.Visible = true;

                                if ((string)cmbModificar.SelectedItem == "Manzanas")
                                {
                                    MessageBox.Show("cambio");
                                }

                            }

                        }

                    }
                 

                }
                if (namepredio == false)
                {
                    foreach (string compareId in splitIdPredio)
                    {
                        if (idPredio == compareId)
                        {
                            MessageBox.Show("El ID que ingresaste ya se encuentra registrado, por favor ingresa otro");
                            idP = true;
                        }

                    }
                }

                if (bandera == false && idP == false)
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
                    btnModificaLote.Visible = true;
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

            switch (opcion) { 
                case "modificar":
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
                                                         if (manzanaPredio == false)
                                                         {

                                                             numeroLote = txtNumeroLote.Text;
                                                             string registrarLote = ws.registraLote(numeroLote, idPredio, "", "");
                                                             if (registrarLote == "1")
                                                             {
                                                                 MessageBox.Show("Lotes modificados con EXITO");
                                                                 bandera = true;
                                                             }
                                                         }
                                                         else {
                                                                string nManzana = cbNumeroManzana.Text;
                                                                string idManzanaActual = ws.getIdManzana(nManzana, idPredio);
                                                                 numeroLote = txtNumeroLote.Text;
                                                                 string lotesActual = ws.contarLotes(idManzanaActual, idPredio);
                                                                 int lotes = Convert.ToInt32(lotesActual)+1;
                                                                 string cantidadActual = Convert.ToString(lotes);
                                                                 string registrarLote = ws.registraLote(cantidadActual, idPredio, idManzanaActual, numeroLote);
                                                                if (registrarLote == "1")
                                                                     {
                                                                       MessageBox.Show("Lotes modificados con EXITO");
                                                                         bandera = true;
                                                                    }
                                                         
                                                         }


                                                       }

                    break;

                case "generar":
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
                                banderaRegistroLote = ws.registraLote(numeroLote, idPredio, "", "");
                            }
                            else
                            {
                                string numeroManzana = Convert.ToString(cbNumeroManzana.SelectedItem);
                                string idManzana = ws.getIdManzana(numeroManzana, idPredio);
                                /*string respuestaLotes = ws.contarLotes(idManzana);
                                if (Convert.ToInt32(respuestaLotes) != 0) { 
                            
                                }*/
                                banderaRegistroLote = ws.registraLote(numeroLote, idPredio, idManzana, "");

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
                    }
                    break;
            
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

        private void btnModificar_Click(object sender, EventArgs e)
        {   

            cargarManzanas("modificar");
        }

        private void btnModificaLote_Click(object sender, EventArgs e)
        {
            cargaLotes("modificar");
        }

        private void cmbModificar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbModificar.Text == "Lotes")
            {
                gbRegistrarLotes.Visible = true;
                btnModificaLote.Visible = true;
                btnModificar.Visible = false;
                txtNumManzanaLote.Visible = false;
                lNumeroManzana.Visible = false;
                string manzanas = ws.cargaColumnaTablaManzana(idPredio, "n_manzana");
                string[] splitManzanas = manzanas.Split(new char[] { ',' });

                foreach (string manzana in splitManzanas)
                {
                    cbNumeroManzana.Items.Add(manzana);
                }

            }
            else
            {
                btnModificar.Visible = true;
                gbRegistrarLotes.Visible = false;
                txtNumManzanaLote.Visible = true;
                lNumeroManzana.Visible = true;
                lNumeroLotes.Visible = false;
            }
        }

        private void cbNumeroManzana_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nManzana = cbNumeroManzana.Text;
            string idManzanaActual = ws.getIdManzana(nManzana, idPredio);
            string lotesXmanzana = ws.contarLotes(idManzanaActual, idPredio);
            txtNumeroLote.Text = lotesXmanzana;
            manzanaPredio = true;

        }
    }//cierre clase frmAltaPredio
}
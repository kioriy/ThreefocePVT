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
        public string numeroLoteActual;
        public string idPredio;
        public string idManzana;
        

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

            //string nombrePredio = ws.cargaColumnaTablaPredio("nombre_predio");
            //string[] splitPredio = nombrePredio.Split(new char[] { ',' });

            while (dataGridView1.RowCount > 1)
            {

                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);

            }

            string infoPredio = ws.getinfoPredio();
            string[] splitInfoPredio = infoPredio.Split(new char[] { '|' });
           
            foreach (string datos in splitInfoPredio) {
                string[] splitPredio = datos.Split(new char[] { ',' });
                dataGridView1.Rows.Add(splitPredio[0], splitPredio[1], splitPredio[2], splitPredio[3]);

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
                txtNumManzanaLote.Visible = true;
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

                            

                            if (Convert.ToInt32(numeroManzanas) > 0)
                            {
                                btnModificar.Visible = true;
                                txtNumManzanaLote.Visible = true;
                                cmbModificar.Text = "Manzanas";
                                lNumeroManzana.Visible = true;
                                txtNumManzanaLote.Text = numeroManzanas;

                            }
                            else
                            {
                                gbRegistrarLotes.Visible = false;
                                lNumeroManzana.Visible = false;
                                cmdGeneraManzanas.Visible = false;
                                btnModificaLote.Visible = true;
                                btnModificar.Visible = false;
                                cmdGenerarLotes.Visible = false;
                                txtNumManzanaLote.Visible = true;
                                cmbModificar.Text = "Lotes";
                                string numeroLots = ws.contarLotes("0", id_predio);
                                txtNumManzanaLote.Text = numeroLots;
                                lNumeroLotes.Visible = true;

                              

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

        public void insertaManzanas(int opcion, string datos){
            lManzana.Visible = true;
            lLotes.Visible = true;
            txtNumManzanaLote.Visible = true;
            cbNumeroManzana.Visible = true;
            string respuestaRegistrarManzana;
            string[] datosManzana = datos.Split(new char[] { ',' });
            string idPredio = Convert.ToString(txtIdPredio.Text);
            int manzanasActual = Convert.ToInt32(datosManzana[0]) + 1;

            if (opcion == 1)
            {
                int i = Convert.ToInt32(txtNumManzanaLote.Text);
                for (int x = 0; x < i; x++)
                {
                    cbNumeroManzana.Items.Add(x + 1);

                }

                respuestaRegistrarManzana = ws.registraManzana("0", idPredio, datosManzana[1]);
                MessageBox.Show(respuestaRegistrarManzana);
                gbRegistrarLotes.Visible = true;
                txtNumeroLote.Visible = true;
                cmdGenerarLotes.Visible = true;
                cmdGeneraManzanas.Visible = false;
                
            }
            if (opcion == 2) {

                respuestaRegistrarManzana = ws.registraManzana(Convert.ToString(manzanasActual), idPredio, datosManzana[1]);
                int i = Convert.ToInt32(datosManzana[1]);
                    for (int x = 0; x < i; x++)
                    {
                        cbNumeroManzana.Items.Add(x + 1);

                    }
                    btnModificar.Visible = false;
                    cmdGeneraManzanas.Visible = false;
                    cmdGenerarLotes.Visible = true;
                    gbRegistrarLotes.Visible = true;
                    btnModificaLote.Visible = true;
                    txtNumeroLote.Visible = true;
            }

           
        }

        public void generaLotes(int opcion, string datos) {
            bool bandera = false;
            string numeroLote = txtNumeroLote.Text;
            string []desglosaDatos = datos.Split(new char[] { ',' });
            string idManzana = ws.getIdManzana(desglosaDatos[0], idPredio);
            int lotesActual = 0;
            if (Convert.ToInt32(desglosaDatos[2]) > 0)
            {
                lotesActual = Convert.ToInt32(desglosaDatos[2]) + 1;
            }
            int items = cbNumeroManzana.Items.Count;
           

            switch(opcion){
                case 1:

                    string resgitraLotesM = ws.registraLote("0", idPredio, idManzana, desglosaDatos[1]);
                     MessageBox.Show(resgitraLotesM);
                   

                    if (cbNumeroManzana.SelectedIndex < (items - 1))
                        {
                                cbNumeroManzana.SelectedIndex += 1;
                        }
                   else
                        {
                                 bandera = true;
                        }
                    break;

                case 2:
                       string resgitraMasLotesM = ws.registraLote(Convert.ToString(lotesActual), idPredio, idManzana, desglosaDatos[1]);
                       MessageBox.Show(resgitraMasLotesM);
                       if (cbNumeroManzana.SelectedIndex < (items - 1))
                       {
                           cbNumeroManzana.SelectedIndex += 1;
                       }
                       else
                       {
                           bandera = true;
                       }
                    break;

                case 3:
                    string resgitraMasLotes = ws.registraLote(Convert.ToString(lotesActual), idPredio, "0", desglosaDatos[1]);
                       MessageBox.Show(resgitraMasLotes);
                       bandera = true;
                    break;

                case 4:
                         string resgitraSoloLotes = ws.registraLote("0", idPredio, "0", desglosaDatos[1]);
                         MessageBox.Show(resgitraSoloLotes);
                         bandera = true;
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
            if(predio == false){
                MessageBox.Show("Primero debes ingresar un predio!");
            }
            else if(txtNumManzanaLote.Text.Length == 0){
                MessageBox.Show("Ingresa el numero de manzanas que deseas registrar");
            }else{
            string manzanasAgregar;
            string parametro;

            
                manzanasAgregar = txtNumManzanaLote.Text;
                parametro =  "0," + manzanasAgregar;
                insertaManzanas(1, parametro);
            }
            cargarPredios();

                 
        }
     
        private void cmdGenerarLotes_Click(object sender, EventArgs e)//boton generar lote
        {
            String cantidadManzas = ws.contarManzanas(idPredio);
            int manzana = Convert.ToInt32(cantidadManzas);
            string indexManzana;
            string lotesIngresar;
            string parametro;

            if (manzana > 0)
            {
                indexManzana = cbNumeroManzana.Text;
                lotesIngresar = txtNumeroLote.Text;
                parametro = indexManzana + "," + lotesIngresar+",0";
                generaLotes(1, parametro);
                
            }
            else {
                lotesIngresar = txtNumManzanaLote.Text;
                parametro = "0," + lotesIngresar + ",0";
                generaLotes(4, parametro);
                
            
            }
            
            cargarPredios();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            String cantidadManzas = ws.contarManzanas(idPredio);
            int manzana = Convert.ToInt32(cantidadManzas);
            string manzanasAgregar;
            string parametro;

            if (manzana > 0)
            {
                manzanasAgregar = txtNumManzanaLote.Text;
                parametro = cantidadManzas + "," + manzanasAgregar;
                insertaManzanas(2, parametro);
            }
            cargarPredios();
        }

        private void btnModificaLote_Click(object sender, EventArgs e)
        {
            String cantidadManzas = ws.contarManzanas(idPredio);
            String cantidadLotesconM = ws.contarLotes(cbNumeroManzana.Text, idPredio);
            String cantidadLotesSinM = ws.contarLotes("0", idPredio);

            int manzana = Convert.ToInt32(cantidadManzas);
            int lotesManzana = Convert.ToInt32(cantidadLotesconM);
            int soloLotes = Convert.ToInt32(cantidadLotesSinM);
            string indexManzana;
            string lotesIngresar;
            string parametro;

            if (manzana > 0 && lotesManzana == 0) {
                indexManzana = cbNumeroManzana.Text;
                lotesIngresar = txtNumeroLote.Text;
                parametro = indexManzana+","+lotesIngresar+",0";
                generaLotes(1, parametro);
            }else
            if (manzana > 0 && lotesManzana > 0) {
                indexManzana = cbNumeroManzana.Text;
                lotesIngresar = txtNumeroLote.Text;
                parametro = indexManzana + "," + lotesIngresar+","+cantidadLotesconM;
                generaLotes(2, parametro);
            
            }else
            if (soloLotes> 0) {
                lotesIngresar = txtNumManzanaLote.Text;
                parametro = "0,"+lotesIngresar + "," + cantidadLotesSinM;
                generaLotes(3, parametro);
            }else
            if (soloLotes == 0) {
                lotesIngresar = txtNumManzanaLote.Text;
                parametro = "0," + lotesIngresar + ",0";
                generaLotes(4, parametro);
            }

            //cargaLotes("modificar");
            cargarPredios();
        }

        private void cmbModificar_SelectedIndexChanged(object sender, EventArgs e)
        {
            String NumeroManzanas = ws.contarManzanas(idPredio);
            int cantidadMAnzanas = Convert.ToInt32(NumeroManzanas);

            if (cmbModificar.Text == "Manzanas") {
                gbRegistrarLotes.Visible = false;
                btnModificaLote.Visible = false;
                btnModificar.Visible = true;
                txtNumManzanaLote.Visible = true;
                txtNumManzanaLote.Text = NumeroManzanas;
                lNumeroManzana.Visible = true;
                lNumeroLotes.Visible = false;
            }
            if (cmbModificar.Text == "Lotes" && cantidadMAnzanas >0)
            {
                gbRegistrarLotes.Visible = true;
                btnModificaLote.Visible = true;
                btnModificar.Visible = false;
                txtNumManzanaLote.Visible = false;
                lNumeroManzana.Visible = false;
                //string manzanas = ws.cargaColumnaTablaManzana(idPredio, "n_manzana");
                string manzanas = txtNumManzanaLote.Text;
                string[] splitManzanas = manzanas.Split(new char[] { ',' });

                foreach (string manzana in splitManzanas)
                {
                    int agregar = Convert.ToInt32(manzana);
                   
                    cbNumeroManzana.Items.Add(agregar);
                }

            }
            else if(cmbModificar.Text == "Lotes" && cantidadMAnzanas == 0)
            {
                btnModificar.Visible = false;
                gbRegistrarLotes.Visible = false;
                txtNumManzanaLote.Visible = true;
                lNumeroManzana.Visible = false;
                lNumeroLotes.Visible = true;
                btnModificaLote.Visible = true;
            }
        }

        private void cbNumeroManzana_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nManzana = cbNumeroManzana.Text;
            string idManzanaActual = ws.getIdManzana(nManzana, idPredio);
            string lotesXmanzana = ws.contarLotes(idManzanaActual, idPredio);
            txtNumeroLote.Text = lotesXmanzana;
        
            //manzanaPredio = true;

        }
    }//cierre clase frmAltaPredio
}
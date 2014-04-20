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
    public partial class MedidaLote : Form
    {

        public MedidaLote()
        {
            InitializeComponent();
            llenarCombos();
        }

        
        WSpvt.PVT medida = new WSpvt.PVT();
        public string idLote;

        private void cmbMedida1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnMedidas_Click(object sender, EventArgs e)
        {
            int este, oeste, norte, sur;
            este = oeste = norte = sur = 0;
            if (cmbMedidaEste.Text.Length != 0)
            {
                este = Convert.ToInt16(cmbMedidaEste.Text);
            }
            if (cmbMedidaOeste.Text.Length != 0)
            {
                oeste = Convert.ToInt16(cmbMedidaOeste.Text);
            }
            if (cmbMedidaNorte.Text.Length != 0)
            {
                norte = Convert.ToInt16(cmbMedidaNorte.Text);
            }
            if (cmbMedidaSur.Text.Length != 0)
            {
                sur = Convert.ToInt16(cmbMedidaSur.Text);
            }
            bool banderaN, banderaS, banderaO, banderaE;
            banderaE = banderaN = banderaO = banderaS = false;
            int nuevoN, nuevoS, nuevoE, nuevoO;
            nuevoE = nuevoN = nuevoO = nuevoS = 0;

            string respuestaCargaLote = medida.getMedida();

            string[] medidaL = respuestaCargaLote.Split(new char[] { ',' });

            if (cmbMedidaNorte.Text.Length != 0)
            {
                foreach (string medidas in medidaL)
                {
                    int compara = Convert.ToInt16(medidas);

                    if (compara == norte)
                    {
                        banderaN = true;
                        break;

                    }
                }
                if (banderaN == false)
                {
                    nuevoN = norte;
                }

            }
            if (cmbMedidaSur.Text.Length != 0)
            {
                foreach (string medidas in medidaL)
                {
                    int compara = Convert.ToInt16(medidas);

                    if (compara == sur)
                    {
                        banderaS = true;
                        break;

                    }
                }
                if (banderaS == false)
                {
                    nuevoS = sur;
                }

            }
            if (cmbMedidaNorte.Text.Length != 0)
            {
                foreach (string medidas in medidaL)
                {
                    int compara = Convert.ToInt16(medidas);

                    if (compara == este)
                    {
                        banderaE = true;
                        break;

                    }
                }
                if (banderaE == false)
                {
                    nuevoE = este;
                }

            }
            if (cmbMedidaNorte.Text.Length != 0)
            {
                foreach (string medidas in medidaL)
                {
                    int compara = Convert.ToInt16(medidas);

                    if (compara == oeste)
                    {
                        banderaO = true;
                        break;

                    }
                }
                if (banderaO == false)
                {
                    nuevoO = oeste;
                }

            }

            if (nuevoN != 0) {
                string nuevaMedida = Convert.ToString(nuevoN);
                string respuestaNuevaM = medida.registraMedida(nuevaMedida);
              //  MessageBox.Show(respuestaNuevaM);
            }
            if (nuevoS != 0 && nuevoN != nuevoS)
            {
                string nuevaMedida = Convert.ToString(nuevoS);
                string respuestaNuevaM = medida.registraMedida(nuevaMedida);
              //  MessageBox.Show(respuestaNuevaM);
            }
            if (nuevoE != 0 && nuevoE != nuevoS)
            {
                string nuevaMedida = Convert.ToString(nuevoE);
                string respuestaNuevaM = medida.registraMedida(nuevaMedida);
              //  MessageBox.Show(respuestaNuevaM);
            }
            if (nuevoO != 0 && nuevoO != nuevoE)
            {
                string nuevaMedida = Convert.ToString(nuevoO);
                string respuestaNuevaM = medida.registraMedida(nuevaMedida);
              //  MessageBox.Show(respuestaNuevaM);
            }

            //MessageBox.Show("id Lote: "+idLote);
            string respInsertar = medida.insertaMedida(idLote, cmbMedidaNorte.Text, cmbMedidaSur.Text, cmbMedidaEste.Text, cmbMedidaOeste.Text);
            //MessageBox.Show(respInsertar);
            if (respInsertar.Length != 0) {
                this.Visible = false;
            }

        }


        private void llenarCombos()
        {

           

            string respuestaCargaLote = medida.getMedida();

            string[] splitLotes = respuestaCargaLote.Split(new char[] { ',' });

            foreach (string medidas in splitLotes)
            {
                cmbMedidaEste.Items.Add(medidas);
                cmbMedidaNorte.Items.Add(medidas);
                cmbMedidaOeste.Items.Add(medidas);
                cmbMedidaSur.Items.Add(medidas);
            }
            
        }
    }
}

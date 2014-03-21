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
        public FrmAltaPredio()
        {
            InitializeComponent();
            cbSeleccionaManzanaLote.Items.Add("Manzanas");
            cbSeleccionaManzanaLote.Items.Add("Lotes");
        }

        private void cbSeleccionaManzanaLote_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)cbSeleccionaManzanaLote.SelectedItem == "Manzanas"){
                
                lNumeroManzana.Visible = true;
                lNumeroLotes.Visible = false;
                txtNumManzanaLote.Visible = true;
                cmdGenerarLotes.Visible = false;
                cmdGeneraManzanas.Visible = true;
                }


            if ((string)cbSeleccionaManzanaLote.SelectedItem == "Lotes"){

                lNumeroLotes.Visible = true;
                lNumeroManzana.Visible = false;
                txtNumManzanaLote.Visible = true;
                cmdGenerarLotes.Visible = true;
                cmdGeneraManzanas.Visible = false;
            }
        }

        private void cmdGeneraManzanas_Click(object sender, EventArgs e)
        {
            lManzana.Visible = true;
            lLotes.Visible = true;
            txtNumeroLote.Visible = true;
            txtNumManzanaLote.Visible = true;
            gbRegistrarLotes.Visible = true;
            cmdGeneraManzanas.Visible = false;
            cmdGenerarLotes.Visible = true;

        }

       
  
    }//cierre clase frmAltaPredio
}

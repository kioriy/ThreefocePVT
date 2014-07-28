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
    public partial class borrar : Form
    {
        WSpvt.PVT ws = new WSpvt.PVT();
        string respuestaNombreComprador = "";
        string[] splitId;
        string datosVenta = "";
        string[] splitDatosVenta;
        string datosPredio = "";
        string[] splitPredio;
        string[] splitIdLote;

        DateTime proximaFechaPago;

        public borrar()
        {
            InitializeComponent();
            llenaComboComprador();
            
        }

        public void llenaComboComprador()
        {

            string idComprador = ws.getIdCompradordeVenta();
            string respuestaNombreComprador = ws.getNombreComprador(idComprador);
            string[] splitComprador = respuestaNombreComprador.Split(new char[] { ',' });
            splitId = idComprador.Split(new char[] { ',' });

            foreach (string comprador in splitComprador)
            {

                cbComprador.Items.Add(comprador);
            }
        }

        public void llenarDatos()
        {
            datosVenta = ws.getVenta(splitId[cbComprador.SelectedIndex]);

            splitDatosVenta = datosVenta.Split(new char[] { ',' });
            //MessageBox.Show(datosVenta);

            datosPredio = ws.getAllPredio(splitId[cbLote.SelectedIndex]);
            splitPredio = datosPredio.Split(new char[] { ',' });
            //MessageBox.Show(datosPredio);

            txtFechaDeCompra.Text = Convert.ToDateTime(splitDatosVenta[4]).ToString("d MMMM y");

            txtPredio.Text = splitPredio[0];
            txtManzana.Text = splitPredio[1];
            int distancia = ((DateTime.Today.Year * 12 + DateTime.Today.Month) -
                            (Convert.ToDateTime(splitDatosVenta[4]).Year * 12 + Convert.ToDateTime(splitDatosVenta[4]).Month)) + 1;
            txtPagoActual.Text = Convert.ToString(distancia);
        }

        private void cbComprador_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarComboLote();
        }

        private void proximoFechaDePago()
        {
            if (txtPagoActual.Text != "" && txtPagoFinal.Text != "")
            {
                Fecha obtenerProximoPago = new Fecha();

                proximaFechaPago = obtenerProximoPago.setProximoPago(dtpFecha.Value, txtPagoActual.Text);
            }
            else
            {
                MessageBox.Show("es necesario ingresar pagos:   /    ");
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            proximoFechaDePago();
            txtProximoPago.Text = Convert.ToString(proximaFechaPago);

        }

        private void cmdGeneraProximoPago_Click(object sender, EventArgs e)
        {
            int pagoActual = Convert.ToInt32(txtPagoActual.Text) + 1;
            string respuestaProximoPago = ws.registraProximoPago(splitDatosVenta[0], splitDatosVenta[2], Convert.ToString(proximaFechaPago), Convert.ToString(pagoActual), txtPagoFinal.Text);
            MessageBox.Show(respuestaProximoPago);
        }

        public void llenarComboLote()
        {
            cbLote.Items.Clear();

            string respuestaIdLoteDeVenta = ws.getIdLoteDeVenta(splitId[cbComprador.SelectedIndex]);//obtengo la lista de id de lotes
            splitIdLote = respuestaIdLoteDeVenta.Split(new char[] { ',' });//genero un arreglo con esa lista de id de lotes
            int tamañoSplit = splitIdLote.Length;                          //obtengo el tamaño del arreglo
            string[] numeroLotes = new string[splitIdLote.Length];         //creo un arreglo de numeroLotes el tamaño del 
            //arreglo es igual
            //al tamaño de id lotes.
            for (int i = 0; i < splitIdLote.Length; i++)
            {
                numeroLotes[i] = ws.getNumeroLote(splitIdLote[i]);//lleno el arreglo con los numeros de lotes
            }

            try
            {
                foreach (string idLotes in numeroLotes)
                {
                    cbLote.Items.Add(idLotes);//lleno el combobox de Lotes con el numero de lotes
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se ingreso ningun cliente");
            }

            if (tamañoSplit > 1)
                MessageBox.Show("Usuario con mas de una compra");

            cbLote.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarDatos();
        }

        //public void llenaComboComprador()
        //{

        //    cbComprador.Items.Clear();
        //    respuestaNombreComprador = ws.cargaComprador();
        //    string[] splitDatosComprador = respuestaNombreComprador.Split(new char[] { '|' });
        //    string[] splitComprador = splitDatosComprador[0].Split(new char[] { ',' });
        //    splitId = splitDatosComprador[1].Split(new char[] { ',' });

        //    foreach (string comprador in splitComprador)
        //    {
        //        cbComprador.Items.Add(comprador);
        //    }

            /*Dictionary<string, string> NombreIdComprador = new Dictionary<string, string>();

            foreach (string datos in splitDatosComprador)
            {
                string[] desgloseIdNombre = datos.Split(new char[] { '|' });
                cbNombre.Items.Add(desgloseIdNombre[0]);
               // NombreIdComprador.Add(desgloseIdNombre[0], desgloseIdNombre[1]);

            }
           MessageBox.Show("el comprador que esta en el index10 "+splitDatosComprador[4]);*/
        }

    //    public void llenarDatos() 
    //    {
    //        datosVenta = ws.getVenta(splitId[cbComprador.SelectedIndex]);
            
    //        splitDatosVenta = datosVenta.Split(new char[] { ',' });
    //        //MessageBox.Show(datosVenta);
            
    //        datosPredio = ws.getAllPredio(splitDatosVenta[1]);
    //        splitPredio = datosPredio.Split(new char[] { ',' });
    //        //MessageBox.Show(datosPredio);

    //        txtFechaDeCompra.Text = Convert.ToDateTime(splitDatosVenta[4]).ToString("d MMMM y");

    //        txtPredio.Text = splitPredio[0];
    //        txtManzana.Text = splitPredio[1];
    //        txtLote.Text = splitPredio[2];
    //        int distancia =  ((DateTime.Today.Year * 12 + DateTime.Today.Month) -
    //                        (Convert.ToDateTime(splitDatosVenta[4]).Year * 12 + Convert.ToDateTime(splitDatosVenta[4]).Month))+1;
    //        txtPagoActual.Text = Convert.ToString(distancia); 
    //    }

    //    private void cbComprador_SelectedIndexChanged(object sender, EventArgs e)
    //    {
    //        llenarDatos();
    //    }

    //    private void proximoFechaDePago()
    //    {
    //        if (txtPagoActual.Text != "" && txtPagoFinal.Text != "")
    //        {
    //            Fecha obtenerProximoPago = new Fecha();

    //            proximaFechaPago = obtenerProximoPago.setProximoPago(dtpFecha.Value, txtPagoActual.Text);
    //        }
    //        else
    //        {
    //            MessageBox.Show("es necesario ingresar pagos:   /    ");
    //        }
    //    }

    //    private void dtpFecha_ValueChanged(object sender, EventArgs e)
    //    {
    //        proximoFechaDePago();
    //        txtProximoPago.Text = Convert.ToString( proximaFechaPago);
    //    }

    //    private void cmdGeneraProximoPago_Click(object sender, EventArgs e)
    //    {
    //       int pagoActual = Convert.ToInt32(txtPagoActual.Text)+1;
    //       string respuestaProximoPago = ws.registraProximoPago(splitDatosVenta[0], splitDatosVenta[2], Convert.ToString(proximaFechaPago), Convert.ToString(pagoActual), txtPagoFinal.Text);
    //       MessageBox.Show(respuestaProximoPago);
    //    }
    //}
}

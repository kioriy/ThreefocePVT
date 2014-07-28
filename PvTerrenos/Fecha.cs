using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvTerrenos
{
    class Fecha
    {
        WSpvt.PVT ws = new WSpvt.PVT();
        //variable tipo datetime


        //constructor
        /*public Fecha(DateTime fecha, string pago_actual) {

            this.fecha = fecha;
            this.pago_actual = pago_actual;
        }*/

        public DateTime setProximoPago(DateTime fechaCompra, string pago_actual)
        {

            DateTime fechaProximoPago;
            int auxiliar = 0;

            for (int i = 1; i <= Convert.ToInt32(pago_actual); i++)
            {
                auxiliar = i;
            }
            return (fechaProximoPago = fechaCompra.AddMonths(auxiliar));
        }

        public DateTime setProximoPagoDos(DateTime ProximoPago)
        {
            ProximoPago = ProximoPago.AddMonths(1);
            return ProximoPago;
        }

        public Boolean estaEnMora(DateTime fechaProximoPago)
        {

            if (fechaProximoPago.AddDays(6) <= DateTime.Today)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean statusMora(string statusMora)
        {
            if (statusMora == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool mesYaEstaEnMora(DateTime proximoPago, string idVenta)
        {
            int bandera = 0;
            string respuestaFechaMora = ws.getFechaMora(idVenta);
            string[] splitFechaMora = respuestaFechaMora.Split(new char[] { ',' });

            foreach (string fechaMora in splitFechaMora)
            {
                DateTime fechaMoraCompara = Convert.ToDateTime(fechaMora);

                //for (int i = 0; )
                if (fechaMoraCompara.Year == DateTime.Today.Year && fechaMoraCompara.Month == DateTime.Today.Month)
                {
                    bandera++;
                }
            }
            if (bandera >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string ultimoMesEnMora(string idVenta)
        {
            string respuestaUltimoMesMora = ws.getFechaMora(idVenta);
            string[] splitUltimoMesMora = respuestaUltimoMesMora.Split(new char[] { ',' });

            int tamañoArreglo = splitUltimoMesMora.Length;

            return splitUltimoMesMora[tamañoArreglo - 1];
        }

        public string calculaMesesMorosos(Boolean esMoroso, Boolean statusMora, DateTime proximoPago, string idVenta, string monto, int actualizo)
        {
            DateTime hoy = DateTime.Today;

            int distancia = (hoy.Year * 12 + hoy.Month) - (Convert.ToDateTime(proximoPago).Year * 12 + Convert.ToDateTime(proximoPago).Month);
            DateTime AuxiliarProximoPago = proximoPago.AddMonths(distancia);

            if (/*proximoPago.AddDays(6).Day*/ AuxiliarProximoPago.AddDays(5) >= DateTime.Today)
            {
                hoy = DateTime.Today.AddMonths(-1);
            }

            double montoMora = 0;
            int auxiliar = 0;
            int auxiliar2 = 0;
            int maxMes = hoy.Month;
            int aMaxMes = 0;
            int bMaxMes = 0;
            string respuestaRegistraMora = "";

            /*for (int i = 1; proximoPago.Month <= hoy.AddMonths(-i).Month; i++)
             {

                 auxiliar = i; //en esta variable se guarda la distancia en meses de dos fecha "proximoPago"  y "fecha hoy" 
             }*/
            auxiliar = (hoy.Year * 12 + hoy.Month) - (Convert.ToDateTime(proximoPago).Year * 12 + Convert.ToDateTime(proximoPago).Month);

            if (esMoroso && !statusMora)//esta sentencia determinamos si la fecha de "proximoPago" ya entro en mora ademas se checa
            {                           //en el status para saber si ya habia entrado a este ciclo de ser asi no se hace todo el calculo de mora desde su ultima fecha no pagada              
                for (int i = 0; i <= auxiliar; i++)
                {
                    aMaxMes = i; //lleba el registro del mes en en que se esta efectuando la mora o moras ejemplo "mora de febrero en Marzo <-- esta variable seria Marzo"
                    bMaxMes = auxiliar - i; //varible que servira para recorrer los meses en el siguiente ciclo

                    for (int j = 0; j <= bMaxMes; j++)
                    { //este recorrera los meses hasta llegar al mes en fecha de proximo pago 

                        montoMora = Convert.ToDouble(monto) * 0.06;

                        DateTime mesPrincipal = proximoPago.AddMonths(auxiliar - aMaxMes);
                        DateTime mesRecorrido = mesPrincipal.AddMonths(-j);

                        respuestaRegistraMora = ws.registraMora(idVenta, Convert.ToString(montoMora), hoy.ToString(), mesRecorrido.ToString(), mesPrincipal.ToString(),"0");
                    }
                } ws.updateStatusMora(idVenta);
                return respuestaRegistraMora;
            }

            if (esMoroso && statusMora && !mesYaEstaEnMora(proximoPago, idVenta) && /*proximoPago.AddDays(6).Day*/AuxiliarProximoPago.AddDays(6) <= DateTime.Today)
            {
                string ultimoMes = ultimoMesEnMora(idVenta);

                for (int i = 1; Convert.ToDateTime(ultimoMes).Month <= hoy.AddMonths(-i).Month; i++)
                {
                    auxiliar = i;
                }
                for (int i = 1; proximoPago.Month <= hoy.AddMonths(-i).Month; i++)
                {
                    auxiliar2 = i;
                }

                for (int i = 0; i < auxiliar; i++)
                {
                    aMaxMes = i; //lleba el registro del mes en en que se esta efectuando la mora o moras ejemplo "mora de febrero en Marzo <-- esta variable seria Marzo"
                    bMaxMes = auxiliar2 - i; //varible que servira para recorrer los meses en el siguiente ciclo

                    for (int j = 0; j <= bMaxMes; j++)
                    {//este recorrera los meses hasta llegar al mes en fecha de proximo pago 

                        montoMora = Convert.ToDouble(monto) * 0.06;

                        DateTime mesPrincipal = Convert.ToDateTime(ultimoMes).AddMonths(auxiliar - aMaxMes);
                        DateTime mesRecorrido = mesPrincipal.AddMonths(-j);

                        respuestaRegistraMora = ws.registraMora(idVenta, Convert.ToString(montoMora), hoy.ToString(), mesRecorrido.ToString(), mesPrincipal.ToString(),"0");
                    }
                } return (respuestaRegistraMora + " se registro nueva mora del mes de "+DateTime.Today.ToString("MMMM").ToUpper()+" para este usuario");
            }
            else if (actualizo != 1)
            {
                return "Usuario con mora \n\nPero no genera nueva mora del mes de "+DateTime.Today.ToString("MMMM").ToUpper();
            }
            return "Usuario con pago al corriente";
        }
    }
}

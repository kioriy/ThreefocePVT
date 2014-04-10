using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvTerrenos
{
    class Fecha
    {
        //variable tipo datetime
        
    
        //constructor
        /*public Fecha(DateTime fecha, string pago_actual) {

            this.fecha = fecha;
            this.pago_actual = pago_actual;
        }*/

        public DateTime setProximoPago(DateTime fechaCompra, string pago_actual) {

            DateTime fechaProximoPago;
            int auxiliar = 0;

            for (int i = 1; i <= Convert.ToInt32(pago_actual); i++) {
                auxiliar = i;
            }
            return (fechaProximoPago = fechaCompra.AddMonths(auxiliar));
        }

        public Boolean estaEnMora(DateTime fechaProximoPago) {

            if (fechaProximoPago <= DateTime.Today.AddDays(6))
            {
                return true;
            }
            else {
                return false;
            }
        }

        public Boolean statusMora(string statusMora) {

            if (statusMora == "1")
            {
                return true;
            }
            else {
                return false;
            }
        }

       public string calculaMesesMorosos(Boolean esMoroso, Boolean statusMora, DateTime proximoPago, string idVenta, string monto) {

           WSpvt.PVT ws = new WSpvt.PVT();

           DateTime hoy = DateTime.Today;

           if (proximoPago.Day <= DateTime.Today.AddDays(6).Day)
           {
               hoy = DateTime.Today.AddMonths(-1);
           }
           
           double montoMora = 0;
           int auxiliar = 0;
           int minMes = proximoPago.Month;
           int maxMes = hoy.Month;
           int aMaxMes = 0;
           int bMaxMes = 0;
           string respuestaRegistraMora= "";

           for (int i = 1; proximoPago <= hoy.AddMonths(-i); i++) {
               auxiliar = i;
           }

               if (esMoroso && !statusMora)
               {

                   for (int i = 0; i <= auxiliar; i++)
                   {
                       aMaxMes = i;
                       bMaxMes = auxiliar-i;

                       for (int j = 0; j <= bMaxMes; j++) {

                           montoMora = Convert.ToDouble(monto) * 0.06;

                           DateTime mesPrincipal = proximoPago.AddMonths(auxiliar -aMaxMes);
                           DateTime mesRecorrido = mesPrincipal.AddMonths(-j);

                           respuestaRegistraMora = ws.registraMora(idVenta, Convert.ToString(montoMora), hoy.ToString(), mesRecorrido.ToString(), mesPrincipal.ToString());
                       }
                   }
               }
            /*if (esMoroso && statusMora) { 


            
            }*/
            return respuestaRegistraMora;
        }

       /* public DateTime setDiferenciaFecha(DateTime fechaInicio, DateTime FechaFinal) {



            return;
        }*/
    }
}

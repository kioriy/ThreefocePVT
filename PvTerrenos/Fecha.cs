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

            if (fechaProximoPago.AddDays(6) <= DateTime.Today)
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
           
           double montoMora = 0;
           int minMes = proximoPago.Month;
           int maxMes = hoy.Month;
           int aMaxMes = 0;
           int bMaxMes = 0;
           string respuestaRegistraMora= "";
            

            if (esMoroso && !statusMora) { 
                
                for (int i = 0; minMes <= maxMes-i; i++) {//Es el mes donde se genraran la moras
                        
                        aMaxMes = i;
                        bMaxMes = maxMes-i;

                    for (int j = 0; minMes <= bMaxMes-j ; j++ ) {//es el ciclo que generara las moras 

                        montoMora = Convert.ToDouble(monto) * 0.06;  

                        DateTime mesPrincipal = hoy.AddMonths(-aMaxMes);
                        DateTime mesRecorrido = mesPrincipal.AddMonths(-j);

                        respuestaRegistraMora= ws.registraMora(idVenta, Convert.ToString(montoMora), hoy.ToString(), mesRecorrido.ToString(),mesPrincipal.ToString());
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

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
                return false;
            }
            else {
                return true;
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

       public string calculaMesesMorosos(Boolean esMoroso, Boolean statusMora, DateTime proximoPago) {

            if (esMoroso && !statusMora) { 
                
                int fechaDeCambio = Convert.ToInt32(DateTime.Today.Month);
                
                for (int incremento = Convert.ToInt32(proximoPago.Month); incremento <= fechaDeCambio; fechaDeCambio--) { 
                    
                    for()
                
                
                
                }
            
            }
            if (esMoroso && statusMora) { 


            
            }
            
        
        
        
        }
       /* public DateTime setDiferenciaFecha(DateTime fechaInicio, DateTime FechaFinal) {



            return;
        }*/
    }
}

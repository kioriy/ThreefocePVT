﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvTerrenos
{
    class Fecha
    {
        //variable tipo datetime
        DateTime fecha;
        string pago_actual;
        string pago_final;
        //constructor
        public Fecha(DateTime fecha, string pago_actual) {

            this.fecha = fecha;
            this.pago_actual = pago_actual;
        }

        public DateTime setProximoPago(DateTime fechaCompra, string pago_actual) {

            DateTime fechaProximoPago;
            int auxiliar = 0;

            for (int i = 1; i <= Convert.ToInt32(pago_actual); i++) {
                auxiliar = i;
            }
            return (fechaProximoPago = fechaCompra.AddMonths(auxiliar));
        }
    }
}

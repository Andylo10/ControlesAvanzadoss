using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlesAvanzados.Clases
{
    public class Venta
    {
        public int Anio { get; set; }
        public int Mes { get; set; }
        public string Departamento { get; set; }
        public decimal Ventas { get; set; } 

        public Venta(int anio, int mes, string departamento, decimal ventas)
        {
            Anio = anio;
            Mes = mes;
            Departamento = departamento;
            Ventas = ventas;
        }
    }
}
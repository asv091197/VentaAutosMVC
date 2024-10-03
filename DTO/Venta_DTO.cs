using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Venta_DTO
    {
        public int ID_Venta { get; set; }
        public int Auto_ID { get; set; }
        public int Cliente_ID { get; set; }
        public int Vendedor_ID { get; set; }
        public string Estatus { get; set; }
        public int Agencia_ID { get; set; }
        public int IVA { get; set; }
        public DateTime Fecha { get; set; }

       
    }
}

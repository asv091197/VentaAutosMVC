using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public  class Auto_DTO
    {
        public int ID_Auto { get; set; }
        public int Marca_ID { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public int Cilindros { get; set; }
        public int Precio { get; set; }
        public int Anio { get; set; }
        public int Tipo_ID { get; set; }
        public bool Estado { get; set; }
    }
}

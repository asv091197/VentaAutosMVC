using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Vendedor_DTO
    {
        public int ID_Vendedor { get; set; }
        public string Nombre { get; set; }
        public string APP { get; set; }
        public string APM { get; set; }
        public string Matricula { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int Direccion_ID { get; set; }

        public string NombreCompleto => $"{Nombre} {APP} {APM}".Trim();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VentaAutosMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuarios
    {
        public int ID_Usuario { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Contraseña { get; set; }
        public Nullable<int> Rol_ID { get; set; }
        public Nullable<int> Cliente_ID { get; set; }
        public Nullable<int> Vendedor_ID { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Roles Roles { get; set; }
        public virtual Vendedor Vendedor { get; set; }
    }
}

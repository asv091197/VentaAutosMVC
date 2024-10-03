using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VentaAutosMVC.Utilidades
{

    public enum NotificationType
    {
        success,
        error,
        warning,
        info
    }

    public class SweetAlert
    {
        public static string Sweet_Alert(string title, string msg, NotificationType nt)
        {
            return $@"
            <script>
                Swal.fire({{
                    title: '{title}',
                    text: '{msg}',
                    icon: '{nt.ToString()}',
                    confirmButtonText: 'Aceptar'
                }});
            </script>";
        }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DasGlobalApp.Web.Models
{
    public class Colaborador
    {
        public int Id {get; set;}
        public int IdSucursal {get; set;}
        public Sucursal Sucursal {get; set;} = null!;
        public string Nombre {get; set;} = string.Empty;
        public string CUI {get; set;} = string.Empty;
    }
}
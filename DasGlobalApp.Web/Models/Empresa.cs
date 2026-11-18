using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DasGlobalApp.Web.Models
{
    public class Empresa
    {
        public int Id {get; set;}
        public string Nombre {get; set;} = string.Empty;
        public string Pais {get; set;} = string.Empty;
        public ICollection<Sucursal> Sucursales {get; set;} = new List<Sucursal>();
    }
}
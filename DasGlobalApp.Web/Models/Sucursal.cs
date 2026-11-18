using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace DasGlobalApp.Web.Models
{
    public class Sucursal
    {
        public int Id {get; set;}
        public int IdEmpresa {get; set;}
        public Empresa Empresa {get; set;} = null!;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public ICollection<Colaborador> Colaboradores { get; set; } = new List<Colaborador>();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DasGlobalApp.Web.Models
{
    [Table("Sucursales")]
    public class Sucursal
    {
        [Key]
        [Column("Id")]
        public int Id {get; set;}
        [ForeignKey("EmpresaId")]
        public int IdEmpresa {get; set;}
        [Column("Nombre")]
        public string Nombre {get; set;} = string.Empty;
        
        public Empresa Empresa {get; set;} = null!;
        [Column("Direccion")]
        public string Direccion { get; set; } = string.Empty;
        [Column("Telefono")]
        public string Telefono { get; set; } = string.Empty;
        public ICollection<Colaborador> Colaboradores { get; set; } = new List<Colaborador>();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DasGlobalApp.Web.Models
{
    [Table("Empresas")]
    public class Empresa
    {
        [Key]
        [Column("Id")]
        public int Id {get; set;}
        [Column("Nombre")]
        public string Nombre {get; set;} = string.Empty;
        [Column("Pais")]
        public string Pais {get; set;} = string.Empty;
        public ICollection<Sucursal> Sucursales {get; set;} = new List<Sucursal>();
    }
}
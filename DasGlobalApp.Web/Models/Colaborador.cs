using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DasGlobalApp.Web.Models
{
    [Table("Colaboradores")]
    public class Colaborador
    {   
        [Key]
        [Column("Id")]
        public int Id {get; set;}

        [ForeignKey("Sucursal")]
        [Column("SucursalId")]
        public int IdSucursal {get; set;}
        public Sucursal Sucursal {get; set;} = null!;

        [Column("Nombre")]
        public string Nombre {get; set;} = string.Empty;

        [Column("CUI")]
        public string CUI {get; set;} = string.Empty;
    }
}
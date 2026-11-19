using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace DasGlobalApp.Web.DTOs
{
   public class EmpresaDto
    {
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [JsonPropertyName("pais")]
        public string Pais { get; set; } = string.Empty;

        [JsonPropertyName("sucursales")]
        public List<SucursalDto> Sucursales { get; set; } = new();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace DasGlobalApp.Web.DTOs
{
    public class SucursalDto
    {
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [JsonPropertyName("direccion")]
        public string Direccion { get; set; } = string.Empty;

        [JsonPropertyName("telefono")]
        public string Telefono { get; set; } = string.Empty;

        [JsonPropertyName("colaboradores")]
        public List<ColaboradorDto> Colaboradores { get; set; } = new();
    }
    public class SucursalPatchDto
    {
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [JsonPropertyName("direccion")]
        public string Direccion { get; set; } = string.Empty;

        [JsonPropertyName("telefono")]
        public string Telefono { get; set; } = string.Empty;

        [JsonPropertyName("colaboradores")]
        public List<ColaboradorDto> Colaboradores { get; set; } = new();

    }

    public class SucursalRespuestaDto
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string NombreEmpresa { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public List<ColaboradorRespuestaDto> Colaboradores { get; set; } = new();
    }

    public class ColaboradorRespuestaDto
    {
        public int Id { get; set; }
        public int IdSucursal { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string CUI { get; set; } = string.Empty;
    }
}
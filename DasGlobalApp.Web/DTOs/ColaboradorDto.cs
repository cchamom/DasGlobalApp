using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace DasGlobalApp.Web.DTOs
{
    public class ColaboradorDto
    {
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("CUI")]
        public string CUI { get; set; }
    }
}
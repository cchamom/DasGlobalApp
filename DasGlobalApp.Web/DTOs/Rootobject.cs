using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace DasGlobalApp.Web.DTOs
{
    public class Rootobject
    {
        [JsonPropertyName("empresa")]
        public EmpresaDto Empresa { get; set; }
    }
}
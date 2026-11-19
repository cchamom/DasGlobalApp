using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using DasGlobalApp.Web.DTOs;
using DasGlobalApp.Web.Interfaces;
using DasGlobalApp.Web.Models;

namespace DasGlobalApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly ISucursalService _sucursalService;

        public EmpresaController(ISucursalService sucursalService)
        {
            _sucursalService = sucursalService;
        }

        [HttpPost("cargar-json")]
        public async Task<IActionResult> CargarJson(IFormFile archivoJson)
        {
            if (archivoJson == null || archivoJson.Length == 0)
                return BadRequest(new { mensaje = "El archivo JSON es obligatorio o esta vacio." });

            try
            {
                using var stream = archivoJson.OpenReadStream();
                var datosJson = await JsonSerializer.DeserializeAsync<Rootobject>(stream);

                if (datosJson == null)
                    return BadRequest(new { mensaje = "No se pudo convertir el archivo JSON." });

                await _sucursalService.GuardarAsync(datosJson);
                return Ok(new { mensaje = "Datos cargados y guardados exitosamente en la base de datos." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al procesar el archivo.", detalle = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Sucursal>>> ObtenerSucursales()
        {
            var sucursales = await _sucursalService.ObtenerSucursalesAsync();
            return Ok(sucursales);
        }

        [HttpPatch("sucursal/{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] SucursalPatchDto sucursalDto)
        {
            if (sucursalDto == null)
                return BadRequest(new { mensaje = "No hay datos para poder actualizar" });

            var existe = await _sucursalService.ObtenerSucursalPorIdAsync(id);
            if (existe == null)
                return NotFound(new { mensaje = "Sucursal no encontrada" });

            await _sucursalService.ActualizarSucursalAsync(id, sucursalDto);
            return Ok(new { mensaje = "Se actualizo con exito" });
        }

        [HttpDelete("sucursal/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var eliminar = await _sucursalService.ObtenerSucursalPorIdAsync(id);
            if (eliminar == null)
                return NotFound(new { mensaje = "Sucursal no encontrada en la base de datos" });

            await _sucursalService.EliminarSucursalAsync(id);
            return Ok(new { mensaje = "Sucursal eliminada" });
        }
    }
}
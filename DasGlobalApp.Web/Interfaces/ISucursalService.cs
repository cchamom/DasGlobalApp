using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DasGlobalApp.Web.DTOs;
using DasGlobalApp.Web.Models;

namespace DasGlobalApp.Web.Interfaces
{
    public interface ISucursalService
    {
        Task GuardarAsync(Rootobject jsonData);
        Task<List<SucursalRespuestaDto>> ObtenerSucursalesAsync();
        Task<Sucursal?> ObtenerSucursalPorIdAsync(int id);
        Task ActualizarSucursalAsync(int id, SucursalPatchDto dto);
        Task EliminarSucursalAsync(int id);
    }
}
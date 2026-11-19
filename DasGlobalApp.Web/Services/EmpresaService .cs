using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DasGlobalApp.Web.Data;
using DasGlobalApp.Web.DTOs;
using DasGlobalApp.Web.Interfaces;
using DasGlobalApp.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace DasGlobalApp.Web.Services
{
    public class EmpresaService : ISucursalService
    {
        private readonly ApplicationDbContext _context;

        public EmpresaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SucursalRespuestaDto>> ObtenerSucursalesAsync()
{
    return await _context.Sucursales
        .Include(s => s.Empresa)
        .Include(s => s.Colaboradores)
        .Select(s => new SucursalRespuestaDto
        {
            Id = s.Id,
            IdEmpresa = s.IdEmpresa,
            NombreEmpresa = s.Empresa.Nombre,
            Nombre = s.Nombre,
            Direccion = s.Direccion,
            Telefono = s.Telefono,
            Colaboradores = s.Colaboradores.Select(c => new ColaboradorRespuestaDto
            {
                Id = c.Id,
                IdSucursal = c.IdSucursal,
                Nombre = c.Nombre,
                CUI = c.CUI
            }).ToList()
        })
        .ToListAsync();
}

        public async Task<Sucursal?> ObtenerSucursalPorIdAsync(int id)
        {
            return await _context.Sucursales
                .Include(s => s.Empresa)
                .Include(s => s.Colaboradores)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task GuardarAsync(Rootobject jsonData)
        {
            if (jsonData?.Empresa == null) return;

            var empresaDto = jsonData.Empresa;
            var empresa = new Empresa
            {
                Nombre = empresaDto.Nombre,
                Pais = empresaDto.Pais,
                Sucursales = empresaDto.Sucursales.Select(s => new Sucursal
                {
                    Nombre = s.Nombre,
                    Direccion = s.Direccion,
                    Telefono = s.Telefono,
                    Colaboradores = s.Colaboradores.Select(c => new Colaborador
                    {
                        Nombre = c.Nombre,
                        CUI = c.CUI
                    }).ToList()
                }).ToList()
            };

            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Empresa>> ObtenerEmpresaAsync()
        {
            return await _context.Empresas
                .Include(e => e.Sucursales)
                    .ThenInclude(s => s.Colaboradores)
                .ToListAsync();
        }

        public async Task ActualizarSucursalAsync(int id, SucursalPatchDto dto)
        {
            var sucursal = await _context.Sucursales.FindAsync(id);
            if (sucursal == null) return;

            if (dto.Nombre != null)
                sucursal.Nombre = dto.Nombre;

            if (dto.Direccion != null)
                sucursal.Direccion = dto.Direccion;

            if (dto.Telefono != null)
                sucursal.Telefono = dto.Telefono;

            await _context.SaveChangesAsync();
        }

        public async Task EliminarSucursalAsync(int id)
        {
            var eliminar = await _context.Sucursales.FindAsync(id);
            if (eliminar != null)
            {
                _context.Sucursales.Remove(eliminar);
                await _context.SaveChangesAsync();
            }
        }
    }
}
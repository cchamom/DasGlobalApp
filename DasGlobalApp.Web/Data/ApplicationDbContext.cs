using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DasGlobalApp.Web.Models;

namespace DasGlobalApp.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Empresa> Empresas => Set<Empresa>();
        public DbSet<Sucursal> Sucursales => Set<Sucursal>();
        public DbSet<Colaborador> Colaboradores => Set<Colaborador>();

        protected override void OodelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Sucursal>()
                .HasOne(s => s.Empresa)
                .WithMany(e => e.Sucursales)
                .HasForeignKey(s => s.IdEmpresa)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Colaborador>()
                .HasOne(c => c.Sucursal)
                .WithMany(s => s.Colaboradores)
                .HasForeignKey(c => c.IdSucursal)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
using TALLER.ENTITY.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Options;

namespace TALLER.ENTITY
{
    public class TalleresContext : DbContext
    {

        public TalleresContext(DbContextOptions<TalleresContext> options) : base(options)
        {

        }
        //Tables 
        public DbSet<AUTOMOVIL> AUTOMOVIL { get; set; }
        public DbSet<CLIENT> CLIENT { get; set; }
        public DbSet<MECANICO> MECANICO { get; set; }
        public DbSet<SOLICITUD> SOLICITUD { get; set; }
        public DbSet<RECIBO> RECIBO { get; set; }

    }
}

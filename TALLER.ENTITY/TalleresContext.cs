using TALLER.ENTITY.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Options;
using TALLER.ENTITY.Models.Views;

namespace TALLER.ENTITY
{
    public class TalleresContext : DbContext
    {

        public TalleresContext(DbContextOptions<TalleresContext> options) : base(options)
        {

        }

        //Views
        public DbSet<VRecibo> VRecibo { get; set; }
        public DbSet<VSolicitud> VSolicitud  { get;set;}
        //Tables 
        public DbSet<AUTOMOVIL> AUTOMOVIL { get; set; }
        public DbSet<CLIENT> CLIENT { get; set; }
        public DbSet<MECANICO> MECANICO { get; set; }
        public DbSet<SOLICITUD> SOLICITUD { get; set; }
        public DbSet<RECIBO> RECIBO { get; set; }

    }
}

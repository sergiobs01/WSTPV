using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTPV.Entities;

namespace WSTPV.Contexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }

        public DbSet<Logins> Logins { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Descuento> Descuento { get; set; }
        public DbSet<Almacen> Almacen { get; set; }
        public DbSet<Venta> Venta { get; set; }
        public DbSet<Mesas> Mesas { get; set; }
    }
}

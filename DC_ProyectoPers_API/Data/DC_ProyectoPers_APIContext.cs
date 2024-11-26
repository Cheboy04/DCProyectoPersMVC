using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DCProyectoPersMVC.Models;

namespace DC_ProyectoPers_API.Data
{
    public class DC_ProyectoPers_APIContext : DbContext
    {
        public DC_ProyectoPers_APIContext (DbContextOptions<DC_ProyectoPers_APIContext> options)
            : base(options)
        {
        }

        public DbSet<DCProyectoPersMVC.Models.DCBebida> DCBebida { get; set; } = default!;
    }
}

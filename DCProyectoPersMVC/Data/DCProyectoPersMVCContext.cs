using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DCProyectoPersMVC.Models;

namespace DCProyectoPersMVC.Data
{
    public class DCProyectoPersMVCContext : DbContext
    {
        public DCProyectoPersMVCContext (DbContextOptions<DCProyectoPersMVCContext> options)
            : base(options)
        {
        }

        public DbSet<DCProyectoPersMVC.Models.DCBebida> DCBebida { get; set; } = default!;
    }
}

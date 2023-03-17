using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Farm.Models;

namespace Farm.Data
{
    public class FarmContext : DbContext
    {
        public FarmContext()
        {
        }

        public FarmContext (DbContextOptions<FarmContext> options)
            : base(options)
        {
        }

        public DbSet<Farm.Models.Cattle> Cattle { get; set; } = default!;

        public DbSet<Farm.Models.RainModel> RainModel { get; set; } = default!;
    }
}

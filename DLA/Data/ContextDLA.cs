using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DLA.Models.TownHallModels;

namespace DLA.Data
{
    public class ContextDLA : DbContext
    {
        public ContextDLA (DbContextOptions<ContextDLA> options)
            : base(options)
        {
        }

        public DbSet<DLA.Models.TownHallModels.TownHallLevels> TownHallLevels { get; set; } = default!;
    }
}

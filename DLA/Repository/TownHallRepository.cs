using DLA.Data;
using DLA.Models.TownHallModels;
using Microsoft.EntityFrameworkCore;

namespace DLA.Repository;

    public sealed class TownHallRepository(ContextDLA context) : Repository<TownHallLevels>(context)
    {
        public override IEnumerable<TownHallLevels> GetAll()
        {
            return context.TownHallLevels.Include(p => p.Data);
        }
    }


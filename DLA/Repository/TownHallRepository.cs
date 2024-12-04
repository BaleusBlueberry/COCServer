using DLA.Data;
using DLA.Models.TownHallModels;

namespace DLA.Repository;

    public sealed class TownHallRepository(ContextDLA context) : Repository<TownHallLevels>(context)
    {

    }


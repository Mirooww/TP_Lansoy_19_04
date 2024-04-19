using Microsoft.EntityFrameworkCore;

namespace Lansoy.RG.DAL.DAL
{
    public interface ILansoyDbContext
    {
        DbSet<Espion> Espions { get; }
        DbSet<Mission> Missions { get; }

        Task SaveChangesAsync();
    }
}
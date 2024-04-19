using Lansoy.RG.DAL.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lansoy.RG.DAL.Services
{
    public interface ISpyService
    {
        Task AddSpyAsync(string nom, string nomDeCode);
        Task AddMissionToSpyAsync(string nomDeCode, string ville, int annee);
        // Autres méthodes selon les besoins
    }

    public class SpyService : ISpyService
    {
        private readonly ILansoyDbContext _dbContext;

        public SpyService(ILansoyDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        }

        public async Task AddSpyAsync(string nom, string nomDeCode)
        {
            var spy = new Espion { Nom = nom, NomDeCode = nomDeCode };
            _dbContext.Espions.Add(spy);
            await _dbContext.SaveChangesAsync(); 
        }
        public async Task AddMissionToSpyAsync(string nomDeCode, string ville, int annee)
        {
            var spy = await _dbContext.Espions.FirstOrDefaultAsync(e => e.NomDeCode == nomDeCode);
            if (spy == null)
            {
                throw new InvalidOperationException("Espion introuvable.");
            }

            var mission = new Mission { Lieu = ville, Annee = annee };
            spy.Missions.Add(mission);
            await _dbContext.SaveChangesAsync(); 
        }

    }
}

using System;
using System.IO;
using Lansoy.RG.DAL;
using Lansoy.RG.DAL.DAL;

namespace Lansoy.RG.Cli
{
    public class ImportEspion
    {
        private readonly LansoyDbContext _dbContext;

        public ImportEspion(LansoyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void ImporterEspions(string cheminFichier)
        {
            var lignes = File.ReadAllLines(cheminFichier);
            foreach (var ligne in lignes)
            {
                var donnees = ligne.Split(';');
                if (donnees.Length >= 2)
                {
                    var espion = new Espion
                    {
                        Nom = donnees[0],
                        NomDeCode = donnees[1]
                    };
                    _dbContext.Espions.Add(espion);
                }
            }
            _dbContext.SaveChanges();
        }
    }
}

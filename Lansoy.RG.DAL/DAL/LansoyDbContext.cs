using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lansoy.RG.DAL.DAL
{
    public class LansoyDbContext : DbContext, ILansoyDbContext
    {
        public DbSet<Espion> Espions { get; set; }
        public DbSet<Espion> Villes { get; set; }
        public DbSet<Mission> Missions { get; set; }


        public List<Espion> GetEspions()
        {
            return this.Espions.ToList();
        }
        public List<Espion> GetVille()
        {
            return this.Villes.ToList();
        }
        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Port=3306;Database=tp_lansoy;Uid=root;Pwd=;";
            var serverVersion = new MySqlServerVersion(new Version(10, 4, 32));
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }
}

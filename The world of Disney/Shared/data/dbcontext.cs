using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_world_of_Disney.Comunes.data.database;

namespace The_world_of_Disney.Comunes.data
{
    public class dbcontext : DbContext
    {
        public DbSet<Personaje> personajes { get; set; }
        public DbSet<Genero> generos { get; set; }
        public DbSet<PeliculaSerie>peliculaSeries { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public dbcontext(DbContextOptions<dbcontext> options)
           : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            }

            base.OnModelCreating(modelBuilder);
        }
    }

}

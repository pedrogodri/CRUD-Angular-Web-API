using Microsoft.EntityFrameworkCore;
using ProjetoCRUD.Application.API.Models;

namespace ProjetoCRUD.Application.API.Context
{
    public class SQLServerContext : DbContext
    {
        public SQLServerContext(DbContextOptions<SQLServerContext> options)
            : base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seed
            modelBuilder.Entity<Person>()
                .HasData(
                new { Id = 1, Name = "Pedro", LastName = "Godri", Age = 17, Phone = "47999998888", Address = "Rua Hermann Tribess", Profession = "Programador" },
                new { Id = 2, Name = "Ramon", LastName = "Lisboa", Age = 33, Phone = "47999997777", Address = "Rua Alberto Einstein", Profession = "Programador" },
                new { Id = 3, Name = "Luiz", LastName = "Godri", Age = 7, Phone = "47999996666", Address = "Rua Julio Michel",  Profession = "Sushi Man" }
                );
        }

        #region DbSets<Tables>
        public DbSet<Person> People { get; set; }
        #endregion
    }
}

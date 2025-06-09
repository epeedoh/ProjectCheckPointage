using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ProjectCheckPointage.Api.Data
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Sexe> Sexes { get; set; }
        public DbSet<RoleType> RoleTypes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🔁 Relation entre Utilisateur et RoleType
            modelBuilder.Entity<Utilisateur>()
                .HasOne(u => u.RoleType)
                .WithMany()
                .HasForeignKey(u => u.RoleTypeID);

            // ✅ Données seedées pour RoleType
            modelBuilder.Entity<RoleType>().HasData(
                new RoleType { RoleTypeID = 1, CodeRole = "Adm", Libelle = "Admin" },
                new RoleType { RoleTypeID = 2, CodeRole = "Sp", Libelle = "Superviseur" },
                new RoleType { RoleTypeID = 2, CodeRole = "Pm", Libelle = "Promoteur" }

            );
        }


    }
}


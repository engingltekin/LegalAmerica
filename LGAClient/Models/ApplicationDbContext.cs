using LGAClient.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LGAClient.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientRelationshipType>().HasData(new ClientRelationshipType { Id = 1, RelationshipType = RelationShipType.Spouse.ToString() });
            modelBuilder.Entity<ClientRelationshipType>().HasData(new ClientRelationshipType { Id = 2, RelationshipType = RelationShipType.Siblings.ToString() });
            modelBuilder.Entity<ClientRelationshipType>().HasData(new ClientRelationshipType { Id = 3, RelationshipType = RelationShipType.Beneficiary.ToString() });
            modelBuilder.Entity<ClientCategory>().HasData(new ClientCategory { Id =1, CategoryName = ClientTypes.Owner.ToString() });
            modelBuilder.Entity<ClientCategory>().HasData(new ClientCategory { Id = 2, CategoryName = ClientTypes.CoOwner.ToString() });
            modelBuilder.Entity<ClientCategory>().HasData(new ClientCategory { Id = 3, CategoryName = ClientTypes.ThirdParty.ToString() });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Person> Person { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<ClientRelationship> ClientRelationships { get; set; }

        public DbSet<ClientRelationshipType> ClientRelationshipTypes { get; set; }

        public DbSet<ClientCategory> ClientCategories { get; set; }

    }
}

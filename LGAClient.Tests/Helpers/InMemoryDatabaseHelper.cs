using LGAClient.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LGAClient.Tests
{
    public class InMemoryDatabaseBase
    {
        public InMemoryDatabaseBase(DbContextOptions<ApplicationDbContext> options)
        {
            ContextOptions = options;

            SeedDatabase();
        }

        protected DbContextOptions<ApplicationDbContext> ContextOptions { get; }

        private void SeedDatabase()
        {
            using (var context = new ApplicationDbContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }
    }
}

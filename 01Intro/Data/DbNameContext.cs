using _01Intro.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Intro.Data
{
    public class DbNameContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseInMemoryDatabase("AddressBook");

            // Om vi använder SQL Server:
            // Då behöver vi NuGet-paketet Microsoft.EntityFrameworkCore.SqlServer (Istället för .InMemory)
            //options.UseSqlServer(
            //    @"Server=(localdb)\mssqllocaldb;Database=<DBNAMN>;Trusted_Connection=True");
        }
    }
}

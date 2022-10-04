using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Prooviulesanne.Models.Domain;
using Prooviulesanne.Data;

namespace Proov.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Citizen> Employee { get; set; }
        public DbSet<Enterprise> Company { get; set; }
        public DbSet<Event> Event { get; set; }
    }
}
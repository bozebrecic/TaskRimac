using Microsoft.EntityFrameworkCore;
using RimacTask.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RimacTask.DbContexts
{
    public class NetworkNodeDbContext : DbContext
    {
        public NetworkNodeDbContext() { }

        public NetworkNodeDbContext(DbContextOptions<NetworkNodeDbContext> options) : base(options) { }

        public DbSet<NetworkNodes> NetworkNodeData { get; set; }
        public DbSet<Messages> MessagesData { get; set; }
        public DbSet<Signals> SignalsData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                App.CreateHostBuilder();
                App.ConfigureAppConfiguration();
                App.BuildHostBuilder();
                App.ConfigureOptionBuilder(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<NetworkNodes>()
                .HasMany<Messages>(f => f.Messages)
                .WithOne(p => p.NetworkNode)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Messages>()
                .HasMany(f => f.Signals)
                .WithOne(p => p.Message)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

﻿using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataStore.EF
{
    public class BugsContext : DbContext
    {
        public BugsContext(DbContextOptions options) : base(options)
        {
        }
        //each one represent a table
        public DbSet<Project> Projects { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        // create the schema
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Tickets)
                .WithOne(t => t.Project)
                .HasForeignKey(t => t.ProjectId);

            //seeding
            modelBuilder.Entity<Project>().HasData(
                    new Project { ProjectId = 1, Name = "Project 1" },
                    new Project { ProjectId = 2, Name = "Project 2" }
                );

            modelBuilder.Entity<Ticket>().HasData(
                    new Ticket { TicketId = 1, Title = "Bug #1", ProjectId = 1 },
                    new Ticket { TicketId = 2, Title = "Bug #2", ProjectId = 1 },
                    new Ticket { TicketId = 3, Title = "Bug #3", ProjectId = 2 }
                );
        }
    }
}

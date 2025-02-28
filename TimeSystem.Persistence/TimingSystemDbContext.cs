﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TimeSystem.Domain;

namespace TimeSystem.Persistence
{
    public class TimingSystemDbContext : DbContext
    {
        public TimingSystemDbContext(DbContextOptions<TimingSystemDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<User> Users { get; set; }
        //public DbSet<Course> Courses { get; set; }
        public DbSet<SpeedWall> SpeedWalls { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<RaceQueue> RaceQueue { get; set; }
        public DbSet<Token> Tokens { get; set; }
    }
}

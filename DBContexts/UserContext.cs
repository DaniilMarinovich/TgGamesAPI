using Microsoft.EntityFrameworkCore;
using RandomTgAPI.Models;
using System;

namespace RandomTgAPI.DBContexts
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserGame> UserGames { get; set; }

        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}

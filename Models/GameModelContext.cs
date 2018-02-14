using System;
using Microsoft.EntityFrameworkCore;

namespace StrategyGame.Models
{
    public class GameModelContext : DbContext 
    {
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserAccountAuthentication> UserAccountAuthentications { get; set; }

        public GameModelContext(DbContextOptions<GameModelContext> options)
            : base(options)
        {
        }
    }
}
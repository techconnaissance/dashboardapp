using System;
using Dashboard.Model;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Data.Context
{
    public class DashboardContext : DbContext
    {
        public DashboardContext(DbContextOptions<DashboardContext> dboption) : base(dboption) { }

        public DbSet<Commodity> Commodities { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<DailyPnL> DailyPnLs { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<ValueAtRisk> ValueAtRisks { get; set; }
        public DbSet<DailyPosition> DailyPositions { get; set; }
        public DbSet<Model.Model> Models { get; set; }
        public DbSet<PriceView> PriceViews { get; set; }
        public DbSet<TranscationView> TransactionViews { get; set; }
    }
}

using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL
{
    public class AccountDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Withdrawal> Withdrawals { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {

            var serverAddress = "localhost\\SQLEXPRESS";
            var databaseName = "AccountDB";
            var connectionString = @"Server =" + serverAddress + "; Database =" + databaseName + "; Integrated Security = true;";
            builder
                .UseSqlServer(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //DEPOSIT
            builder.Entity<Deposit>()
                .HasOne<User>(d => d.User)
                .WithMany(u => u.Deposits)
                .HasForeignKey(d => d.DepositId);

            builder.Entity<Deposit>()
                .HasKey(d => d.DepositId);

            builder.Entity<Deposit>().Property(d => d.Date).HasColumnType("date");
            builder.Entity<Deposit>().Property(d => d.DepositAmount).HasColumnType("money");

            //WITHDRAWAL
            builder.Entity<Withdrawal>()
                .HasOne<User>(w => w.User)
                .WithMany(u => u.Withdrawals)
                .HasForeignKey(w => w.WithdrawalId);

            builder.Entity<Withdrawal>()
                .HasKey(w => w.WithdrawalId);

            builder.Entity<Withdrawal>().Property(d => d.WithdrawalDate).HasColumnType("date");
            builder.Entity<Withdrawal>().Property(d => d.WithdrawalAmount).HasColumnType("money");

            //USER
            builder.Entity<User>()
                .HasKey(u => u.UserId);

            builder.Entity<User>().Property(u => u.Created).HasColumnType("date");
            builder.Entity<User>().Property(u => u.Balance).HasColumnType("money");
        }
    }
}
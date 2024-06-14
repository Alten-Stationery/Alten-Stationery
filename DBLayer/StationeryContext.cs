﻿using DBLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DBLayer.Models.Item;

namespace DBLayer
{
    public class StationeryContext : DbContext
    {
        public StationeryContext() { }

        public StationeryContext(DbContextOptions<StationeryContext> options) : base(options) { }

      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Alessandro
            //string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StationeryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            //Vittorio
            string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StationaryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            optionsBuilder.UseSqlServer(connString);
        }


        public DbSet<Item> Items { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Refill> Refills { get; set; }
        public DbSet<User> Users { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Items
            modelBuilder.Entity<Item>(i =>
            {
                i.HasKey(c => c.ItemId);
                i.Property(c => c.Name).HasColumnType("nvarchar").HasMaxLength(50);
                i.Property(c => c.Description).HasColumnType("nvarchar(max)");
                i.Property(c => c.Location).HasColumnType("nvarchar").HasMaxLength(50);
                i.Property(c => c.Type).
                HasConversion(
                    i => i.ToString(),
                    i => (ItemType)Enum.Parse(typeof(ItemType), i)).HasColumnType("nvarchar(50)");
                i.Property(c => c.ExpirationDate).HasColumnType("datetime");
                i.Property(c => c.ExpireFEDate).HasColumnType("datetime");
                i.ToTable("Items");
            });
            #endregion

            #region Alerts
            modelBuilder.Entity<Alert>(i =>
            {
                i.HasKey(c => c.AlertId);
                i.Property(c => c.AlertDate).HasColumnType("datetime");
                i.Property(c => c.Email).HasColumnType("nvarchar").HasMaxLength(50);
                i.Property(c => c.EmailBody).HasColumnType("nvarchar(max)");
                i.ToTable("Alerts");
            });
            #endregion

            #region Refills
            modelBuilder.Entity<Refill>(r =>
            {
                r.HasKey(c => c.RefillId);
                r.Property(c => c.RefillDate).HasColumnType("datetime");
                r.ToTable("Refills");
            });
            #endregion

            #region Users
            modelBuilder.Entity<User>(i =>
            {
                i.HasKey(c => c.UserId);
                i.Property(c => c.LastName).HasColumnType("nvarchar").HasMaxLength(50);
                i.Property(c => c.FirstName).HasColumnType("nvarchar").HasMaxLength(50);
                i.Property(c => c.Email).HasColumnType("nvarchar").HasMaxLength(50);
                i.Property(c => c.Password).HasColumnType("nvarchar").HasMaxLength(50);
                i.ToTable("Users");
            });
            #endregion

            #region Items-Alerts(1-*)
            modelBuilder.Entity<Item>()
            .HasMany(o => o.Alerts)
            .WithOne(oi => oi.Item)
            .HasForeignKey(oi => oi.ItemId);
            #endregion

            #region Refills-Alerts(1-*)
            modelBuilder.Entity<Refill>()
                .HasMany(a => a.Alerts)
                .WithOne(r => r.Refill)
                .HasForeignKey(c => c.RefillId);
            #endregion

            #region Users-Refills(1-*)
            modelBuilder.Entity<User>()
            .HasMany(o => o.Refills)
            .WithOne(oi => oi.User)
            .HasForeignKey(oi => oi.UserId);
            #endregion

        }


    }
}

﻿// <auto-generated />
using System;
using DBLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsoleApp.Migrations
{
    [DbContext(typeof(StationeryContext))]
    partial class StationeryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DBLayer.Models.Alert", b =>
                {
                    b.Property<int>("AlertId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlertId"));

                    b.Property<DateTime>("AlertDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.Property<string>("EmailBody")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("RefillId")
                        .HasColumnType("int");

                    b.HasKey("AlertId");

                    b.HasIndex("ItemId");

                    b.HasIndex("RefillId");

                    b.ToTable("Alerts", (string)null);
                });

            modelBuilder.Entity("DBLayer.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("ExpireFEDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Threshold")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ItemId");

                    b.ToTable("Items", (string)null);
                });

            modelBuilder.Entity("DBLayer.Models.Refill", b =>
                {
                    b.Property<int>("RefillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RefillId"));

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("RefillDate")
                        .HasColumnType("datetime");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RefillId");

                    b.HasIndex("UserId");

                    b.ToTable("Refills", (string)null);
                });

            modelBuilder.Entity("DBLayer.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.HasKey("UserId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("DBLayer.Models.Alert", b =>
                {
                    b.HasOne("DBLayer.Models.Item", "Item")
                        .WithMany("Alerts")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBLayer.Models.Refill", "Refill")
                        .WithMany("Alerts")
                        .HasForeignKey("RefillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Refill");
                });

            modelBuilder.Entity("DBLayer.Models.Refill", b =>
                {
                    b.HasOne("DBLayer.Models.User", "User")
                        .WithMany("Refills")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DBLayer.Models.Item", b =>
                {
                    b.Navigation("Alerts");
                });

            modelBuilder.Entity("DBLayer.Models.Refill", b =>
                {
                    b.Navigation("Alerts");
                });

            modelBuilder.Entity("DBLayer.Models.User", b =>
                {
                    b.Navigation("Refills");
                });
#pragma warning restore 612, 618
        }
    }
}

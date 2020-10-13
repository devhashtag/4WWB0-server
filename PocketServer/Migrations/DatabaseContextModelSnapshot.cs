﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PocketServer.DataAccess;

namespace PocketServer.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PocketServer.DataAccess.Entities.Alert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Cancelled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("DeviceId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<double>("LocationLat")
                        .HasColumnType("double");

                    b.Property<double>("LocationLong")
                        .HasColumnType("double");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.ToTable("Alerts");
                });

            modelBuilder.Entity("PocketServer.DataAccess.Entities.AlertResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AlertId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Received")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Seen")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("AlertId");

                    b.HasIndex("UserId");

                    b.ToTable("AlertResponses");
                });

            modelBuilder.Entity("PocketServer.DataAccess.Entities.Device", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("OwnerAddress")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("OwnerCity")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("OwnerFirstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("OwnerLastName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("OwnerZipCode")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("PocketServer.DataAccess.Entities.Heartbeat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DeviceId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<double>("Lattitue")
                        .HasColumnType("double");

                    b.Property<double>("Longitude")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.ToTable("Heartbeats");
                });

            modelBuilder.Entity("PocketServer.DataAccess.Entities.Subscription", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("DeviceId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("UserId", "DeviceId");

                    b.HasIndex("DeviceId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("PocketServer.DataAccess.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PocketServer.DataAccess.Entities.Alert", b =>
                {
                    b.HasOne("PocketServer.DataAccess.Entities.Device", "Device")
                        .WithMany("Alerts")
                        .HasForeignKey("DeviceId");
                });

            modelBuilder.Entity("PocketServer.DataAccess.Entities.AlertResponse", b =>
                {
                    b.HasOne("PocketServer.DataAccess.Entities.Alert", "Alert")
                        .WithMany("AlertResponses")
                        .HasForeignKey("AlertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PocketServer.DataAccess.Entities.User", "User")
                        .WithMany("AlertResponses")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("PocketServer.DataAccess.Entities.Heartbeat", b =>
                {
                    b.HasOne("PocketServer.DataAccess.Entities.Device", "Device")
                        .WithMany("Heartbeats")
                        .HasForeignKey("DeviceId");
                });

            modelBuilder.Entity("PocketServer.DataAccess.Entities.Subscription", b =>
                {
                    b.HasOne("PocketServer.DataAccess.Entities.Device", "Device")
                        .WithMany("Subscriptions")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PocketServer.DataAccess.Entities.User", "User")
                        .WithMany("Subscriptions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

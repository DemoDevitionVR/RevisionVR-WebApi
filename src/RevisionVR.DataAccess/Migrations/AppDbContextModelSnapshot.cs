﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RevisionVR.DataAccess.Contexts;

#nullable disable

namespace RevisionVR.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RevisionVR.Domain.Entities.Devices.Device", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("DeviceId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("RevisionVR.Domain.Entities.Positions.UserPosition", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("DeviceId")
                        .HasColumnType("bigint");

                    b.Property<string>("Head")
                        .HasColumnType("text");

                    b.Property<string>("LeftHand")
                        .HasColumnType("text");

                    b.Property<string>("Main")
                        .HasColumnType("text");

                    b.Property<string>("RightHand")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("RevisionVR.Domain.Entities.Positions.UserPosition", b =>
                {
                    b.HasOne("RevisionVR.Domain.Entities.Devices.Device", "Device")
                        .WithMany("UserPositions")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("RevisionVR.Domain.Entities.Devices.Device", b =>
                {
                    b.Navigation("UserPositions");
                });
#pragma warning restore 612, 618
        }
    }
}

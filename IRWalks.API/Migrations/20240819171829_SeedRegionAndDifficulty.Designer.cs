﻿// <auto-generated />
using System;
using IRWalks.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IRWalks.API.Migrations
{
    [DbContext(typeof(IRWalksDbContext))]
    [Migration("20240819171829_SeedRegionAndDifficulty")]
    partial class SeedRegionAndDifficulty
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IRWalks.API.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulty");

                    b.HasData(
                        new
                        {
                            Id = new Guid("98a39a48-78fa-41d7-ad97-445ccb84177c"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("d817f8e9-5b09-4181-b064-8069b4b8fa61"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("95ad1fcd-7876-4b09-be77-859c9e94a9b3"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("IRWalks.API.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("75a93ca7-7b5c-4038-b0c0-140952f70e4f"),
                            Code = "FRS",
                            Name = "Fars",
                            RegionImageUrl = "region.jpg"
                        },
                        new
                        {
                            Id = new Guid("0a2c8388-f3cc-4328-9b3e-6f47b92c4a11"),
                            Code = "TBZ",
                            Name = "Tabriz",
                            RegionImageUrl = "region.jpg"
                        },
                        new
                        {
                            Id = new Guid("10191792-8707-4768-9e95-7aa628328853"),
                            Code = "TEH",
                            Name = "Tehran",
                            RegionImageUrl = "region.jpg"
                        },
                        new
                        {
                            Id = new Guid("5d860541-eb55-4aa7-9fd5-1c525f617788"),
                            Code = "SEM",
                            Name = "Semnan",
                            RegionImageUrl = "region.jpg"
                        });
                });

            modelBuilder.Entity("IRWalks.API.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("IRWalks.API.Models.Domain.Walk", b =>
                {
                    b.HasOne("IRWalks.API.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IRWalks.API.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}

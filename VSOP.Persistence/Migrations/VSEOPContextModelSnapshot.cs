﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VSOP.Persistence;

#nullable disable

namespace VSOP.Persistence.Migrations
{
    [DbContext(typeof(VSEOPContext))]
    partial class VSEOPContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProcessProducer", b =>
                {
                    b.Property<Guid>("FactoriesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProcessesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FactoriesId", "ProcessesId");

                    b.HasIndex("ProcessesId");

                    b.ToTable("ProcessProducer");
                });

            modelBuilder.Entity("VSOP.Domain.DbModels.Commodities.Commodity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("WorldId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WorldId");

                    b.ToTable("Commodity");
                });

            modelBuilder.Entity("VSOP.Domain.DbModels.Countries.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("WorldId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WorldId");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("VSOP.Domain.DbModels.Producers.Process", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ProcessesCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Process");
                });

            modelBuilder.Entity("VSOP.Domain.DbModels.Producers.ProcessedCommodity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CommodityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProcessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommodityId");

                    b.HasIndex("ProcessId");

                    b.ToTable("ProcessedCommodity");
                });

            modelBuilder.Entity("VSOP.Domain.DbModels.Producers.Producer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Producers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("Producer");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("VSOP.Domain.DbModels.Regions.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionStoreId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("VSOP.Domain.DbModels.Regions.RegionStore", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RegionId")
                        .IsUnique();

                    b.ToTable("RegionStore");
                });

            modelBuilder.Entity("VSOP.Domain.DbModels.Regions.StoredCommodity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CommodityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CurrentDemand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(20,0)");

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.Property<decimal>("SelfCost")
                        .HasColumnType("decimal(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("CommodityId");

                    b.ToTable("StoredCommodity");
                });

            modelBuilder.Entity("VSOP.Domain.DbModels.Worlds.World", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("World");
                });

            modelBuilder.Entity("VSOP.Domain.DbModels.Factories.Factory", b =>
                {
                    b.HasBaseType("VSOP.Domain.DbModels.Producers.Producer");

                    b.ToTable("Producers", (string)null);

                    b.HasDiscriminator().HasValue("Factory");
                });

            modelBuilder.Entity("ProcessProducer", b =>
                {
                    b.HasOne("VSOP.Domain.DbModels.Producers.Producer", null)
                        .WithMany()
                        .HasForeignKey("FactoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VSOP.Domain.DbModels.Producers.Process", null)
                        .WithMany()
                        .HasForeignKey("ProcessesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VSOP.Domain.DbModels.Commodities.Commodity", b =>
                {
                    b.HasOne("VSOP.Domain.DbModels.Worlds.World", "World")
                        .WithMany("Commodities")
                        .HasForeignKey("WorldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("World");
                });

            modelBuilder.Entity("VSOP.Domain.DbModels.Countries.Country", b =>
                {
                    b.HasOne("VSOP.Domain.DbModels.Worlds.World", "World")
                        .WithMany("Countries")
                        .HasForeignKey("WorldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("World");
                });

            modelBuilder.Entity("VSOP.Domain.DbModels.Producers.ProcessedCommodity", b =>
                {
                    b.HasOne("VSOP.Domain.DbModels.Commodities.Commodity", "Commodity")
                        .WithMany()
                        .HasForeignKey("CommodityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VSOP.Domain.DbModels.Producers.Process", "Process")
                        .WithMany("ProcessedCommodities")
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Commodity");

                    b.Navigation("Process");
                });

            modelBuilder.Entity("VSOP.Domain.DbModels.Producers.Producer", b =>
                {
                    b.HasOne("VSOP.Domain.DbModels.Regions.Region", "Region")
                        .WithMany("Producers")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("VSOP.Domain.DbModels.Regions.Region", b =>
                {
                    b.HasOne("VSOP.Domain.DbModels.Countries.Country", "Country")
                        .WithMany("Regions")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("VSOP.Domain.DbModels.Regions.RegionStore", b =>
                {
                    b.HasOne("VSOP.Domain.DbModels.Regions.Region", null)
                        .WithOne("RegionStore")
                        .HasForeignKey("VSOP.Domain.DbModels.Regions.RegionStore", "RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VSOP.Domain.DbModels.Regions.StoredCommodity", b =>
                {
                    b.HasOne("VSOP.Domain.DbModels.Commodities.Commodity", "Commodity")
                        .WithMany()
                        .HasForeignKey("CommodityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Commodity");
                });

            modelBuilder.Entity("VSOP.Domain.DbModels.Countries.Country", b =>
                {
                    b.Navigation("Regions");
                });

            modelBuilder.Entity("VSOP.Domain.DbModels.Producers.Process", b =>
                {
                    b.Navigation("ProcessedCommodities");
                });

            modelBuilder.Entity("VSOP.Domain.DbModels.Regions.Region", b =>
                {
                    b.Navigation("Producers");

                    b.Navigation("RegionStore")
                        .IsRequired();
                });

            modelBuilder.Entity("VSOP.Domain.DbModels.Worlds.World", b =>
                {
                    b.Navigation("Commodities");

                    b.Navigation("Countries");
                });
#pragma warning restore 612, 618
        }
    }
}

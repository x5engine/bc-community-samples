﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherInsurance.Integration.Database;

namespace WeatherInsurance.Integration.Database.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeatherInsurance.Integration.Database.Model.ContractFile", b =>
                {
                    b.Property<long>("ContractFileId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApiType")
                        .HasMaxLength(25);

                    b.Property<string>("ApiVersion")
                        .HasMaxLength(25);

                    b.Property<string>("ContractFileName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<bool>("IncludesJson");

                    b.Property<bool>("IncludesSol");

                    b.Property<string>("OwnerAddress")
                        .IsRequired()
                        .HasMaxLength(42);

                    b.HasKey("ContractFileId");

                    b.HasIndex("ContractFileName", "OwnerAddress")
                        .IsUnique();

                    b.ToTable("ContractFiles");
                });

            modelBuilder.Entity("WeatherInsurance.Integration.Database.Model.DeployedContract", b =>
                {
                    b.Property<string>("ContractAddress")
                        .HasMaxLength(42);

                    b.Property<long>("NetworkId");

                    b.Property<string>("ConstructorArguments");

                    b.Property<long>("ContractFileId");

                    b.Property<string>("ContractName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("ContractType");

                    b.Property<string>("Description");

                    b.Property<DateTime>("ExpirationDateTime");

                    b.Property<bool>("IsRegistered");

                    b.Property<string>("OwnerAddress")
                        .IsRequired()
                        .HasMaxLength(42);

                    b.HasKey("ContractAddress", "NetworkId");

                    b.HasIndex("ContractFileId");

                    b.HasIndex("NetworkId");

                    b.HasIndex("OwnerAddress");

                    b.HasIndex("ContractName", "NetworkId")
                        .IsUnique();

                    b.ToTable("DeployedContracts");
                });

            modelBuilder.Entity("WeatherInsurance.Integration.Database.Model.Fee", b =>
                {
                    b.Property<long>("FeeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Amount");

                    b.Property<string>("ContractAddress")
                        .IsRequired();

                    b.Property<bool>("IsConfirmed");

                    b.Property<long>("NetworkId");

                    b.Property<string>("Recipient")
                        .IsRequired()
                        .HasMaxLength(42);

                    b.Property<string>("Sender")
                        .IsRequired()
                        .HasMaxLength(42);

                    b.Property<DateTime>("Timestamp");

                    b.Property<string>("TransactionHash")
                        .IsRequired()
                        .HasMaxLength(66);

                    b.HasKey("FeeId");

                    b.HasIndex("ContractAddress", "NetworkId");

                    b.ToTable("Fees");
                });

            modelBuilder.Entity("WeatherInsurance.Integration.Database.Model.Network", b =>
                {
                    b.Property<long>("NetworkId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NetworkName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Platform");

                    b.Property<string>("ReferenceContractAddress")
                        .IsRequired()
                        .HasMaxLength(42);

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("NetworkId");

                    b.HasIndex("NetworkName")
                        .IsUnique();

                    b.ToTable("Networks");

                    b.HasData(
                        new
                        {
                            NetworkId = 1L,
                            NetworkName = "ETH:Unknown",
                            Platform = 0,
                            ReferenceContractAddress = "0x0",
                            Url = ""
                        },
                        new
                        {
                            NetworkId = 2L,
                            NetworkName = "ETH:Mainnet",
                            Platform = 0,
                            ReferenceContractAddress = "0x13Cb835C47782dad075Ce7fAA1F8439b548B712D",
                            Url = "https://etherscan.io"
                        },
                        new
                        {
                            NetworkId = 3L,
                            NetworkName = "ETH:Kovan",
                            Platform = 0,
                            ReferenceContractAddress = "0x3422a48ebf29809bda10e264207ed94a5a819368",
                            Url = "https://kovan.etherscan.io"
                        },
                        new
                        {
                            NetworkId = 4L,
                            NetworkName = "ETH:Sokol",
                            Platform = 0,
                            ReferenceContractAddress = "0x64F84Fadae3F535BC02b17eD12a7Db33FBBEF29E",
                            Url = ""
                        },
                        new
                        {
                            NetworkId = 5L,
                            NetworkName = "ETH:Ropsten",
                            Platform = 0,
                            ReferenceContractAddress = "0x1F807D49324d83C3c5836Ad162839ba360EC834b",
                            Url = "https://ropsten.etherscan.io"
                        });
                });

            modelBuilder.Entity("WeatherInsurance.Integration.Database.Model.Purchase", b =>
                {
                    b.Property<long>("PurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContractAddress")
                        .HasMaxLength(42);

                    b.Property<long>("NetworkId");

                    b.Property<decimal>("Notional");

                    b.Property<decimal>("Premium")
                        .HasColumnType("decimal(18, 6)");

                    b.Property<DateTime>("PurchaseTimestamp");

                    b.Property<string>("UserAddress")
                        .HasMaxLength(42);

                    b.HasKey("PurchaseId");

                    b.HasIndex("ContractAddress", "NetworkId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("WeatherInsurance.Integration.Database.Model.DeployedContract", b =>
                {
                    b.HasOne("WeatherInsurance.Integration.Database.Model.ContractFile", "ContractFile")
                        .WithMany()
                        .HasForeignKey("ContractFileId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WeatherInsurance.Integration.Database.Model.Network", "Network")
                        .WithMany()
                        .HasForeignKey("NetworkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WeatherInsurance.Integration.Database.Model.Fee", b =>
                {
                    b.HasOne("WeatherInsurance.Integration.Database.Model.DeployedContract", "Contract")
                        .WithMany()
                        .HasForeignKey("ContractAddress", "NetworkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WeatherInsurance.Integration.Database.Model.Purchase", b =>
                {
                    b.HasOne("WeatherInsurance.Integration.Database.Model.DeployedContract", "Contract")
                        .WithMany()
                        .HasForeignKey("ContractAddress", "NetworkId");
                });
#pragma warning restore 612, 618
        }
    }
}

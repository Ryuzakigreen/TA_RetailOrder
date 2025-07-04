﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TARetailOrder.ApiService.DataContext;

#nullable disable

namespace TARetailOrder.ApiService.DataContext.Migrations
{
    [DbContext(typeof(DBDataContext))]
    [Migration("20250630041726_Added-Seed-Product")]
    partial class AddedSeedProduct
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TARetailOrder.ApiService.DataContext.Models.Category", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("integer");

                    b.Property<int>("DeleterUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("LastModifierUserId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TARetailOrder.ApiService.DataContext.Models.Customer", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BillingAddress")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("integer");

                    b.Property<int>("DeleterUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("LastModifierUserId")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.Property<string>("ShippingAddress")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.HasKey("ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TARetailOrder.ApiService.DataContext.Models.Product", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("integer");

                    b.Property<int>("DeleterUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("LastModifierUserId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int>("Qty")
                        .HasColumnType("integer");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ID = new Guid("d2bd2470-d3b6-4baf-aba5-d07d57f9bd7b"),
                            CategoryId = new Guid("0e798d71-0ea8-4166-8051-aa77545c1842"),
                            CreationTime = new DateTime(2025, 5, 1, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            CreatorUserId = 0,
                            DeleterUserId = 0,
                            Description = "High-quality wireless headphones with noise cancellation",
                            IsDeleted = false,
                            Name = "Wireless Bluetooth Headphones",
                            Qty = 25,
                            SKU = "WBH12345",
                            Status = 0,
                            UnitPrice = 149.99m
                        },
                        new
                        {
                            ID = new Guid("41170985-4bac-4b38-be81-e1e2c9c1850a"),
                            CategoryId = new Guid("0e798d71-0ea8-4166-8051-aa77545c1842"),
                            CreationTime = new DateTime(2025, 5, 6, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            CreatorUserId = 0,
                            DeleterUserId = 0,
                            Description = "Durable protective case for smartphones",
                            IsDeleted = false,
                            LastModificationTime = new DateTime(2025, 6, 20, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            LastModifierUserId = 1,
                            Name = "Smartphone Case",
                            Qty = 150,
                            SKU = "SPC67890",
                            Status = 0,
                            UnitPrice = 24.99m
                        },
                        new
                        {
                            ID = new Guid("2e621347-dc5e-47d1-88e7-1f997f78fa50"),
                            CategoryId = new Guid("0e798d71-0ea8-4166-8051-aa77545c1842"),
                            CreationTime = new DateTime(2025, 5, 11, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            CreatorUserId = 0,
                            DeleterUserId = 0,
                            Description = "Fast wireless charging pad for compatible devices",
                            IsDeleted = false,
                            Name = "Wireless Charger",
                            Qty = 75,
                            SKU = "WCH11111",
                            Status = 0,
                            UnitPrice = 39.99m
                        },
                        new
                        {
                            ID = new Guid("d7986281-b767-4779-b6d8-51e6922cd50d"),
                            CategoryId = new Guid("0e798d71-0ea8-4166-8051-aa77545c1842"),
                            CreationTime = new DateTime(2025, 5, 16, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            CreatorUserId = 0,
                            DeleterUserId = 0,
                            Description = "High-speed USB charging and data cable",
                            IsDeleted = false,
                            Name = "USB Cable",
                            Qty = 200,
                            SKU = "USB22222",
                            Status = 0,
                            UnitPrice = 12.99m
                        },
                        new
                        {
                            ID = new Guid("bbd05eeb-3d2b-4ab4-8b88-7aaae30b8617"),
                            CategoryId = new Guid("0e798d71-0ea8-4166-8051-aa77545c1842"),
                            CreationTime = new DateTime(2025, 5, 21, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            CreatorUserId = 0,
                            DeleterUserId = 0,
                            Description = "Portable battery charger with high capacity",
                            IsDeleted = false,
                            LastModificationTime = new DateTime(2025, 6, 25, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            LastModifierUserId = 1,
                            Name = "Power Bank",
                            Qty = 50,
                            SKU = "PWB33333",
                            Status = 1,
                            UnitPrice = 59.99m
                        },
                        new
                        {
                            ID = new Guid("8a70a786-a932-4dc5-adea-b0ee3f0d73b3"),
                            CategoryId = new Guid("2300c16c-ac05-48d1-8053-d39d3d704f61"),
                            CreationTime = new DateTime(2025, 4, 26, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            CreatorUserId = 0,
                            DeleterUserId = 0,
                            Description = "Comfortable 100% cotton t-shirt in various colors",
                            IsDeleted = false,
                            Name = "Cotton T-Shirt",
                            Qty = 100,
                            SKU = "CTS44444",
                            Status = 0,
                            UnitPrice = 19.99m
                        },
                        new
                        {
                            ID = new Guid("4d1d522d-eb82-48e5-bf00-015824d3ecb4"),
                            CategoryId = new Guid("2300c16c-ac05-48d1-8053-d39d3d704f61"),
                            CreationTime = new DateTime(2025, 5, 3, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            CreatorUserId = 0,
                            DeleterUserId = 0,
                            Description = "Classic fit denim jeans with premium quality",
                            IsDeleted = false,
                            LastModificationTime = new DateTime(2025, 6, 15, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            LastModifierUserId = 1,
                            Name = "Denim Jeans",
                            Qty = 60,
                            SKU = "DNJ55555",
                            Status = 0,
                            UnitPrice = 79.99m
                        },
                        new
                        {
                            ID = new Guid("888c1258-b756-4ca7-9c66-af4d2c0ca0f2"),
                            CategoryId = new Guid("2300c16c-ac05-48d1-8053-d39d3d704f61"),
                            CreationTime = new DateTime(2025, 5, 9, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            CreatorUserId = 0,
                            DeleterUserId = 0,
                            Description = "Warm and stylish winter jacket with hood",
                            IsDeleted = false,
                            Name = "Winter Jacket",
                            Qty = 30,
                            SKU = "WJK66666",
                            Status = 0,
                            UnitPrice = 129.99m
                        },
                        new
                        {
                            ID = new Guid("17bdeb16-7ddb-42dc-816e-a97dc402e8e3"),
                            CategoryId = new Guid("2300c16c-ac05-48d1-8053-d39d3d704f61"),
                            CreationTime = new DateTime(2025, 5, 13, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            CreatorUserId = 0,
                            DeleterUserId = 0,
                            Description = "Light and breezy summer dress perfect for warm weather",
                            IsDeleted = false,
                            Name = "Summer Dress",
                            Qty = 40,
                            SKU = "SMD77777",
                            Status = 0,
                            UnitPrice = 49.99m
                        },
                        new
                        {
                            ID = new Guid("968c4310-1dc8-4e14-aa42-62d6ca53cbc3"),
                            CategoryId = new Guid("2300c16c-ac05-48d1-8053-d39d3d704f61"),
                            CreationTime = new DateTime(2025, 5, 19, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            CreatorUserId = 0,
                            DeleterUserId = 0,
                            Description = "Comfortable sneakers for everyday wear",
                            IsDeleted = false,
                            LastModificationTime = new DateTime(2025, 6, 22, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            LastModifierUserId = 1,
                            Name = "Casual Sneakers",
                            Qty = 45,
                            SKU = "CSN88888",
                            Status = 0,
                            UnitPrice = 89.99m
                        },
                        new
                        {
                            ID = new Guid("24230192-6077-4b35-8b66-e068204dc610"),
                            CategoryId = new Guid("825b818a-d436-4bac-8e1b-9472409335e1"),
                            CreationTime = new DateTime(2025, 4, 21, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            CreatorUserId = 0,
                            DeleterUserId = 0,
                            Description = "Professional grade cookware set with non-stick coating",
                            IsDeleted = false,
                            Name = "Stainless Steel Cookware Set",
                            Qty = 20,
                            SKU = "SSC99999",
                            Status = 0,
                            UnitPrice = 199.99m
                        },
                        new
                        {
                            ID = new Guid("0dd88309-6994-4d4b-9dbf-6e568c8a9063"),
                            CategoryId = new Guid("825b818a-d436-4bac-8e1b-9472409335e1"),
                            CreationTime = new DateTime(2025, 4, 28, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            CreatorUserId = 0,
                            DeleterUserId = 0,
                            Description = "Programmable coffee maker with thermal carafe",
                            IsDeleted = false,
                            Name = "Coffee Maker",
                            Qty = 35,
                            SKU = "CFM00000",
                            Status = 0,
                            UnitPrice = 89.99m
                        },
                        new
                        {
                            ID = new Guid("4b999958-03db-4071-9a4f-1d2ddc4aedd1"),
                            CategoryId = new Guid("825b818a-d436-4bac-8e1b-9472409335e1"),
                            CreationTime = new DateTime(2025, 5, 5, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            CreatorUserId = 0,
                            DeleterUserId = 0,
                            Description = "Sharp and durable kitchen knives with wooden block",
                            IsDeleted = false,
                            LastModificationTime = new DateTime(2025, 6, 18, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            LastModifierUserId = 1,
                            Name = "Kitchen Knife Set",
                            Qty = 25,
                            SKU = "KNS11111",
                            Status = 0,
                            UnitPrice = 119.99m
                        },
                        new
                        {
                            ID = new Guid("d52b0270-57f0-413e-8c86-f415d3ad14cb"),
                            CategoryId = new Guid("825b818a-d436-4bac-8e1b-9472409335e1"),
                            CreationTime = new DateTime(2025, 5, 12, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            CreatorUserId = 0,
                            DeleterUserId = 0,
                            Description = "High-quality non-stick frying pan",
                            IsDeleted = false,
                            Name = "Non-Stick Pan",
                            Qty = 80,
                            SKU = "NSP22222",
                            Status = 0,
                            UnitPrice = 34.99m
                        },
                        new
                        {
                            ID = new Guid("d3f5c0ea-b611-4eb1-b9a9-536db1e32dc1"),
                            CategoryId = new Guid("825b818a-d436-4bac-8e1b-9472409335e1"),
                            CreationTime = new DateTime(2025, 5, 18, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            CreatorUserId = 0,
                            DeleterUserId = 0,
                            Description = "Powerful blender for smoothies and food preparation",
                            IsDeleted = false,
                            LastModificationTime = new DateTime(2025, 6, 23, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            LastModifierUserId = 1,
                            Name = "Blender",
                            Qty = 40,
                            SKU = "BLD33333",
                            Status = 1,
                            UnitPrice = 79.99m
                        },
                        new
                        {
                            ID = new Guid("0eddcf59-4ec4-4b6f-85d6-caaaf92c5165"),
                            CategoryId = new Guid("efdab8b9-fd6b-4311-9a45-f014682f47ed"),
                            CreationTime = new DateTime(2025, 4, 23, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            CreatorUserId = 0,
                            DeleterUserId = 0,
                            Description = "Comprehensive guide to modern programming languages",
                            IsDeleted = false,
                            Name = "Programming Guide",
                            Qty = 50,
                            SKU = "PRG44444",
                            Status = 0,
                            UnitPrice = 39.99m
                        },
                        new
                        {
                            ID = new Guid("70b1314b-4418-4dd0-a53f-8f4a7bba71b3"),
                            CategoryId = new Guid("efdab8b9-fd6b-4311-9a45-f014682f47ed"),
                            CreationTime = new DateTime(2025, 4, 30, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            CreatorUserId = 0,
                            DeleterUserId = 0,
                            Description = "Thrilling mystery novel with unexpected twists",
                            IsDeleted = false,
                            Name = "Mystery Novel",
                            Qty = 75,
                            SKU = "MYN55555",
                            Status = 0,
                            UnitPrice = 14.99m
                        },
                        new
                        {
                            ID = new Guid("52d69aa8-aa3d-4a6b-a4fa-3253fea373da"),
                            CategoryId = new Guid("efdab8b9-fd6b-4311-9a45-f014682f47ed"),
                            CreationTime = new DateTime(2025, 5, 7, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            CreatorUserId = 0,
                            DeleterUserId = 0,
                            Description = "Epic science fiction adventure in space",
                            IsDeleted = false,
                            LastModificationTime = new DateTime(2025, 6, 12, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            LastModifierUserId = 1,
                            Name = "Science Fiction Book",
                            Qty = 60,
                            SKU = "SFB66666",
                            Status = 0,
                            UnitPrice = 16.99m
                        },
                        new
                        {
                            ID = new Guid("26f3c4dc-0525-4743-97ef-c24020fb2b63"),
                            CategoryId = new Guid("efdab8b9-fd6b-4311-9a45-f014682f47ed"),
                            CreationTime = new DateTime(2025, 5, 14, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            CreatorUserId = 0,
                            DeleterUserId = 0,
                            Description = "Delicious recipes for home cooking enthusiasts",
                            IsDeleted = false,
                            Name = "Cookbook",
                            Qty = 45,
                            SKU = "CBK77777",
                            Status = 0,
                            UnitPrice = 24.99m
                        },
                        new
                        {
                            ID = new Guid("d5f1228b-d43f-48f4-9681-b14ede1a2404"),
                            CategoryId = new Guid("efdab8b9-fd6b-4311-9a45-f014682f47ed"),
                            CreationTime = new DateTime(2025, 5, 20, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            CreatorUserId = 0,
                            DeleterUserId = 0,
                            Description = "Comprehensive overview of world history",
                            IsDeleted = false,
                            LastModificationTime = new DateTime(2025, 6, 27, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            LastModifierUserId = 1,
                            Name = "History Book",
                            Qty = 35,
                            SKU = "HSB88888",
                            Status = 1,
                            UnitPrice = 29.99m
                        },
                        new
                        {
                            ID = new Guid("d88475ff-0add-4acd-970b-5bbc4bbd033a"),
                            CategoryId = new Guid("fec1de25-5bc4-4351-a9ac-6a46addd55f7"),
                            CreationTime = new DateTime(2025, 4, 19, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            CreatorUserId = 0,
                            DeleterUserId = 0,
                            Description = "Non-slip yoga mat for exercise and meditation",
                            IsDeleted = false,
                            Name = "Yoga Mat",
                            Qty = 80,
                            SKU = "YGM99999",
                            Status = 0,
                            UnitPrice = 29.99m
                        },
                        new
                        {
                            ID = new Guid("11318585-0d25-4e19-9051-652fa8911b7d"),
                            CategoryId = new Guid("fec1de25-5bc4-4351-a9ac-6a46addd55f7"),
                            CreationTime = new DateTime(2025, 4, 25, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            CreatorUserId = 0,
                            DeleterUserId = 0,
                            Description = "Lightweight running shoes with superior cushioning",
                            IsDeleted = false,
                            LastModificationTime = new DateTime(2025, 6, 16, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            LastModifierUserId = 1,
                            Name = "Running Shoes",
                            Qty = 55,
                            SKU = "RNS00001",
                            Status = 0,
                            UnitPrice = 119.99m
                        },
                        new
                        {
                            ID = new Guid("592e4cb0-ba05-4cff-b652-a425671a2926"),
                            CategoryId = new Guid("fec1de25-5bc4-4351-a9ac-6a46addd55f7"),
                            CreationTime = new DateTime(2025, 5, 2, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            CreatorUserId = 0,
                            DeleterUserId = 0,
                            Description = "Insulated water bottle perfect for workouts",
                            IsDeleted = false,
                            Name = "Gym Water Bottle",
                            Qty = 120,
                            SKU = "GWB00002",
                            Status = 0,
                            UnitPrice = 19.99m
                        },
                        new
                        {
                            ID = new Guid("13996ce9-735c-4a96-8a5c-e8eb762361bc"),
                            CategoryId = new Guid("fec1de25-5bc4-4351-a9ac-6a46addd55f7"),
                            CreationTime = new DateTime(2025, 5, 8, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            CreatorUserId = 0,
                            DeleterUserId = 0,
                            Description = "Set of resistance bands for strength training",
                            IsDeleted = false,
                            Name = "Resistance Bands",
                            Qty = 65,
                            SKU = "RSB00003",
                            Status = 0,
                            UnitPrice = 24.99m
                        },
                        new
                        {
                            ID = new Guid("9d1013ab-f060-4e1e-a521-b545b9b67440"),
                            CategoryId = new Guid("fec1de25-5bc4-4351-a9ac-6a46addd55f7"),
                            CreationTime = new DateTime(2025, 5, 15, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            CreatorUserId = 0,
                            DeleterUserId = 0,
                            Description = "Official size basketball for indoor and outdoor play",
                            IsDeleted = false,
                            LastModificationTime = new DateTime(2025, 6, 24, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60),
                            LastModifierUserId = 1,
                            Name = "Basketball",
                            Qty = 40,
                            SKU = "BSK00004",
                            Status = 0,
                            UnitPrice = 34.99m
                        });
                });

            modelBuilder.Entity("TARetailOrder.ApiService.DataContext.Models.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("integer");

                    b.Property<int>("DeleterUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("LastModifierUserId")
                        .HasColumnType("integer");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TARetailOrder.ApiService.DataContext.Models.Product", b =>
                {
                    b.HasOne("TARetailOrder.ApiService.DataContext.Models.Category", "CategoryFk")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("CategoryFk");
                });
#pragma warning restore 612, 618
        }
    }
}

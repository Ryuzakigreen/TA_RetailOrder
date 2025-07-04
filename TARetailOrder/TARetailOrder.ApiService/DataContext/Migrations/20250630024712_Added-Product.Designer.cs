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
    [Migration("20250630024712_Added-Product")]
    partial class AddedProduct
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

                    b.HasData(
                        new
                        {
                            ID = new Guid("8559a783-d185-4825-857a-3abec14a70a4"),
                            BillingAddress = "123 Main Street, Quezon City, Metro Manila, Philippines",
                            CreationTime = new DateTime(2025, 5, 31, 2, 47, 11, 218, DateTimeKind.Utc).AddTicks(4973),
                            CreatorUserId = 1,
                            DeleterUserId = 0,
                            Email = "john.smith@email.com",
                            FirstName = "John",
                            IsDeleted = false,
                            LastName = "Smith",
                            PhoneNo = "09123456789",
                            ShippingAddress = "123 Main Street, Quezon City, Metro Manila, Philippines"
                        },
                        new
                        {
                            ID = new Guid("70dec98d-0f1b-42f6-a311-a3ae12a03272"),
                            BillingAddress = "456 Rizal Avenue, Makati City, Metro Manila, Philippines",
                            CreationTime = new DateTime(2025, 6, 5, 2, 47, 11, 218, DateTimeKind.Utc).AddTicks(4973),
                            CreatorUserId = 1,
                            DeleterUserId = 0,
                            Email = "maria.santos@gmail.com",
                            FirstName = "Maria",
                            IsDeleted = false,
                            LastModificationTime = new DateTime(2025, 6, 20, 2, 47, 11, 218, DateTimeKind.Utc).AddTicks(4973),
                            LastModifierUserId = 2,
                            LastName = "Santos",
                            PhoneNo = "09187654321",
                            ShippingAddress = "456 Rizal Avenue, Makati City, Metro Manila, Philippines"
                        },
                        new
                        {
                            ID = new Guid("3a5c1a45-124c-44db-af07-57cced5b04a9"),
                            BillingAddress = "321 Ortigas Center, Pasig City, Metro Manila, Philippines",
                            CreationTime = new DateTime(2025, 6, 10, 2, 47, 11, 218, DateTimeKind.Utc).AddTicks(4973),
                            CreatorUserId = 2,
                            DeleterUserId = 0,
                            Email = "carlos.reyes@yahoo.com",
                            FirstName = "Carlos",
                            IsDeleted = false,
                            LastName = "Reyes",
                            PhoneNo = "09234567890",
                            ShippingAddress = "789 Commonwealth Ave, Quezon City, Metro Manila, Philippines"
                        },
                        new
                        {
                            ID = new Guid("3d4fd180-e8cd-4685-8978-5c93d16df7af"),
                            BillingAddress = "147 Taft Avenue, Manila, Metro Manila, Philippines",
                            CreationTime = new DateTime(2025, 6, 15, 2, 47, 11, 218, DateTimeKind.Utc).AddTicks(4973),
                            CreatorUserId = 1,
                            DeleterUserId = 0,
                            Email = "ana.cruz@hotmail.com",
                            FirstName = "Ana",
                            IsDeleted = false,
                            LastModificationTime = new DateTime(2025, 6, 25, 2, 47, 11, 218, DateTimeKind.Utc).AddTicks(4973),
                            LastModifierUserId = 1,
                            LastName = "Cruz",
                            PhoneNo = "09198765432",
                            ShippingAddress = "147 Taft Avenue, Manila, Metro Manila, Philippines"
                        },
                        new
                        {
                            ID = new Guid("9ccafb2d-5c50-4921-be9d-a951766fea71"),
                            BillingAddress = "258 EDSA, Mandaluyong City, Metro Manila, Philippines",
                            CreationTime = new DateTime(2025, 6, 18, 2, 47, 11, 218, DateTimeKind.Utc).AddTicks(4973),
                            CreatorUserId = 2,
                            DeleterUserId = 0,
                            Email = "roberto.garcia@outlook.com",
                            FirstName = "Roberto",
                            IsDeleted = false,
                            LastName = "Garcia",
                            PhoneNo = "09345678901",
                            ShippingAddress = "258 EDSA, Mandaluyong City, Metro Manila, Philippines"
                        },
                        new
                        {
                            ID = new Guid("25e50bc2-0550-4279-bd60-337e64dda83c"),
                            BillingAddress = "159 BGC, Taguig City, Metro Manila, Philippines",
                            CreationTime = new DateTime(2025, 6, 22, 2, 47, 11, 218, DateTimeKind.Utc).AddTicks(4973),
                            CreatorUserId = 1,
                            DeleterUserId = 0,
                            Email = "elena.mendoza@gmail.com",
                            FirstName = "Elena",
                            IsDeleted = false,
                            LastModificationTime = new DateTime(2025, 6, 28, 2, 47, 11, 218, DateTimeKind.Utc).AddTicks(4973),
                            LastModifierUserId = 2,
                            LastName = "Mendoza",
                            PhoneNo = "09456789012",
                            ShippingAddress = "369 Katipunan Avenue, Quezon City, Metro Manila, Philippines"
                        },
                        new
                        {
                            ID = new Guid("1c224857-51b4-4a9d-a70f-6333c5a7b41b"),
                            BillingAddress = "741 Shaw Boulevard, Mandaluyong City, Metro Manila, Philippines",
                            CreationTime = new DateTime(2025, 6, 24, 2, 47, 11, 218, DateTimeKind.Utc).AddTicks(4973),
                            CreatorUserId = 2,
                            DeleterUserId = 0,
                            Email = "miguel.torres@email.com",
                            FirstName = "Miguel",
                            IsDeleted = false,
                            LastName = "Torres",
                            PhoneNo = "09567890123",
                            ShippingAddress = "741 Shaw Boulevard, Mandaluyong City, Metro Manila, Philippines"
                        },
                        new
                        {
                            ID = new Guid("41493021-9ad2-4fcf-bfbf-d77809605752"),
                            BillingAddress = "852 Alabang-Zapote Road, Las Piñas City, Metro Manila, Philippines",
                            CreationTime = new DateTime(2025, 6, 26, 2, 47, 11, 218, DateTimeKind.Utc).AddTicks(4973),
                            CreatorUserId = 1,
                            DeleterUserId = 0,
                            Email = "isabella.flores@yahoo.com",
                            FirstName = "Isabella",
                            IsDeleted = false,
                            LastModificationTime = new DateTime(2025, 6, 29, 2, 47, 11, 218, DateTimeKind.Utc).AddTicks(4973),
                            LastModifierUserId = 1,
                            LastName = "Flores",
                            PhoneNo = "09678901234",
                            ShippingAddress = "852 Alabang-Zapote Road, Las Piñas City, Metro Manila, Philippines"
                        },
                        new
                        {
                            ID = new Guid("e9283598-9b0d-4d79-8b90-8890aac46b09"),
                            BillingAddress = "963 C5 Road, Pasig City, Metro Manila, Philippines",
                            CreationTime = new DateTime(2025, 6, 28, 2, 47, 11, 218, DateTimeKind.Utc).AddTicks(4973),
                            CreatorUserId = 2,
                            DeleterUserId = 0,
                            FirstName = "Diego",
                            IsDeleted = false,
                            LastName = "Villanueva",
                            PhoneNo = "09789012345",
                            ShippingAddress = "963 C5 Road, Pasig City, Metro Manila, Philippines"
                        });
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

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
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

                    b.HasData(
                        new
                        {
                            ID = new Guid("6a987ea6-7f38-4d16-89bb-3728d13aa956"),
                            CreationTime = new DateTime(2025, 5, 1, 2, 47, 11, 218, DateTimeKind.Utc).AddTicks(5229),
                            CreatorUserId = 0,
                            DeleterUserId = 0,
                            IsDeleted = false,
                            Password = "AM4OLBpptxBYmM79lGOX9egzZk3vIQU3d/gFCJzaBjAPXzYIK3tQ2N7X4fcrHtElTw==",
                            Role = 1,
                            Username = "admin"
                        },
                        new
                        {
                            ID = new Guid("5cf595f0-304c-4900-a45f-821cb2c6a48e"),
                            CreationTime = new DateTime(2025, 5, 16, 2, 47, 11, 218, DateTimeKind.Utc).AddTicks(5229),
                            CreatorUserId = 0,
                            DeleterUserId = 0,
                            IsDeleted = false,
                            LastModificationTime = new DateTime(2025, 6, 20, 2, 47, 11, 218, DateTimeKind.Utc).AddTicks(5229),
                            LastModifierUserId = 1,
                            Password = "AM4OLBpptxBYmM79lGOX9egzZk3vIQU3d/gFCJzaBjAPXzYIK3tQ2N7X4fcrHtElTw==",
                            Role = 0,
                            Username = "user"
                        });
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

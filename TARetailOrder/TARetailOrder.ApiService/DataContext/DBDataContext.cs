using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TARetailOrder.ApiService.DataContext.Models;
using TARetailOrder.ApiService.Enums;
using TARetailOrder.ApiService.Services.Customers;
using TARetailOrder.ApiService.Services.PasswordHash;


namespace TARetailOrder.ApiService.DataContext
{
    public class DBDataContext : DbContext
    {
        public DBDataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set;}
        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed data - For Demo Purpose only
            //SeedCustomers(modelBuilder);
            //SeedUsers(modelBuilder);
            //SeedCategories(modelBuilder);
            //SeedProducts(modelBuilder);
        }

        private void SeedCustomers(ModelBuilder modelBuilder)
        {
            var baseDate = DateTime.UtcNow;

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    ID = Guid.NewGuid(),
                    FirstName = "John",
                    LastName = "Smith",
                    Email = "john.smith@email.com",
                    PhoneNo = "09123456789",
                    ShippingAddress = "123 Main Street, Quezon City, Metro Manila, Philippines",
                    BillingAddress = "123 Main Street, Quezon City, Metro Manila, Philippines",
                    CreationTime = baseDate.AddDays(-30),
                    CreatorUserId = 1,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Customer
                {
                    ID = Guid.NewGuid(),
                    FirstName = "Maria",
                    LastName = "Santos",
                    Email = "maria.santos@gmail.com",
                    PhoneNo = "09187654321",
                    ShippingAddress = "456 Rizal Avenue, Makati City, Metro Manila, Philippines",
                    BillingAddress = "456 Rizal Avenue, Makati City, Metro Manila, Philippines",
                    CreationTime = baseDate.AddDays(-25),
                    CreatorUserId = 1,
                    LastModificationTime = baseDate.AddDays(-10),
                    LastModifierUserId = 2,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Customer
                {
                    ID = Guid.NewGuid(),
                    FirstName = "Carlos",
                    LastName = "Reyes",
                    Email = "carlos.reyes@yahoo.com",
                    PhoneNo = "09234567890",
                    ShippingAddress = "789 Commonwealth Ave, Quezon City, Metro Manila, Philippines",
                    BillingAddress = "321 Ortigas Center, Pasig City, Metro Manila, Philippines",
                    CreationTime = baseDate.AddDays(-20),
                    CreatorUserId = 2,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Customer
                {
                    ID = Guid.NewGuid(),
                    FirstName = "Ana",
                    LastName = "Cruz",
                    Email = "ana.cruz@hotmail.com",
                    PhoneNo = "09198765432",
                    ShippingAddress = "147 Taft Avenue, Manila, Metro Manila, Philippines",
                    BillingAddress = "147 Taft Avenue, Manila, Metro Manila, Philippines",
                    CreationTime = baseDate.AddDays(-15),
                    CreatorUserId = 1,
                    LastModificationTime = baseDate.AddDays(-5),
                    LastModifierUserId = 1,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Customer
                {
                    ID = Guid.NewGuid(),
                    FirstName = "Roberto",
                    LastName = "Garcia",
                    Email = "roberto.garcia@outlook.com",
                    PhoneNo = "09345678901",
                    ShippingAddress = "258 EDSA, Mandaluyong City, Metro Manila, Philippines",
                    BillingAddress = "258 EDSA, Mandaluyong City, Metro Manila, Philippines",
                    CreationTime = baseDate.AddDays(-12),
                    CreatorUserId = 2,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Customer
                {
                    ID = Guid.NewGuid(),
                    FirstName = "Elena",
                    LastName = "Mendoza",
                    Email = "elena.mendoza@gmail.com",
                    PhoneNo = "09456789012",
                    ShippingAddress = "369 Katipunan Avenue, Quezon City, Metro Manila, Philippines",
                    BillingAddress = "159 BGC, Taguig City, Metro Manila, Philippines",
                    CreationTime = baseDate.AddDays(-8),
                    CreatorUserId = 1,
                    LastModificationTime = baseDate.AddDays(-2),
                    LastModifierUserId = 2,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Customer
                {
                    ID = Guid.NewGuid(),
                    FirstName = "Miguel",
                    LastName = "Torres",
                    Email = "miguel.torres@email.com",
                    PhoneNo = "09567890123",
                    ShippingAddress = "741 Shaw Boulevard, Mandaluyong City, Metro Manila, Philippines",
                    BillingAddress = "741 Shaw Boulevard, Mandaluyong City, Metro Manila, Philippines",
                    CreationTime = baseDate.AddDays(-6),
                    CreatorUserId = 2,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Customer
                {
                    ID = Guid.NewGuid(),
                    FirstName = "Isabella",
                    LastName = "Flores",
                    Email = "isabella.flores@yahoo.com",
                    PhoneNo = "09678901234",
                    ShippingAddress = "852 Alabang-Zapote Road, Las Piñas City, Metro Manila, Philippines",
                    BillingAddress = "852 Alabang-Zapote Road, Las Piñas City, Metro Manila, Philippines",
                    CreationTime = baseDate.AddDays(-4),
                    CreatorUserId = 1,
                    LastModificationTime = baseDate.AddDays(-1),
                    LastModifierUserId = 1,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Customer
                {
                    ID = Guid.NewGuid(),
                    FirstName = "Diego",
                    LastName = "Villanueva",
                    Email = null, // This customer has no email
                    PhoneNo = "09789012345",
                    ShippingAddress = "963 C5 Road, Pasig City, Metro Manila, Philippines",
                    BillingAddress = "963 C5 Road, Pasig City, Metro Manila, Philippines",
                    CreationTime = baseDate.AddDays(-2),
                    CreatorUserId = 2,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                }
            );
        }
        private void SeedUsers(ModelBuilder modelBuilder)
        {
            var baseDate = DateTime.UtcNow;

            modelBuilder.Entity<User>().HasData(
               new User
               {
                   ID = Guid.NewGuid(),
                   Username = "admin",
                   Password = "AM4OLBpptxBYmM79lGOX9egzZk3vIQU3d/gFCJzaBjAPXzYIK3tQ2N7X4fcrHtElTw==",
                   Role = UserRole.Admin,
                   CreationTime = baseDate.AddDays(-60),
                   CreatorUserId = 0, // System user
                   LastModificationTime = null,
                   LastModifierUserId = null,
                   DeletionTime = null,
                   IsDeleted = false,
                   DeleterUserId = 0
               },
                new User
                {
                    ID = Guid.NewGuid(),
                    Username = "user",
                    Password = "AM4OLBpptxBYmM79lGOX9egzZk3vIQU3d/gFCJzaBjAPXzYIK3tQ2N7X4fcrHtElTw==",
                    Role = UserRole.User,
                    CreationTime = baseDate.AddDays(-45),
                    CreatorUserId = 0,
                    LastModificationTime = baseDate.AddDays(-10),
                    LastModifierUserId = 1,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                }
            );
        }

        private void SeedCategories(ModelBuilder modelBuilder)
        {
            var baseDate = DateTime.UtcNow;
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    ID = Guid.NewGuid(),
                    Name = "Electronics",
                    Description = "Electronic devices and accessories for modern living",
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-90),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Category
                {
                    ID = Guid.NewGuid(),
                    Name = "Clothing",
                    Description = "Fashion and apparel for all occasions",
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-85),
                    CreatorUserId = 0,
                    LastModificationTime = baseDate.AddDays(-20),
                    LastModifierUserId = 1,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Category
                {
                    ID = Guid.NewGuid(),
                    Name = "Home & Kitchen",
                    Description = "Essential items for your home and kitchen needs",
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-80),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Category
                {
                    ID = Guid.NewGuid(),
                    Name = "Books",
                    Description = "Educational and entertainment reading materials",
                    Status = Status.Inactive,
                    CreationTime = baseDate.AddDays(-75),
                    CreatorUserId = 0,
                    LastModificationTime = baseDate.AddDays(-15),
                    LastModifierUserId = 1,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Category
                {
                    ID = Guid.NewGuid(),
                    Name = "Sports & Outdoors",
                    Description = "Equipment and gear for outdoor activities and sports",
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-70),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                }
            );
        }

        private void SeedProducts(ModelBuilder modelBuilder)
        {
            var baseDate = DateTime.UtcNow;
            var electronicsId = Guid.Parse("0e798d71-0ea8-4166-8051-aa77545c1842");
            var clothingId = Guid.Parse("2300c16c-ac05-48d1-8053-d39d3d704f61");
            var homeKitchenId = Guid.Parse("825b818a-d436-4bac-8e1b-9472409335e1");
            var booksId = Guid.Parse("efdab8b9-fd6b-4311-9a45-f014682f47ed");
            var sportsId = Guid.Parse("fec1de25-5bc4-4351-a9ac-6a46addd55f7");

            modelBuilder.Entity<Product>().HasData(
                // Electronics Products
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Wireless Bluetooth Headphones",
                    Description = "High-quality wireless headphones with noise cancellation",
                    UnitPrice = 149.99m,
                    Qty = 25,
                    SKU = "WBH12345",
                    CategoryId = electronicsId,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-60),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Smartphone Case",
                    Description = "Durable protective case for smartphones",
                    UnitPrice = 24.99m,
                    Qty = 150,
                    SKU = "SPC67890",
                    CategoryId = electronicsId,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-55),
                    CreatorUserId = 0,
                    LastModificationTime = baseDate.AddDays(-10),
                    LastModifierUserId = 1,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Wireless Charger",
                    Description = "Fast wireless charging pad for compatible devices",
                    UnitPrice = 39.99m,
                    Qty = 75,
                    SKU = "WCH11111",
                    CategoryId = electronicsId,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-50),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "USB Cable",
                    Description = "High-speed USB charging and data cable",
                    UnitPrice = 12.99m,
                    Qty = 200,
                    SKU = "USB22222",
                    CategoryId = electronicsId,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-45),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Power Bank",
                    Description = "Portable battery charger with high capacity",
                    UnitPrice = 59.99m,
                    Qty = 50,
                    SKU = "PWB33333",
                    CategoryId = electronicsId,
                    Status = Status.Inactive,
                    CreationTime = baseDate.AddDays(-40),
                    CreatorUserId = 0,
                    LastModificationTime = baseDate.AddDays(-5),
                    LastModifierUserId = 1,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },

                // Clothing Products
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Cotton T-Shirt",
                    Description = "Comfortable 100% cotton t-shirt in various colors",
                    UnitPrice = 19.99m,
                    Qty = 100,
                    SKU = "CTS44444",
                    CategoryId = clothingId,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-65),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Denim Jeans",
                    Description = "Classic fit denim jeans with premium quality",
                    UnitPrice = 79.99m,
                    Qty = 60,
                    SKU = "DNJ55555",
                    CategoryId = clothingId,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-58),
                    CreatorUserId = 0,
                    LastModificationTime = baseDate.AddDays(-15),
                    LastModifierUserId = 1,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Winter Jacket",
                    Description = "Warm and stylish winter jacket with hood",
                    UnitPrice = 129.99m,
                    Qty = 30,
                    SKU = "WJK66666",
                    CategoryId = clothingId,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-52),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Summer Dress",
                    Description = "Light and breezy summer dress perfect for warm weather",
                    UnitPrice = 49.99m,
                    Qty = 40,
                    SKU = "SMD77777",
                    CategoryId = clothingId,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-48),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Casual Sneakers",
                    Description = "Comfortable sneakers for everyday wear",
                    UnitPrice = 89.99m,
                    Qty = 45,
                    SKU = "CSN88888",
                    CategoryId = clothingId,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-42),
                    CreatorUserId = 0,
                    LastModificationTime = baseDate.AddDays(-8),
                    LastModifierUserId = 1,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },

                // Home & Kitchen Products
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Stainless Steel Cookware Set",
                    Description = "Professional grade cookware set with non-stick coating",
                    UnitPrice = 199.99m,
                    Qty = 20,
                    SKU = "SSC99999",
                    CategoryId = homeKitchenId,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-70),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Coffee Maker",
                    Description = "Programmable coffee maker with thermal carafe",
                    UnitPrice = 89.99m,
                    Qty = 35,
                    SKU = "CFM00000",
                    CategoryId = homeKitchenId,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-63),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Kitchen Knife Set",
                    Description = "Sharp and durable kitchen knives with wooden block",
                    UnitPrice = 119.99m,
                    Qty = 25,
                    SKU = "KNS11111",
                    CategoryId = homeKitchenId,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-56),
                    CreatorUserId = 0,
                    LastModificationTime = baseDate.AddDays(-12),
                    LastModifierUserId = 1,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Non-Stick Pan",
                    Description = "High-quality non-stick frying pan",
                    UnitPrice = 34.99m,
                    Qty = 80,
                    SKU = "NSP22222",
                    CategoryId = homeKitchenId,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-49),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Blender",
                    Description = "Powerful blender for smoothies and food preparation",
                    UnitPrice = 79.99m,
                    Qty = 40,
                    SKU = "BLD33333",
                    CategoryId = homeKitchenId,
                    Status = Status.Inactive,
                    CreationTime = baseDate.AddDays(-43),
                    CreatorUserId = 0,
                    LastModificationTime = baseDate.AddDays(-7),
                    LastModifierUserId = 1,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },

                // Books Products
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Programming Guide",
                    Description = "Comprehensive guide to modern programming languages",
                    UnitPrice = 39.99m,
                    Qty = 50,
                    SKU = "PRG44444",
                    CategoryId = booksId,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-68),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Mystery Novel",
                    Description = "Thrilling mystery novel with unexpected twists",
                    UnitPrice = 14.99m,
                    Qty = 75,
                    SKU = "MYN55555",
                    CategoryId = booksId,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-61),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Science Fiction Book",
                    Description = "Epic science fiction adventure in space",
                    UnitPrice = 16.99m,
                    Qty = 60,
                    SKU = "SFB66666",
                    CategoryId = booksId,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-54),
                    CreatorUserId = 0,
                    LastModificationTime = baseDate.AddDays(-18),
                    LastModifierUserId = 1,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Cookbook",
                    Description = "Delicious recipes for home cooking enthusiasts",
                    UnitPrice = 24.99m,
                    Qty = 45,
                    SKU = "CBK77777",
                    CategoryId = booksId,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-47),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "History Book",
                    Description = "Comprehensive overview of world history",
                    UnitPrice = 29.99m,
                    Qty = 35,
                    SKU = "HSB88888",
                    CategoryId = booksId,
                    Status = Status.Inactive,
                    CreationTime = baseDate.AddDays(-41),
                    CreatorUserId = 0,
                    LastModificationTime = baseDate.AddDays(-3),
                    LastModifierUserId = 1,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },

                // Sports & Outdoors Products
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Yoga Mat",
                    Description = "Non-slip yoga mat for exercise and meditation",
                    UnitPrice = 29.99m,
                    Qty = 80,
                    SKU = "YGM99999",
                    CategoryId = sportsId,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-72),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Running Shoes",
                    Description = "Lightweight running shoes with superior cushioning",
                    UnitPrice = 119.99m,
                    Qty = 55,
                    SKU = "RNS00001",
                    CategoryId = sportsId,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-66),
                    CreatorUserId = 0,
                    LastModificationTime = baseDate.AddDays(-14),
                    LastModifierUserId = 1,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Gym Water Bottle",
                    Description = "Insulated water bottle perfect for workouts",
                    UnitPrice = 19.99m,
                    Qty = 120,
                    SKU = "GWB00002",
                    CategoryId = sportsId,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-59),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Resistance Bands",
                    Description = "Set of resistance bands for strength training",
                    UnitPrice = 24.99m,
                    Qty = 65,
                    SKU = "RSB00003",
                    CategoryId = sportsId,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-53),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Basketball",
                    Description = "Official size basketball for indoor and outdoor play",
                    UnitPrice = 34.99m,
                    Qty = 40,
                    SKU = "BSK00004",
                    CategoryId = sportsId,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-46),
                    CreatorUserId = 0,
                    LastModificationTime = baseDate.AddDays(-6),
                    LastModifierUserId = 1,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                }
            );
        }
    }


    // For Aspire Auto create Database when Postgressql server is running
    public static class Extensions
    {
        public static void CreateDbIfNotExists(this IHost host)
        {
            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<DBDataContext>();
            try
            {
                context.Database.EnsureCreated();
                DbInitializer.Initialize(context);

            }
            catch
            {
            }
        }
    }

    public static class DbInitializer
    {
        public static void Initialize(DBDataContext context)
        {
            InitializeDataCustomers(context);
            InitializeDataUsers(context);
            InitializeDataCategories(context);
            InitializeDataProducts(context);
        }

        public static void InitializeDataCustomers(DBDataContext context)
        {
            if (context.Customer.Any())
                return;
            var baseDate = DateTime.UtcNow;

            var customers = new List<Customer>
    {

                new Customer
                {
                    ID = Guid.NewGuid(),
                    FirstName = "John",
                    LastName = "Smith",
                    Email = "john.smith@email.com",
                    PhoneNo = "09123456789",
                    ShippingAddress = "123 Main Street, Quezon City, Metro Manila, Philippines",
                    BillingAddress = "123 Main Street, Quezon City, Metro Manila, Philippines",
                    CreationTime = baseDate.AddDays(-30),
                    CreatorUserId = 1,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Customer
                {
                    ID = Guid.NewGuid(),
                    FirstName = "Maria",
                    LastName = "Santos",
                    Email = "maria.santos@gmail.com",
                    PhoneNo = "09187654321",
                    ShippingAddress = "456 Rizal Avenue, Makati City, Metro Manila, Philippines",
                    BillingAddress = "456 Rizal Avenue, Makati City, Metro Manila, Philippines",
                    CreationTime = baseDate.AddDays(-25),
                    CreatorUserId = 1,
                    LastModificationTime = baseDate.AddDays(-10),
                    LastModifierUserId = 2,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Customer
                {
                    ID = Guid.NewGuid(),
                    FirstName = "Carlos",
                    LastName = "Reyes",
                    Email = "carlos.reyes@yahoo.com",
                    PhoneNo = "09234567890",
                    ShippingAddress = "789 Commonwealth Ave, Quezon City, Metro Manila, Philippines",
                    BillingAddress = "321 Ortigas Center, Pasig City, Metro Manila, Philippines",
                    CreationTime = baseDate.AddDays(-20),
                    CreatorUserId = 2,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Customer
                {
                    ID = Guid.NewGuid(),
                    FirstName = "Ana",
                    LastName = "Cruz",
                    Email = "ana.cruz@hotmail.com",
                    PhoneNo = "09198765432",
                    ShippingAddress = "147 Taft Avenue, Manila, Metro Manila, Philippines",
                    BillingAddress = "147 Taft Avenue, Manila, Metro Manila, Philippines",
                    CreationTime = baseDate.AddDays(-15),
                    CreatorUserId = 1,
                    LastModificationTime = baseDate.AddDays(-5),
                    LastModifierUserId = 1,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Customer
                {
                    ID = Guid.NewGuid(),
                    FirstName = "Roberto",
                    LastName = "Garcia",
                    Email = "roberto.garcia@outlook.com",
                    PhoneNo = "09345678901",
                    ShippingAddress = "258 EDSA, Mandaluyong City, Metro Manila, Philippines",
                    BillingAddress = "258 EDSA, Mandaluyong City, Metro Manila, Philippines",
                    CreationTime = baseDate.AddDays(-12),
                    CreatorUserId = 2,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Customer
                {
                    ID = Guid.NewGuid(),
                    FirstName = "Elena",
                    LastName = "Mendoza",
                    Email = "elena.mendoza@gmail.com",
                    PhoneNo = "09456789012",
                    ShippingAddress = "369 Katipunan Avenue, Quezon City, Metro Manila, Philippines",
                    BillingAddress = "159 BGC, Taguig City, Metro Manila, Philippines",
                    CreationTime = baseDate.AddDays(-8),
                    CreatorUserId = 1,
                    LastModificationTime = baseDate.AddDays(-2),
                    LastModifierUserId = 2,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Customer
                {
                    ID = Guid.NewGuid(),
                    FirstName = "Miguel",
                    LastName = "Torres",
                    Email = "miguel.torres@email.com",
                    PhoneNo = "09567890123",
                    ShippingAddress = "741 Shaw Boulevard, Mandaluyong City, Metro Manila, Philippines",
                    BillingAddress = "741 Shaw Boulevard, Mandaluyong City, Metro Manila, Philippines",
                    CreationTime = baseDate.AddDays(-6),
                    CreatorUserId = 2,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Customer
                {
                    ID = Guid.NewGuid(),
                    FirstName = "Isabella",
                    LastName = "Flores",
                    Email = "isabella.flores@yahoo.com",
                    PhoneNo = "09678901234",
                    ShippingAddress = "852 Alabang-Zapote Road, Las Piñas City, Metro Manila, Philippines",
                    BillingAddress = "852 Alabang-Zapote Road, Las Piñas City, Metro Manila, Philippines",
                    CreationTime = baseDate.AddDays(-4),
                    CreatorUserId = 1,
                    LastModificationTime = baseDate.AddDays(-1),
                    LastModifierUserId = 1,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Customer
                {
                    ID = Guid.NewGuid(),
                    FirstName = "Diego",
                    LastName = "Villanueva",
                    Email = null,
                    PhoneNo = "09789012345",
                    ShippingAddress = "963 C5 Road, Pasig City, Metro Manila, Philippines",
                    BillingAddress = "963 C5 Road, Pasig City, Metro Manila, Philippines",
                    CreationTime = baseDate.AddDays(-2),
                    CreatorUserId = 2,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                }
            };
            context.AddRange(customers);
            context.SaveChanges();
        }

        public static void InitializeDataUsers(DBDataContext context)
        {
            if (context.User.Any())
                return;
            var baseDate = DateTime.UtcNow;

            var users = new List<User>
                {
                    new User
                    {
                        ID = Guid.NewGuid(),
                        Username = "admin",
                        Password = "123qwe", // Consider hashing this password
                        Role = UserRole.Admin,
                        CreationTime = baseDate.AddDays(-60),
                        CreatorUserId = 0, // System user
                        LastModificationTime = null,
                        LastModifierUserId = null,
                        DeletionTime = null,
                        IsDeleted = false,
                        DeleterUserId = 0
                    },
                    new User
                    {
                        ID = Guid.NewGuid(),
                        Username = "user",
                        Password = "123qwe",
                        Role = UserRole.User,
                        CreationTime = baseDate.AddDays(-45),
                        CreatorUserId = 0,
                        LastModificationTime = baseDate.AddDays(-10),
                        LastModifierUserId = 1,
                        DeletionTime = null,
                        IsDeleted = false,
                        DeleterUserId = 0
                    }
                };
            context.AddRange(users);
            context.SaveChanges();
        }
        public static void InitializeDataCategories(DBDataContext context)
        {
            if (context.Category.Any())
                return;
            var baseDate = DateTime.UtcNow;
            var categories = new List<Category>
            {
                new Category
                {
                    ID = Guid.Parse("0e798d71-0ea8-4166-8051-aa77545c1842"),
                    Name = "Electronics",
                    Description = "Electronic devices and accessories for modern living",
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-90),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Category
                {
                    ID = Guid.Parse("2300c16c-ac05-48d1-8053-d39d3d704f61"),
                    Name = "Clothing",
                    Description = "Fashion and apparel for all occasions",
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-85),
                    CreatorUserId = 0,
                    LastModificationTime = baseDate.AddDays(-20),
                    LastModifierUserId = 1,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Category
                {
                    ID = Guid.Parse("825b818a-d436-4bac-8e1b-9472409335e1"),
                    Name = "Home & Kitchen",
                    Description = "Essential items for your home and kitchen needs",
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-80),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Category
                {
                    ID = Guid.Parse("efdab8b9-fd6b-4311-9a45-f014682f47ed"),
                    Name = "Books",
                    Description = "Educational and entertainment reading materials",
                    Status = Status.Inactive,
                    CreationTime = baseDate.AddDays(-75),
                    CreatorUserId = 0,
                    LastModificationTime = baseDate.AddDays(-15),
                    LastModifierUserId = 1,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Category
                {
                    ID = Guid.Parse("fec1de25-5bc4-4351-a9ac-6a46addd55f7"),
                    Name = "Sports & Outdoors",
                    Description = "Equipment and gear for outdoor activities and sports",
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-70),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                }
            };

            context.AddRange(categories);
            context.SaveChanges();
        }

        public static void InitializeDataProducts(DBDataContext context)
        {
            if (context.Product.Any())
                return;


            var baseDate = DateTime.UtcNow;

            var electronicsId = Guid.Parse("0e798d71-0ea8-4166-8051-aa77545c1842");
            var clothingId = Guid.Parse("2300c16c-ac05-48d1-8053-d39d3d704f61");
            var homeKitchenId = Guid.Parse("825b818a-d436-4bac-8e1b-9472409335e1");
            var booksId = Guid.Parse("efdab8b9-fd6b-4311-9a45-f014682f47ed");
            var sportsId = Guid.Parse("fec1de25-5bc4-4351-a9ac-6a46addd55f7");

            var products = new List<Product>
            {
                // Electronics Products
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Wireless Bluetooth Headphones",
                    Description = "High-quality wireless headphones with noise cancellation",
                    UnitPrice = 149.99m,
                    Qty = 25,
                    SKU = "WBH12345",
                    CategoryId = electronicsId ,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-60),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Smartphone Case",
                    Description = "Durable protective case for smartphones",
                    UnitPrice = 24.99m,
                    Qty = 150,
                    SKU = "SPC67890",
                    CategoryId = electronicsId ,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-55),
                    CreatorUserId = 0,
                    LastModificationTime = baseDate.AddDays(-10),
                    LastModifierUserId = 1,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Wireless Charger",
                    Description = "Fast wireless charging pad for compatible devices",
                    UnitPrice = 39.99m,
                    Qty = 75,
                    SKU = "WCH11111",
                    CategoryId = electronicsId ,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-50),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "USB Cable",
                    Description = "High-speed USB charging and data cable",
                    UnitPrice = 12.99m,
                    Qty = 200,
                    SKU = "USB22222",
                    CategoryId = electronicsId ,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-45),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Power Bank",
                    Description = "Portable battery charger with high capacity",
                    UnitPrice = 59.99m,
                    Qty = 50,
                    SKU = "PWB33333",
                    CategoryId = electronicsId ,
                    Status = Status.Inactive,
                    CreationTime = baseDate.AddDays(-40),
                    CreatorUserId = 0,
                    LastModificationTime = baseDate.AddDays(-5),
                    LastModifierUserId = 1,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },

                // Clothing Products
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Cotton T-Shirt",
                    Description = "Comfortable 100% cotton t-shirt in various colors",
                    UnitPrice = 19.99m,
                    Qty = 100,
                    SKU = "CTS44444",
                    CategoryId = clothingId ,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-65),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Denim Jeans",
                    Description = "Classic fit denim jeans with premium quality",
                    UnitPrice = 79.99m,
                    Qty = 60,
                    SKU = "DNJ55555",
                    CategoryId = clothingId ,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-58),
                    CreatorUserId = 0,
                    LastModificationTime = baseDate.AddDays(-15),
                    LastModifierUserId = 1,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Winter Jacket",
                    Description = "Warm and stylish winter jacket with hood",
                    UnitPrice = 129.99m,
                    Qty = 30,
                    SKU = "WJK66666",
                    CategoryId = clothingId ,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-52),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Summer Dress",
                    Description = "Light and breezy summer dress perfect for warm weather",
                    UnitPrice = 49.99m,
                    Qty = 40,
                    SKU = "SMD77777",
                    CategoryId = clothingId ,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-48),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Casual Sneakers",
                    Description = "Comfortable sneakers for everyday wear",
                    UnitPrice = 89.99m,
                    Qty = 45,
                    SKU = "CSN88888",
                    CategoryId = clothingId ,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-42),
                    CreatorUserId = 0,
                    LastModificationTime = baseDate.AddDays(-8),
                    LastModifierUserId = 1,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },

                // Home & Kitchen Products
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Stainless Steel Cookware Set",
                    Description = "Professional grade cookware set with non-stick coating",
                    UnitPrice = 199.99m,
                    Qty = 20,
                    SKU = "SSC99999",
                    CategoryId = homeKitchenId ,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-70),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Coffee Maker",
                    Description = "Programmable coffee maker with thermal carafe",
                    UnitPrice = 89.99m,
                    Qty = 35,
                    SKU = "CFM00000",
                    CategoryId = homeKitchenId ,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-63),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Kitchen Knife Set",
                    Description = "Sharp and durable kitchen knives with wooden block",
                    UnitPrice = 119.99m,
                    Qty = 25,
                    SKU = "KNS11111",
                    CategoryId = homeKitchenId ,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-56),
                    CreatorUserId = 0,
                    LastModificationTime = baseDate.AddDays(-12),
                    LastModifierUserId = 1,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Non-Stick Pan",
                    Description = "High-quality non-stick frying pan",
                    UnitPrice = 34.99m,
                    Qty = 80,
                    SKU = "NSP22222",
                    CategoryId = homeKitchenId ,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-49),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Blender",
                    Description = "Powerful blender for smoothies and food preparation",
                    UnitPrice = 79.99m,
                    Qty = 40,
                    SKU = "BLD33333",
                    CategoryId = homeKitchenId ,
                    Status = Status.Inactive,
                    CreationTime = baseDate.AddDays(-43),
                    CreatorUserId = 0,
                    LastModificationTime = baseDate.AddDays(-7),
                    LastModifierUserId = 1,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },

                // Books Products
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Programming Guide",
                    Description = "Comprehensive guide to modern programming languages",
                    UnitPrice = 39.99m,
                    Qty = 50,
                    SKU = "PRG44444",
                    CategoryId = booksId ,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-68),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Mystery Novel",
                    Description = "Thrilling mystery novel with unexpected twists",
                    UnitPrice = 14.99m,
                    Qty = 75,
                    SKU = "MYN55555",
                    CategoryId = booksId ,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-61),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Science Fiction Book",
                    Description = "Epic science fiction adventure in space",
                    UnitPrice = 16.99m,
                    Qty = 60,
                    SKU = "SFB66666",
                    CategoryId = booksId ,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-54),
                    CreatorUserId = 0,
                    LastModificationTime = baseDate.AddDays(-18),
                    LastModifierUserId = 1,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Cookbook",
                    Description = "Delicious recipes for home cooking enthusiasts",
                    UnitPrice = 24.99m,
                    Qty = 45,
                    SKU = "CBK77777",
                    CategoryId = booksId ,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-47),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "History Book",
                    Description = "Comprehensive overview of world history",
                    UnitPrice = 29.99m,
                    Qty = 35,
                    SKU = "HSB88888",
                    CategoryId = booksId ,
                    Status = Status.Inactive,
                    CreationTime = baseDate.AddDays(-41),
                    CreatorUserId = 0,
                    LastModificationTime = baseDate.AddDays(-3),
                    LastModifierUserId = 1,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },

                // Sports & Outdoors Products
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Yoga Mat",
                    Description = "Non-slip yoga mat for exercise and meditation",
                    UnitPrice = 29.99m,
                    Qty = 80,
                    SKU = "YGM99999",
                    CategoryId = sportsId ,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-72),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Running Shoes",
                    Description = "Lightweight running shoes with superior cushioning",
                    UnitPrice = 119.99m,
                    Qty = 55,
                    SKU = "RNS00001",
                    CategoryId = sportsId ,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-66),
                    CreatorUserId = 0,
                    LastModificationTime = baseDate.AddDays(-14),
                    LastModifierUserId = 1,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Gym Water Bottle",
                    Description = "Insulated water bottle perfect for workouts",
                    UnitPrice = 19.99m,
                    Qty = 120,
                    SKU = "GWB00002",
                    CategoryId = sportsId ,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-59),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Resistance Bands",
                    Description = "Set of resistance bands for strength training",
                    UnitPrice = 24.99m,
                    Qty = 65,
                    SKU = "RSB00003",
                    CategoryId = sportsId ,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-53),
                    CreatorUserId = 0,
                    LastModificationTime = null,
                    LastModifierUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Basketball",
                    Description = "Official size basketball for indoor and outdoor play",
                    UnitPrice = 34.99m,
                    Qty = 40,
                    SKU = "BSK00004",
                    CategoryId = sportsId ,
                    Status = Status.Active,
                    CreationTime = baseDate.AddDays(-46),
                    CreatorUserId = 0,
                    LastModificationTime = baseDate.AddDays(-6),
                    LastModifierUserId = 1,
                    DeletionTime = null,
                    IsDeleted = false,
                    DeleterUserId = 0
                }
            };

                    context.AddRange(products);
                    context.SaveChanges();
                }
    }
}

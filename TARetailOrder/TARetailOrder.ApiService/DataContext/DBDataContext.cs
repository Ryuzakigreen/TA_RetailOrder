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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            PostgresqlDatetimeUTCConversion(modelBuilder);
            //Seed data of Customers
            SeedCustomers(modelBuilder);
            SeedUsers(modelBuilder);
        }

        private void PostgresqlDatetimeUTCConversion(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(e =>
            {
                e.HasKey(u => u.ID);
            });
            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(u => u.ID);
            });
            modelBuilder.Entity<Category>(e =>
            {
                e.HasKey(u => u.ID);
            });
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
    }
}

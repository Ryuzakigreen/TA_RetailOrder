using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TARetailOrder.ApiService.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class AddedCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNo = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    ShippingAddress = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    BillingAddress = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorUserId = table.Column<int>(type: "integer", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierUserId = table.Column<int>(type: "integer", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleterUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "BillingAddress", "CreationTime", "CreatorUserId", "DeleterUserId", "DeletionTime", "Email", "FirstName", "IsDeleted", "LastModificationTime", "LastModifierUserId", "LastName", "PhoneNo", "ShippingAddress" },
                values: new object[,]
                {
                    { new Guid("4f3f17ea-a442-449d-95ad-6df6fe4f4858"), "147 Taft Avenue, Manila, Metro Manila, Philippines", new DateTime(2025, 6, 14, 4, 46, 24, 718, DateTimeKind.Utc).AddTicks(7299), 1, 0, null, "ana.cruz@hotmail.com", "Ana", false, new DateTime(2025, 6, 24, 4, 46, 24, 718, DateTimeKind.Utc).AddTicks(7299), 1, "Cruz", "09198765432", "147 Taft Avenue, Manila, Metro Manila, Philippines" },
                    { new Guid("4fcfb431-fc3e-4300-a08e-34b10e5b7b0a"), "321 Ortigas Center, Pasig City, Metro Manila, Philippines", new DateTime(2025, 6, 9, 4, 46, 24, 718, DateTimeKind.Utc).AddTicks(7299), 2, 0, null, "carlos.reyes@yahoo.com", "Carlos", false, null, null, "Reyes", "09234567890", "789 Commonwealth Ave, Quezon City, Metro Manila, Philippines" },
                    { new Guid("63ac7e3c-6d96-47c3-9891-b6bcb1b80c21"), "456 Rizal Avenue, Makati City, Metro Manila, Philippines", new DateTime(2025, 6, 4, 4, 46, 24, 718, DateTimeKind.Utc).AddTicks(7299), 1, 0, null, "maria.santos@gmail.com", "Maria", false, new DateTime(2025, 6, 19, 4, 46, 24, 718, DateTimeKind.Utc).AddTicks(7299), 2, "Santos", "09187654321", "456 Rizal Avenue, Makati City, Metro Manila, Philippines" },
                    { new Guid("7687101b-298c-4191-b2a6-892190014183"), "159 BGC, Taguig City, Metro Manila, Philippines", new DateTime(2025, 6, 21, 4, 46, 24, 718, DateTimeKind.Utc).AddTicks(7299), 1, 0, null, "elena.mendoza@gmail.com", "Elena", false, new DateTime(2025, 6, 27, 4, 46, 24, 718, DateTimeKind.Utc).AddTicks(7299), 2, "Mendoza", "09456789012", "369 Katipunan Avenue, Quezon City, Metro Manila, Philippines" },
                    { new Guid("7dc2dcde-5566-45df-b0e5-45a799e092a8"), "963 C5 Road, Pasig City, Metro Manila, Philippines", new DateTime(2025, 6, 27, 4, 46, 24, 718, DateTimeKind.Utc).AddTicks(7299), 2, 0, null, null, "Diego", false, null, null, "Villanueva", "09789012345", "963 C5 Road, Pasig City, Metro Manila, Philippines" },
                    { new Guid("a8d92d30-8932-4b93-86a3-c5540689970a"), "852 Alabang-Zapote Road, Las Piñas City, Metro Manila, Philippines", new DateTime(2025, 6, 25, 4, 46, 24, 718, DateTimeKind.Utc).AddTicks(7299), 1, 0, null, "isabella.flores@yahoo.com", "Isabella", false, new DateTime(2025, 6, 28, 4, 46, 24, 718, DateTimeKind.Utc).AddTicks(7299), 1, "Flores", "09678901234", "852 Alabang-Zapote Road, Las Piñas City, Metro Manila, Philippines" },
                    { new Guid("b3dbbfc9-3026-4485-b9ca-6b6cb51e0f1e"), "258 EDSA, Mandaluyong City, Metro Manila, Philippines", new DateTime(2025, 6, 17, 4, 46, 24, 718, DateTimeKind.Utc).AddTicks(7299), 2, 0, null, "roberto.garcia@outlook.com", "Roberto", false, null, null, "Garcia", "09345678901", "258 EDSA, Mandaluyong City, Metro Manila, Philippines" },
                    { new Guid("ba1e3f8b-367a-4fc0-a8a2-0d4ed869509c"), "123 Main Street, Quezon City, Metro Manila, Philippines", new DateTime(2025, 5, 30, 4, 46, 24, 718, DateTimeKind.Utc).AddTicks(7299), 1, 0, null, "john.smith@email.com", "John", false, null, null, "Smith", "09123456789", "123 Main Street, Quezon City, Metro Manila, Philippines" },
                    { new Guid("e3de4898-565e-4d3e-b9fb-586a29ab273b"), "741 Shaw Boulevard, Mandaluyong City, Metro Manila, Philippines", new DateTime(2025, 6, 23, 4, 46, 24, 718, DateTimeKind.Utc).AddTicks(7299), 2, 0, null, "miguel.torres@email.com", "Miguel", false, null, null, "Torres", "09567890123", "741 Shaw Boulevard, Mandaluyong City, Metro Manila, Philippines" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}

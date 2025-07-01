using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TARetailOrder.ApiService.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "CreationTime", "CreatorUserId", "DeleterUserId", "DeletionTime", "Description", "IsDeleted", "LastModificationTime", "LastModifierUserId", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("0e798d71-0ea8-4166-8051-aa77545c1842"), new DateTime(2025, 4, 1, 4, 13, 39, 91, DateTimeKind.Utc).AddTicks(8194), 0, 0, null, "Electronic devices and accessories for modern living", false, null, null, "Electronics", 0 },
                    { new Guid("2300c16c-ac05-48d1-8053-d39d3d704f61"), new DateTime(2025, 4, 6, 4, 13, 39, 91, DateTimeKind.Utc).AddTicks(8194), 0, 0, null, "Fashion and apparel for all occasions", false, new DateTime(2025, 6, 10, 4, 13, 39, 91, DateTimeKind.Utc).AddTicks(8194), 1, "Clothing", 0 },
                    { new Guid("825b818a-d436-4bac-8e1b-9472409335e1"), new DateTime(2025, 4, 11, 4, 13, 39, 91, DateTimeKind.Utc).AddTicks(8194), 0, 0, null, "Essential items for your home and kitchen needs", false, null, null, "Home & Kitchen", 0 },
                    { new Guid("efdab8b9-fd6b-4311-9a45-f014682f47ed"), new DateTime(2025, 4, 16, 4, 13, 39, 91, DateTimeKind.Utc).AddTicks(8194), 0, 0, null, "Educational and entertainment reading materials", false, new DateTime(2025, 6, 15, 4, 13, 39, 91, DateTimeKind.Utc).AddTicks(8194), 1, "Books", 1 },
                    { new Guid("fec1de25-5bc4-4351-a9ac-6a46addd55f7"), new DateTime(2025, 4, 21, 4, 13, 39, 91, DateTimeKind.Utc).AddTicks(8194), 0, 0, null, "Equipment and gear for outdoor activities and sports", false, null, null, "Sports & Outdoors", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("0e798d71-0ea8-4166-8051-aa77545c1842"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("2300c16c-ac05-48d1-8053-d39d3d704f61"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("825b818a-d436-4bac-8e1b-9472409335e1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("efdab8b9-fd6b-4311-9a45-f014682f47ed"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("fec1de25-5bc4-4351-a9ac-6a46addd55f7"));

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Products");
        }
    }
}

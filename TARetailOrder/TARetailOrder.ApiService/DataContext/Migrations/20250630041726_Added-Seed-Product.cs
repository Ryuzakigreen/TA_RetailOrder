using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TARetailOrder.ApiService.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryId", "CreationTime", "CreatorUserId", "DeleterUserId", "DeletionTime", "Description", "IsDeleted", "LastModificationTime", "LastModifierUserId", "Name", "Qty", "SKU", "Status", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("0dd88309-6994-4d4b-9dbf-6e568c8a9063"), new Guid("825b818a-d436-4bac-8e1b-9472409335e1"), new DateTime(2025, 4, 28, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 0, 0, null, "Programmable coffee maker with thermal carafe", false, null, null, "Coffee Maker", 35, "CFM00000", 0, 89.99m },
                    { new Guid("0eddcf59-4ec4-4b6f-85d6-caaaf92c5165"), new Guid("efdab8b9-fd6b-4311-9a45-f014682f47ed"), new DateTime(2025, 4, 23, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 0, 0, null, "Comprehensive guide to modern programming languages", false, null, null, "Programming Guide", 50, "PRG44444", 0, 39.99m },
                    { new Guid("11318585-0d25-4e19-9051-652fa8911b7d"), new Guid("fec1de25-5bc4-4351-a9ac-6a46addd55f7"), new DateTime(2025, 4, 25, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 0, 0, null, "Lightweight running shoes with superior cushioning", false, new DateTime(2025, 6, 16, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 1, "Running Shoes", 55, "RNS00001", 0, 119.99m },
                    { new Guid("13996ce9-735c-4a96-8a5c-e8eb762361bc"), new Guid("fec1de25-5bc4-4351-a9ac-6a46addd55f7"), new DateTime(2025, 5, 8, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 0, 0, null, "Set of resistance bands for strength training", false, null, null, "Resistance Bands", 65, "RSB00003", 0, 24.99m },
                    { new Guid("17bdeb16-7ddb-42dc-816e-a97dc402e8e3"), new Guid("2300c16c-ac05-48d1-8053-d39d3d704f61"), new DateTime(2025, 5, 13, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 0, 0, null, "Light and breezy summer dress perfect for warm weather", false, null, null, "Summer Dress", 40, "SMD77777", 0, 49.99m },
                    { new Guid("24230192-6077-4b35-8b66-e068204dc610"), new Guid("825b818a-d436-4bac-8e1b-9472409335e1"), new DateTime(2025, 4, 21, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 0, 0, null, "Professional grade cookware set with non-stick coating", false, null, null, "Stainless Steel Cookware Set", 20, "SSC99999", 0, 199.99m },
                    { new Guid("26f3c4dc-0525-4743-97ef-c24020fb2b63"), new Guid("efdab8b9-fd6b-4311-9a45-f014682f47ed"), new DateTime(2025, 5, 14, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 0, 0, null, "Delicious recipes for home cooking enthusiasts", false, null, null, "Cookbook", 45, "CBK77777", 0, 24.99m },
                    { new Guid("2e621347-dc5e-47d1-88e7-1f997f78fa50"), new Guid("0e798d71-0ea8-4166-8051-aa77545c1842"), new DateTime(2025, 5, 11, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 0, 0, null, "Fast wireless charging pad for compatible devices", false, null, null, "Wireless Charger", 75, "WCH11111", 0, 39.99m },
                    { new Guid("41170985-4bac-4b38-be81-e1e2c9c1850a"), new Guid("0e798d71-0ea8-4166-8051-aa77545c1842"), new DateTime(2025, 5, 6, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 0, 0, null, "Durable protective case for smartphones", false, new DateTime(2025, 6, 20, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 1, "Smartphone Case", 150, "SPC67890", 0, 24.99m },
                    { new Guid("4b999958-03db-4071-9a4f-1d2ddc4aedd1"), new Guid("825b818a-d436-4bac-8e1b-9472409335e1"), new DateTime(2025, 5, 5, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 0, 0, null, "Sharp and durable kitchen knives with wooden block", false, new DateTime(2025, 6, 18, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 1, "Kitchen Knife Set", 25, "KNS11111", 0, 119.99m },
                    { new Guid("4d1d522d-eb82-48e5-bf00-015824d3ecb4"), new Guid("2300c16c-ac05-48d1-8053-d39d3d704f61"), new DateTime(2025, 5, 3, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 0, 0, null, "Classic fit denim jeans with premium quality", false, new DateTime(2025, 6, 15, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 1, "Denim Jeans", 60, "DNJ55555", 0, 79.99m },
                    { new Guid("52d69aa8-aa3d-4a6b-a4fa-3253fea373da"), new Guid("efdab8b9-fd6b-4311-9a45-f014682f47ed"), new DateTime(2025, 5, 7, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 0, 0, null, "Epic science fiction adventure in space", false, new DateTime(2025, 6, 12, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 1, "Science Fiction Book", 60, "SFB66666", 0, 16.99m },
                    { new Guid("592e4cb0-ba05-4cff-b652-a425671a2926"), new Guid("fec1de25-5bc4-4351-a9ac-6a46addd55f7"), new DateTime(2025, 5, 2, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 0, 0, null, "Insulated water bottle perfect for workouts", false, null, null, "Gym Water Bottle", 120, "GWB00002", 0, 19.99m },
                    { new Guid("70b1314b-4418-4dd0-a53f-8f4a7bba71b3"), new Guid("efdab8b9-fd6b-4311-9a45-f014682f47ed"), new DateTime(2025, 4, 30, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 0, 0, null, "Thrilling mystery novel with unexpected twists", false, null, null, "Mystery Novel", 75, "MYN55555", 0, 14.99m },
                    { new Guid("888c1258-b756-4ca7-9c66-af4d2c0ca0f2"), new Guid("2300c16c-ac05-48d1-8053-d39d3d704f61"), new DateTime(2025, 5, 9, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 0, 0, null, "Warm and stylish winter jacket with hood", false, null, null, "Winter Jacket", 30, "WJK66666", 0, 129.99m },
                    { new Guid("8a70a786-a932-4dc5-adea-b0ee3f0d73b3"), new Guid("2300c16c-ac05-48d1-8053-d39d3d704f61"), new DateTime(2025, 4, 26, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 0, 0, null, "Comfortable 100% cotton t-shirt in various colors", false, null, null, "Cotton T-Shirt", 100, "CTS44444", 0, 19.99m },
                    { new Guid("968c4310-1dc8-4e14-aa42-62d6ca53cbc3"), new Guid("2300c16c-ac05-48d1-8053-d39d3d704f61"), new DateTime(2025, 5, 19, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 0, 0, null, "Comfortable sneakers for everyday wear", false, new DateTime(2025, 6, 22, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 1, "Casual Sneakers", 45, "CSN88888", 0, 89.99m },
                    { new Guid("9d1013ab-f060-4e1e-a521-b545b9b67440"), new Guid("fec1de25-5bc4-4351-a9ac-6a46addd55f7"), new DateTime(2025, 5, 15, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 0, 0, null, "Official size basketball for indoor and outdoor play", false, new DateTime(2025, 6, 24, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 1, "Basketball", 40, "BSK00004", 0, 34.99m },
                    { new Guid("bbd05eeb-3d2b-4ab4-8b88-7aaae30b8617"), new Guid("0e798d71-0ea8-4166-8051-aa77545c1842"), new DateTime(2025, 5, 21, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 0, 0, null, "Portable battery charger with high capacity", false, new DateTime(2025, 6, 25, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 1, "Power Bank", 50, "PWB33333", 1, 59.99m },
                    { new Guid("d2bd2470-d3b6-4baf-aba5-d07d57f9bd7b"), new Guid("0e798d71-0ea8-4166-8051-aa77545c1842"), new DateTime(2025, 5, 1, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 0, 0, null, "High-quality wireless headphones with noise cancellation", false, null, null, "Wireless Bluetooth Headphones", 25, "WBH12345", 0, 149.99m },
                    { new Guid("d3f5c0ea-b611-4eb1-b9a9-536db1e32dc1"), new Guid("825b818a-d436-4bac-8e1b-9472409335e1"), new DateTime(2025, 5, 18, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 0, 0, null, "Powerful blender for smoothies and food preparation", false, new DateTime(2025, 6, 23, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 1, "Blender", 40, "BLD33333", 1, 79.99m },
                    { new Guid("d52b0270-57f0-413e-8c86-f415d3ad14cb"), new Guid("825b818a-d436-4bac-8e1b-9472409335e1"), new DateTime(2025, 5, 12, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 0, 0, null, "High-quality non-stick frying pan", false, null, null, "Non-Stick Pan", 80, "NSP22222", 0, 34.99m },
                    { new Guid("d5f1228b-d43f-48f4-9681-b14ede1a2404"), new Guid("efdab8b9-fd6b-4311-9a45-f014682f47ed"), new DateTime(2025, 5, 20, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 0, 0, null, "Comprehensive overview of world history", false, new DateTime(2025, 6, 27, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 1, "History Book", 35, "HSB88888", 1, 29.99m },
                    { new Guid("d7986281-b767-4779-b6d8-51e6922cd50d"), new Guid("0e798d71-0ea8-4166-8051-aa77545c1842"), new DateTime(2025, 5, 16, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 0, 0, null, "High-speed USB charging and data cable", false, null, null, "USB Cable", 200, "USB22222", 0, 12.99m },
                    { new Guid("d88475ff-0add-4acd-970b-5bbc4bbd033a"), new Guid("fec1de25-5bc4-4351-a9ac-6a46addd55f7"), new DateTime(2025, 4, 19, 4, 17, 26, 433, DateTimeKind.Utc).AddTicks(60), 0, 0, null, "Non-slip yoga mat for exercise and meditation", false, null, null, "Yoga Mat", 80, "YGM99999", 0, 29.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("0dd88309-6994-4d4b-9dbf-6e568c8a9063"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("0eddcf59-4ec4-4b6f-85d6-caaaf92c5165"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("11318585-0d25-4e19-9051-652fa8911b7d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("13996ce9-735c-4a96-8a5c-e8eb762361bc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("17bdeb16-7ddb-42dc-816e-a97dc402e8e3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("24230192-6077-4b35-8b66-e068204dc610"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("26f3c4dc-0525-4743-97ef-c24020fb2b63"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("2e621347-dc5e-47d1-88e7-1f997f78fa50"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("41170985-4bac-4b38-be81-e1e2c9c1850a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("4b999958-03db-4071-9a4f-1d2ddc4aedd1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("4d1d522d-eb82-48e5-bf00-015824d3ecb4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("52d69aa8-aa3d-4a6b-a4fa-3253fea373da"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("592e4cb0-ba05-4cff-b652-a425671a2926"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("70b1314b-4418-4dd0-a53f-8f4a7bba71b3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("888c1258-b756-4ca7-9c66-af4d2c0ca0f2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("8a70a786-a932-4dc5-adea-b0ee3f0d73b3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("968c4310-1dc8-4e14-aa42-62d6ca53cbc3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("9d1013ab-f060-4e1e-a521-b545b9b67440"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("bbd05eeb-3d2b-4ab4-8b88-7aaae30b8617"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("d2bd2470-d3b6-4baf-aba5-d07d57f9bd7b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("d3f5c0ea-b611-4eb1-b9a9-536db1e32dc1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("d52b0270-57f0-413e-8c86-f415d3ad14cb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("d5f1228b-d43f-48f4-9681-b14ede1a2404"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("d7986281-b767-4779-b6d8-51e6922cd50d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("d88475ff-0add-4acd-970b-5bbc4bbd033a"));
        }
    }
}

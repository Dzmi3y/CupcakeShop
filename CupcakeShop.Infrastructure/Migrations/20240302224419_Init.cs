using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CupcakeShop.Database.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdditionDecorations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionDecorations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdditionSubspecies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionSubspecies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdditionWeights",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    UnitOfMeasurement = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionWeights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SequenceNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AdditionWeightId = table.Column<Guid>(type: "uuid", nullable: false),
                    AdditionDecorationId = table.Column<Guid>(type: "uuid", nullable: false),
                    AdditionSubspeciesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AdditionDecorations_AdditionDecorationId",
                        column: x => x.AdditionDecorationId,
                        principalTable: "AdditionDecorations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_AdditionSubspecies_AdditionSubspeciesId",
                        column: x => x.AdditionSubspeciesId,
                        principalTable: "AdditionSubspecies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_AdditionWeights_AdditionWeightId",
                        column: x => x.AdditionWeightId,
                        principalTable: "AdditionWeights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsBestseller = table.Column<bool>(type: "boolean", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    UnitOfMeasurement = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    ImgUrl = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    StorageConditions = table.Column<string>(type: "text", nullable: false),
                    Delivery = table.Column<string>(type: "text", nullable: false),
                    ImgUrlsJson = table.Column<string>(type: "text", nullable: false),
                    ShortDetailsJson = table.Column<string>(type: "text", nullable: false),
                    ProductTypeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<string>(type: "text", nullable: false),
                    DeliveryMethod = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    House = table.Column<string>(type: "text", nullable: false),
                    Entrance = table.Column<string>(type: "text", nullable: false),
                    Building = table.Column<string>(type: "text", nullable: false),
                    Apartment = table.Column<string>(type: "text", nullable: false),
                    Floor = table.Column<string>(type: "text", nullable: false),
                    PaymentMethod = table.Column<string>(type: "text", nullable: false),
                    Commentary = table.Column<string>(type: "text", nullable: false),
                    CartId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartProduct",
                columns: table => new
                {
                    CartsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProduct", x => new { x.CartsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CartProduct_Carts_CartsId",
                        column: x => x.CartsId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AdditionDecorations",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("6ee29878-b244-4c95-8636-b6bd67efe7fe"), "Decor 3", 3.0 },
                    { new Guid("73b2ddf7-e893-4459-81be-4840dc3e595b"), "Without decoration", 0.0 },
                    { new Guid("77372acc-0194-4921-9594-b01787fdbd51"), "Decor 1", 1.0 },
                    { new Guid("fbf6138a-b184-4929-bd18-dd1542a88261"), "Decor 2", 2.0 }
                });

            migrationBuilder.InsertData(
                table: "AdditionSubspecies",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("0b808798-06fe-41d0-9162-6a01c612242a"), "Type 2", 2.0 },
                    { new Guid("1b153fb3-cc43-4c68-9a13-b763fa4dec6d"), "Default type", 0.0 },
                    { new Guid("6709f6c1-8773-4533-83a8-bd37de4cdd84"), "Type 3", 3.0 },
                    { new Guid("789aeb12-8932-4cd3-a052-32b23708ef66"), "Type 1", 1.0 }
                });

            migrationBuilder.InsertData(
                table: "AdditionWeights",
                columns: new[] { "Id", "Price", "UnitOfMeasurement", "Weight" },
                values: new object[,]
                {
                    { new Guid("94a6db5b-7d50-492c-8cfe-7c185d56af47"), 2.0, "g", 300.0 },
                    { new Guid("95322093-4a58-4cfe-9024-fc388daaa85a"), 1.0, "g", 100.0 },
                    { new Guid("9fd997e9-e434-4c21-b5b4-1eb440b35ae7"), 5.0, "kg", 1.5 },
                    { new Guid("b9fbb819-d8de-443c-b6a6-ba76e0216eee"), 0.0, "g", 0.0 },
                    { new Guid("c01d3f80-5c5d-4af0-8c70-93754c52eab5"), 4.0, "kg", 1.0 },
                    { new Guid("c13baddf-6c73-47c2-907b-397c0c9b0267"), 6.0, "kg", 2.0 },
                    { new Guid("deb339ec-5642-4db6-9aa3-2420288db67d"), 3.0, "g", 500.0 }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Name", "SequenceNumber" },
                values: new object[,]
                {
                    { new Guid("377644e5-7b93-4ff9-b0c2-e9bff580ced4"), "choux", 3 },
                    { new Guid("45408256-b28f-41e2-895a-7b5623360e85"), "cake", 1 },
                    { new Guid("67c19964-f980-4b79-9f84-ed5981f9203b"), "cookie", 2 },
                    { new Guid("b0d05d03-e2b6-4b89-8155-68e99e2371ee"), "pizza", 4 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Delivery", "Description", "ImgUrl", "ImgUrlsJson", "IsBestseller", "Name", "Price", "ProductTypeId", "ShortDetailsJson", "StorageConditions", "UnitOfMeasurement", "Weight" },
                values: new object[,]
                {
                    { new Guid("15ed97c4-460b-48c8-8728-489cc7e1513b"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/pizza.jpg", "[\"/images/pizza.jpg\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", true, "Four Cheese", 5.0, new Guid("b0d05d03-e2b6-4b89-8155-68e99e2371ee"), "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "g", 500.0 },
                    { new Guid("3ead1c7f-172f-4479-9f73-be992b963ffd"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/cookie.png", "[\"/images/cookie.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", true, "Chocolate Chip", 1.0, new Guid("67c19964-f980-4b79-9f84-ed5981f9203b"), "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "g", 100.0 },
                    { new Guid("68077407-5463-4cbb-aed2-b581a73fe27b"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/pizza.jpg", "[\"/images/pizza.jpg\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", false, "Veggie", 3.0, new Guid("b0d05d03-e2b6-4b89-8155-68e99e2371ee"), "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "g", 300.0 },
                    { new Guid("89d2f900-3f2c-414b-b89e-37d5a497be8c"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/choux.png", "[\"/images/choux.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", true, "Lemon Choux", 1.0, new Guid("377644e5-7b93-4ff9-b0c2-e9bff580ced4"), "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "g", 100.0 },
                    { new Guid("b8550731-b514-49a1-a1ec-dd893ddaf605"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/choux.png", "[\"/images/choux.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", false, "Strawberry Choux", 4.0, new Guid("377644e5-7b93-4ff9-b0c2-e9bff580ced4"), "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "g", 400.0 },
                    { new Guid("bf199811-19f3-425f-977c-52a9cdf472f2"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/cookie.png", "[\"/images/cookie.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", false, "Peanut Butter", 5.0, new Guid("67c19964-f980-4b79-9f84-ed5981f9203b"), "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "g", 500.0 },
                    { new Guid("f3c3e245-4b49-43d8-aafb-6369980af9fc"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/cake.png", "[\"/images/cake.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", true, "Chocolate cake", 2.0, new Guid("45408256-b28f-41e2-895a-7b5623360e85"), "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "kg", 1.0 },
                    { new Guid("f5a2422d-7cf5-458d-9b60-f9fbfd06624e"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/cake.png", "[\"/images/cake.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", false, "Apple pie", 3.0, new Guid("45408256-b28f-41e2-895a-7b5623360e85"), "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "kg", 2.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_ProductsId",
                table: "CartProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_AdditionDecorationId",
                table: "Carts",
                column: "AdditionDecorationId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_AdditionSubspeciesId",
                table: "Carts",
                column: "AdditionSubspeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_AdditionWeightId",
                table: "Carts",
                column: "AdditionWeightId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartId",
                table: "Orders",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartProduct");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "AdditionDecorations");

            migrationBuilder.DropTable(
                name: "AdditionSubspecies");

            migrationBuilder.DropTable(
                name: "AdditionWeights");
        }
    }
}

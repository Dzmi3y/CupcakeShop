using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
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
                    ProductTypeId = table.Column<int>(type: "integer", nullable: false)
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
                    { new Guid("6e14d01d-2302-497c-a5cd-8f564f8ac2dd"), "Decor 2", 2.0 },
                    { new Guid("a7756877-402d-49ad-92c5-11f007ae87a6"), "Decor 1", 1.0 },
                    { new Guid("b7225a3b-4fdc-4631-b269-8ff6a9305857"), "Without decoration", 0.0 },
                    { new Guid("caf80b89-b775-4fcc-a9c8-0b025a038318"), "Decor 3", 3.0 }
                });

            migrationBuilder.InsertData(
                table: "AdditionSubspecies",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("02444e89-a0d5-4562-8b50-e73a0ba8f519"), "Type 3", 3.0 },
                    { new Guid("77858b5f-7530-44fc-8247-e084572989f7"), "Type 2", 2.0 },
                    { new Guid("c2904f79-f217-431e-b5eb-fe3638963b71"), "Type 1", 1.0 },
                    { new Guid("cc679db7-2d5b-4cf0-a5f1-c2e049a71a07"), "Default type", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "AdditionWeights",
                columns: new[] { "Id", "Price", "UnitOfMeasurement", "Weight" },
                values: new object[,]
                {
                    { new Guid("004fe7dc-ecac-4a3f-9074-15f6c1755604"), 3.0, "g", 500.0 },
                    { new Guid("1a51258c-90fe-4ebe-bb6f-7007fafaec0f"), 4.0, "kg", 1.0 },
                    { new Guid("1e8d8f9b-2ad9-4d29-aeec-86d5db6316a9"), 0.0, "g", 0.0 },
                    { new Guid("219fc935-dd1c-4c67-a551-d19ba60bde71"), 1.0, "g", 100.0 },
                    { new Guid("baaf0b6c-8b9e-4045-8caf-2b5f633d2b41"), 5.0, "kg", 1.5 },
                    { new Guid("c23f492b-dc46-4a3b-9491-386524ae0209"), 6.0, "kg", 2.0 },
                    { new Guid("cbeed6cc-b212-4138-a8d2-c75300f782b3"), 2.0, "g", 300.0 }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "cake" },
                    { 2, "cookie" },
                    { 3, "choux" },
                    { 4, "pizza" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Delivery", "Description", "ImgUrl", "ImgUrlsJson", "IsBestseller", "Name", "Price", "ProductTypeId", "ShortDetailsJson", "StorageConditions", "UnitOfMeasurement", "Weight" },
                values: new object[,]
                {
                    { new Guid("0a8fb0ee-a3fa-4c3b-93a5-6bf05978df3d"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/pizza.jpg", "[\"/images/pizza.jpg\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", false, "Veggie", 3.0, 4, "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "g", 300.0 },
                    { new Guid("1c2740a8-461a-42dc-8bbb-854fe3d7c5d5"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/pizza.jpg", "[\"/images/pizza.jpg\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", true, "Four Cheese", 5.0, 4, "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "g", 500.0 },
                    { new Guid("2a97e352-03cc-41c9-8445-f3331f214c5d"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/choux.png", "[\"/images/choux.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", true, "Lemon Choux", 1.0, 3, "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "g", 100.0 },
                    { new Guid("42ccdbf6-b837-4d33-8a2f-794c25b85ed6"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/choux.png", "[\"/images/choux.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", false, "Strawberry Choux", 4.0, 3, "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "g", 400.0 },
                    { new Guid("4875f480-4cee-415b-b2c6-3827a97555d3"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/cake.png", "[\"/images/cake.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", false, "Apple pie", 3.0, 1, "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "kg", 2.0 },
                    { new Guid("571ee700-828e-45bc-b9eb-f67211e5c7ff"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/cookie.png", "[\"/images/cookie.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", true, "Chocolate Chip", 1.0, 2, "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "g", 100.0 },
                    { new Guid("5d7b863e-e182-4585-bd5e-f02811bc6cca"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/cookie.png", "[\"/images/cookie.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", false, "Peanut Butter", 5.0, 2, "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "g", 500.0 },
                    { new Guid("e3a3e259-f800-44e9-9fd2-8783d89aed41"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/cake.png", "[\"/images/cake.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", true, "Chocolate cake", 2.0, 1, "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "kg", 1.0 }
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

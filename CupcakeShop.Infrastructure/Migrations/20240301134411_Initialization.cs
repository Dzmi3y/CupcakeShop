using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CupcakeShop.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initialization : Migration
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
                    TypeName = table.Column<string>(type: "text", nullable: false),
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
                    { new Guid("0802a710-43fb-45b1-a283-dd227e683807"), "Without decoration", 0.0 },
                    { new Guid("3bcbdf36-dd1d-4486-9b9c-d77782b69f6e"), "Decor 2", 2.0 },
                    { new Guid("67f9e47a-9d2c-44a8-926c-93754540dbcc"), "Decor 3", 3.0 },
                    { new Guid("c7c21019-0c49-4756-8c32-f76b18654312"), "Decor 1", 1.0 }
                });

            migrationBuilder.InsertData(
                table: "AdditionSubspecies",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("0f3749f0-8c4a-4607-b688-06e6ed22c4e6"), "Default type", 0.0 },
                    { new Guid("9e279c29-b170-4655-8e20-1d115010a774"), "Type 3", 3.0 },
                    { new Guid("a333ac68-d72f-4d1a-b5a9-19aadf582068"), "Type 2", 2.0 },
                    { new Guid("f8d84b4e-25a9-4199-829b-bd1373d4520f"), "Type 1", 1.0 }
                });

            migrationBuilder.InsertData(
                table: "AdditionWeights",
                columns: new[] { "Id", "Price", "UnitOfMeasurement", "Weight" },
                values: new object[,]
                {
                    { new Guid("1a585ded-a194-436b-90d8-8702650af087"), 1.0, "g", 100.0 },
                    { new Guid("1cb1e0bd-e6bc-4971-adbf-452c09b28862"), 0.0, "g", 0.0 },
                    { new Guid("2aa7b1cd-e74e-401f-ab5e-873ec1fe6ee8"), 6.0, "kg", 2.0 },
                    { new Guid("5325904a-6b10-406c-999a-01acc1f86165"), 2.0, "g", 300.0 },
                    { new Guid("6abde488-64b9-4297-8941-4bb2f412d276"), 5.0, "kg", 1.5 },
                    { new Guid("e59ee52d-5dec-4cb0-ad9f-f8398e074c4d"), 4.0, "kg", 1.0 },
                    { new Guid("e73bcd9f-4598-476d-8777-b48d4be306a4"), 3.0, "g", 500.0 }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Name", "SequenceNumber" },
                values: new object[,]
                {
                    { new Guid("12563480-964b-4d4d-9bea-66316df7a177"), "cake", 1 },
                    { new Guid("5a5c231c-5b2a-41c8-a46f-24166d3554e8"), "cookie", 2 },
                    { new Guid("b5a9f37d-df70-4856-8dd8-5679c2b27a61"), "choux", 3 },
                    { new Guid("e5dc2ac0-5b2f-49ed-9845-4fd1220545cc"), "pizza", 4 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Delivery", "Description", "ImgUrl", "ImgUrlsJson", "IsBestseller", "Name", "Price", "ProductTypeId", "ShortDetailsJson", "StorageConditions", "TypeName", "UnitOfMeasurement", "Weight" },
                values: new object[,]
                {
                    { new Guid("024cd4bc-6afb-40a8-9d73-672d9027829e"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/choux.png", "[\"/images/choux.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", true, "Lemon Choux", 1.0, new Guid("b5a9f37d-df70-4856-8dd8-5679c2b27a61"), "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "", "g", 100.0 },
                    { new Guid("7a68473c-6cb7-4419-af3b-b271f6264af6"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/pizza.jpg", "[\"/images/pizza.jpg\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", false, "Veggie", 3.0, new Guid("e5dc2ac0-5b2f-49ed-9845-4fd1220545cc"), "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "", "g", 300.0 },
                    { new Guid("8ece835e-cbf3-4f26-923a-9d33da0a1dea"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/pizza.png", "[\"/images/pizza.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", true, "Four Cheese", 5.0, new Guid("e5dc2ac0-5b2f-49ed-9845-4fd1220545cc"), "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "", "g", 500.0 },
                    { new Guid("d5bddb65-2b7e-461d-bd33-d1681a916eeb"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/cookie.png", "[\"/images/cookie.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", false, "Peanut Butter", 5.0, new Guid("5a5c231c-5b2a-41c8-a46f-24166d3554e8"), "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "", "g", 500.0 },
                    { new Guid("df39afa4-aa3f-4921-bf70-3e80b7b60a8f"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/cake.png", "[\"/images/cake.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", false, "Apple pie", 3.0, new Guid("12563480-964b-4d4d-9bea-66316df7a177"), "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "", "kg", 2.0 },
                    { new Guid("e9ec2cb3-057c-433e-8c9e-cf23d0474a8f"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/choux.png", "[\"/images/choux.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", false, "Strawberry Choux", 4.0, new Guid("b5a9f37d-df70-4856-8dd8-5679c2b27a61"), "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "", "g", 400.0 },
                    { new Guid("f7e0a6d3-fdcc-46ef-8725-ae6e9040f81f"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/cookie.png", "[\"/images/cookie.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", true, "Chocolate Chip", 1.0, new Guid("5a5c231c-5b2a-41c8-a46f-24166d3554e8"), "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "", "g", 100.0 },
                    { new Guid("f7eba1ac-5846-4f22-8635-0b94fc1594a5"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/cake.png", "[\"/images/cake.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", true, "Chocolate cake", 2.0, new Guid("12563480-964b-4d4d-9bea-66316df7a177"), "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "", "kg", 1.0 }
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

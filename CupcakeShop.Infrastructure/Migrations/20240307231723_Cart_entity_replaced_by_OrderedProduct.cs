using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CupcakeShop.Database.Migrations
{
    /// <inheritdoc />
    public partial class Cart_entity_replaced_by_OrderedProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Carts_CartId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "CartProduct");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CartId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "AdditionDecorations",
                keyColumn: "Id",
                keyValue: new Guid("b10c6ef0-c117-4912-811d-fef1219f4066"));

            migrationBuilder.DeleteData(
                table: "AdditionDecorations",
                keyColumn: "Id",
                keyValue: new Guid("b4d1821b-f99c-46ae-8dbd-d75c787b4f55"));

            migrationBuilder.DeleteData(
                table: "AdditionDecorations",
                keyColumn: "Id",
                keyValue: new Guid("b5de6069-6f67-4a57-a363-1038f2025dfc"));

            migrationBuilder.DeleteData(
                table: "AdditionDecorations",
                keyColumn: "Id",
                keyValue: new Guid("c59893b6-c9a6-4057-98ee-61762c0e1e65"));

            migrationBuilder.DeleteData(
                table: "AdditionSubspecies",
                keyColumn: "Id",
                keyValue: new Guid("39ba287b-7332-4a06-a675-3f0af57550e1"));

            migrationBuilder.DeleteData(
                table: "AdditionSubspecies",
                keyColumn: "Id",
                keyValue: new Guid("50c6a4af-fc6a-4767-9ff7-b25ab27eaca1"));

            migrationBuilder.DeleteData(
                table: "AdditionSubspecies",
                keyColumn: "Id",
                keyValue: new Guid("90fba71b-35a9-444f-838f-b88c8adba7dd"));

            migrationBuilder.DeleteData(
                table: "AdditionSubspecies",
                keyColumn: "Id",
                keyValue: new Guid("c51c4fde-8c2b-4dbc-8bfe-1815c77cc34d"));

            migrationBuilder.DeleteData(
                table: "AdditionWeights",
                keyColumn: "Id",
                keyValue: new Guid("39b63a20-5825-44f4-b540-aedc56ca61cf"));

            migrationBuilder.DeleteData(
                table: "AdditionWeights",
                keyColumn: "Id",
                keyValue: new Guid("43ea0f03-8df2-49df-a305-804cf4c7dfa1"));

            migrationBuilder.DeleteData(
                table: "AdditionWeights",
                keyColumn: "Id",
                keyValue: new Guid("54d540f5-5c9b-4c6e-8e8a-ac9c282dc5ab"));

            migrationBuilder.DeleteData(
                table: "AdditionWeights",
                keyColumn: "Id",
                keyValue: new Guid("688741f5-108d-43e2-b51c-494db4557e3f"));

            migrationBuilder.DeleteData(
                table: "AdditionWeights",
                keyColumn: "Id",
                keyValue: new Guid("97a440d7-618e-4a48-944d-bf3ccd84c286"));

            migrationBuilder.DeleteData(
                table: "AdditionWeights",
                keyColumn: "Id",
                keyValue: new Guid("ca8b76b9-012a-4c58-beee-689bca8f99e7"));

            migrationBuilder.DeleteData(
                table: "AdditionWeights",
                keyColumn: "Id",
                keyValue: new Guid("d378c344-404f-4342-81a5-38ba29fdab40"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("257ebfde-0ba8-46d8-8ea2-d269b70c44d4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2b93d692-e7f0-4754-86c3-ca8a680b0d70"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("316b6a0e-83dc-4465-81ab-4aef34dbb4eb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5bfe4662-ffc8-4ee1-a753-06d5a09b765a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7410e84e-87c4-4648-8892-0105e19cb9ef"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c42faafa-6fc3-4d33-8945-967b95e2c661"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ea682f36-3f8b-4c14-a362-eb4671976e65"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("eee708d4-7654-4378-ba6c-a7c457c6f1c9"));

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "OrderedProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: true),
                    AdditionWeightId = table.Column<Guid>(type: "uuid", nullable: true),
                    AdditionDecorationId = table.Column<Guid>(type: "uuid", nullable: true),
                    AdditionSubspeciesId = table.Column<Guid>(type: "uuid", nullable: true),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderedProducts_AdditionDecorations_AdditionDecorationId",
                        column: x => x.AdditionDecorationId,
                        principalTable: "AdditionDecorations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderedProducts_AdditionSubspecies_AdditionSubspeciesId",
                        column: x => x.AdditionSubspeciesId,
                        principalTable: "AdditionSubspecies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderedProducts_AdditionWeights_AdditionWeightId",
                        column: x => x.AdditionWeightId,
                        principalTable: "AdditionWeights",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderedProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderedProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AdditionDecorations",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("5f11aebf-5fc5-4662-861f-9f9378fc2d9e"), "Decor 3", 3.0 },
                    { new Guid("645be3e2-40ff-4b16-9a20-df53061414b5"), "Without decoration", 0.0 },
                    { new Guid("a916556e-c8a1-4d41-843b-7e7ceac0f7cb"), "Decor 1", 1.0 },
                    { new Guid("e1f1d756-9070-452b-9f5d-f961e2811b30"), "Decor 2", 2.0 }
                });

            migrationBuilder.InsertData(
                table: "AdditionSubspecies",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("3cc70b7a-9439-4443-a5d6-fd8615dbb7ec"), "Type 3", 3.0 },
                    { new Guid("619efffd-f5e7-4b4d-a4d8-f7d98a972863"), "Default type", 0.0 },
                    { new Guid("7a9a2845-8b70-4b61-ab5a-8af8030df919"), "Type 1", 1.0 },
                    { new Guid("b1ee2f02-91e8-4038-adac-5becaae327fe"), "Type 2", 2.0 }
                });

            migrationBuilder.InsertData(
                table: "AdditionWeights",
                columns: new[] { "Id", "Price", "UnitOfMeasurement", "Weight" },
                values: new object[,]
                {
                    { new Guid("39e68b14-8289-4001-ac6b-676b9f27bcf1"), 2.0, "g", 300.0 },
                    { new Guid("4c99c2d2-01bb-4a59-af73-6d074e37a4b2"), 1.0, "g", 100.0 },
                    { new Guid("66df66c7-c668-4c23-a32f-d20cbbd4e8b3"), 4.0, "kg", 1.0 },
                    { new Guid("c6154837-99aa-461d-8505-801f84d7c24b"), 0.0, "g", 0.0 },
                    { new Guid("d118d291-805f-42e4-87d7-f8eb11b09776"), 5.0, "kg", 1.5 },
                    { new Guid("ea16f344-21cd-4faf-b24a-49542c622776"), 6.0, "kg", 2.0 },
                    { new Guid("fdde0517-a673-4dbd-92c1-39b6d5e25c43"), 3.0, "g", 500.0 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Delivery", "Description", "ImgUrl", "ImgUrlsJson", "IsBestseller", "Name", "Price", "ProductTypeId", "ShortDetailsJson", "StorageConditions", "UnitOfMeasurement", "Weight" },
                values: new object[,]
                {
                    { new Guid("146ee41c-478c-4581-8ee9-80cd2d25cea0"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/choux.png", "[\"/images/choux.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", true, "Lemon Choux", 1.0, 3, "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "g", 100.0 },
                    { new Guid("27600b58-07ab-437d-9398-d6bca0b2a1fd"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/cookie.png", "[\"/images/cookie.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", false, "Peanut Butter", 5.0, 2, "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "g", 500.0 },
                    { new Guid("642a2282-13df-48f1-8a93-8463ab548dfe"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/cake.png", "[\"/images/cake.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", true, "Chocolate cake", 2.0, 1, "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "kg", 1.0 },
                    { new Guid("83bf731a-1237-4468-9417-32426b1ccca1"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/pizza.jpg", "[\"/images/pizza.jpg\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", false, "Veggie", 3.0, 4, "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "g", 300.0 },
                    { new Guid("a565b14c-029b-4581-8d93-acc0e3211487"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/pizza.jpg", "[\"/images/pizza.jpg\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", true, "Four Cheese", 5.0, 4, "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "g", 500.0 },
                    { new Guid("b1232a7a-8dc4-4b59-95f7-b32a27cf71e5"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/cake.png", "[\"/images/cake.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", false, "Apple pie", 3.0, 1, "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "kg", 2.0 },
                    { new Guid("b38368e4-f54c-4316-9e6a-6e63ddddaaae"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/choux.png", "[\"/images/choux.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", false, "Strawberry Choux", 4.0, 3, "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "g", 400.0 },
                    { new Guid("e0ac2114-4bf6-42b0-95fa-0ea014fb0b30"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/cookie.png", "[\"/images/cookie.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", true, "Chocolate Chip", 1.0, 2, "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "g", 100.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderedProducts_AdditionDecorationId",
                table: "OrderedProducts",
                column: "AdditionDecorationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedProducts_AdditionSubspeciesId",
                table: "OrderedProducts",
                column: "AdditionSubspeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedProducts_AdditionWeightId",
                table: "OrderedProducts",
                column: "AdditionWeightId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedProducts_OrderId",
                table: "OrderedProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedProducts_ProductId",
                table: "OrderedProducts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderedProducts");

            migrationBuilder.DeleteData(
                table: "AdditionDecorations",
                keyColumn: "Id",
                keyValue: new Guid("5f11aebf-5fc5-4662-861f-9f9378fc2d9e"));

            migrationBuilder.DeleteData(
                table: "AdditionDecorations",
                keyColumn: "Id",
                keyValue: new Guid("645be3e2-40ff-4b16-9a20-df53061414b5"));

            migrationBuilder.DeleteData(
                table: "AdditionDecorations",
                keyColumn: "Id",
                keyValue: new Guid("a916556e-c8a1-4d41-843b-7e7ceac0f7cb"));

            migrationBuilder.DeleteData(
                table: "AdditionDecorations",
                keyColumn: "Id",
                keyValue: new Guid("e1f1d756-9070-452b-9f5d-f961e2811b30"));

            migrationBuilder.DeleteData(
                table: "AdditionSubspecies",
                keyColumn: "Id",
                keyValue: new Guid("3cc70b7a-9439-4443-a5d6-fd8615dbb7ec"));

            migrationBuilder.DeleteData(
                table: "AdditionSubspecies",
                keyColumn: "Id",
                keyValue: new Guid("619efffd-f5e7-4b4d-a4d8-f7d98a972863"));

            migrationBuilder.DeleteData(
                table: "AdditionSubspecies",
                keyColumn: "Id",
                keyValue: new Guid("7a9a2845-8b70-4b61-ab5a-8af8030df919"));

            migrationBuilder.DeleteData(
                table: "AdditionSubspecies",
                keyColumn: "Id",
                keyValue: new Guid("b1ee2f02-91e8-4038-adac-5becaae327fe"));

            migrationBuilder.DeleteData(
                table: "AdditionWeights",
                keyColumn: "Id",
                keyValue: new Guid("39e68b14-8289-4001-ac6b-676b9f27bcf1"));

            migrationBuilder.DeleteData(
                table: "AdditionWeights",
                keyColumn: "Id",
                keyValue: new Guid("4c99c2d2-01bb-4a59-af73-6d074e37a4b2"));

            migrationBuilder.DeleteData(
                table: "AdditionWeights",
                keyColumn: "Id",
                keyValue: new Guid("66df66c7-c668-4c23-a32f-d20cbbd4e8b3"));

            migrationBuilder.DeleteData(
                table: "AdditionWeights",
                keyColumn: "Id",
                keyValue: new Guid("c6154837-99aa-461d-8505-801f84d7c24b"));

            migrationBuilder.DeleteData(
                table: "AdditionWeights",
                keyColumn: "Id",
                keyValue: new Guid("d118d291-805f-42e4-87d7-f8eb11b09776"));

            migrationBuilder.DeleteData(
                table: "AdditionWeights",
                keyColumn: "Id",
                keyValue: new Guid("ea16f344-21cd-4faf-b24a-49542c622776"));

            migrationBuilder.DeleteData(
                table: "AdditionWeights",
                keyColumn: "Id",
                keyValue: new Guid("fdde0517-a673-4dbd-92c1-39b6d5e25c43"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("146ee41c-478c-4581-8ee9-80cd2d25cea0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("27600b58-07ab-437d-9398-d6bca0b2a1fd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("642a2282-13df-48f1-8a93-8463ab548dfe"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("83bf731a-1237-4468-9417-32426b1ccca1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a565b14c-029b-4581-8d93-acc0e3211487"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b1232a7a-8dc4-4b59-95f7-b32a27cf71e5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b38368e4-f54c-4316-9e6a-6e63ddddaaae"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e0ac2114-4bf6-42b0-95fa-0ea014fb0b30"));

            migrationBuilder.AddColumn<Guid>(
                name: "CartId",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AdditionDecorationId = table.Column<Guid>(type: "uuid", nullable: true),
                    AdditionSubspeciesId = table.Column<Guid>(type: "uuid", nullable: true),
                    AdditionWeightId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AdditionDecorations_AdditionDecorationId",
                        column: x => x.AdditionDecorationId,
                        principalTable: "AdditionDecorations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Carts_AdditionSubspecies_AdditionSubspeciesId",
                        column: x => x.AdditionSubspeciesId,
                        principalTable: "AdditionSubspecies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Carts_AdditionWeights_AdditionWeightId",
                        column: x => x.AdditionWeightId,
                        principalTable: "AdditionWeights",
                        principalColumn: "Id");
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
                    { new Guid("b10c6ef0-c117-4912-811d-fef1219f4066"), "Decor 2", 2.0 },
                    { new Guid("b4d1821b-f99c-46ae-8dbd-d75c787b4f55"), "Decor 3", 3.0 },
                    { new Guid("b5de6069-6f67-4a57-a363-1038f2025dfc"), "Without decoration", 0.0 },
                    { new Guid("c59893b6-c9a6-4057-98ee-61762c0e1e65"), "Decor 1", 1.0 }
                });

            migrationBuilder.InsertData(
                table: "AdditionSubspecies",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("39ba287b-7332-4a06-a675-3f0af57550e1"), "Default type", 0.0 },
                    { new Guid("50c6a4af-fc6a-4767-9ff7-b25ab27eaca1"), "Type 3", 3.0 },
                    { new Guid("90fba71b-35a9-444f-838f-b88c8adba7dd"), "Type 2", 2.0 },
                    { new Guid("c51c4fde-8c2b-4dbc-8bfe-1815c77cc34d"), "Type 1", 1.0 }
                });

            migrationBuilder.InsertData(
                table: "AdditionWeights",
                columns: new[] { "Id", "Price", "UnitOfMeasurement", "Weight" },
                values: new object[,]
                {
                    { new Guid("39b63a20-5825-44f4-b540-aedc56ca61cf"), 6.0, "kg", 2.0 },
                    { new Guid("43ea0f03-8df2-49df-a305-804cf4c7dfa1"), 0.0, "g", 0.0 },
                    { new Guid("54d540f5-5c9b-4c6e-8e8a-ac9c282dc5ab"), 2.0, "g", 300.0 },
                    { new Guid("688741f5-108d-43e2-b51c-494db4557e3f"), 3.0, "g", 500.0 },
                    { new Guid("97a440d7-618e-4a48-944d-bf3ccd84c286"), 1.0, "g", 100.0 },
                    { new Guid("ca8b76b9-012a-4c58-beee-689bca8f99e7"), 5.0, "kg", 1.5 },
                    { new Guid("d378c344-404f-4342-81a5-38ba29fdab40"), 4.0, "kg", 1.0 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Delivery", "Description", "ImgUrl", "ImgUrlsJson", "IsBestseller", "Name", "Price", "ProductTypeId", "ShortDetailsJson", "StorageConditions", "UnitOfMeasurement", "Weight" },
                values: new object[,]
                {
                    { new Guid("257ebfde-0ba8-46d8-8ea2-d269b70c44d4"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/cookie.png", "[\"/images/cookie.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", true, "Chocolate Chip", 1.0, 2, "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "g", 100.0 },
                    { new Guid("2b93d692-e7f0-4754-86c3-ca8a680b0d70"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/cookie.png", "[\"/images/cookie.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", false, "Peanut Butter", 5.0, 2, "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "g", 500.0 },
                    { new Guid("316b6a0e-83dc-4465-81ab-4aef34dbb4eb"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/cake.png", "[\"/images/cake.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", false, "Apple pie", 3.0, 1, "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "kg", 2.0 },
                    { new Guid("5bfe4662-ffc8-4ee1-a753-06d5a09b765a"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/choux.png", "[\"/images/choux.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", false, "Strawberry Choux", 4.0, 3, "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "g", 400.0 },
                    { new Guid("7410e84e-87c4-4648-8892-0105e19cb9ef"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/cake.png", "[\"/images/cake.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", true, "Chocolate cake", 2.0, 1, "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "kg", 1.0 },
                    { new Guid("c42faafa-6fc3-4d33-8945-967b95e2c661"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/choux.png", "[\"/images/choux.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", true, "Lemon Choux", 1.0, 3, "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "g", 100.0 },
                    { new Guid("ea682f36-3f8b-4c14-a362-eb4671976e65"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/pizza.jpg", "[\"/images/pizza.jpg\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", true, "Four Cheese", 5.0, 4, "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "g", 500.0 },
                    { new Guid("eee708d4-7654-4378-ba6c-a7c457c6f1c9"), "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,", "quibusdam praesentium nemo commodi! Provident dicta pariatur", "/images/pizza.jpg", "[\"/images/pizza.jpg\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]", false, "Veggie", 3.0, 4, "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]", "unde sit modi possimus incidunt ab neque sunt fugit.", "g", 300.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartId",
                table: "Orders",
                column: "CartId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Carts_CartId",
                table: "Orders",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

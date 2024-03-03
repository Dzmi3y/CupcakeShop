using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CupcakeShop.Database.Migrations
{
    /// <inheritdoc />
    public partial class changed_optional_fields_in_cart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AdditionDecorations_AdditionDecorationId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AdditionSubspecies_AdditionSubspeciesId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AdditionWeights_AdditionWeightId",
                table: "Carts");

            migrationBuilder.DeleteData(
                table: "AdditionDecorations",
                keyColumn: "Id",
                keyValue: new Guid("6e14d01d-2302-497c-a5cd-8f564f8ac2dd"));

            migrationBuilder.DeleteData(
                table: "AdditionDecorations",
                keyColumn: "Id",
                keyValue: new Guid("a7756877-402d-49ad-92c5-11f007ae87a6"));

            migrationBuilder.DeleteData(
                table: "AdditionDecorations",
                keyColumn: "Id",
                keyValue: new Guid("b7225a3b-4fdc-4631-b269-8ff6a9305857"));

            migrationBuilder.DeleteData(
                table: "AdditionDecorations",
                keyColumn: "Id",
                keyValue: new Guid("caf80b89-b775-4fcc-a9c8-0b025a038318"));

            migrationBuilder.DeleteData(
                table: "AdditionSubspecies",
                keyColumn: "Id",
                keyValue: new Guid("02444e89-a0d5-4562-8b50-e73a0ba8f519"));

            migrationBuilder.DeleteData(
                table: "AdditionSubspecies",
                keyColumn: "Id",
                keyValue: new Guid("77858b5f-7530-44fc-8247-e084572989f7"));

            migrationBuilder.DeleteData(
                table: "AdditionSubspecies",
                keyColumn: "Id",
                keyValue: new Guid("c2904f79-f217-431e-b5eb-fe3638963b71"));

            migrationBuilder.DeleteData(
                table: "AdditionSubspecies",
                keyColumn: "Id",
                keyValue: new Guid("cc679db7-2d5b-4cf0-a5f1-c2e049a71a07"));

            migrationBuilder.DeleteData(
                table: "AdditionWeights",
                keyColumn: "Id",
                keyValue: new Guid("004fe7dc-ecac-4a3f-9074-15f6c1755604"));

            migrationBuilder.DeleteData(
                table: "AdditionWeights",
                keyColumn: "Id",
                keyValue: new Guid("1a51258c-90fe-4ebe-bb6f-7007fafaec0f"));

            migrationBuilder.DeleteData(
                table: "AdditionWeights",
                keyColumn: "Id",
                keyValue: new Guid("1e8d8f9b-2ad9-4d29-aeec-86d5db6316a9"));

            migrationBuilder.DeleteData(
                table: "AdditionWeights",
                keyColumn: "Id",
                keyValue: new Guid("219fc935-dd1c-4c67-a551-d19ba60bde71"));

            migrationBuilder.DeleteData(
                table: "AdditionWeights",
                keyColumn: "Id",
                keyValue: new Guid("baaf0b6c-8b9e-4045-8caf-2b5f633d2b41"));

            migrationBuilder.DeleteData(
                table: "AdditionWeights",
                keyColumn: "Id",
                keyValue: new Guid("c23f492b-dc46-4a3b-9491-386524ae0209"));

            migrationBuilder.DeleteData(
                table: "AdditionWeights",
                keyColumn: "Id",
                keyValue: new Guid("cbeed6cc-b212-4138-a8d2-c75300f782b3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0a8fb0ee-a3fa-4c3b-93a5-6bf05978df3d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1c2740a8-461a-42dc-8bbb-854fe3d7c5d5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2a97e352-03cc-41c9-8445-f3331f214c5d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("42ccdbf6-b837-4d33-8a2f-794c25b85ed6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4875f480-4cee-415b-b2c6-3827a97555d3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("571ee700-828e-45bc-b9eb-f67211e5c7ff"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5d7b863e-e182-4585-bd5e-f02811bc6cca"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e3a3e259-f800-44e9-9fd2-8783d89aed41"));

            migrationBuilder.AlterColumn<Guid>(
                name: "AdditionWeightId",
                table: "Carts",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "AdditionSubspeciesId",
                table: "Carts",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "AdditionDecorationId",
                table: "Carts",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AdditionDecorations_AdditionDecorationId",
                table: "Carts",
                column: "AdditionDecorationId",
                principalTable: "AdditionDecorations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AdditionSubspecies_AdditionSubspeciesId",
                table: "Carts",
                column: "AdditionSubspeciesId",
                principalTable: "AdditionSubspecies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AdditionWeights_AdditionWeightId",
                table: "Carts",
                column: "AdditionWeightId",
                principalTable: "AdditionWeights",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AdditionDecorations_AdditionDecorationId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AdditionSubspecies_AdditionSubspeciesId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AdditionWeights_AdditionWeightId",
                table: "Carts");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "AdditionWeightId",
                table: "Carts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AdditionSubspeciesId",
                table: "Carts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AdditionDecorationId",
                table: "Carts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AdditionDecorations_AdditionDecorationId",
                table: "Carts",
                column: "AdditionDecorationId",
                principalTable: "AdditionDecorations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AdditionSubspecies_AdditionSubspeciesId",
                table: "Carts",
                column: "AdditionSubspeciesId",
                principalTable: "AdditionSubspecies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AdditionWeights_AdditionWeightId",
                table: "Carts",
                column: "AdditionWeightId",
                principalTable: "AdditionWeights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

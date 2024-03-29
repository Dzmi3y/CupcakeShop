﻿// <auto-generated />
using System;
using CupcakeShop.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CupcakeShop.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240303180240_changed_optional_fields_in_cart")]
    partial class changed_optional_fields_in_cart
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CartProduct", b =>
                {
                    b.Property<Guid>("CartsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductsId")
                        .HasColumnType("uuid");

                    b.HasKey("CartsId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("CartProduct");
                });

            modelBuilder.Entity("CupcakeShop.Core.Entities.AdditionDecoration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("AdditionDecorations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b5de6069-6f67-4a57-a363-1038f2025dfc"),
                            Name = "Without decoration",
                            Price = 0.0
                        },
                        new
                        {
                            Id = new Guid("c59893b6-c9a6-4057-98ee-61762c0e1e65"),
                            Name = "Decor 1",
                            Price = 1.0
                        },
                        new
                        {
                            Id = new Guid("b10c6ef0-c117-4912-811d-fef1219f4066"),
                            Name = "Decor 2",
                            Price = 2.0
                        },
                        new
                        {
                            Id = new Guid("b4d1821b-f99c-46ae-8dbd-d75c787b4f55"),
                            Name = "Decor 3",
                            Price = 3.0
                        });
                });

            modelBuilder.Entity("CupcakeShop.Core.Entities.AdditionSubspecies", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("AdditionSubspecies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("39ba287b-7332-4a06-a675-3f0af57550e1"),
                            Name = "Default type",
                            Price = 0.0
                        },
                        new
                        {
                            Id = new Guid("c51c4fde-8c2b-4dbc-8bfe-1815c77cc34d"),
                            Name = "Type 1",
                            Price = 1.0
                        },
                        new
                        {
                            Id = new Guid("90fba71b-35a9-444f-838f-b88c8adba7dd"),
                            Name = "Type 2",
                            Price = 2.0
                        },
                        new
                        {
                            Id = new Guid("50c6a4af-fc6a-4767-9ff7-b25ab27eaca1"),
                            Name = "Type 3",
                            Price = 3.0
                        });
                });

            modelBuilder.Entity("CupcakeShop.Core.Entities.AdditionWeight", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<string>("UnitOfMeasurement")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("AdditionWeights");

                    b.HasData(
                        new
                        {
                            Id = new Guid("43ea0f03-8df2-49df-a305-804cf4c7dfa1"),
                            Price = 0.0,
                            UnitOfMeasurement = "g",
                            Weight = 0.0
                        },
                        new
                        {
                            Id = new Guid("97a440d7-618e-4a48-944d-bf3ccd84c286"),
                            Price = 1.0,
                            UnitOfMeasurement = "g",
                            Weight = 100.0
                        },
                        new
                        {
                            Id = new Guid("54d540f5-5c9b-4c6e-8e8a-ac9c282dc5ab"),
                            Price = 2.0,
                            UnitOfMeasurement = "g",
                            Weight = 300.0
                        },
                        new
                        {
                            Id = new Guid("688741f5-108d-43e2-b51c-494db4557e3f"),
                            Price = 3.0,
                            UnitOfMeasurement = "g",
                            Weight = 500.0
                        },
                        new
                        {
                            Id = new Guid("d378c344-404f-4342-81a5-38ba29fdab40"),
                            Price = 4.0,
                            UnitOfMeasurement = "kg",
                            Weight = 1.0
                        },
                        new
                        {
                            Id = new Guid("ca8b76b9-012a-4c58-beee-689bca8f99e7"),
                            Price = 5.0,
                            UnitOfMeasurement = "kg",
                            Weight = 1.5
                        },
                        new
                        {
                            Id = new Guid("39b63a20-5825-44f4-b540-aedc56ca61cf"),
                            Price = 6.0,
                            UnitOfMeasurement = "kg",
                            Weight = 2.0
                        });
                });

            modelBuilder.Entity("CupcakeShop.Core.Entities.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AdditionDecorationId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AdditionSubspeciesId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AdditionWeightId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AdditionDecorationId");

                    b.HasIndex("AdditionSubspeciesId");

                    b.HasIndex("AdditionWeightId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("CupcakeShop.Core.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Apartment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Building")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("CartId")
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Commentary")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DeliveryMethod")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Entrance")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Floor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("House")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CupcakeShop.Core.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Delivery")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImgUrlsJson")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsBestseller")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("ShortDetailsJson")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StorageConditions")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UnitOfMeasurement")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7410e84e-87c4-4648-8892-0105e19cb9ef"),
                            Delivery = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,",
                            Description = "quibusdam praesentium nemo commodi! Provident dicta pariatur",
                            ImgUrl = "/images/cake.png",
                            ImgUrlsJson = "[\"/images/cake.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]",
                            IsBestseller = true,
                            Name = "Chocolate cake",
                            Price = 2.0,
                            ProductTypeId = 1,
                            ShortDetailsJson = "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]",
                            StorageConditions = "unde sit modi possimus incidunt ab neque sunt fugit.",
                            UnitOfMeasurement = "kg",
                            Weight = 1.0
                        },
                        new
                        {
                            Id = new Guid("316b6a0e-83dc-4465-81ab-4aef34dbb4eb"),
                            Delivery = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,",
                            Description = "quibusdam praesentium nemo commodi! Provident dicta pariatur",
                            ImgUrl = "/images/cake.png",
                            ImgUrlsJson = "[\"/images/cake.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]",
                            IsBestseller = false,
                            Name = "Apple pie",
                            Price = 3.0,
                            ProductTypeId = 1,
                            ShortDetailsJson = "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]",
                            StorageConditions = "unde sit modi possimus incidunt ab neque sunt fugit.",
                            UnitOfMeasurement = "kg",
                            Weight = 2.0
                        },
                        new
                        {
                            Id = new Guid("257ebfde-0ba8-46d8-8ea2-d269b70c44d4"),
                            Delivery = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,",
                            Description = "quibusdam praesentium nemo commodi! Provident dicta pariatur",
                            ImgUrl = "/images/cookie.png",
                            ImgUrlsJson = "[\"/images/cookie.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]",
                            IsBestseller = true,
                            Name = "Chocolate Chip",
                            Price = 1.0,
                            ProductTypeId = 2,
                            ShortDetailsJson = "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]",
                            StorageConditions = "unde sit modi possimus incidunt ab neque sunt fugit.",
                            UnitOfMeasurement = "g",
                            Weight = 100.0
                        },
                        new
                        {
                            Id = new Guid("2b93d692-e7f0-4754-86c3-ca8a680b0d70"),
                            Delivery = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,",
                            Description = "quibusdam praesentium nemo commodi! Provident dicta pariatur",
                            ImgUrl = "/images/cookie.png",
                            ImgUrlsJson = "[\"/images/cookie.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]",
                            IsBestseller = false,
                            Name = "Peanut Butter",
                            Price = 5.0,
                            ProductTypeId = 2,
                            ShortDetailsJson = "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]",
                            StorageConditions = "unde sit modi possimus incidunt ab neque sunt fugit.",
                            UnitOfMeasurement = "g",
                            Weight = 500.0
                        },
                        new
                        {
                            Id = new Guid("c42faafa-6fc3-4d33-8945-967b95e2c661"),
                            Delivery = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,",
                            Description = "quibusdam praesentium nemo commodi! Provident dicta pariatur",
                            ImgUrl = "/images/choux.png",
                            ImgUrlsJson = "[\"/images/choux.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]",
                            IsBestseller = true,
                            Name = "Lemon Choux",
                            Price = 1.0,
                            ProductTypeId = 3,
                            ShortDetailsJson = "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]",
                            StorageConditions = "unde sit modi possimus incidunt ab neque sunt fugit.",
                            UnitOfMeasurement = "g",
                            Weight = 100.0
                        },
                        new
                        {
                            Id = new Guid("5bfe4662-ffc8-4ee1-a753-06d5a09b765a"),
                            Delivery = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,",
                            Description = "quibusdam praesentium nemo commodi! Provident dicta pariatur",
                            ImgUrl = "/images/choux.png",
                            ImgUrlsJson = "[\"/images/choux.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]",
                            IsBestseller = false,
                            Name = "Strawberry Choux",
                            Price = 4.0,
                            ProductTypeId = 3,
                            ShortDetailsJson = "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]",
                            StorageConditions = "unde sit modi possimus incidunt ab neque sunt fugit.",
                            UnitOfMeasurement = "g",
                            Weight = 400.0
                        },
                        new
                        {
                            Id = new Guid("ea682f36-3f8b-4c14-a362-eb4671976e65"),
                            Delivery = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,",
                            Description = "quibusdam praesentium nemo commodi! Provident dicta pariatur",
                            ImgUrl = "/images/pizza.jpg",
                            ImgUrlsJson = "[\"/images/pizza.jpg\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]",
                            IsBestseller = true,
                            Name = "Four Cheese",
                            Price = 5.0,
                            ProductTypeId = 4,
                            ShortDetailsJson = "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]",
                            StorageConditions = "unde sit modi possimus incidunt ab neque sunt fugit.",
                            UnitOfMeasurement = "g",
                            Weight = 500.0
                        },
                        new
                        {
                            Id = new Guid("eee708d4-7654-4378-ba6c-a7c457c6f1c9"),
                            Delivery = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,",
                            Description = "quibusdam praesentium nemo commodi! Provident dicta pariatur",
                            ImgUrl = "/images/pizza.jpg",
                            ImgUrlsJson = "[\"/images/pizza.jpg\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]",
                            IsBestseller = false,
                            Name = "Veggie",
                            Price = 3.0,
                            ProductTypeId = 4,
                            ShortDetailsJson = "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]",
                            StorageConditions = "unde sit modi possimus incidunt ab neque sunt fugit.",
                            UnitOfMeasurement = "g",
                            Weight = 300.0
                        });
                });

            modelBuilder.Entity("CupcakeShop.Core.Entities.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "cake"
                        },
                        new
                        {
                            Id = 2,
                            Name = "cookie"
                        },
                        new
                        {
                            Id = 3,
                            Name = "choux"
                        },
                        new
                        {
                            Id = 4,
                            Name = "pizza"
                        });
                });

            modelBuilder.Entity("CartProduct", b =>
                {
                    b.HasOne("CupcakeShop.Core.Entities.Cart", null)
                        .WithMany()
                        .HasForeignKey("CartsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CupcakeShop.Core.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CupcakeShop.Core.Entities.Cart", b =>
                {
                    b.HasOne("CupcakeShop.Core.Entities.AdditionDecoration", "AdditionDecoration")
                        .WithMany()
                        .HasForeignKey("AdditionDecorationId");

                    b.HasOne("CupcakeShop.Core.Entities.AdditionSubspecies", "AdditionSubspecies")
                        .WithMany()
                        .HasForeignKey("AdditionSubspeciesId");

                    b.HasOne("CupcakeShop.Core.Entities.AdditionWeight", "AdditionWeight")
                        .WithMany()
                        .HasForeignKey("AdditionWeightId");

                    b.Navigation("AdditionDecoration");

                    b.Navigation("AdditionSubspecies");

                    b.Navigation("AdditionWeight");
                });

            modelBuilder.Entity("CupcakeShop.Core.Entities.Order", b =>
                {
                    b.HasOne("CupcakeShop.Core.Entities.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("CupcakeShop.Core.Entities.Product", b =>
                {
                    b.HasOne("CupcakeShop.Core.Entities.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductType");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using ERPNet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ERPNet.Migrations
{
    [DbContext(typeof(ERPNetContext))]
    [Migration("20201002124205_addNewWareHouseData")]
    partial class addNewWareHouseData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeWebMySQL.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressContactName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AddressNumber")
                        .HasColumnType("int");

                    b.Property<string>("AddressStreet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.ToTable("Address");

                    b.HasData(
                        new
                        {
                            AddressId = 1,
                            AddressNumber = 7676,
                            AddressStreet = "8 street / 23"
                        },
                        new
                        {
                            AddressId = 2,
                            AddressNumber = 6376,
                            AddressStreet = "Zona Franca"
                        });
                });

            modelBuilder.Entity("EmployeeWebMySQL.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("CategoryId");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Clothing"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Merchandising"
                        });
                });

            modelBuilder.Entity("EmployeeWebMySQL.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            PersonId = 6
                        },
                        new
                        {
                            CustomerId = 2,
                            PersonId = 7
                        },
                        new
                        {
                            CustomerId = 3,
                            PersonId = 8
                        },
                        new
                        {
                            CustomerId = 4,
                            PersonId = 9
                        });
                });

            modelBuilder.Entity("EmployeeWebMySQL.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("PositionJob")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            Password = "test",
                            PersonId = 1,
                            PositionJob = "Boss",
                            Salary = 300,
                            UserName = "Ironman"
                        },
                        new
                        {
                            EmployeeId = 2,
                            Password = "test",
                            PersonId = 2,
                            PositionJob = "Soldier",
                            Salary = 200,
                            UserName = "Capitan America"
                        },
                        new
                        {
                            EmployeeId = 3,
                            Password = "test",
                            PersonId = 3,
                            PositionJob = "BioTech",
                            Salary = 200,
                            UserName = "Hulk"
                        },
                        new
                        {
                            EmployeeId = 4,
                            Password = "test",
                            PersonId = 4,
                            PositionJob = "Secret Agent",
                            Salary = 200,
                            UserName = "Black Widow"
                        },
                        new
                        {
                            EmployeeId = 5,
                            Password = "test",
                            PersonId = 5,
                            PositionJob = "God of Thunder",
                            Salary = 200,
                            UserName = "Thor"
                        });
                });

            modelBuilder.Entity("EmployeeWebMySQL.Models.Movements", b =>
                {
                    b.Property<int>("MovementsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InOutDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsInput")
                        .HasColumnType("bit");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("StorageId")
                        .HasColumnType("int");

                    b.HasKey("MovementsId");

                    b.HasIndex("StorageId");

                    b.ToTable("Movements");
                });

            modelBuilder.Entity("EmployeeWebMySQL.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationOrder")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DoneByEmployeeOrder")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderCompleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderPriority")
                        .HasColumnType("int");

                    b.Property<int>("OrderState")
                        .HasColumnType("int");

                    b.Property<double>("PriceItem")
                        .HasColumnType("float");

                    b.Property<double>("PriceItemIva")
                        .HasColumnType("float");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("OrderId");

                    b.HasIndex("AddressId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("EmployeeWebMySQL.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("PersonId");

                    b.ToTable("Person");

                    b.HasData(
                        new
                        {
                            PersonId = 2,
                            LastName = "Rogers",
                            Name = "Steve"
                        },
                        new
                        {
                            PersonId = 3,
                            LastName = "Banner",
                            Name = "Bruce"
                        },
                        new
                        {
                            PersonId = 4,
                            LastName = "Romanoff",
                            Name = "Natacha"
                        },
                        new
                        {
                            PersonId = 5,
                            LastName = "Son of Odin",
                            Name = "Thor"
                        },
                        new
                        {
                            PersonId = 6,
                            LastName = "Wilde",
                            Name = "Olivia"
                        },
                        new
                        {
                            PersonId = 7,
                            LastName = "Carreño",
                            Name = "Teresa"
                        },
                        new
                        {
                            PersonId = 8,
                            LastName = "Singleton",
                            Name = "Lujan"
                        },
                        new
                        {
                            PersonId = 9,
                            LastName = "Jefferson",
                            Name = "Thomas"
                        });
                });

            modelBuilder.Entity("EmployeeWebMySQL.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("TotalQuantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OrderId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("EmployeeWebMySQL.Models.Storage", b =>
                {
                    b.Property<int>("StorageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PartialQuantity")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("StorageId");

                    b.HasIndex("ProductId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("Storage");
                });

            modelBuilder.Entity("EmployeeWebMySQL.Models.Warehouse", b =>
                {
                    b.Property<int>("WarehouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("WarehouseId");

                    b.HasIndex("AddressId");

                    b.ToTable("Warehouse");

                    b.HasData(
                        new
                        {
                            WarehouseId = 1,
                            AddressId = 1,
                            Name = "New York C"
                        },
                        new
                        {
                            WarehouseId = 2,
                            AddressId = 2,
                            Name = "Barcelona C"
                        });
                });

            modelBuilder.Entity("EmployeeWebMySQL.Models.Customer", b =>
                {
                    b.HasOne("EmployeeWebMySQL.Models.Person", "Person")
                        .WithOne("Customer")
                        .HasForeignKey("EmployeeWebMySQL.Models.Customer", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeWebMySQL.Models.Employee", b =>
                {
                    b.HasOne("EmployeeWebMySQL.Models.Person", "Person")
                        .WithOne("Employee")
                        .HasForeignKey("EmployeeWebMySQL.Models.Employee", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeWebMySQL.Models.Movements", b =>
                {
                    b.HasOne("EmployeeWebMySQL.Models.Storage", "Storage")
                        .WithMany("InputOutputs")
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeWebMySQL.Models.Order", b =>
                {
                    b.HasOne("EmployeeWebMySQL.Models.Address", null)
                        .WithMany("Orders")
                        .HasForeignKey("AddressId");

                    b.HasOne("EmployeeWebMySQL.Models.Customer", null)
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId");

                    b.HasOne("EmployeeWebMySQL.Models.Employee", null)
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("EmployeeWebMySQL.Models.Product", b =>
                {
                    b.HasOne("EmployeeWebMySQL.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeWebMySQL.Models.Order", null)
                        .WithMany("Products")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("EmployeeWebMySQL.Models.Storage", b =>
                {
                    b.HasOne("EmployeeWebMySQL.Models.Product", "Product")
                        .WithMany("Storages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeWebMySQL.Models.Warehouse", "Warehouse")
                        .WithMany("Storages")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeWebMySQL.Models.Warehouse", b =>
                {
                    b.HasOne("EmployeeWebMySQL.Models.Address", "Address")
                        .WithMany("Warehouses")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

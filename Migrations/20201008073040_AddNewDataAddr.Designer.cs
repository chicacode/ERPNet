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
    [Migration("20201008073040_AddNewDataAddr")]
    partial class AddNewDataAddr
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ERPNet.Models.OrderProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("PriceItem")
                        .HasColumnType("float");

                    b.Property<double>("PriceItemIva")
                        .HasColumnType("float");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("EmployeeWebMySQL.Models.Address", b =>
                {
                    b.Property<int>("Id")
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

                    b.HasKey("Id");

                    b.ToTable("Address");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressNumber = 7676,
                            AddressStreet = "8 street / 23"
                        },
                        new
                        {
                            Id = 2,
                            AddressNumber = 6376,
                            AddressStreet = "Zona Franca"
                        });
                });

            modelBuilder.Entity("EmployeeWebMySQL.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Clothing"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Merchandising"
                        });
                });

            modelBuilder.Entity("EmployeeWebMySQL.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PersonId = 6
                        },
                        new
                        {
                            Id = 2,
                            PersonId = 7
                        },
                        new
                        {
                            Id = 3,
                            PersonId = 8
                        },
                        new
                        {
                            Id = 4,
                            PersonId = 9
                        });
                });

            modelBuilder.Entity("EmployeeWebMySQL.Models.Employee", b =>
                {
                    b.Property<int>("Id")
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

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "test",
                            PersonId = 1,
                            PositionJob = "Boss",
                            Salary = 300,
                            UserName = "Ironman",
                            isAdmin = false
                        },
                        new
                        {
                            Id = 2,
                            Password = "test",
                            PersonId = 2,
                            PositionJob = "Soldier",
                            Salary = 200,
                            UserName = "Capitan America",
                            isAdmin = false
                        },
                        new
                        {
                            Id = 3,
                            Password = "test",
                            PersonId = 3,
                            PositionJob = "BioTech",
                            Salary = 200,
                            UserName = "Hulk",
                            isAdmin = false
                        },
                        new
                        {
                            Id = 4,
                            Password = "test",
                            PersonId = 4,
                            PositionJob = "Secret Agent",
                            Salary = 200,
                            UserName = "Black Widow",
                            isAdmin = false
                        },
                        new
                        {
                            Id = 5,
                            Password = "test",
                            PersonId = 5,
                            PositionJob = "God of Thunder",
                            Salary = 200,
                            UserName = "Thor",
                            isAdmin = false
                        });
                });

            modelBuilder.Entity("EmployeeWebMySQL.Models.Movements", b =>
                {
                    b.Property<int>("Id")
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

                    b.HasKey("Id");

                    b.HasIndex("StorageId");

                    b.ToTable("Movements");
                });

            modelBuilder.Entity("EmployeeWebMySQL.Models.Order", b =>
                {
                    b.Property<int>("Id")
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

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("EmployeeWebMySQL.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Person");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LastName = "Stark",
                            Name = "Tony"
                        },
                        new
                        {
                            Id = 2,
                            LastName = "Rogers",
                            Name = "Steve"
                        },
                        new
                        {
                            Id = 3,
                            LastName = "Banner",
                            Name = "Bruce"
                        },
                        new
                        {
                            Id = 4,
                            LastName = "Romanoff",
                            Name = "Natacha"
                        },
                        new
                        {
                            Id = 5,
                            LastName = "Son of Odin",
                            Name = "Thor"
                        },
                        new
                        {
                            Id = 6,
                            LastName = "Wilde",
                            Name = "Olivia"
                        },
                        new
                        {
                            Id = 7,
                            LastName = "Carreño",
                            Name = "Teresa"
                        },
                        new
                        {
                            Id = 8,
                            LastName = "Singleton",
                            Name = "Lujan"
                        },
                        new
                        {
                            Id = 9,
                            LastName = "Jefferson",
                            Name = "Thomas"
                        });
                });

            modelBuilder.Entity("EmployeeWebMySQL.Models.Product", b =>
                {
                    b.Property<int>("Id")
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

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("TotalQuantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("EmployeeWebMySQL.Models.Storage", b =>
                {
                    b.Property<int>("Id")
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

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("Storage");
                });

            modelBuilder.Entity("EmployeeWebMySQL.Models.Warehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Warehouse");
                });

            modelBuilder.Entity("ERPNet.Models.OrderProduct", b =>
                {
                    b.HasOne("EmployeeWebMySQL.Models.Order", "Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId");

                    b.HasOne("EmployeeWebMySQL.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
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
                    b.HasOne("EmployeeWebMySQL.Models.Address", "Address")
                        .WithMany("Orders")
                        .HasForeignKey("AddressId");

                    b.HasOne("EmployeeWebMySQL.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId");

                    b.HasOne("EmployeeWebMySQL.Models.Employee", "Employee")
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

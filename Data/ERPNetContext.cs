﻿using Microsoft.EntityFrameworkCore;
using ERPNet.Models;
using ERPNet.Entities;

namespace ERPNet.Data
{
    public class ERPNetContext : DbContext
    {
        public ERPNetContext (DbContextOptions<ERPNetContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Address { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<Movements> Movements { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<OrderProduct> OrderProduct { get; set; }

        public DbSet<Storage> Storage { get; set; }

        public DbSet<Warehouse> Warehouse { get; set; }


        protected override void OnModelCreating ( ModelBuilder modelBuilder )
        {
            base.OnModelCreating ( modelBuilder );

            modelBuilder.Entity<Employee> ().HasData (
                new Employee
                {
                    Id = 1,
                    Name = "Tony",
                    LastName = "Stark",
                    PositionJob = "Boss",
                    Salary = 300,
                    UserName = "Ironman",
                    Password = "test"
                },
               new Employee
               {
                   Id = 2,
                   Name = "Steve",
                   LastName = "Rogers",
                   PositionJob = "Soldier",
                   Salary = 200,
                   UserName = "Capitan America",
                   Password = "test"
               },
                new Employee
                {
                    Id = 3,
                    Name = "Bruce",
                    LastName = "Banner",
                    PositionJob = "BioTech",
                    Salary = 200,
                    UserName = "Hulk",
                    Password = "test"
                },
                 new Employee
                 {
                     Id = 4,
                     Name = "Natacha",
                     LastName = "Romanoff",
                     PositionJob = "Secret Agent",
                     Salary = 200,
                     UserName = "Black Widow",
                     Password = "test"
                 },
                  new Employee
                  {
                      Id = 5,
                      Name = "Thor",
                      LastName = "Son of Odin",
                      PositionJob = "God of Thunder",
                      Salary = 200,
                      UserName = "Thor",
                      Password = "test"
                  }
                );

            modelBuilder.Entity<Customer> ().HasData (
                 new Customer
                 {
                     Id = 1,
                     Name = "Olivia",
                     LastName = "Wilde"

                 },
                 new Customer
                 {
                     Id = 2,
                     Name = "Teresa",
                     LastName = "Carreño"
                 },
                  new Customer
                  {
                      Id = 3,
                      Name = "Lujan",
                      LastName = "Singleton"
                  },
                 new Customer
                 {
                     Id = 4,
                     Name = "Thomas",
                     LastName = "Jefferson"
                 }
             );
            modelBuilder.Entity<Address> ().HasData (
               new Address
               {
                   Id = 1,
                   AddressNumber = 7676,
                   AddressStreet = "8 street / 23"
               },
               new Address
               {
                   Id = 2,
                   AddressNumber = 6376,
                   AddressStreet = "Zona Franca"
               }
           );
            modelBuilder.Entity<Warehouse> ().HasData (
                new Warehouse
                {
                    Id = 1,
                    Name = "New York C",
                    AddressId = 1
                },
                new Warehouse
                {
                    Id = 2,
                    Name = "Barcelona C",
                    AddressId = 2
                }
            );
            modelBuilder.Entity<Product> ().HasData (
                new Product
                {
                    Id = 1,
                    Name = "T-Shirts",
                    Description = "Shop high-quality unique T-Shirts designed and sold by artist. 100% cotton",
                    TotalQuantity = 2,
                    CategoryName = "Clothing"
                },
                new Product
                {
                    Id = 2,
                    Name = "Hoodies",
                    Description = "Shop high-quality unique Hoodies designed and sold by artist. 100% cotton",
                    TotalQuantity = 2,
                    CategoryName = "Clothing"
                },
                 new Product
                 {
                     Id = 3,
                     Name = "Mugs",
                     Description = "Coffee, Tea Mugs",
                     TotalQuantity = 12,
                     CategoryName = "Merchandising"
                 },
                  new Product
                  {
                      Id = 4,
                      Name = "Stickers",
                      Description = "Code Stickers",
                      TotalQuantity = 10,
                      CategoryName = "Merchandising"
                  }
            );
            modelBuilder.Entity<Order> ().HasData (
                new Order
                {
                    Id = 1,
                    OrderNumber = "XXX909090",
                    CustomerId = 1
                },
                new Order
                {
                    Id = 2,
                    OrderNumber = "XXX909091",
                    CustomerId = 2
                },
                 new Order
                 {
                     Id = 4,
                     OrderNumber = "XXX909092",
                     CustomerId = 1
                 },
                new Order
                {
                    Id = 5,
                    OrderNumber = "XXX909093",
                    CustomerId = 2

                }
            );

            modelBuilder.Entity<Storage> ().HasData (
             new Storage
             {
                 Id = 1,
                 PartialQuantity = 900,
                 ProductId = 1,
                 WarehouseId = 1
             },
             new Storage
             {
                 Id = 2,
                 PartialQuantity = 700,
                 ProductId = 2,
                 WarehouseId = 1
             }
         );
        }
    }
 }

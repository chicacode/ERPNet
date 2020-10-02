using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeWebMySQL.Models;

namespace ERPNet.Data
{
    public class ERPNetContext : DbContext
    {
        public ERPNetContext (DbContextOptions<ERPNetContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Address { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<Movements> Movements { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<Person> Person { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Storage> Storage { get; set; }

        public DbSet<Warehouse> Warehouse { get; set; }


        protected override void OnModelCreating ( ModelBuilder modelBuilder )
        {
            base.OnModelCreating ( modelBuilder );

            //modelBuilder.Entity<Customer> ()
            //.HasOne ( a => a.Person )
            //.WithOne ( b => b.Customer )
            //.HasForeignKey<Customer> ( c => c.PersonForeignKey );

            modelBuilder.Entity<Category> ().HasData (
               new Category
               {
                   CategoryId = 1,
                   Name = "Clothing"
               },
               new Category
               {
                   CategoryId = 2,
                   Name = "Merchandising"
               }
            );
            modelBuilder.Entity<Person> ().HasData (
   
                new Person
                {
                    PersonId = 2,
                    Name = "Steve",
                    LastName = "Rogers"
 
                },
                 new Person
                 {
                     PersonId = 3,
                     Name = "Bruce",
                     LastName = "Banner"
          
                 },
                  new Person
                  {
                      PersonId = 4,
                      Name = "Natacha",
                      LastName = "Romanoff"
        
                  },
                   new Person
                   {
                       PersonId = 5,
                       Name = "Thor",
                       LastName = "Son of Odin"
                   },
                  new Person
                    {
                        PersonId = 6,
                        Name = "Olivia",
                        LastName = "Wilde"

                    },
                   new Person
                    {
                        PersonId = 7,
                        Name = "Teresa",
                        LastName = "Carreño"
                     },
                   
                   new Person
                     {
                        PersonId = 8,
                        Name = "Lujan",
                        LastName = "Singleton"

                     },
                    new Person
                     {
                         PersonId = 9,
                         Name = "Thomas",
                         LastName = "Jefferson"
                    }
                );
            modelBuilder.Entity<Employee> ().HasData (
                new Employee
                {
                    EmployeeId = 1,
                    PersonId = 1,
                    PositionJob = "Boss",
                    Salary = 300,
                    UserName = "Ironman",
                    Password = "test"
                },
               new Employee
               {
                   EmployeeId = 2,
                   PersonId = 2,
                   PositionJob = "Soldier",
                   Salary = 200,
                   UserName = "Capitan America",
                   Password = "test"
               },
                new Employee
                {
                    EmployeeId = 3,
                    PersonId = 3,
                    PositionJob = "BioTech",
                    Salary = 200,
                    UserName = "Hulk",
                    Password = "test"
                },
                 new Employee
                 {
                     EmployeeId = 4,
                     PersonId = 4,
                     PositionJob = "Secret Agent",
                     Salary = 200,
                     UserName = "Black Widow",
                     Password = "test"
                 },
                  new Employee
                  {
                      EmployeeId = 5,
                      PersonId = 5,
                      PositionJob = "God of Thunder",
                      Salary = 200,
                      UserName = "Thor",
                      Password = "test"
                  }
                );
            modelBuilder.Entity<Customer> ().HasData (
                 new Customer
                 {
                     CustomerId = 1,
                     PersonId = 6
                 },
                 new Customer
                 {
                     CustomerId = 2,
                     PersonId = 7
                 },
                  new Customer
                  {
                      CustomerId = 3,
                      PersonId = 8
                  },
                 new Customer
                 {
                     CustomerId = 4,
                     PersonId = 9
                 }
             );
             modelBuilder.Entity<Address> ().HasData (
                new Address
                {
                    AddressId = 1,
                    AddressNumber = 7676,
                    AddressStreet = "8 street / 23"
                },
                new Address
                {
                    AddressId = 2,
                    AddressNumber = 6376,
                    AddressStreet = "Zona Franca"
                }
            );
            modelBuilder.Entity<Warehouse> ().HasData (
                new Warehouse
                {
                    WarehouseId = 1,
                    Name = "New York C",
                    AddressId = 1
                },
                new Warehouse
                {
                    WarehouseId = 2,
                    Name = "Barcelona C",
                    AddressId = 2
                }
            );
            modelBuilder.Entity<Product> ().HasData (
            new Product
            {
                ProductId = 1,
                Name = "T-Shirts",
                Description = "Shop high-quality unique T-Shirts designed and sold by artist. 100% cotton",
                TotalQuantity = 2,
                CategoryId = 1
            },
            new Product
            {
                ProductId = 2,
                Name = "Hoodies",
                Description = "Shop high-quality unique Hoodies designed and sold by artist. 100% cotton",
                TotalQuantity = 2,
                CategoryId = 1
            },
             new Product
             {
                 ProductId = 3,
                 Name = "Mugs",
                 Description = "Coffee, Tea Mugs",
                 TotalQuantity = 12,
                 CategoryId = 2
             },
              new Product
              {
                  ProductId = 4,
                  Name = "Stickers",
                  Description = "Code Stickers",
                  TotalQuantity = 10,
                  CategoryId = 2
              }
            );
        }
    }
 }

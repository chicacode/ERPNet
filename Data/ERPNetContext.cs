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

        }
    }
 }

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

        }
     }
 }

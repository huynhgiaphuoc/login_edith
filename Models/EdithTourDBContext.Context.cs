﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EdithTour.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EdithTourEntities : DbContext
    {
        public EdithTourEntities()
            : base("name=EdithTourEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Airline> Airlines { get; set; }
        public virtual DbSet<Combo> Comboes { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Customer_Level> Customer_Level { get; set; }
        public virtual DbSet<Data_market> Data_market { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Orderdetail> Orderdetails { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Ticket_Combo> Ticket_Combo { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<Tour_Inside> Tour_Inside { get; set; }
        public virtual DbSet<Tour_Outside> Tour_Outside { get; set; }
        public virtual DbSet<Tourtrending> Tourtrendings { get; set; }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pegas.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PegasEntities : DbContext
    {
        public PegasEntities()
            : base("name=PegasEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<FlightCodeEnum> FlightCodeEnums { get; set; }
        public virtual DbSet<JobDetail> JobDetails { get; set; }
        public virtual DbSet<JobTypeEnum> JobTypeEnums { get; set; }
        public virtual DbSet<MeetingPointEnum> MeetingPointEnums { get; set; }
        public virtual DbSet<UserRoleEnum> UserRoleEnums { get; set; }
        public virtual DbSet<VehicleTypeEnum> VehicleTypeEnums { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
    }
}

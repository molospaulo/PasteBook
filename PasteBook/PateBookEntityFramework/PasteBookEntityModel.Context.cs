﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PateBookEntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PasteBookDataEntities : DbContext
    {
        public PasteBookDataEntities()
            : base("name=PasteBookDataEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<PB_COMMENTS> PB_COMMENTS { get; set; }
        public virtual DbSet<PB_FRIENDS> PB_FRIENDS { get; set; }
        public virtual DbSet<PB_LIKES> PB_LIKES { get; set; }
        public virtual DbSet<PB_NOTIFICATION> PB_NOTIFICATION { get; set; }
        public virtual DbSet<PB_POSTS> PB_POSTS { get; set; }
        public virtual DbSet<PB_REF_COUNTRY> PB_REF_COUNTRY { get; set; }
        public virtual DbSet<PB_USER> PB_USER { get; set; }
    }
}
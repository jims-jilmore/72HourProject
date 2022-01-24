﻿using _72HourProj.Data;
using _72HourProj.Data.PostEntity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace _72HourProj.Web
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //Insert DbContext Here
        public DbSet<Post> Posts { get; set; }
        //<<<-------
        //<<<-------
        //<<<-------

    }
}
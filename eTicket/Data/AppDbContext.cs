using eTicket.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        //private readonly object Orm;

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actor_Movies).HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actor_Movies).HasForeignKey(m => m.ActorId);
            base.OnModelCreating(modelBuilder);

            /* foreach (var i in this.Orm..Entries())
                 i.Reload();*/
            /*var refreshableObjects = AppDbContext.ChangeTracker.Entries().Select(c => c.Entity).ToList();
            AppDbcontext.Refresh(RefreshMode.StoreWins, refreshableObjects);*/
        }
        // var context =((IObjectContextAdapter)
        /*   var refreshableObject = AppDbContext.ChangeTraker.Entries().Select(c => c.Entity).ToList();
           Context.Refresh(RefreshMode.StoreWins, refreshableObjects);*/


    
        public DbSet<Actor> Actors{ get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actor_Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set;}

               

    }


}

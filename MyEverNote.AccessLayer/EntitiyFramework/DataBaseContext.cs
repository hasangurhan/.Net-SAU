using MyEverNote.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEverNote.AccessLayer.EntitiyFramework
{
    public class DataBaseContext : DbContext 
    {
        public DbSet<EverNoteUser> EvernoteUsers { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Liked> Likes { get; set; }
        public DataBaseContext()
        {
            Database.SetInitializer(new MyInitializer());
        }
    }
}

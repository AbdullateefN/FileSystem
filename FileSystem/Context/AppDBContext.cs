using FileSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileSystem.Context
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {
                
        }
        public DbSet<Folder> Folders{ get; set; }
        public DbSet<File> Files { get; set; }

        //protected void OnModleCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.HasMany()
        //    //    mod.HasOne(f=>f.FolderParent)
        //    //    .WithMany(f=>f.Files) 
        //        .OnDelete(DeleteBehavior.Cascade);

        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Folder>().HasMany(f => f.Files)
          .WithOne(c => c.Folder)
           .OnDelete(DeleteBehavior.Cascade);
        }
    }
   
}



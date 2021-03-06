using bookshop.Models;
using Microsoft.EntityFrameworkCore;

namespace bookshop.Persistance
{
    public class BookDbContext : DbContext
    {
        public DbSet<BookDef> BookDefinitons{get;set;}

        public DbSet<BookInst> BookInstances { get; set; }

        public DbSet<Writer> Writers{get;set;}       

        public DbSet<Genre> Genres {get;set;}

        public DbSet<Country> Countries {get;set;}

        public DbSet<Language> Languages {get;set;}

        public DbSet<Publisher> Publishers {get;set;}

        public DbSet<Translator> Translators {get;set;}

        public DbSet<BookInstPhoto> Photos {get;set;}

        public DbSet<User> Users{get;set;}

        public DbSet<CustomClaim> CustomClaims{get;set;}

        public BookDbContext(DbContextOptions<Persistance.BookDbContext> options2) : base(options2)
        {
             
        }

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<BookDefGenre>().HasKey(bd => new { bd.BookDefId, bd.GenreId });

            builder.Entity<BookDefGenre>()
            .HasOne(pt => pt.BookDef)
            .WithMany(p => p.BookDefGenres)
            .HasForeignKey(pt => pt.BookDefId);

            builder.Entity<UserCustomClaim>().HasKey(u => new{ u.UserId, u.CustomClaimId });

            builder.Entity<UserCustomClaim>()
                .HasOne(u => u.User)
                .WithMany(c => c.UserCustomClaims)
                .HasForeignKey(k => k.UserId);

        }
    }
}
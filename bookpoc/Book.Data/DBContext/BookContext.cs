using Book.Data.DataModel;
using Book.Model.DataModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Book.Data.DBContext
{

    public class BookContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<BookDetails> BookDetails { get; set; }
        public virtual DbSet<Favorites> Favorites { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<History> History { get; set; }

        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<BookDetails>()
            .HasOne(b => b.Favorites)
            .WithOne(i => i.BookDetails)
            .HasForeignKey<Favorites>(b => b.BookId);

            builder.Entity<BookDetails>()
           .HasOne(b => b.Review)
           .WithOne(i => i.BookDetails)
           .HasForeignKey<Review>(b => b.BookId);

            builder.Entity<BookDetails>()
           .HasOne(b => b.History)
           .WithOne(i => i.BookDetails)
           .HasForeignKey<History>(b => b.BookId);
        }
    }
}

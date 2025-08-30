using System;
using System.Collections.Generic;
using Library_Management.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Library_Management.Data;

public partial class BookDbContext : DbContext
{
    public BookDbContext()
    {
    }

    public BookDbContext(DbContextOptions<BookDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookCopy> BookCopies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=library_db;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Author__3214EC0792C7110D");

            entity.ToTable("Author");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.ProfileImageUrl).HasMaxLength(500);

            entity.HasMany(d => d.Books).WithMany(p => p.Authors)
                .UsingEntity<Dictionary<string, object>>(
                    "AuthorBook",
                    r => r.HasOne<Book>().WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_AuthorBook_Book"),
                    l => l.HasOne<Author>().WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_AuthorBook_Author"),
                    j =>
                    {
                        j.HasKey("AuthorId", "BookId").HasName("PK__AuthorBo__1304F014073B0AE5");
                        j.ToTable("AuthorBook");
                    });
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Book__3214EC07A95F85A7");

            entity.ToTable("Book");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Genre).HasMaxLength(100);
            entity.Property(e => e.Isbn)
                .HasMaxLength(50)
                .HasColumnName("ISBN");
            entity.Property(e => e.PublishedDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<BookCopy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BookCopy__3214EC0745271D62");

            entity.ToTable("BookCopy");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AddedDate).HasColumnType("datetime");
            entity.Property(e => e.Condition).HasMaxLength(100);
            entity.Property(e => e.CoverImageUrl).HasMaxLength(500);
            entity.Property(e => e.PulloutDate).HasColumnType("datetime");
            entity.Property(e => e.PulloutReason).HasMaxLength(255);
            entity.Property(e => e.Source).HasMaxLength(100);

            entity.HasOne(d => d.Book).WithMany(p => p.BookCopies)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK_BookCopy_Book");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ProductsStore.Models.dbContext
{
    public partial class HardCodeContext : DbContext
    {
        public HardCodeContext()
        {
        }

        public HardCodeContext(DbContextOptions<HardCodeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryField> CategoryFields { get; set; }
        public virtual DbSet<Field> Fields { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductField> ProductFields { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=GRINTSEVICHGS;Database=HardCode;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CategoryField>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Category_Fields");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.FieldId).HasColumnName("Field_Id");

                entity.HasOne(d => d.Category)
                    .WithMany()
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Category_Fields_Categories1");

                entity.HasOne(d => d.Field)
                    .WithMany()
                    .HasForeignKey(d => d.FieldId)
                    .HasConstraintName("FK_Category_Fields_Fields");
            });

            modelBuilder.Entity<Field>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Products_Categories");
            });

            modelBuilder.Entity<ProductField>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FieldId).HasColumnName("Field_Id");

                entity.Property(e => e.Value).HasMaxLength(50);

                entity.HasOne(d => d.Field)
                    .WithMany()
                    .HasForeignKey(d => d.FieldId)
                    .HasConstraintName("FK_ProductFields_Fields");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ProductFields_Products");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

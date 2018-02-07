using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB
{
    public partial class ECommerceDBContext : DbContext
    {
        public ECommerceDBContext(DbContextOptions options):base(options)
        {

        }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CommentAbuse> CommentAbuse { get; set; }
        public virtual DbSet<Courier> Courier { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<Periode> Periode { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductAbuse> ProductAbuse { get; set; }
        public virtual DbSet<ProductComment> ProductComment { get; set; }
        public virtual DbSet<ProductFavorite> ProductFavorite { get; set; }
        public virtual DbSet<ProductGroup> ProductGroup { get; set; }
        public virtual DbSet<ProductImage> ProductImage { get; set; }
        public virtual DbSet<ProductOrder> ProductOrder { get; set; }
        public virtual DbSet<ProductRating> ProductRating { get; set; }
        public virtual DbSet<ProductReview> ProductReview { get; set; }
        public virtual DbSet<ProductSpec> ProductSpec { get; set; }
        public virtual DbSet<ProductVariation> ProductVariation { get; set; }
        public virtual DbSet<ProductVariationImage> ProductVariationImage { get; set; }
        public virtual DbSet<ProductVariationSpec> ProductVariationSpec { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<SubCategory> SubCategory { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<UserCartlist> UserCartlist { get; set; }
        public virtual DbSet<UserWishlist> UserWishlist { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category", "Merchandise");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Images).IsRequired();

                entity.Property(e => e.LastUpdated).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CommentAbuse>(entity =>
            {
                entity.ToTable("CommentAbuse", "Abuse");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ApprovedDateTime).HasColumnType("datetime");

                entity.Property(e => e.ApprovedMessage)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.PenaltyCompletedDateTime).HasColumnType("datetime");

                entity.Property(e => e.PenaltyGiven)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PenaltyGivenDateTime).HasColumnType("datetime");

                entity.Property(e => e.ReportReason)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReportedDateTime).HasColumnType("datetime");

                entity.Property(e => e.SolvedDateTime).HasColumnType("datetime");

                entity.Property(e => e.SolvedMessage)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.CommentAbuse)
                    .HasForeignKey(d => d.CommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CommentAbuse_ProductComment");
            });

            modelBuilder.Entity<Courier>(entity =>
            {
                entity.ToTable("Courier", "Courier");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CourierName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveredDateTime).HasColumnType("datetime");

                entity.Property(e => e.DropOffAddress)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.OrderTime).HasColumnType("datetime");

                entity.Property(e => e.PickUpAddress)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ReceivedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VendorName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Group", "Merchandise");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory", "Merchandise");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.VariationId).HasColumnName("VariationID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventory_Product");

                entity.HasOne(d => d.Variation)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.VariationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventory_ProductVariation");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.ToTable("Manufacturer", "Merchandise");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastUpdated).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Payments>(entity =>
            {
                entity.ToTable("Payments", "Transaction");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.CancelledReason)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CancelledTime).HasColumnType("datetime");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaidOffDateTime).HasColumnType("datetime");

                entity.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethodID");

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VerifiedDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payments_Transaction");
            });

            modelBuilder.Entity<Periode>(entity =>
            {
                entity.ToTable("Periode", "Event");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.LastUpdated).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.UpdatedBy).HasColumnType("datetime");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product", "Merchandise");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Disable).HasColumnName("DIsable");

                entity.Property(e => e.LastPriceChanged).HasColumnType("datetime");

                entity.Property(e => e.LastUpdated).HasColumnType("datetime");

                entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.AddedDateTime).HasColumnType("datetime");

                entity.Property(e => e.SubCategoryId).HasColumnName("SubCategoryID");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Manufacturer");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.SubCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_SubCategory");
            });

            modelBuilder.Entity<ProductAbuse>(entity =>
            {
                entity.ToTable("ProductAbuse", "Abuse");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ApprovedDateTime).HasColumnType("datetime");

                entity.Property(e => e.ApprovedMessage)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PenaltyCompletedDateTime).HasColumnType("datetime");

                entity.Property(e => e.PenaltyGiven)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PenaltyGivenDateTime).HasColumnType("datetime");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductVariationId).HasColumnName("ProductVariationID");

                entity.Property(e => e.ReportReason)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReportedDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductAbuse)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductAbuse_Product");

                entity.HasOne(d => d.ProductVariation)
                    .WithMany(p => p.ProductAbuse)
                    .HasForeignKey(d => d.ProductVariationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductAbuse_ProductVariation");
            });

            modelBuilder.Entity<ProductComment>(entity =>
            {
                entity.ToTable("ProductComment", "Activity");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CommentDateTime).HasColumnType("datetime");

                entity.Property(e => e.Comments)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ReportedDateTime).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductComment)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductComment_Product");
            });

            modelBuilder.Entity<ProductFavorite>(entity =>
            {
                entity.ToTable("ProductFavorite", "Activity");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FavoritedDateTime).HasColumnType("datetime");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductVariationId).HasColumnName("ProductVariationID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductFavorite)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductFavorite_Product");

                entity.HasOne(d => d.ProductVariation)
                    .WithMany(p => p.ProductFavorite)
                    .HasForeignKey(d => d.ProductVariationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductFavorite_ProductVariation");
            });

            modelBuilder.Entity<ProductGroup>(entity =>
            {
                entity.ToTable("ProductGroup", "Merchandise");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddedDateTime).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductVariationId).HasColumnName("ProductVariationID");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.ProductGroup)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductGroup_Group");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductGroup)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ProductGroup_Product");

                entity.HasOne(d => d.ProductVariation)
                    .WithMany(p => p.ProductGroup)
                    .HasForeignKey(d => d.ProductVariationId)
                    .HasConstraintName("FK_ProductGroup_ProductVariation");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.ToTable("ProductImage", "Merchandise");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Image).IsRequired();

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductImage)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductImage_Product");
            });

            modelBuilder.Entity<ProductOrder>(entity =>
            {
                entity.ToTable("ProductOrder", "Transaction");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CourierId).HasColumnName("CourierID");

                entity.Property(e => e.Message).IsUnicode(false);

                entity.Property(e => e.OrderTime).HasColumnType("datetime");

                entity.Property(e => e.ProductVariationId).HasColumnName("ProductVariationID");

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.UserAddressId).HasColumnName("UserAddressID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VendorVerifiedDateTime).HasColumnType("date");

                entity.HasOne(d => d.Courier)
                    .WithMany(p => p.ProductOrder)
                    .HasForeignKey(d => d.CourierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductOrder_Courier");

                entity.HasOne(d => d.ProductVariation)
                    .WithMany(p => p.ProductOrder)
                    .HasForeignKey(d => d.ProductVariationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductOrder_ProductVariation");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.ProductOrder)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductOrder_Transaction");
            });

            modelBuilder.Entity<ProductRating>(entity =>
            {
                entity.ToTable("ProductRating", "Activity");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductVariationId).HasColumnName("ProductVariationID");

                entity.Property(e => e.RatingDateTime).HasColumnType("datetime");

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductRating)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductRating_Product");

                entity.HasOne(d => d.ProductVariation)
                    .WithMany(p => p.ProductRating)
                    .HasForeignKey(d => d.ProductVariationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductRating_ProductVariation");
            });

            modelBuilder.Entity<ProductReview>(entity =>
            {
                entity.ToTable("ProductReview", "Activity");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.LastReviewed).HasColumnType("datetime");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductVariationId).HasColumnName("ProductVariationID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductReview)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductReview_Product");

                entity.HasOne(d => d.ProductVariation)
                    .WithMany(p => p.ProductReview)
                    .HasForeignKey(d => d.ProductVariationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductReview_ProductVariation");
            });

            modelBuilder.Entity<ProductSpec>(entity =>
            {
                entity.ToTable("ProductSpec", "Merchandise");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastUpdated).HasColumnType("datetime");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductSpec)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductSpec_Product");
            });

            modelBuilder.Entity<ProductVariation>(entity =>
            {
                entity.ToTable("ProductVariation", "Merchandise");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Condition)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.ExpiryDate).HasColumnType("date");

                entity.Property(e => e.LastPriceChanged).HasColumnType("datetime");

                entity.Property(e => e.LastUpdated).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Quantifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegisteredDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductVariation)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductVariation_Product");
            });

            modelBuilder.Entity<ProductVariationImage>(entity =>
            {
                entity.ToTable("ProductVariationImage", "Merchandise");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Image).IsRequired();

                entity.Property(e => e.ProductVariationId).HasColumnName("ProductVariationID");

                entity.HasOne(d => d.ProductVariation)
                    .WithMany(p => p.ProductVariationImage)
                    .HasForeignKey(d => d.ProductVariationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductVariationImage_ProductVariation");
            });

            modelBuilder.Entity<ProductVariationSpec>(entity =>
            {
                entity.ToTable("ProductVariationSpec", "Merchandise");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastUpdated).HasColumnType("datetime");

                entity.Property(e => e.ProductVariationId).HasColumnName("ProductVariationID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.ProductVariation)
                    .WithMany(p => p.ProductVariationSpec)
                    .HasForeignKey(d => d.ProductVariationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductVariationSpec_ProductVariation");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("Sale", "Event");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodeId).HasColumnName("PeriodeID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.SubCategoryId).HasColumnName("SubCategoryID");

                entity.Property(e => e.VariationId).HasColumnName("VariationID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Sale_Category");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Sale_Group");

                entity.HasOne(d => d.Periode)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.PeriodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sale_Periode");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Sale_Product");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.SubCategoryId)
                    .HasConstraintName("FK_Sale_SubCategory");

                entity.HasOne(d => d.Variation)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.VariationId)
                    .HasConstraintName("FK_Sale_ProductVariation");
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.ToTable("SubCategory", "Merchandise");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastUpdated).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SubCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubCategory_Category");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transaction", "Transaction");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CompletedDateTime).HasColumnType("datetime");

                entity.Property(e => e.OrderTime).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VerifiedByUserDateTime).HasColumnType("datetime");

                entity.Property(e => e.VerifiedByVendorDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserCartlist>(entity =>
            {
                entity.ToTable("UserCartlist", "Activity");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddedDateTime).HasColumnType("datetime");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductVariationId).HasColumnName("ProductVariationID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.UserCartlist)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCartlist_Product");

                entity.HasOne(d => d.ProductVariation)
                    .WithMany(p => p.UserCartlist)
                    .HasForeignKey(d => d.ProductVariationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCartlist_ProductVariation");
            });

            modelBuilder.Entity<UserWishlist>(entity =>
            {
                entity.ToTable("UserWishlist", "Activity");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddedDateTime).HasColumnType("datetime");

                entity.Property(e => e.ProductVariationId).HasColumnName("ProductVariationID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.ProductVariation)
                    .WithMany(p => p.UserWishlist)
                    .HasForeignKey(d => d.ProductVariationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserWishlist_ProductVariation");
            });
        }
    }
}

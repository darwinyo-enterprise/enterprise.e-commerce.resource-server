using System;
using System.Collections.Generic;

namespace Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB
{
    public partial class Product
    {
        public Product()
        {
            Inventory = new HashSet<Inventory>();
            ProductAbuse = new HashSet<ProductAbuse>();
            ProductComment = new HashSet<ProductComment>();
            ProductFavorite = new HashSet<ProductFavorite>();
            ProductGroup = new HashSet<ProductGroup>();
            ProductImage = new HashSet<ProductImage>();
            ProductRating = new HashSet<ProductRating>();
            ProductReview = new HashSet<ProductReview>();
            ProductSpec = new HashSet<ProductSpec>();
            ProductVariation = new HashSet<ProductVariation>();
            Sale = new HashSet<Sale>();
            UserCartlist = new HashSet<UserCartlist>();
        }

        public Guid Id { get; set; }
        public Guid SubCategoryId { get; set; }
        public Guid ManufacturerId { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal OverallRating { get; set; }
        public int TotalFavorites { get; set; }
        public int TotalReviews { get; set; }
        public int TotalComments { get; set; }
        public string Description { get; set; }
        
        public DateTime LastUpdated { get; set; }
        public Guid LastUpdatedBy { get; set; }

        public Guid AddedBy { get; set; }
        public DateTime AddedDateTime { get; set; }

        public Guid PriceChangedBy { get; set; }
        public DateTime LastPriceChanged { get; set; }

        public bool Disable { get; set; }
        public bool ReportedAbuse { get; set; }

        public Manufacturer Manufacturer { get; set; }
        public SubCategory SubCategory { get; set; }
        public ICollection<Inventory> Inventory { get; set; }
        public ICollection<ProductAbuse> ProductAbuse { get; set; }
        public ICollection<ProductComment> ProductComment { get; set; }
        public ICollection<ProductFavorite> ProductFavorite { get; set; }
        public ICollection<ProductGroup> ProductGroup { get; set; }
        public ICollection<ProductImage> ProductImage { get; set; }
        public ICollection<ProductRating> ProductRating { get; set; }
        public ICollection<ProductReview> ProductReview { get; set; }
        public ICollection<ProductSpec> ProductSpec { get; set; }
        public ICollection<ProductVariation> ProductVariation { get; set; }
        public ICollection<Sale> Sale { get; set; }
        public ICollection<UserCartlist> UserCartlist { get; set; }
    }
}

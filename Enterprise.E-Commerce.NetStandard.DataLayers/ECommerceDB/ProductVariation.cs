using System;
using System.Collections.Generic;

namespace Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB
{
    public partial class ProductVariation
    {
        public ProductVariation()
        {
            Inventory = new HashSet<Inventory>();
            ProductAbuse = new HashSet<ProductAbuse>();
            ProductFavorite = new HashSet<ProductFavorite>();
            ProductGroup = new HashSet<ProductGroup>();
            ProductOrder = new HashSet<ProductOrder>();
            ProductRating = new HashSet<ProductRating>();
            ProductReview = new HashSet<ProductReview>();
            ProductVariationImage = new HashSet<ProductVariationImage>();
            ProductVariationSpec = new HashSet<ProductVariationSpec>();
            Sale = new HashSet<Sale>();
            UserCartlist = new HashSet<UserCartlist>();
            UserWishlist = new HashSet<UserWishlist>();
        }

        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public int Reviews { get; set; }
        public int Favorites { get; set; }
        public decimal Rate { get; set; }
        public decimal Price { get; set; }
        public int TotalSold { get; set; }
        public int MinimalPurchaseAmount { get; set; }
        public string Quantifier { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public bool HasExpiry { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime RegisteredDateTime { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime LastPriceChanged { get; set; }
        public Guid RegisteredBy { get; set; }
        public Guid UpdatedBy { get; set; }
        public Guid PriceChangedBy { get; set; }
        public bool Disable { get; set; }

        /// <summary>
        /// If true then wont takes effect when base product changed.
        /// Otherwise will take changes as user change base product
        /// </summary>
        public bool Overriden { get; set; }

        public Product Product { get; set; }
        public ICollection<Inventory> Inventory { get; set; }
        public ICollection<ProductAbuse> ProductAbuse { get; set; }
        public ICollection<ProductFavorite> ProductFavorite { get; set; }
        public ICollection<ProductGroup> ProductGroup { get; set; }
        public ICollection<ProductOrder> ProductOrder { get; set; }
        public ICollection<ProductRating> ProductRating { get; set; }
        public ICollection<ProductReview> ProductReview { get; set; }
        public ICollection<ProductVariationImage> ProductVariationImage { get; set; }
        public ICollection<ProductVariationSpec> ProductVariationSpec { get; set; }
        public ICollection<Sale> Sale { get; set; }
        public ICollection<UserCartlist> UserCartlist { get; set; }
        public ICollection<UserWishlist> UserWishlist { get; set; }
    }
}

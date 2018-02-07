using Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB;
using Enterprise.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.E_Commerce.NetStandard.Interfaces.ECommerceDB
{
    public interface ICategoryRepository : IRepository<Category> { }
    public interface ICommentAbuseRepository : IRepository<CommentAbuse> { }
    public interface ICourierRepository : IRepository<Courier> { }
    public interface IGroupRepository : IRepository<Group> { }
    public interface IInventoryRepository : IRepository<Inventory> { }
    public interface IManufacturerRepository : IRepository<Manufacturer> { }
    public interface IPaymentsRepository : IRepository<Payments> { }
    public interface IPeriodeRepository : IRepository<Periode> { }
    public interface IProductRepository : IRepository<Product> { }
    public interface IProductAbuseRepository : IRepository<ProductAbuse> { }
    public interface IProductCommentRepository : IRepository<ProductComment> { }
    public interface IProductFavoriteRepository : IRepository<ProductFavorite> { }
    public interface IProductGroupRepository : IRepository<ProductGroup> { }
    public interface IProductImageRepository : IRepository<ProductImage> { }
    public interface IProductOrderRepository : IRepository<ProductOrder> { }
    public interface IProductRatingRepository : IRepository<ProductRating> { }
    public interface IProductReviewRepository : IRepository<ProductReview> { }
    public interface IProductSpecRepository : IRepository<ProductSpec> { }
    public interface IProductVariationRepository : IRepository<ProductVariation> { }
    public interface IProductVariationImageRepository : IRepository<ProductVariationImage> { }
    public interface IProductVariationSpecRepository : IRepository<ProductVariationSpec> { }
    public interface ISaleRepository : IRepository<Sale> { }
    public interface ISubCategoryRepository : IRepository<SubCategory> { }
    public interface ITransactionRepository : IRepository<Transaction> { }
    public interface IUserCartlistRepository : IRepository<UserCartlist> { }
    public interface IUserWishlistRepository : IRepository<UserWishlist> { }
}

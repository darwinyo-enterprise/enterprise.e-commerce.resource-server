using Enterprise.Abstract.NetStandard;
using Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB;
using Enterprise.E_Commerce.NetStandard.Interfaces.ECommerceDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.E_Commerce.NetStandard.Repository.ECommerceDB
{
    public class CategoryRepository : BaseRepository<Category, ECommerceDBContext>, ICategoryRepository
    {
        public CategoryRepository(ECommerceDBContext context) : base(context)
        {
        }
    }
    public class CommentAbuseRepository : BaseRepository<CommentAbuse, ECommerceDBContext>, ICommentAbuseRepository
    {
        public CommentAbuseRepository(ECommerceDBContext context) : base(context)
        {
        }
    }
    public class CourierRepository : BaseRepository<Courier, ECommerceDBContext>, ICourierRepository
    {
        public CourierRepository(ECommerceDBContext context) : base(context)
        {
        }
    }
    public class GroupRepository : BaseRepository<Group, ECommerceDBContext>, IGroupRepository
    {
        public GroupRepository(ECommerceDBContext context) : base(context)
        {
        }
    }
    public class InventoryRepository : BaseRepository<Inventory, ECommerceDBContext>, IInventoryRepository
    {
        public InventoryRepository(ECommerceDBContext context) : base(context)
        {
        }
    }
    public class ManufacturerRepository : BaseRepository<Manufacturer, ECommerceDBContext>, IManufacturerRepository
    {
        public ManufacturerRepository(ECommerceDBContext context) : base(context)
        {
        }
    }
    public class PaymentsRepository : BaseRepository<Payments, ECommerceDBContext>, IPaymentsRepository
    {
        public PaymentsRepository(ECommerceDBContext context) : base(context)
        {
        }
    }
    public class PeriodeRepository : BaseRepository<Periode, ECommerceDBContext>, IPeriodeRepository
    {
        public PeriodeRepository(ECommerceDBContext context) : base(context)
        {
        }
    }
    public class ProductRepository : BaseRepository<Product, ECommerceDBContext>, IProductRepository
    {
        public ProductRepository(ECommerceDBContext context) : base(context)
        {
        }
    }
    public class ProductAbuseRepository : BaseRepository<ProductAbuse, ECommerceDBContext>, IProductAbuseRepository
    {
        public ProductAbuseRepository(ECommerceDBContext context) : base(context)
        {
        }
    }
    public class ProductCommentRepository : BaseRepository<ProductComment, ECommerceDBContext>, IProductCommentRepository
    {
        public ProductCommentRepository(ECommerceDBContext context) : base(context)
        {
        }
    }
    public class ProductFavoriteRepository : BaseRepository<ProductFavorite, ECommerceDBContext>, IProductFavoriteRepository
    {
        public ProductFavoriteRepository(ECommerceDBContext context) : base(context)
        {
        }
    }
    public class ProductGroupRepository : BaseRepository<ProductGroup, ECommerceDBContext>, IProductGroupRepository
    {
        public ProductGroupRepository(ECommerceDBContext context) : base(context)
        {
        }
    }
    public class ProductImageRepository : BaseRepository<ProductImage, ECommerceDBContext>, IProductImageRepository
    {
        public ProductImageRepository(ECommerceDBContext context) : base(context)
        {
        }
    }
    public class ProductOrderRepository : BaseRepository<ProductOrder, ECommerceDBContext>, IProductOrderRepository
    {
        public ProductOrderRepository(ECommerceDBContext context) : base(context)
        {
        }
    }
    public class ProductRatingRepository : BaseRepository<ProductRating, ECommerceDBContext>, IProductRatingRepository
    {
        public ProductRatingRepository(ECommerceDBContext context) : base(context)
        {
        }
    }
    public class ProductReviewRepository : BaseRepository<ProductReview, ECommerceDBContext>, IProductReviewRepository
    {
        public ProductReviewRepository(ECommerceDBContext context) : base(context)
        {
        }
    }
    public class ProductSpecRepository : BaseRepository<ProductSpec, ECommerceDBContext>, IProductSpecRepository
    {
        public ProductSpecRepository(ECommerceDBContext context) : base(context)
        {
        }
    }
    public class ProductVariationRepository : BaseRepository<ProductVariation, ECommerceDBContext>, IProductVariationRepository
    {
        public ProductVariationRepository(ECommerceDBContext context) : base(context)
        {
        }
    }
    public class ProductVariationImageRepository : BaseRepository<ProductVariationImage, ECommerceDBContext>, IProductVariationImageRepository
    {
        public ProductVariationImageRepository(ECommerceDBContext context) : base(context)
        {
        }
    }
    public class ProductVariationSpecRepository : BaseRepository<ProductVariationSpec, ECommerceDBContext>, IProductVariationSpecRepository
    {
        public ProductVariationSpecRepository(ECommerceDBContext context) : base(context)
        {
        }
    }
    public class SaleRepository : BaseRepository<Sale, ECommerceDBContext>, ISaleRepository
    {
        public SaleRepository(ECommerceDBContext context) : base(context)
        {
        }
    }
    public class SubCategoryRepository : BaseRepository<SubCategory, ECommerceDBContext>, ISubCategoryRepository
    {
        public SubCategoryRepository(ECommerceDBContext context) : base(context)
        {
        }
    }
    public class TransactionRepository : BaseRepository<Transaction, ECommerceDBContext>, ITransactionRepository
    {
        public TransactionRepository(ECommerceDBContext context) : base(context)
        {
        }
    }
    public class UserCartlistRepository : BaseRepository<UserCartlist, ECommerceDBContext>, IUserCartlistRepository
    {
        public UserCartlistRepository(ECommerceDBContext context) : base(context)
        {
        }
    }
    public class UserWishlistRepository : BaseRepository<UserWishlist, ECommerceDBContext>, IUserWishlistRepository
    {
        public UserWishlistRepository(ECommerceDBContext context) : base(context)
        {
        }
    }
}

using Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB;
using Enterprise.Interfaces.NetStandard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.E_Commerce.NetStandard.Interfaces.ECommerceDB
{
    public interface IECommerceDBUnitOfWork:IUnitOfWork
    {
        ECommerceDBContext ECommerceContext { get; }
        ICategoryRepository CategoryRepository { get; }
        ICommentAbuseRepository CommentAbuseRepository { get; }
        ICourierRepository CourierRepository { get; }
        IGroupRepository GroupRepository { get; }
        IInventoryRepository InventoryRepository { get; }
        IManufacturerRepository ManufacturerRepository { get; }
        IPaymentsRepository PaymentsRepository { get; }
        IPeriodeRepository PeriodeRepository { get; }
        IProductRepository ProductRepository { get; }
        IProductAbuseRepository ProductAbuseRepository { get; }
        IProductCommentRepository ProductCommentRepository { get; }
        IProductFavoriteRepository ProductFavoriteRepository { get; }
        IProductGroupRepository ProductGroupRepository { get; }
        IProductImageRepository ProductImageRepository { get; }
        IProductOrderRepository ProductOrderRepository { get; }
        IProductRatingRepository ProductRatingRepository { get; }
        IProductReviewRepository ProductReviewRepository { get; }
        IProductSpecRepository ProductSpecRepository { get; }
        IProductVariationRepository ProductVariationRepository { get; }
        IProductVariationImageRepository ProductVariationImageRepository { get; }
        IProductVariationSpecRepository ProductVariationSpecRepository { get; }
        ISaleRepository SaleRepository { get; }
        ISubCategoryRepository SubCategoryRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        IUserCartlistRepository UserCartlistRepository { get; }
        IUserWishlistRepository UserWishlistRepository { get; }
    }
}

using Enterprise.Abstract.NetStandard;
using Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB;
using Enterprise.E_Commerce.NetStandard.Interfaces.ECommerceDB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.E_Commerce.NetStandard.UnitOfWork
{
    public class ECommerceDBUnitOfWork : BaseDispose, IECommerceDBUnitOfWork
    {
        private readonly ECommerceDBContext _eCommerceContext;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICommentAbuseRepository _commentAbuseRepository;
        private readonly ICourierRepository _courierRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IPaymentsRepository _paymentsRepository;
        private readonly IPeriodeRepository _periodeRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductAbuseRepository _productAbuseRepository;
        private readonly IProductCommentRepository _productCommentRepository;
        private readonly IProductFavoriteRepository _productFavoriteRepository;
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IProductImageRepository _productImageRepository;
        private readonly IProductOrderRepository _productOrderRepository;
        private readonly IProductRatingRepository _productRatingRepository;
        private readonly IProductReviewRepository _productReviewRepository;
        private readonly IProductSpecRepository _productSpecRepository;
        private readonly IProductVariationRepository _productVariationRepository;
        private readonly IProductVariationImageRepository _productVariationImageRepository;
        private readonly IProductVariationSpecRepository _productVariationSpecRepository;
        private readonly ISaleRepository _saleRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUserCartlistRepository _userCartlistRepository;
        private readonly IUserWishlistRepository _userWishlistRepository;

        public ECommerceDBUnitOfWork(ECommerceDBContext eCommerceContext,
        ICategoryRepository categoryRepository,
        ICommentAbuseRepository commentAbuseRepository,
        ICourierRepository courierRepository,
        IGroupRepository groupRepository,
        IInventoryRepository inventoryRepository,
        IManufacturerRepository manufacturerRepository,
        IPaymentsRepository paymentsRepository,
        IPeriodeRepository periodeRepository,
        IProductRepository productRepository,
        IProductAbuseRepository productAbuseRepository,
        IProductCommentRepository productCommentRepository,
        IProductFavoriteRepository productFavoriteRepository,
        IProductGroupRepository productGroupRepository,
        IProductImageRepository productImageRepository,
        IProductOrderRepository productOrderRepository,
        IProductRatingRepository productRatingRepository,
        IProductReviewRepository productReviewRepository,
        IProductSpecRepository productSpecRepository,
        IProductVariationRepository productVariationRepository,
        IProductVariationImageRepository productVariationImageRepository,
        IProductVariationSpecRepository productVariationSpecRepository,
        ISaleRepository saleRepository,
        ISubCategoryRepository subCategoryRepository,
        ITransactionRepository transactionRepository,
        IUserCartlistRepository userCartlistRepository,
        IUserWishlistRepository userWishlistRepository)
        {
            _eCommerceContext = eCommerceContext;
            _categoryRepository = categoryRepository;
            _commentAbuseRepository = commentAbuseRepository;
            _courierRepository = courierRepository;
            _groupRepository = groupRepository;
            _inventoryRepository = inventoryRepository;
            _manufacturerRepository = manufacturerRepository;
            _paymentsRepository = paymentsRepository;
            _periodeRepository = periodeRepository;
            _productRepository = productRepository;
            _productAbuseRepository = productAbuseRepository;
            _productCommentRepository = productCommentRepository;
            _productFavoriteRepository = productFavoriteRepository;
            _productGroupRepository = productGroupRepository;
            _productImageRepository = productImageRepository;
            _productOrderRepository = productOrderRepository;
            _productRatingRepository = productRatingRepository;
            _productReviewRepository = productReviewRepository;
            _productSpecRepository = productSpecRepository;
            _productVariationRepository = productVariationRepository;
            _productVariationImageRepository = productVariationImageRepository;
            _productVariationSpecRepository = productVariationSpecRepository;
            _saleRepository = saleRepository;
            _subCategoryRepository = subCategoryRepository;
            _transactionRepository = transactionRepository;
            _userCartlistRepository = userCartlistRepository;
            _userWishlistRepository = userWishlistRepository;
        }

        public ECommerceDBContext ECommerceContext { get => _eCommerceContext; }
        public ICategoryRepository CategoryRepository { get => _categoryRepository; }
        public ICommentAbuseRepository CommentAbuseRepository { get => _commentAbuseRepository; }
        public ICourierRepository CourierRepository { get => _courierRepository; }
        public IGroupRepository GroupRepository { get => _groupRepository; }
        public IInventoryRepository InventoryRepository { get => _inventoryRepository; }
        public IManufacturerRepository ManufacturerRepository { get => _manufacturerRepository; }
        public IPaymentsRepository PaymentsRepository { get => _paymentsRepository; }
        public IPeriodeRepository PeriodeRepository { get => _periodeRepository; }
        public IProductRepository ProductRepository { get => _productRepository; }
        public IProductAbuseRepository ProductAbuseRepository { get => _productAbuseRepository; }
        public IProductCommentRepository ProductCommentRepository { get => _productCommentRepository; }
        public IProductFavoriteRepository ProductFavoriteRepository { get => _productFavoriteRepository; }
        public IProductGroupRepository ProductGroupRepository { get => _productGroupRepository; }
        public IProductImageRepository ProductImageRepository { get => _productImageRepository; }
        public IProductOrderRepository ProductOrderRepository { get => _productOrderRepository; }
        public IProductRatingRepository ProductRatingRepository { get => _productRatingRepository; }
        public IProductReviewRepository ProductReviewRepository { get => _productReviewRepository; }
        public IProductSpecRepository ProductSpecRepository { get => _productSpecRepository; }
        public IProductVariationRepository ProductVariationRepository { get => _productVariationRepository; }
        public IProductVariationImageRepository ProductVariationImageRepository { get => _productVariationImageRepository; }
        public IProductVariationSpecRepository ProductVariationSpecRepository { get => _productVariationSpecRepository; }
        public ISaleRepository SaleRepository { get => _saleRepository; }
        public ISubCategoryRepository SubCategoryRepository { get => _subCategoryRepository; }
        public ITransactionRepository TransactionRepository { get => _transactionRepository; }
        public IUserCartlistRepository UserCartlistRepository { get => _userCartlistRepository; }
        public IUserWishlistRepository UserWishlistRepository { get => _userWishlistRepository; }

        public override void Dispose()
        {
            this.Dispose(_eCommerceContext);
        }

        public async Task SaveAsync()
        {
            await _eCommerceContext.SaveChangesAsync();
        }
    }
}

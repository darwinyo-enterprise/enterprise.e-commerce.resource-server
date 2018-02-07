using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Enterprise.ECommerce.ResourceServer.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Merchandise");

            migrationBuilder.EnsureSchema(
                name: "Abuse");

            migrationBuilder.EnsureSchema(
                name: "Courier");

            migrationBuilder.EnsureSchema(
                name: "Transaction");

            migrationBuilder.EnsureSchema(
                name: "Event");

            migrationBuilder.EnsureSchema(
                name: "Activity");

            migrationBuilder.CreateTable(
                name: "Courier",
                schema: "Courier",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Completed = table.Column<bool>(nullable: false),
                    CourierName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    DeliveredDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DropOffAddress = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    OrderTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    PickUpAddress = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    ReceivedBy = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    VendorName = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courier", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Periode",
                schema: "Event",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Alias = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    UpdatedBy = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periode", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Merchandise",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Images = table.Column<string>(nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                schema: "Merchandise",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(unicode: false, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                schema: "Merchandise",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    AddedBy = table.Column<Guid>(nullable: false),
                    AddedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                schema: "Transaction",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Completed = table.Column<bool>(nullable: false),
                    CompletedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    VerifiedByUser = table.Column<Guid>(nullable: true),
                    VerifiedByUserDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    VerifiedByVendor = table.Column<Guid>(nullable: true),
                    VerifiedByVendorDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SubCategory",
                schema: "Merchandise",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CategoryID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SubCategory_Category",
                        column: x => x.CategoryID,
                        principalSchema: "Merchandise",
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                schema: "Transaction",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18, 5)", nullable: false),
                    Cancelled = table.Column<bool>(nullable: false),
                    CancelledBy = table.Column<Guid>(nullable: true),
                    CancelledReason = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    CancelledTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Currency = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Installment = table.Column<bool>(nullable: false),
                    InstallmentLength = table.Column<int>(nullable: true),
                    InstallmentProgress = table.Column<int>(nullable: true),
                    InterestRate = table.Column<decimal>(nullable: true),
                    PaidOff = table.Column<bool>(nullable: false),
                    PaidOffDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    PaymentMethodID = table.Column<Guid>(nullable: false),
                    PaymentVerified = table.Column<bool>(nullable: false),
                    TransactionID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    VerifiedBy = table.Column<Guid>(nullable: false),
                    VerifiedDateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Payments_Transaction",
                        column: x => x.TransactionID,
                        principalSchema: "Transaction",
                        principalTable: "Transaction",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Merchandise",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(unicode: false, nullable: true),
                    DIsable = table.Column<bool>(nullable: false),
                    LastPriceChanged = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedBy = table.Column<Guid>(nullable: false),
                    ManufacturerID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    OverallRating = table.Column<decimal>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
                    PriceChangedBy = table.Column<Guid>(nullable: false),
                    RegisteredBy = table.Column<Guid>(nullable: false),
                    RegisteredDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ReportedAbuse = table.Column<bool>(nullable: false),
                    SubCategoryID = table.Column<Guid>(nullable: false),
                    TotalComments = table.Column<int>(nullable: false),
                    TotalFavorites = table.Column<int>(nullable: false),
                    TotalReviews = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Product_Manufacturer",
                        column: x => x.ManufacturerID,
                        principalSchema: "Merchandise",
                        principalTable: "Manufacturer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_SubCategory",
                        column: x => x.SubCategoryID,
                        principalSchema: "Merchandise",
                        principalTable: "SubCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductComment",
                schema: "Activity",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Abuse = table.Column<bool>(nullable: false),
                    CommentDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Comments = table.Column<string>(unicode: false, nullable: false),
                    ProductID = table.Column<Guid>(nullable: false),
                    ReportedBy = table.Column<Guid>(nullable: true),
                    ReportedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductComment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductComment_Product",
                        column: x => x.ProductID,
                        principalSchema: "Merchandise",
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductImage",
                schema: "Merchandise",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    AddedBy = table.Column<Guid>(nullable: false),
                    AddedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Image = table.Column<string>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductImage_Product",
                        column: x => x.ProductID,
                        principalSchema: "Merchandise",
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductSpec",
                schema: "Merchandise",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    AddedBy = table.Column<Guid>(nullable: false),
                    AddedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProductID = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Value = table.Column<string>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSpec", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductSpec_Product",
                        column: x => x.ProductID,
                        principalSchema: "Merchandise",
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariation",
                schema: "Merchandise",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Condition = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(unicode: false, nullable: true),
                    Disable = table.Column<bool>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "date", nullable: true),
                    Favorites = table.Column<int>(nullable: false),
                    HasExpiry = table.Column<bool>(nullable: false),
                    LastPriceChanged = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: false),
                    MinimalPurchaseAmount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
                    PriceChangedBy = table.Column<Guid>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: false),
                    Quantifier = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Rate = table.Column<decimal>(nullable: false),
                    RegisteredBy = table.Column<Guid>(nullable: false),
                    RegisteredDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Reviews = table.Column<int>(nullable: false),
                    TotalSold = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductVariation_Product",
                        column: x => x.ProductID,
                        principalSchema: "Merchandise",
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommentAbuse",
                schema: "Abuse",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Actor = table.Column<Guid>(nullable: false),
                    Approved = table.Column<bool>(nullable: false),
                    ApprovedBy = table.Column<Guid>(nullable: true),
                    ApprovedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ApprovedMessage = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    CommentID = table.Column<Guid>(nullable: false),
                    PenaltyCompleted = table.Column<bool>(nullable: true),
                    PenaltyCompletedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    PenaltyGiven = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    PenaltyGivenDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ReportReason = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    ReportedBy = table.Column<Guid>(nullable: false),
                    ReportedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Solved = table.Column<bool>(nullable: false),
                    SolvedBy = table.Column<Guid>(nullable: true),
                    SolvedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    SolvedMessage = table.Column<string>(unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentAbuse", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CommentAbuse_ProductComment",
                        column: x => x.CommentID,
                        principalSchema: "Activity",
                        principalTable: "ProductComment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductAbuse",
                schema: "Abuse",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Approved = table.Column<bool>(nullable: false),
                    ApprovedBy = table.Column<Guid>(nullable: true),
                    ApprovedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ApprovedMessage = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    PenaltyCompleted = table.Column<bool>(nullable: true),
                    PenaltyCompletedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    PenaltyGiven = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    PenaltyGivenDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ProductID = table.Column<Guid>(nullable: false),
                    ProductVariationID = table.Column<Guid>(nullable: false),
                    ReportReason = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    ReportedBy = table.Column<Guid>(nullable: false),
                    ReportedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Solved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAbuse", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductAbuse_Product",
                        column: x => x.ProductID,
                        principalSchema: "Merchandise",
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductAbuse_ProductVariation",
                        column: x => x.ProductVariationID,
                        principalSchema: "Merchandise",
                        principalTable: "ProductVariation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductFavorite",
                schema: "Activity",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    FavoritedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProductID = table.Column<Guid>(nullable: false),
                    ProductVariationID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFavorite", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductFavorite_Product",
                        column: x => x.ProductID,
                        principalSchema: "Merchandise",
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductFavorite_ProductVariation",
                        column: x => x.ProductVariationID,
                        principalSchema: "Merchandise",
                        principalTable: "ProductVariation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductRating",
                schema: "Activity",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: false),
                    ProductVariationID = table.Column<Guid>(nullable: false),
                    Rate = table.Column<decimal>(nullable: false),
                    RatingDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    TransactionID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRating", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductRating_Product",
                        column: x => x.ProductID,
                        principalSchema: "Merchandise",
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductRating_ProductVariation",
                        column: x => x.ProductVariationID,
                        principalSchema: "Merchandise",
                        principalTable: "ProductVariation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductReview",
                schema: "Activity",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    LastReviewed = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProductID = table.Column<Guid>(nullable: false),
                    ProductVariationID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReview", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductReview_Product",
                        column: x => x.ProductID,
                        principalSchema: "Merchandise",
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductReview_ProductVariation",
                        column: x => x.ProductVariationID,
                        principalSchema: "Merchandise",
                        principalTable: "ProductVariation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserCartlist",
                schema: "Activity",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    AddedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProductID = table.Column<Guid>(nullable: false),
                    ProductVariationID = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    Valid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCartlist", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserCartlist_Product",
                        column: x => x.ProductID,
                        principalSchema: "Merchandise",
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCartlist_ProductVariation",
                        column: x => x.ProductVariationID,
                        principalSchema: "Merchandise",
                        principalTable: "ProductVariation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserWishlist",
                schema: "Activity",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    AddedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProductVariationID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    Valid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWishlist", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserWishlist_ProductVariation",
                        column: x => x.ProductVariationID,
                        principalSchema: "Merchandise",
                        principalTable: "ProductVariation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                schema: "Event",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    AllProduct = table.Column<bool>(nullable: false),
                    CategoryID = table.Column<Guid>(nullable: true),
                    Completed = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(unicode: false, nullable: true),
                    GroupID = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    PeriodeID = table.Column<Guid>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: true),
                    SubCategoryID = table.Column<Guid>(nullable: true),
                    VariationID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sale_Category",
                        column: x => x.CategoryID,
                        principalSchema: "Merchandise",
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sale_Group",
                        column: x => x.GroupID,
                        principalSchema: "Merchandise",
                        principalTable: "Group",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sale_Periode",
                        column: x => x.PeriodeID,
                        principalSchema: "Event",
                        principalTable: "Periode",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sale_Product",
                        column: x => x.ProductID,
                        principalSchema: "Merchandise",
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sale_SubCategory",
                        column: x => x.SubCategoryID,
                        principalSchema: "Merchandise",
                        principalTable: "SubCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sale_ProductVariation",
                        column: x => x.VariationID,
                        principalSchema: "Merchandise",
                        principalTable: "ProductVariation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BaseProductSpec",
                schema: "Merchandise",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    AddedBy = table.Column<Guid>(nullable: false),
                    AddedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProductID = table.Column<Guid>(nullable: true),
                    ProductVariationID = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseProductSpec", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BaseProductSpec_Product",
                        column: x => x.ProductID,
                        principalSchema: "Merchandise",
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseProductSpec_ProductVariation",
                        column: x => x.ProductVariationID,
                        principalSchema: "Merchandise",
                        principalTable: "ProductVariation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                schema: "Merchandise",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Location = table.Column<int>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: false),
                    StockAmount = table.Column<int>(nullable: false),
                    VariationID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Inventory_Product",
                        column: x => x.ProductID,
                        principalSchema: "Merchandise",
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventory_ProductVariation",
                        column: x => x.VariationID,
                        principalSchema: "Merchandise",
                        principalTable: "ProductVariation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductGroup",
                schema: "Merchandise",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    AddedBy = table.Column<Guid>(nullable: false),
                    AddedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    GroupID = table.Column<Guid>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: true),
                    ProductVariationID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroup", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductGroup_Group",
                        column: x => x.GroupID,
                        principalSchema: "Merchandise",
                        principalTable: "Group",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductGroup_Product",
                        column: x => x.ProductID,
                        principalSchema: "Merchandise",
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductGroup_ProductVariation",
                        column: x => x.ProductVariationID,
                        principalSchema: "Merchandise",
                        principalTable: "ProductVariation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariationImage",
                schema: "Merchandise",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    AddedBy = table.Column<Guid>(nullable: false),
                    AddedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Image = table.Column<string>(nullable: false),
                    ProductVariationID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariationImage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductVariationImage_ProductVariation",
                        column: x => x.ProductVariationID,
                        principalSchema: "Merchandise",
                        principalTable: "ProductVariation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariationSpec",
                schema: "Merchandise",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    AddedBy = table.Column<Guid>(nullable: false),
                    AddedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProductVariationID = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Value = table.Column<string>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariationSpec", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductVariationSpec_ProductVariation",
                        column: x => x.ProductVariationID,
                        principalSchema: "Merchandise",
                        principalTable: "ProductVariation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductOrder",
                schema: "Transaction",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Completed = table.Column<bool>(nullable: false),
                    CourierID = table.Column<Guid>(nullable: false),
                    Message = table.Column<string>(unicode: false, nullable: true),
                    OrderTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    OrderTimePrice = table.Column<decimal>(nullable: false),
                    ProductVariationID = table.Column<Guid>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: true),
                    TransactionID = table.Column<Guid>(nullable: false),
                    UserAddressID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    Valid = table.Column<bool>(nullable: false),
                    VendorVerified = table.Column<bool>(nullable: false),
                    VendorVerifiedDateTime = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrder", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductOrder_Courier",
                        column: x => x.CourierID,
                        principalSchema: "Courier",
                        principalTable: "Courier",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductOrder_ProductVariation",
                        column: x => x.ProductVariationID,
                        principalSchema: "Merchandise",
                        principalTable: "ProductVariation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductOrder_Transaction",
                        column: x => x.TransactionID,
                        principalSchema: "Transaction",
                        principalTable: "Transaction",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentAbuse_CommentID",
                schema: "Abuse",
                table: "CommentAbuse",
                column: "CommentID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAbuse_ProductID",
                schema: "Abuse",
                table: "ProductAbuse",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAbuse_ProductVariationID",
                schema: "Abuse",
                table: "ProductAbuse",
                column: "ProductVariationID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComment_ProductID",
                schema: "Activity",
                table: "ProductComment",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFavorite_ProductID",
                schema: "Activity",
                table: "ProductFavorite",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFavorite_ProductVariationID",
                schema: "Activity",
                table: "ProductFavorite",
                column: "ProductVariationID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRating_ProductID",
                schema: "Activity",
                table: "ProductRating",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRating_ProductVariationID",
                schema: "Activity",
                table: "ProductRating",
                column: "ProductVariationID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReview_ProductID",
                schema: "Activity",
                table: "ProductReview",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReview_ProductVariationID",
                schema: "Activity",
                table: "ProductReview",
                column: "ProductVariationID");

            migrationBuilder.CreateIndex(
                name: "IX_UserCartlist_ProductID",
                schema: "Activity",
                table: "UserCartlist",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_UserCartlist_ProductVariationID",
                schema: "Activity",
                table: "UserCartlist",
                column: "ProductVariationID");

            migrationBuilder.CreateIndex(
                name: "IX_UserWishlist_ProductVariationID",
                schema: "Activity",
                table: "UserWishlist",
                column: "ProductVariationID");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_CategoryID",
                schema: "Event",
                table: "Sale",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_GroupID",
                schema: "Event",
                table: "Sale",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_PeriodeID",
                schema: "Event",
                table: "Sale",
                column: "PeriodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_ProductID",
                schema: "Event",
                table: "Sale",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_SubCategoryID",
                schema: "Event",
                table: "Sale",
                column: "SubCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_VariationID",
                schema: "Event",
                table: "Sale",
                column: "VariationID");

            migrationBuilder.CreateIndex(
                name: "IX_BaseProductSpec_ProductID",
                schema: "Merchandise",
                table: "BaseProductSpec",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_BaseProductSpec_ProductVariationID",
                schema: "Merchandise",
                table: "BaseProductSpec",
                column: "ProductVariationID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ProductID",
                schema: "Merchandise",
                table: "Inventory",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_VariationID",
                schema: "Merchandise",
                table: "Inventory",
                column: "VariationID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ManufacturerID",
                schema: "Merchandise",
                table: "Product",
                column: "ManufacturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SubCategoryID",
                schema: "Merchandise",
                table: "Product",
                column: "SubCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroup_GroupID",
                schema: "Merchandise",
                table: "ProductGroup",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroup_ProductID",
                schema: "Merchandise",
                table: "ProductGroup",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroup_ProductVariationID",
                schema: "Merchandise",
                table: "ProductGroup",
                column: "ProductVariationID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductID",
                schema: "Merchandise",
                table: "ProductImage",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSpec_ProductID",
                schema: "Merchandise",
                table: "ProductSpec",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariation_ProductID",
                schema: "Merchandise",
                table: "ProductVariation",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariationImage_ProductVariationID",
                schema: "Merchandise",
                table: "ProductVariationImage",
                column: "ProductVariationID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariationSpec_ProductVariationID",
                schema: "Merchandise",
                table: "ProductVariationSpec",
                column: "ProductVariationID");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryID",
                schema: "Merchandise",
                table: "SubCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_TransactionID",
                schema: "Transaction",
                table: "Payments",
                column: "TransactionID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrder_CourierID",
                schema: "Transaction",
                table: "ProductOrder",
                column: "CourierID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrder_ProductVariationID",
                schema: "Transaction",
                table: "ProductOrder",
                column: "ProductVariationID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrder_TransactionID",
                schema: "Transaction",
                table: "ProductOrder",
                column: "TransactionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentAbuse",
                schema: "Abuse");

            migrationBuilder.DropTable(
                name: "ProductAbuse",
                schema: "Abuse");

            migrationBuilder.DropTable(
                name: "ProductFavorite",
                schema: "Activity");

            migrationBuilder.DropTable(
                name: "ProductRating",
                schema: "Activity");

            migrationBuilder.DropTable(
                name: "ProductReview",
                schema: "Activity");

            migrationBuilder.DropTable(
                name: "UserCartlist",
                schema: "Activity");

            migrationBuilder.DropTable(
                name: "UserWishlist",
                schema: "Activity");

            migrationBuilder.DropTable(
                name: "Sale",
                schema: "Event");

            migrationBuilder.DropTable(
                name: "BaseProductSpec",
                schema: "Merchandise");

            migrationBuilder.DropTable(
                name: "Inventory",
                schema: "Merchandise");

            migrationBuilder.DropTable(
                name: "ProductGroup",
                schema: "Merchandise");

            migrationBuilder.DropTable(
                name: "ProductImage",
                schema: "Merchandise");

            migrationBuilder.DropTable(
                name: "ProductSpec",
                schema: "Merchandise");

            migrationBuilder.DropTable(
                name: "ProductVariationImage",
                schema: "Merchandise");

            migrationBuilder.DropTable(
                name: "ProductVariationSpec",
                schema: "Merchandise");

            migrationBuilder.DropTable(
                name: "Payments",
                schema: "Transaction");

            migrationBuilder.DropTable(
                name: "ProductOrder",
                schema: "Transaction");

            migrationBuilder.DropTable(
                name: "ProductComment",
                schema: "Activity");

            migrationBuilder.DropTable(
                name: "Periode",
                schema: "Event");

            migrationBuilder.DropTable(
                name: "Group",
                schema: "Merchandise");

            migrationBuilder.DropTable(
                name: "Courier",
                schema: "Courier");

            migrationBuilder.DropTable(
                name: "ProductVariation",
                schema: "Merchandise");

            migrationBuilder.DropTable(
                name: "Transaction",
                schema: "Transaction");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Merchandise");

            migrationBuilder.DropTable(
                name: "Manufacturer",
                schema: "Merchandise");

            migrationBuilder.DropTable(
                name: "SubCategory",
                schema: "Merchandise");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "Merchandise");
        }
    }
}

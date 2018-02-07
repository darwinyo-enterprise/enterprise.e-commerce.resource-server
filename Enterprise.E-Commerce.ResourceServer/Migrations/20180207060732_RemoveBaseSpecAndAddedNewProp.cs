using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Enterprise.ECommerce.ResourceServer.Migrations
{
    public partial class RemoveBaseSpecAndAddedNewProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseProductSpec",
                schema: "Merchandise");

            migrationBuilder.RenameColumn(
                name: "RegisteredDateTime",
                schema: "Merchandise",
                table: "Product",
                newName: "AddedDateTime");

            migrationBuilder.RenameColumn(
                name: "RegisteredBy",
                schema: "Merchandise",
                table: "Product",
                newName: "AddedBy");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                schema: "Merchandise",
                table: "ProductVariationSpec",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Overriden",
                schema: "Merchandise",
                table: "ProductVariationSpec",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                schema: "Merchandise",
                table: "ProductVariationSpec",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Overriden",
                schema: "Merchandise",
                table: "ProductVariation",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                schema: "Merchandise",
                table: "ProductSpec",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                schema: "Merchandise",
                table: "ProductSpec",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdated",
                schema: "Merchandise",
                table: "ProductVariationSpec");

            migrationBuilder.DropColumn(
                name: "Overriden",
                schema: "Merchandise",
                table: "ProductVariationSpec");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "Merchandise",
                table: "ProductVariationSpec");

            migrationBuilder.DropColumn(
                name: "Overriden",
                schema: "Merchandise",
                table: "ProductVariation");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                schema: "Merchandise",
                table: "ProductSpec");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "Merchandise",
                table: "ProductSpec");

            migrationBuilder.RenameColumn(
                name: "AddedDateTime",
                schema: "Merchandise",
                table: "Product",
                newName: "RegisteredDateTime");

            migrationBuilder.RenameColumn(
                name: "AddedBy",
                schema: "Merchandise",
                table: "Product",
                newName: "RegisteredBy");

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
        }
    }
}

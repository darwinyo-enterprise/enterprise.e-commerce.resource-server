using System;
using System.Collections.Generic;

namespace Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB
{
    public partial class Sale
    {
        public Guid Id { get; set; }
        public Guid PeriodeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool AllProduct { get; set; }
        public Guid? GroupId { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? SubCategoryId { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? VariationId { get; set; }
        public bool Completed { get; set; }

        public Category Category { get; set; }
        public Group Group { get; set; }
        public Periode Periode { get; set; }
        public Product Product { get; set; }
        public SubCategory SubCategory { get; set; }
        public ProductVariation Variation { get; set; }
    }
}

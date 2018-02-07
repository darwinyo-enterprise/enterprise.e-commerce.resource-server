using Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.E_Commerce.NetStandard.MockData
{
    public class CategoryMockData
    {
        public Category CategoryNonSubCategory()
        {
            return new Category
            {
                Enabled = true,
                Images = null,
                Name = "Electronic",
                SubCategory = null
            };
        }
        public Category CategoryWithSubCategory()
        {
            var categories = (ICollection<SubCategory>)(new SubCategoryMockData().GetListOfSubCategory());
            return new Category
            {
                Enabled = true,
                Images = null,
                Name = "Electronic",
                SubCategory = null
            };
        }
    }
}

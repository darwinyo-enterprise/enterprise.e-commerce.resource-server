using Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.E_Commerce.NetStandard.MockData
{
    public class SubCategoryMockData
    {
        public IEnumerable<SubCategory> GetListOfSubCategory()
        {
            return new List<SubCategory>
            {
                new SubCategory
                {
                    Enabled=true,
                    Image=null,
                    Name="Laptop"
                },
                new SubCategory
                {
                    Enabled=true,
                    Image=null,
                    Name="Mobile Phone"
                },
                new SubCategory
                {
                    Enabled=true,
                    Image=null,
                    Name="Desktop"
                },
                new SubCategory
                {
                    Enabled=true,
                    Image=null,
                    Name="Headset"
                },
                new SubCategory
                {
                    Enabled=true,
                    Image=null,
                    Name="TV"
                }
            };
        }
    }
}

using Enterprise.Fixtures.NetStandard;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Enterprise.E_Commerce.ResourceServer.Tests
{
    [CollectionDefinition("E-Commerce Resource Server Test Collection")]
    public class ECommerceControllerTest : ICollectionFixture<AuthorizationServiceFixture>, ICollectionFixture<ECommerceServiceFixture>
    {
    }
}

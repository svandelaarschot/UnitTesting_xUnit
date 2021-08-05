using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Cars.Tests
{
    [CollectionDefinition("CarFixture collection")]
    public class CarFixtureCollection : ICollectionFixture<CarFixture> { }
}

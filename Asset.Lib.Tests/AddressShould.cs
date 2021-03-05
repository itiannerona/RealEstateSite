using AssetsManagement.Inventory.Models;
using System;
using Xunit;

namespace AssetsManagement.Inventory.Tests
{
    public class AddressShould
    {
        [Theory]
        [InlineData("", "", "", "")]
        public void NotAllowBlankAddress(string street, string city, string state, string postalCode)
        {
            Assert.Throws<ArgumentException>(CreateProperty);

            Asset CreateProperty() => new Asset
            {
                Address = new Address
                {
                    Street = street,
                    City = city,
                    State = state,
                    PostalCode = postalCode
                }
            };
        }
    }
}

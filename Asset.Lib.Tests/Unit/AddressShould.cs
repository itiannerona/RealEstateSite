using AssetsManagement.Inventory.Models;
using System;
using Xunit;

namespace AssetsManagement.Inventory.Unit
{
    public class AddressShould
    {
        [Theory]
        [InlineData("", "", "", "")]
        public void NotAllowBlankAddress(string street, string city, string state, string postalCode)
        {
            Assert.Throws<ArgumentException>(CreateAsset);

            Asset CreateAsset() => new Asset
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

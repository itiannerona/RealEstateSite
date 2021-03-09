using AssetsManagement.Inventory.Models;
using AssetsManagement.Inventory.Repositories.Interface;
using Moq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AssetsManagement.Inventory.IntegrationTests
{
    public class AssetTypesManagerShould
    {
        private readonly Mock<IAssetTypesRepository> _properyTypesRepository;
        private AssetTypesManager _sut;

        public AssetTypesManagerShould() 
        {
            _properyTypesRepository = new();
        }

        [Theory(Skip = "Needs more information")]
        [InlineData("test")]
        public async Task Not_Accept_Existing_PropertyType(string typeName)
        {
            _properyTypesRepository.Setup(r => r.DoesTypeExist(It.IsAny<string>())).ReturnsAsync(true);
            _sut = new(_properyTypesRepository.Object);

            bool result = await _sut.DoesTypeExist(typeName);

            Assert.True(result);
        }

        [Theory, ClassData(typeof(CreateDistinctListOfAttributes_Fakes))]
        public async Task Create_Distinct_From_List_Of_Attributes(IEnumerable<string> expected, string newFakeType, IEnumerable<string> newFakeFeatures)
        {
            _properyTypesRepository.Setup(r => r.AddAssetTypeAsync(It.IsAny<string>(), It.IsAny<IEnumerable<string>>()))
                .Callback<string, IEnumerable<string>>((fakeAssetTypeName, fakeFeatures) => 
                {
                    MockAssetTypesDB.Add(fakeAssetTypeName, fakeFeatures);
                });

            _properyTypesRepository.Setup(r => r.GetAssetTypeByNameAsync(It.IsAny<string>()))
                .Returns<string>((fakeAssetTypeName) => GetFakeAssetType(fakeAssetTypeName));


            _sut = new(_properyTypesRepository.Object);
            await _sut.AddAssetTypeAsync(newFakeType, newFakeFeatures);

            var assetType = await _sut.GetAssetTypeByNameAsync(newFakeType);
            var actual = assetType.Features.Select(f => f.Name);

            var difference = expected.Except(actual);

            Assert.True(difference.Any() is false);
        }

        private Dictionary<string, IEnumerable<string>> MockAssetTypesDB = new();

        private async Task<AssetType> GetFakeAssetType(string fakeAssetTypeName)
        {
            var fakeData = MockAssetTypesDB.First(m => m.Key == fakeAssetTypeName);
            
            return new AssetType
            {
                Id = 1,
                Name = fakeData.Key,
                Features = fakeData.Value.Select((f, idx) => new Feature
                { 
                    Id = idx,
                    Name = f
                })
            };
        }

        private class CreateDistinctListOfAttributes_Fakes : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    new List<string>() { "restroom", "meeting room", "floors" },
                    "office",
                    new List<string>() { "restroom", "restroom", "meeting room", "meeting room", "floors", "floors", "floors" }
                };

                yield return new object[]
                {
                    new List<string>() { "bathrooms", "bedrooms", "area" },
                    "apartment",
                    new List<string>() { "bathrooms", "bathrooms", "bedrooms", "bedrooms", "area", "area", "area" }
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}

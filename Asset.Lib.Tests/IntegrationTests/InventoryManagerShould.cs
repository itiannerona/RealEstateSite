using Moq;
using AssetsManagement.Inventory.Models;
using AssetsManagement.Inventory.Repositories.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using AssetsManagement.Inventory.DTO;
using System.Linq;
using AssetsManagement.Inventory.IntegrationTests;
using System.Collections.Immutable;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace AssetsManagement.Inventory.IntegrationTests
{
    public partial class InventoryManagerShould
    {
        private InventoryManager _sut;
        private List<Asset> _mockAssetContext;
        private readonly Mock<IInventoryRepository> _mockInventoryRepository;
        private readonly Mock<IConfiguration> _mockConfig;

        public InventoryManagerShould()
        {
            _mockInventoryRepository = new();
            _mockAssetContext = new();
            _mockConfig = CreateMockConfig();
        }

        private Mock<IConfiguration> CreateMockConfig()
        {
            Mock<IConfiguration> config = new();
            config.Setup(c => c["fileManagement:fileSizeLimit"]).Returns("710");
            return config;
        }

        [Theory]
        [MemberData(nameof(FakeAssetsDTO))]
        public async void Return_GuidId_Of_NewAsset(AssetDTO newAssetDTO)
        {
            _mockInventoryRepository.Setup(i => i.AddAssetAsync(It.IsNotNull<Asset>()))
                .Callback<Asset>((newFakeAsset) => _mockAssetContext.Add(newFakeAsset))
                .ReturnsAsync(() => _mockAssetContext.Any() ? Guid.NewGuid() : Guid.Empty);

            _sut = new(_mockInventoryRepository.Object, _mockConfig.Object);

            Guid current = await _sut.AddAssetAsync(newAssetDTO);

            Assert.NotEqual(Guid.Empty, current);
        }

        [Theory]
        [MemberData(nameof(BytesCheck_TestData))]
        public async void Only_Allow_FileSize_Limit_From_Config(Address address, int assetId, string description, IEnumerable<Tuple<int, string>> featuresValues, IEnumerable<Tuple<string, string>> files)
        {
            _mockInventoryRepository.Setup(i => i.AddAssetAsync(It.IsNotNull<Asset>()))
                .Callback<Asset>((newFakeAsset) => _mockAssetContext.Add(newFakeAsset))
                .ReturnsAsync(() => _mockAssetContext.Any() ? Guid.NewGuid() : Guid.Empty);

            AssetDTO newAssetDTO = AssetDTOFactory(address, assetId, description, featuresValues, files);
            long configlLimit = long.Parse(_mockConfig.Object["fileManagement:fileSizeLimit"]);
            long totalSize = newAssetDTO.FormFiles.Sum(f => f.Length);

            _sut = new(_mockInventoryRepository.Object, _mockConfig.Object);
            var exception = await Record.ExceptionAsync(() => _sut.AddAssetAsync(newAssetDTO));

            if (totalSize > configlLimit)
                Assert.NotNull(exception);
        }

        private AssetDTO AssetDTOFactory(Address address, int assetTypeId, string description, IEnumerable<Tuple<int, string>> featuresValues, IEnumerable<Tuple<string, string>> fakeFiles)
        {
            List<FormFile> formFiles = new();
            if (fakeFiles is not null && fakeFiles.Any())
            {
                foreach (var fakefile in fakeFiles)
                {
                    byte[] fakeBytes = Encoding.UTF8.GetBytes(fakefile.Item2);
                    formFiles.Add(new
                        (
                            baseStream: new MemoryStream(fakeBytes), // no need to dispose; memory streams do not hold resources to dispose
                            baseStreamOffset: 0,
                            length: fakeBytes.Length,
                            name: "data",
                            fileName: fakefile.Item1
                        )
                    );
                }
            }

            return new AssetDTO()
            {
                Address = address,
                AssetTypeId = assetTypeId,
                Description = description,
                FeatureValues = featuresValues,
                FormFiles = formFiles
            };
        }

    }
}

using AssetsManagement.Inventory.DTO;
using AssetsManagement.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Xunit;

namespace AssetsManagement.Inventory.IntegrationTests
{
    public partial class InventoryManagerShould
    {
        public static TheoryData<AssetDTO> FakeAssetsDTO
        => new()
        {
            {
                new() 
                {
                    Address = new Address()
                    {
                        Street = "fake street",
                        Colonia = "fake colonia",
                        City = "fake city",
                        State = "fake state",
                        PostalCode = "fake postal code"
                    },
                    AssetTypeId = 1,
                    Description = "fake description",
                    FeatureValues =
                    new Tuple<int, string>[]
                    {
                        new(1, "fakeValue1"),
                        new(2, "fakeValue2")
                    }
                }
            },
        };

        public static TheoryData<Address, int, string, IEnumerable<Tuple<int, string>>, IEnumerable<Tuple<string, string>>> BytesCheck_TestData
        => new()
        {
            {
                new Address()
                {
                    Street = "fake street",
                    Colonia = "fake colonia",
                    City = "fake city",
                    State = "fake state",
                    PostalCode = "fake postal code"
                },
                1,
                "fake description",
                new Tuple<int, string>[]
                {
                    new(1, "fakeValue1"),
                    new(2, "fakeValue2")
                },
                new Tuple<string, string>[] 
                {
                    new Tuple<string, string>("fakeFileName: test1", "fakeFileContent:Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam dapibus pellentesque nulla lobortis feugiat. Suspendisse potenti. Nam mollis scelerisque varius. Curabitur est libero, varius vitae urna sed, finibus fermentum nisi. Nam blandit leo purus, faucibus lacinia est tristique quis. Nulla vulputate elit non dolor viverra porttitor."),
                    new Tuple<string, string>("fakeFileName: test1", "fakeFileContent:Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam dapibus pellentesque nulla lobortis feugiat. Suspendisse potenti. Nam mollis scelerisque varius. Curabitur est libero, varius vitae urna sed, finibus fermentum nisi. Nam blandit leo purus, faucibus lacinia est tristique quis. Nulla vulputate elit non dolor viverra porttitor."),
                }
            },
            {
                new Address()
                {
                    Street = "fake street",
                    Colonia = "fake colonia",
                    City = "fake city",
                    State = "fake state",
                    PostalCode = "fake postal code"
                },
                1,
                "fake description",
                new Tuple<int, string>[]
                {
                    new(1, "fakeValue1"),
                    new(2, "fakeValue2")
                },
                new Tuple<string, string>[]
                {
                    new Tuple<string, string>("fakeFileName: test1", "fakeFileContent:Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam dapibus pellentesque nulla lobortis feugiat. Suspendisse potenti. Nam mollis scelerisque varius. Curabitur est libero, varius vitae urna sed, finibus fermentum nisi. Nam blandit leo purus, faucibus lacinia est tristique quis. Nulla vulputate elit non dolor viverra porttitor. scelerisque varius. Curabitur scelerisque varius. Curabitur scelerisque varius. Curabitur porttitor. scelerisque varius. Curabitur scelerisque varius. Curabitur scelerisque varius. Curabitur porttitor. scelerisque varius. Curabitur scelerisque varius. Curabitur scelerisque varius. Curabitur porttitor. scelerisque varius. Curabitur scelerisque varius. Curabitur scelerisque varius. Curabitur "),
                    new Tuple<string, string>("fakeFileName: test1", "fakeFileContent:Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam dapibus pellentesque nulla lobortis feugiat. Suspendisse potenti. Nam mollis scelerisque varius. Curabitur est libero, varius vitae urna sed, finibus fermentum nisi. Nam blandit leo purus, faucibus lacinia est tristique quis. Nulla vulputate elit non dolor viverra porttitor. scelerisque varius. Curabitur "),
                }
            },
        };
    }
}

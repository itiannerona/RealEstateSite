using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace AssetsManagement.Inventory.Tests
{
    public abstract class BaseTest
    {
        protected readonly ITestOutputHelper _outputHelper;

        public BaseTest(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        public bool AnyPropertyIsMutable(IEnumerable<PropertyInfo> properties)
        {
            return properties.Any(prop =>
            {
                var genericTypeArgs = prop.PropertyType.GenericTypeArguments;
                if (genericTypeArgs.Any())
                {
                    var genericTypeProperties = genericTypeArgs.SelectMany(type => type.GetProperties());
                    _outputHelper.WriteLine(prop.Name);
                    return prop.CanWrite && AnyPropertyIsMutable(genericTypeProperties);
                }
                _outputHelper.WriteLine(prop.Name);
                return prop.CanWrite;
            });
        }
    }
}

using System;

namespace Asset.Inventory.Helpers
{
    internal class ArgumentValidationHelpers
    {
        internal static void StringCannotBeNullOrEmpty(string propertyName, string argument)
        {
            if (string.IsNullOrWhiteSpace(argument))
                throw new ArgumentException($"{propertyName} cannot be empty or null");
        }

        internal static void NumberCannotBeLessThanZero(string propertyName, int argument)
        {
            if (argument < 0)
                throw new ArgumentException($"{propertyName} cannot be less than zero");
        }

        internal static void NumberCannotBeLessThanZero(string propertyName, float argument)
        {
            if (argument < 0)
                throw new ArgumentException($"{propertyName} cannot be less than zero");
        }
    }
}

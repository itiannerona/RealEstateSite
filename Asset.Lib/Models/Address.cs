using AssetsManagement.Inventory.Helpers;

namespace AssetsManagement.Inventory.Models
{
    public record Address
    {
        public Address() { }

        private readonly string street;
        public string Street 
        { 
            get => street;
            init 
            {
                ArgumentValidationHelpers.StringCannotBeNullOrEmpty(nameof(Street), value);
                street = value;
            } 
        }
        
        public string InteriorNumber { get; init; } // suite#, apt#
        
        private readonly string colonia;
        public string Colonia
        {
            get => colonia;
            init
            {
                ArgumentValidationHelpers.StringCannotBeNullOrEmpty(nameof(Colonia), value);
                colonia = value;
            }
        }
        private readonly string city;
        public string City
        {
            get => city;
            init
            {
                ArgumentValidationHelpers.StringCannotBeNullOrEmpty(nameof(City), value);
                city = value;
            }
        }

        private readonly string state;
        public string State
        {
            get => state;
            init
            {
                ArgumentValidationHelpers.StringCannotBeNullOrEmpty(nameof(State), value);
                state = value;
            }
        }

        private readonly string postalCode;
        public string PostalCode
        {
            get => postalCode;
            init
            {
                ArgumentValidationHelpers.StringCannotBeNullOrEmpty(nameof(PostalCode), value);
                postalCode = value;
            }
        }
    }
}

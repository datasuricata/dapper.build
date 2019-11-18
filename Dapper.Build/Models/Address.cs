using Dapper.Build.Models.Base;

namespace Dapper.Build.Models {
    public class Address : Entity {
        public Address (string street) {
            Street = street;
        }

        public string Street { get; set; }
    }
}
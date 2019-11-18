using Dapper.Build.Models.Base;

namespace Dapper.Build.Models {
    public class User : Entity {
        public User (string name, string email, string addressId) {
            Name = name;
            Email = email;
            AddressId = addressId;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string AddressId { get; set; }
        public Address Address { get; set; }
    }
}
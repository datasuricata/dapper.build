using Dapper.Build.Models;
using Dapper.FluentMap.Dommel.Mapping;

namespace Dapper.Build.Data.Map {
    public class AddressMap : DommelEntityMap<Address> {
        public AddressMap () {
            ToTable ("Address");
            Map (m => m.Id).ToColumn ("Id").IsKey ().IsIdentity ();
            Map (m => m.Street).ToColumn ("Street");
            Map (m => m.CreatedAt).ToColumn ("CreatedAt");
            Map (m => m.UpdatedAt).ToColumn ("UpdatedAt");
            Map (m => m.IsDeleted).ToColumn ("IsDeleted");
        }

    }
}
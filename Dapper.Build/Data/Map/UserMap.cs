using Dapper.Build.Models;
using Dapper.FluentMap.Dommel.Mapping;

namespace Dapper.Build.Data.Map
{
    public class UserMap : DommelEntityMap<User>
    {
        public UserMap(){
            ToTable("User");
            Map(m => m.Id).ToColumn("Id").IsKey().IsIdentity();
            Map(m => m.Name).ToColumn("Name");
            Map(m => m.CreatedAt).ToColumn("CreatedAt");
            Map(m => m.UpdatedAt).ToColumn("UpdatedAt");
            Map(m => m.IsDeleted).ToColumn("IsDeleted");
            Map(m => m.AddressId).ToColumn("AddressId");
            Map(m => m.Address).Ignore();
        }
    }
}
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;

namespace Dapper.Build.Data.Map.Base
{
    public class RegisterMappings
    {
        public RegisterMappings()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new UserMap());
                config.AddMap(new AddressMap());
                config.ForDommel();
            });
        }
    }
}
using MalaaviMVC_DomainClasses.Users;
using System.Data.Entity.ModelConfiguration;

namespace MalaaviMVC_DataLayerConfigurations.UsersConfiguration
{
    class UserConfig:EntityTypeConfiguration<User>
    {
        public UserConfig()
        {

        }
    }
}

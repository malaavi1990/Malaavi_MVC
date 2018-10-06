using MalaaviMVC_DomainClasses.Users;
using System.Data.Entity.ModelConfiguration;

namespace MalaaviMVC_DataLayerConfigurations.UsersConfiguration
{
    class RoleConfig:EntityTypeConfiguration<Role>
    {
        public RoleConfig()
        {

        }
    }
}

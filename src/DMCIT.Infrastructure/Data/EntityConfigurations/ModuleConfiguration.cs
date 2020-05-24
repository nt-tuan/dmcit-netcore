using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DMCIT.Infrastructure.Data.EntityConfigurations
{
    public interface IModuleConfiguration
    {
        void ConfigureAll(ModelBuilder modelBuilder);
    }

    public class ModelConfiguration : IModuleConfiguration
    {
        public virtual void ConfigureAll(ModelBuilder modelBuilder)
        {
            var types = GetType().GetInterfaces().Where(u => u.IsGenericType && u.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>));

            foreach (var iter in types)
            {

            }
        }
    }
}

using DMCIT.Core.SharedKernel;

namespace DMCIT.Core.Entities.Core
{
    public class Country : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public Country()
        {

        }

        public Country(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}

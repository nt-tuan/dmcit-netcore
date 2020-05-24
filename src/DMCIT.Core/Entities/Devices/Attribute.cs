using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMCIT.Core.Entities.Devices
{
    [Table("de_attribute")]
    public class Attribute
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<DeviceAttribute> DeviceAttributes { get; set; }
    }
}

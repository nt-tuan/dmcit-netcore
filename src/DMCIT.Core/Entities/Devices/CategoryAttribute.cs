using System.ComponentModel.DataAnnotations.Schema;

namespace DMCIT.Core.Entities.Devices
{
    [Table("de_deviceattribute")]
    public class DeviceAttribute
    {
        public int AttributeId { get; set; }
        public Attribute Attribute { get; set; }

        public int DeviceId { get; set; }
        public Device Device { get; set; }

        public string AttributeValue { get; set; }
    }
}

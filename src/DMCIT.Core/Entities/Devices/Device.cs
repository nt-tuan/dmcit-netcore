using DMCIT.Core.SharedKernel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMCIT.Core.Entities.Devices
{
    [Table("de_device")]
    public class Device : BaseVersionControlEntity<Device>
    {
        //Mã thiết bị
        public string Code { get; set; }

        //Tên thiết bị / model
        public string Name { get; set; }

        //Da bi xoa khoi he thong
        public bool Removed { get; set; } = false;

        //Loại thiết bị
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<DeviceAttribute> DeviceAttributes { get; set; }
    }
}

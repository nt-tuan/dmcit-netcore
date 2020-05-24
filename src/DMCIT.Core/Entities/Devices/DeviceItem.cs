using DMCIT.Core.Entities.Core;
using DMCIT.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMCIT.Core.Entities.Devices
{
    public class DeviceItem : BaseVersionControlEntity<DeviceItem>
    {
        //Số serial
        public string SerialNumber { get; set; }

        //Là thiết bị bộ phận của
        public int? AssembledToId { get; set; }
        [ForeignKey("AssembledToId")]
        public Device AssembledTo { get; set; }

        //Được tạo ra bằng các tách rời một thiết bị
        public int? DisassembledFromId { get; set; }
        [ForeignKey("DisassembledFromId")]
        public Device DisassembledFrom { get; set; }

        //Nhân viên đang sử dụng
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        //Bộ phận đang sử dụng
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        //Năm sử dụng
        public DateTime? UsingDate { get; set; }

        public string Location { get; set; }
        public ICollection<Device> AssembledDevices { get; set; }
        public ICollection<Device> DisassembledDevices { get; set; }

    }
}

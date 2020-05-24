using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMCIT.Core.Entities.Devices
{
    [Table("de_class")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Discripttion { get; set; }

        public ICollection<Device> Devices { get; set; }
    }
}

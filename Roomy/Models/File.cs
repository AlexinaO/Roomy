using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Roomy.Models
{
    public class File : BaseModel
    {
        [Required]
        [StringLength(254)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string ContentType { get; set; }

        [Required]
        public byte[] Content { get; set; }

        public int RoomID { get; set; }

        [ForeignKey("RoomID")]
        public Room Room { get; set; }

    }
}

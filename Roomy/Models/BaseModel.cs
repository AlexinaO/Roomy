using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomy.Models
{
    public class BaseModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public bool Deleted { get; set; }
    }
}

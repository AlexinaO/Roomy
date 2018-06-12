using Roomy.Languages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Roomy.Models
{
    public class User
    {
        public string LastName { get; set; }

        public string Firstname { get; set; }

        [Display(Name = "email", ResourceType = typeof(Resource))]
        public string Mail { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public DateTime BirthDate { get; set; }



    }
}

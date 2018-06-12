using Roomy.Languages;
using Roomy.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Roomy.Models
{
    public class User
    {
        [Display(Name = "lastname", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Le champ {0} doit contenir entre {2} et {1} caractères")]
        public string Lastname { get; set; }

        [Display(Name = "firstname", ResourceType = typeof(Resource), Prompt = "firstname")]
        public string Firstname { get; set; }

        [Display(Name = "email", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType =typeof(Resource))]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Le format du mail est incorrect.")]
        public string Mail { get; set; }

        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(Resource))]
        [DataType(DataType.Password)]
        [Display(Name = "password", ResourceType = typeof(Resource))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "confirm_password", ResourceType = typeof(Resource))]
        [Compare("Password", ErrorMessage = "Confirmation du mot de passe incorrect.")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "birthdate", ResourceType = typeof(Resource))]
        [DateCompare(18, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "major")]
        public DateTime? BirthDate { get; set; }



    }
}

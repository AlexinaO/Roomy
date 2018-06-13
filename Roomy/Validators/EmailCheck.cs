using Microsoft.EntityFrameworkCore;
using Roomy.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Roomy.Validators
{
    public class EmailCheck : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var db = (RoomyDbContext)validationContext.GetService(typeof(RoomyDbContext));
            if(!string.IsNullOrWhiteSpace(value?.ToString()))
            {
                var user = db.Users.SingleOrDefault(x => x.Mail == value.ToString());
                if (user == null)
                    return ValidationResult.Success;
            }
            return new ValidationResult("Mail existant");
        }
    }
}

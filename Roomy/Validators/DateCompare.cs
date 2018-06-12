using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Roomy.Validators
{
    public class DateCompare : ValidationAttribute
    {
        private int years;

        public DateCompare(int years) : base()
        {
            this.years = years;
        }

        public override bool IsValid(object value)
        {
            if(value is DateTime && value != null)
            {
                var dt = (DateTime)value;
                return dt.AddYears(this.years) <= DateTime.Now;
            }
            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            if(this.ErrorMessage != null)
                return string.Format(this.ErrorMessage, name, this.years.ToString());
            else
                return string.Format(this.ErrorMessageString, name, this.years.ToString());
        }

       
    }
}

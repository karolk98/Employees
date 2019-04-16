using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFlab2
{
    public class SalaryValidation : ValidationRule
    {
        public string Min { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string s = value as string;
            int i;
            if (!int.TryParse(s, out i))
                return new ValidationResult(isValid: false, "Value should be integer!");

            if (i < int.Parse(Min))
                return new ValidationResult(isValid: false, $"Salary can not be less than {Min}!");
            return new ValidationResult(isValid: true,"");
        }
    }
}

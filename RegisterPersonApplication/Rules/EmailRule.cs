using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RegisterPersonApplication.Rules
{
    public class EmailRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            bool isValid = ((string)value).Length > 0 && ((string)value).Contains("@");
            return new ValidationResult(isValid, null);

        }
    }
}

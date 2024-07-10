using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RegisterPersonApplication.Rules
{
    public class PhoneNumberRule : ValidationRule
    {
        public int Len { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            bool isValid = ((string)value).Length == Len && int.TryParse((string)value, out _);
            return new ValidationResult(isValid, null);

        }
    }
}

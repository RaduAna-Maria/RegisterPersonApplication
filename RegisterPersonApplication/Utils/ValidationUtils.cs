using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RegisterPersonApplication.Utils
{
    public static class ValidationUtils
    {
        public static bool EmailValidation(this string email)
        {
            return email.Length > 0 && email.Contains('@');
        }

        public static bool PhoneNumberValidation(this string phoneNumber)
        {
            return phoneNumber.Length == 3 && int.TryParse(phoneNumber, out _);
        }
    }
}

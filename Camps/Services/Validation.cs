using Camps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services.Camps
{
    public class Validation
    {
        public List<string> UserValidation(Users user)
        {
            List<string> errors = new List<string>();
            if (!IsNameSurnameValid(user.Name))
            {
                errors.Add("Name must be between 1 and 50 characters and cannot contain digits.");
            }
            if (!IsNameSurnameValid(user.Surname))
            {
                errors.Add("Surname must be between 1 and 50 characters and cannot contain digits.");
            }
            if (!IsNameSurnameValid(user.Username))
            {
                errors.Add("Username must be between 1 and 50 characters.");
            }
            return errors;
        }
        public bool IsPasswordValid(string password, string confirmPassword)
        {
            if (password.Length < 6 || password.Length > 60)
            {
                return false;
            }
            if (password != confirmPassword)
            {
                return false;
            }
            return true;
        }
        public bool IsNameSurnameValid(string input)
        {
            if (input.Length < 1 || input.Length > 50 || input.Any(char.IsDigit))
            {
                return false;
            }
            return true;
        }
        public bool IsUsernameValid(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;

            if (input.Length < 1 || input.Length > 50) return false;

            return Regex.IsMatch(input, @"^[a-zA-Z0-9_.-]+$");
        }
        public static bool IsNameAllowedSoFar(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length == 0) return true;
            if (input.Length > 50 || input.Any(char.IsDigit)) return false;
            return true;
        }
        public static bool IsSurnameAllowedSoFar(string input) => IsNameAllowedSoFar(input);
        public static bool IsUsernameAllowedSoFar(string input)
        {
            if (string.IsNullOrEmpty(input)) return true;

            if (input.Length > 50) return false;

            return Regex.IsMatch(input, @"^[a-zA-Z0-9_.-]*$");
        }
        public bool IsPhoneAllowedSoFar(string input)
        {
            if (string.IsNullOrEmpty(input)) return true;
            if (input.Length > 15 || input.Any(c => !char.IsDigit(c) && c != '+' && c != '-' && c != ' ')) return false;
            return true;
        }
        public bool IsBirthYearValid(int year)
        {
            int minYear = DateTime.Now.Year - 18;
            int maxYear = DateTime.Now.Year - 7;
            if (year < minYear || year > maxYear)
            {
                return false;
            }
            return true;
        }
        public bool IsPhoneValid(string phone)
        {
            if (phone.Length < 7 || phone.Length > 15 || !phone.All(c => char.IsDigit(c) || c == '+' || c == '-' || c == ' '))
            {
                return false;
            }
            return true;
        }
        public bool IsUserNameUnique(string username, List<Users> existingUsers)
        {
            if (existingUsers.Any(c => c.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }
            return true;
        }

    }
}

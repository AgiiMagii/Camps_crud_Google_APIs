using Camps;
using Camps.Lib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Services.Camps
{
    public class Validation
    {
        ErrorProvider errorProvider = new ErrorProvider();
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
        public List<string> CampValidation(Camp camp)
        {
            List<string> errors = new List<string>();
            if (string.IsNullOrWhiteSpace(camp.Name) || camp.Name.Length > 50)
            {
                errors.Add("Camp name must be between 1 and 50 characters.");
            }
            if (string.IsNullOrWhiteSpace(camp.Description) || camp.Description.Length > 225)
            {
                errors.Add("Camp description must be between 1 and 225 characters.");
            }
            if (camp.Capacity <= 0 || camp.Capacity > 800)
            {
                errors.Add("Camp capacity must be a positive number and less than or equal to 800.");
            }
            return errors;
        }
        public List<string> ChildValidation(Children child)
        {
            List<string> errors = new List<string>();
            if (!IsNameSurnameValid(child.Name))
            {
                errors.Add("Name must be between 1 and 50 characters and cannot contain digits.");
            }
            if (!IsNameSurnameValid(child.Surname))
            {
                errors.Add("Surname must be between 1 and 50 characters and cannot contain digits.");
            }
            if (!IsGenderValid(child.Gender))
            {
                errors.Add("Gender must be either 'M' or 'F'.");
            }
            if (!IsBirthYearValid(child.BirthYear))
            {
                errors.Add("Birth year must indicate age between 7 and 18.");
            }
            return errors;
        }
        public List<string> ParentsValidation(List<Parents> parents)
        {
            List<string> errors = new List<string>();
            foreach (var parent in parents)
            {
                if (!IsNameSurnameValid(parent.Name))
                {
                    errors.Add($"Parent {parent.Name} {parent.Surname}: Name must be between 1 and 50 characters and cannot contain digits.");
                }
                if (!IsNameSurnameValid(parent.Surname))
                {
                    errors.Add($"Parent {parent.Name} {parent.Surname}: Surname must be between 1 and 50 characters and cannot contain digits.");
                }
                if (!IsPhoneValid(parent.Phone))
                {
                    errors.Add($"Parent {parent.Name} {parent.Surname}: Phone number must be between 7 and 15 characters and can only contain digits, '+', '-', and spaces.");
                }
                if (!IsEmailValid(parent.Email))
                {
                    errors.Add($"Parent {parent.Name} {parent.Surname}: Email is not valid.");
                }
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
            if (string.IsNullOrWhiteSpace(input)) return false;
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
        public static bool IsCampNameValid(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;

            if (input.Length < 2 || input.Length > 50) return false;

            return Regex.IsMatch(input, @"^[a-zA-Z0-9āčēģīķļņšūžĀČĒĢĪĶĻŅŠŪŽ ._-]+$");
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
        public static bool IsCampNameAllowedSoFar(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;

            if (input.Length > 50) return false;

            return Regex.IsMatch(input, @"^[a-zA-Z0-9āčēģīķļņšūžĀČĒĢĪĶĻŅŠŪŽ ._-]+$");
        }
        public static bool IsPhoneAllowedSoFar(string input)
        {
            if (string.IsNullOrEmpty(input)) return true;
            if (input.Length > 15 || input.Any(c => !char.IsDigit(c) && c != '+' && c != '-' && c != ' ')) return false;
            return true;
        }
        public bool IsBirthYearValid(int? year)
        {
            if (!year.HasValue || year.Value == 0) return false;
            int minYear = DateTime.Now.Year - 18;
            int maxYear = DateTime.Now.Year - 7;
            if (year < minYear || year > maxYear)
            {
                return false;
            }
            return true;
        }
        public bool IsGenderValid(string gender)
        {
            if (gender == null) return false;
            if (gender != "M" && gender != "F") return false;
            else return true;
        }
        public bool IsPhoneValid(string phone)
        {
            if (phone.Length < 7 || phone.Length > 15 || !phone.All(c => char.IsDigit(c) || c == '+' || c == '-' || c == ' '))
            {
                return false;
            }
            return true;
        }
        public bool IsEmailValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email && email.Contains(".");
            }
            catch
            {
                return false;
            }
        }
        public bool IsUserNameUnique(string username, List<Users> existingUsers)
        {
            if (existingUsers.Any(c => c.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }
            return true;
        }
        public void UpdateError(Control control, bool isValid, string errorMessage)
        {
            if (!isValid)
            {
                control.BackColor = Color.MistyRose;
                errorProvider.SetError(control, errorMessage);
            }
            else
            {
                control.BackColor = Color.White;
                errorProvider.SetError(control, "");
            }
        }
    }
}

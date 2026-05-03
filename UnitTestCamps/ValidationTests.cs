using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Camps;
using Services.Camps;

namespace UnitTestCamps
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void IsPasswordValid_TooShort_ReturnsFalse()
        {
            var validation = new Validation();
            var result = validation.IsPasswordValid("pass", "pass");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void IsPasswordValid_ValidPassword_ReturnsTrue()
        {
            var validation = new Validation();
            var result = validation.IsPasswordValid("password123", "password123");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsPasswordValid_NotMatching_ReturnsFalse()
        {
            var validation = new Validation();
            var result = validation.IsPasswordValid("secret123", "different");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsNameSurnameValid_ValidName_ReturnsTrue()
        {
            var v = new Validation();
            var result = v.IsNameSurnameValid("Anna");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsNameSurnameValid_Empty_ReturnsFalse()
        {
            var v = new Validation();
            var result = v.IsNameSurnameValid("");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void IsNameSurnameValid_WithDigits_ReturnsFalse()
        {
            var v = new Validation();
            var result = v.IsNameSurnameValid("Anna123");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void IsUsernameValid_ValidUsername_ReturnsTrue()
        {
            var v = new Validation();
            var result = v.IsUsernameValid("user_name");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsUsernameValid_InvalidUsername_ReturnsFalse()
        {
            var v = new Validation();
            var result = v.IsUsernameValid("user name");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void IsUsernameValid_EmptyUsername_ReturnsFalse()
        {
            var v = new Validation();
            var result = v.IsUsernameValid("");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void IsUsernameValid_SpecialChars_ReturnsFalse()
        {
            var v = new Validation();
            var result = v.IsUsernameValid("user@name");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsBirthYearValid_ValidAge_ReturnsTrue()
        {
            var v = new Validation();
            int year = DateTime.Now.Year - 10;

            var result = v.IsBirthYearValid(year);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsBirthYearValid_TooYoung_ReturnsFalse()
        {
            var v = new Validation();
            int year = DateTime.Now.Year - 5;

            var result = v.IsBirthYearValid(year);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsEmailValid_ValidEmail_ReturnsTrue()
        {
            var v = new Validation();
            var result = v.IsEmailValid("test@test.com");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsEmailValid_InvalidEmail_ReturnsFalse()
        {
            var v = new Validation();
            var result = v.IsEmailValid("not-email.com");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UserValidation_InvalidUser_ReturnsErrors()
        {
            var v = new Validation();

            var user = new Users
            {
                Name = "",
                Surname = "",
                Username = ""
            };

            var errors = v.UserValidation(user);

            Assert.IsNotNull(errors);
            Assert.AreEqual(3, errors.Count);
        }
    }
}

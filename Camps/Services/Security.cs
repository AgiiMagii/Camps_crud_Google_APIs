using System;
using System.Collections.Generic;
using System.Linq;
using Camps.Lib;


namespace Camps.Services
{
    public class Security
    {
        Repository repo = new Repository(new SummerCampEntities());

        public Result<Users> AuthenticateUser(string username, string password)
        {
            try
            {
                Users person = repo.GetEntityByFilter<Users>(p => p.Username == username);
                if (person == null)
                {
                    return new Result<Users>
                    {
                        Data = null,
                        Error = "User doesn't exist."
                    };
                }
                if (!person.Enabled)
                {
                    if (DateTime.Now > person.DisabledTill)
                    {
                        AccountStatusChange(person.Username, true);
                    }
                    else
                    {
                        TimeSpan timeSpan = person.DisabledTill.Value - DateTime.Now;
                        return new Result<Users>
                        {
                            Data = null,
                            Error = $"Person disabled. Waiting time: {timeSpan.Minutes:d2}-{timeSpan.Seconds:d2}"
                        };
                    }
                }

                bool isSuccess = PasswordIsValid(person, password);

                if (!isSuccess)
                {
                    return new Result<Users>
                    {
                        Data = null,
                        Error = "Invalid password."
                    };
                }
                return new Result<Users>
                {
                    Data = person
                };
            }
            catch (Exception ex)
            {
                return new Result<Users>
                {
                    Data = null,
                    Error = "An error occurred during authentication.",
                    InnerException = ex.Message
                };
            }
        }
        private bool PasswordIsValid(Users person, string password)
        {
            bool isSuccess = Password.VerifyPassword(password, person.passwordHash);
            LogAuthenticationAttempt(person.Username, isSuccess);
            return isSuccess;
        }
        private void LogAuthenticationAttempt(string username, bool isSuccess)
        {
            try
            {
                Audit auditEntry = new Audit
                {
                    LogTime = DateTime.Now,
                    Username = username,
                    LogResult = isSuccess
                };
                repo.InsertEntity<Audit>(auditEntry);
                if (!isSuccess)
                {
                    AttemptCheck(username);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while logging the authentication attempt.", ex);

            }
        }
        private void AttemptCheck(string username)
        {
            DateTime dt = DateTime.Now.AddMinutes(-5);
            List<Audit> audits = repo.GetEntitiesByFilter<Audit>(a => a.Username == username && a.LogTime > dt).OrderByDescending(x => x.ID_audit).Take(3).ToList();
            int unSuccessfullAttempts = audits.Where(a => a.LogResult == false).Count();
            if (unSuccessfullAttempts == 3)
            {
                AccountStatusChange(username, false);
            }
        }
        private void AccountStatusChange(string username, bool enabled)
        {
            try
            {
                Users person = repo.GetEntityByFilter<Users>(p => p.Username == username);
                if (person != null)
                {
                    person.Enabled = enabled;
                    if (!enabled)
                    {
                        person.DisabledTill = DateTime.Now.AddMinutes(1);
                    }
                    else
                    {
                        person.DisabledTill = null;
                    }
                    repo.UpdateEntity<Users>(person);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while changing the account status.", ex);
            }
        }
        public bool ChangePassword(string username, string newPassword)
        {
            try
            {
                Users user = repo.GetEntityByFilter<Users>(u => u.Username == username);
                if (user != null)
                {
                    user.passwordHash = newPassword;
                    repo.UpdateEntity(user);
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while changing the password.", ex);
            }
        }
    }
}

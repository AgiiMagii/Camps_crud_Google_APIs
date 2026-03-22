using Camps.Services;
using Camps.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Camps.Lib
{
    public class Factory
    {
        Repository repo = new Repository(new SummerCampEntities());
        private static readonly Sheets _sheet = new Sheets();
        private static readonly GForms _gforms = new GForms();
        public Sheets Sheet => _sheet;
        public GForms Forms => _gforms;
        public List<UserView> MapToUserView()
        {
            List<Users> users = repo.GetEntities<Users>();
            return users.Select(u => new UserView
            {
                Username = u.Username,
                Name = u.Name,
                Surname = u.Surname,
                Status = u.Enabled ? "Enabled" : (u.DisabledTill.HasValue && u.DisabledTill.Value > DateTime.Now) ? $"Disabled until {u.DisabledTill.Value.ToShortDateString()}" : "Disabled",
                Role = repo.GetEntityByFilter<UserRoles>(r => r.roleID == u.roleID)?.Description ?? "Unknown"
            }).ToList();

        }
        public List<CampsView> MapToCampsView()
        {
            List<Camps> camps = repo.GetEntities<Camps>();
            List<Address> addresses = repo.GetEntities<Address>();
            return camps.Select(c => new CampsView
            {
                campID = c.campID,
                Name = c.Name,
                Capacity = c.Capacity,
                Description = c.Description,
                FullAddress = addresses.FirstOrDefault(a => a.addressID == c.addressID) != null
                    ? $"{addresses.FirstOrDefault(a => a.addressID == c.addressID).Address1}, {addresses.FirstOrDefault(a => a.addressID == c.addressID).City}, {addresses.FirstOrDefault(a => a.addressID == c.addressID).Region}, {addresses.FirstOrDefault(a => a.addressID == c.addressID).Country}, {addresses.FirstOrDefault(a => a.addressID == c.addressID).ZipCode}"
                    : "No address"

            }).ToList();

        }
        public void UpdateUser(UserView userView)
        {
            Users user = repo.GetEntityByFilter<Users>(u => u.Username == userView.Username);
            if (user != null)
            {
                user.Username = userView.Username;
                user.Name = userView.Name;
                user.Surname = userView.Surname;
                user.roleID = repo.GetEntities<UserRoles>().FirstOrDefault(r => r.Description == userView.Role)?.roleID;
                repo.UpdateEntity(user);
            }
        }
        public void UpdateCamp(Camps camp)
        {
            Camps existingCamp = repo.GetEntityByFilter<Camps>(c => c.campID == camp.campID);
            if (existingCamp != null)
            {
                existingCamp.Name = camp.Name;
                existingCamp.Description = camp.Description;
                existingCamp.Capacity = camp.Capacity;
                existingCamp.addressID = camp.addressID;
                repo.UpdateEntity(existingCamp);
            }
        }
        public void UpdateAddress(Address address)
        {
            Address existingAddress = repo.GetEntityByFilter<Address>(a => a.addressID == address.addressID);
            if (existingAddress != null)
            {
                existingAddress.Country = address.Country;
                existingAddress.City = address.City;
                existingAddress.Region = address.Region;
                existingAddress.ZipCode = address.ZipCode;
                existingAddress.Address1 = address.Address1;
                repo.UpdateEntity(existingAddress);
            }
        }
        public void AddUser(Users userData)
        {
            Users user = new Users
            {
                Username = userData.Username,
                Name = userData.Name,
                Surname = userData.Surname,
                passwordHash = userData.passwordHash,
                Enabled = true,
                IsAdmin = userData.IsAdmin,
                roleID = userData.roleID
            };
            repo.InsertEntity(user);
        }
        public void AddCamp(Camps campData)
        {
            Camps camp = new Camps
            {
                addressID = campData.addressID,
                Name = campData.Name,
                Capacity = campData.Capacity,
                Description = campData.Description

            };
            repo.InsertEntity(camp);
        }
        public void AddAddress(Address addressData)
        {
            Address address = new Address
            {
                Country = addressData.Country,
                City = addressData.City,
                Region = addressData.Region,
                ZipCode = addressData.ZipCode,
                Address1 = addressData.Address1
            };
            repo.InsertEntity(address);
        }
        public List<UserRoles> GetRoles()
        {
            return repo.GetEntities<UserRoles>();

        }
        public List<Address> GetAddresses()
        {
            return repo.GetEntities<Address>();
        }
        public List<Camps> GetCamps()
        {
            return repo.GetEntities<Camps>();
        }
        public Address GetAddressByID(long? addressID)
        {
            return repo.GetEntityByFilter<Address>(a => a.addressID == addressID);
        }
        public Address GetAddressByCampID(long campID)
        {
            Camps camp = repo.GetEntityByFilter<Camps>(c => c.campID == campID);
            if (camp != null)
            {
                return GetAddressByID(camp.addressID);
            }
            return null;
        }
        public long GetLastAddressID()
        {
            return repo.GetEntities<Address>().OrderByDescending(a => a.addressID).FirstOrDefault()?.addressID ?? 0;
        }
        public Camps GetCampByID(long campID)
        {
            return repo.GetEntityByFilter<Camps>(c => c.campID == campID);
        }
        public bool DeleteUser(string username)
        {
            Users user = repo.GetEntityByFilter<Users>(u => u.Username == username);
            if (user != null)
            {
                repo.DeleteEntity(user);
                return true;
            }
            return false;
        }
        public bool DeleteCamp(long campID)
        {
            Camps camp = repo.GetEntityByFilter<Camps>(c => c.campID == campID);
            if (camp != null)
            {
                repo.DeleteEntity(camp);
                return true;
            }
            return false;
        }
        public bool DeleteContract(int contractID)
        {
            Contracts contract = repo.GetEntityByFilter<Contracts>(c => c.contractID == contractID);
            if (contract != null)
            {
                repo.DeleteEntity(contract);
                return true;
            }
            return false;
        }
        public async Task<List<SheetDataView>> GetSheetDataAsync(string spreadsheetId, string range)
        {
            var values = await _sheet.GetRangeAsync(spreadsheetId, range)
                         ?? new List<IList<object>>();

            return values
                .Select((row, index) => new { row, index }) // saglabājam oriģinālo indeksu
                .Skip(1) // izlaižam header
                .Where(x => x.row.ElementAtOrDefault(20)?.ToString() != "Processed") // ignorē processed
                .Select(x => new SheetDataView
                {
                    RowIndex = x.index + 1, // īstais Google Sheets row index

                    Date = x.row.ElementAtOrDefault(0)?.ToString(),

                    
                    ChildName = x.row.ElementAtOrDefault(1)?.ToString(),
                    ChildSurname = x.row.ElementAtOrDefault(2)?.ToString(),
                    Gender = x.row.ElementAtOrDefault(3)?.ToString(),

                    BirthYear = short.TryParse(x.row.ElementAtOrDefault(4)?.ToString(), out var year)
                        ? year
                        : (short)0,

                    Interests = x.row.ElementAtOrDefault(5)?.ToString(),
                    Avoidances = x.row.ElementAtOrDefault(6)?.ToString(),
                    EatingHabits = x.row.ElementAtOrDefault(7)?.ToString(),

                    ParentName = x.row.ElementAtOrDefault(8)?.ToString(),
                    ParentSurname = x.row.ElementAtOrDefault(9)?.ToString(),
                    ParentType = x.row.ElementAtOrDefault(10)?.ToString(),
                    ParentEmail = x.row.ElementAtOrDefault(11)?.ToString(),
                    ParentPhone = x.row.ElementAtOrDefault(12)?.ToString(),
                    ParentAddress = x.row.ElementAtOrDefault(13)?.ToString(),

                    ParentName1 = x.row.ElementAtOrDefault(14)?.ToString(),
                    ParentSurname1 = x.row.ElementAtOrDefault(15)?.ToString(),
                    ParentType1 = x.row.ElementAtOrDefault(16)?.ToString(),
                    ParentPhone1 = x.row.ElementAtOrDefault(17)?.ToString(),
                    Camp = x.row.ElementAtOrDefault(19)?.ToString(),
                })
                .ToList();
        }
        public async Task SyncCampsToGoogleFormsAsync(string formId, string questionId)
        {
            List<Camps> camps = repo.GetEntities<Camps>();
            List<string> campNames = camps.Where(c => c.IsActive = true).Select(c => c.Name).ToList();
            await _gforms.SyncQuestionOptionsToFormAsync(formId, questionId, campNames);
        }
        public List<ContractsView> MapToContractsView()
        {
            List<Contracts> contracts = repo.GetEntities<Contracts>();
            List<Camps> camps = repo.GetEntities<Camps>();
            List<Children> children = repo.GetEntities<Children>();
            List<Parents> parents = repo.GetEntities<Parents>();
            return contracts.Select(c => new ContractsView
            {
                contractID = c.contractID,
                CampName = camps.FirstOrDefault(camp => camp.campID == c.campID)?.Name ?? "Unknown Camp",
                ChildFullName = children.FirstOrDefault(child => child.childID == c.childID) != null
                    ? $"{children.FirstOrDefault(child => child.childID == c.childID).Name} {children.FirstOrDefault(child => child.childID == c.childID).Surname}"
                    : "Unknown Child",
                ParentFullName = parents.FirstOrDefault(parent => parent.parentID == c.parentID) != null
                    ? $"{parents.FirstOrDefault(parent => parent.parentID == c.parentID).Name} {parents.FirstOrDefault(parent => parent.parentID == c.parentID).Surname}"
                    : "Unknown Parent",
                ParentFullName2 = parents.FirstOrDefault(parent => parent.parentID == c.patent2ID) != null
                    ? $"{parents.FirstOrDefault(parent => parent.parentID == c.patent2ID).Name} {parents.FirstOrDefault(parent => parent.parentID == c.patent2ID).Surname}"
                    : string.Empty,
                ParentPhone = parents.FirstOrDefault(parent => parent.parentID == c.parentID)?.Phone ?? "Unknown Phone",
                Date = c.Date,
                Balance = c.Balance
            }).ToList();
        }
    }
}

using Camps.Services;
using Camps.Views;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Camps.Lib
{
    public class Factory
    {
        private readonly Repository repo = new Repository(new SummerCampEntities());
        private static readonly Sheets _sheet = new Sheets();
        private static readonly GForms _gforms = new GForms();
        private static readonly Random random = new Random();
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
        public List<ParticipiantView> MapToParticipiantView()
        {
            return repo.GetEntities<Children>()
                .Select(child => new ParticipiantView
                {
                    childID = child.childID,
                    Name = child.Name,
                    Surname = child.Surname,
                    Gender = child.Gender,
                    BirthYear = child.BirthYear,

                }).ToList();
        }
        public List<ParentsView> MapToParentsView(long childID)
        {
            List<Parents> parents = GetParentsByChildID(childID);
            return parents.Select(parent => new ParentsView
            {
                parentID = parent.parentID,
                Name = parent.Name,
                Surname = parent.Surname,
                Parent = parent.Parent,
                Email = parent.Email ?? string.Empty,
                Phone = parent.Phone,
                Address = parent.Address ?? string.Empty
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
        public List<Parents> GetParentsByChildID(long childID)
        {
            var parents = repo.GetQueryable<Parents>()
                  .Include(p => p.Children)
                  .Where(p => p.Children.Any(c => c.childID == childID))
                  .ToList();
            return parents;
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
        public Children GetChildByID(long childID)
        {
            return repo.GetEntityByFilter<Children>(c => c.childID == childID);
        }
        public Parents GetParentByID(long parentID)
        {
            return repo.GetEntityByFilter<Parents>(p => p.parentID == parentID);
        }
        public long GetLastAddressID()
        {
            return repo.GetEntities<Address>().OrderByDescending(a => a.addressID).FirstOrDefault()?.addressID ?? 0;
        }
        public Camps GetCampByID(long campID)
        {
            return repo.GetEntityByFilter<Camps>(c => c.campID == campID);
        }
        public Camps GetCampByName(string name)
        {
            return repo.GetEntityByFilter<Camps>(c => c.Name == name);
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
            return repo.DeleteEntityById<Contracts>(contractID);
        }
        public bool DeleteChild(long childID)
        {
            Children child = repo.GetEntityByFilter<Children>(c => c.childID == childID);
            if (child != null)
            {
                repo.DeleteEntity(child);
                return true;
            }
            return false;
        }
        public bool DeleteParent(long parentID)
        {
            Parents parent = repo.GetEntityByFilter<Parents>(p => p.parentID == parentID);
            if (parent != null)
            {
                repo.DeleteEntity(parent);
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
                ParentFullName2 = parents.FirstOrDefault(parent => parent.parentID == c.parentID) != null
                    ? $"{parents.FirstOrDefault(parent => parent.parentID == c.parentID).Name} {parents.FirstOrDefault(parent => parent.parentID == c.parentID).Surname}"
                    : "Unknown Parent",
                ParentFullName = parents.FirstOrDefault(parent => parent.parentID == c.patent2ID) != null
                    ? $"{parents.FirstOrDefault(parent => parent.parentID == c.patent2ID).Name} {parents.FirstOrDefault(parent => parent.parentID == c.patent2ID).Surname}"
                    : string.Empty,
                ParentPhone = parents.FirstOrDefault(parent => parent.parentID == c.parentID)?.Phone ?? "Unknown Phone",
                Date = c.Date,
                Balance = c.Balance
            }).ToList();
        }
        public void CreateContract(Children child, List<Parents> parents, Camps selectedCamp, SheetDataView sheetData = null)
        {
            using (var transaction = repo.BeginTransaction())
            {
                try
                {
                    repo.InsertEntity(child);
                    repo.SaveChanges();

                    foreach (var parent in parents)
                    {
                        repo.InsertEntity(parent);
                    }
                    repo.SaveChanges();

                    Parents mainParent = parents.FirstOrDefault(p =>
                        !string.IsNullOrWhiteSpace(p.Email) &&
                        !string.IsNullOrWhiteSpace(p.Address)
                    ) ?? parents.First();

                    Parents secondaryParent = parents.FirstOrDefault(p => p != mainParent);

                    if (mainParent == null)
                    {
                        MessageBox.Show("Nav iespējams izveidot līgumu bez galvenā vecāka informācijas (e-pasts un adrese).");
                        transaction.Rollback();
                        return;
                    }

                    Contracts contract = new Contracts
                    {
                        childID = child.childID,
                        parentID = secondaryParent?.parentID,
                        patent2ID = mainParent.parentID,
                        campID = selectedCamp.campID,
                        Date = DateTime.Now,
                        Balance = random.Next(100, 400)
                    };
                    foreach (var parent in parents)
                    {
                        child.Parents.Add(parent); // EF automātiski saista mapping table
                    }
                    repo.InsertEntity(contract);
                    repo.SaveChanges();

                    transaction.Commit();
                    if (sheetData != null)
                    {
                        // async var saukt šeit vai service līmenī
                        Task.Run(async () =>
                        {
                            await Sheet.MarkRowAsProcessed(
                                "1lUzhU0ZjLNwUYT-tuW9aNQkdR1219c16Q4JAetMx2EQ",
                                "FormResponses",
                                sheetData.RowIndex);
                        });
                    }
                }
                catch (DbEntityValidationException ex)
                {
                    var errors = ex.EntityValidationErrors
                        .SelectMany(e => e.ValidationErrors)
                        .Select(e => $"{e.PropertyName}: {e.ErrorMessage}");
                    MessageBox.Show(string.Join("\n", errors));

                    transaction.Rollback();
                    throw;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public List<ContractsView> GetTContracts(int pageSize, int pageNr)
        {
            try
            {
                return repo.GetEntities<Contracts>()
                    .OrderBy(c => c.contractID)
                    .Skip((pageNr - 1) * pageSize)
                    .Take(pageSize)
                    .Select(c => new ContractsView
                    {
                        contractID = c.contractID,
                        CampName = repo.GetEntityByFilter<Camps>(camp => camp.campID == c.campID)?.Name ?? "-",
                        ChildFullName = repo.GetEntityByFilter<Children>(child => child.childID == c.childID) != null
                            ? $"{repo.GetEntityByFilter<Children>(child => child.childID == c.childID).Name} {repo.GetEntityByFilter<Children>(child => child.childID == c.childID).Surname}"
                            : "-",
                        ParentFullName = repo.GetEntityByFilter<Parents>(parent => parent.parentID == c.patent2ID) != null
                            ? $"{repo.GetEntityByFilter<Parents>(parent => parent.parentID == c.patent2ID).Name} {repo.GetEntityByFilter<Parents>(parent => parent.parentID == c.patent2ID).Surname}"
                            : "-",
                        ParentFullName2 = repo.GetEntityByFilter<Parents>(parent => parent.parentID == c.parentID) != null
                            ? $"{repo.GetEntityByFilter<Parents>(parent => parent.parentID == c.parentID).Name} {repo.GetEntityByFilter<Parents>(parent => parent.parentID == c.parentID).Surname}"
                            : string.Empty,
                        ParentPhone = repo.GetEntityByFilter<Parents>(parent => parent.parentID == c.patent2ID)?.Phone ?? "-",
                        Date = c.Date,
                        Balance = c.Balance
                    })
                    .ToList();

            }
            catch
            {
                return new List<ContractsView>();
            }

        }
        public int GetTotalContractCount()
        {
            try
            {
                return repo.GetCount<Contracts>();
            }
            catch { return 0; }
        }
        public async Task MarkProcessedRows(int rowIndex)
        {
            await Sheet.MarkRowAsProcessed(
                "1ySwP3-xn8RUxH7NenO-gZ-q_FhhZZ1_h9l3e9hRKfzg",
                "Form Responses 1",
                rowIndex);
        }
        public IQueryable<T> GetSqlResult<T>(string sql) where T : class
        {
            try
            {
                return repo.GetEntitiesFromStrinSql<T>(sql);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"SQL Error: {ex.Message}");
                return Enumerable.Empty<T>().AsQueryable();
            }
        }
    }
}


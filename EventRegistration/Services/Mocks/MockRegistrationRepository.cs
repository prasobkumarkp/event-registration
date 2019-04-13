using EventRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventRegistration.Services.Mocks
{
    public class MockRegistrationRepository : IRepository<Registration>
    {
        private List<Registration> _registrations;
        public MockRegistrationRepository()
        {
            _registrations = new List<Registration>
            {
                new Registration
                {
                    Id = 1,
                    User = new User
                    {
                        EmailId = "Shirly@gmail.com",
                        Gender = new Gender{ Label = "Female",Value = "F"},
                        Name = "Shirley Setia"
                    },
                    DateRegistered = new DateTime(2019,04,11),
                    AdditionalRequest = "Nothing",
                    RegistrationDay = new List<RegistrationDay>
                    {
                       new RegistrationDay
                       {
                           EventDay =  new Day
                           {
                               Id=1,
                               Label = "Day 1"
                           }
                       },
                       new RegistrationDay
                       {
                           EventDay =  new Day
                           {
                               Id=2,
                               Label = "Day 2"
                           }
                       }
                    }
                },

                new Registration
                {
                    Id = 2,
                    User = new User
                    {
                        EmailId = "Shreya@gmail.com",
                        Gender = new Gender{ Label = "Female",Value = "F"},
                        Name = "Shreya Ghoshal"
                    },
                    DateRegistered = new DateTime(2019,04,10),
                    AdditionalRequest = "Nothing",
                    RegistrationDay = new List<RegistrationDay>
                    {
                        new RegistrationDay
                        {
                            EventDay =  new Day
                            {
                                Id=1,
                                Label = "Day 1"
                            }
                        }
                    }
                }
            };
        }
        public Registration Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Registration> GetAll()
        {
            return _registrations;
        }

        public bool Add(Registration item)
        {
            try
            {
                item.Id = GetAll().Max(m => m.Id) + 1;
                _registrations.Add(item);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(Registration item)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Registration item)
        {
            throw new NotImplementedException();
        }
    }
}

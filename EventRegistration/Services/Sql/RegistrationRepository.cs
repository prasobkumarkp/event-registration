using EventRegistration.Data;
using EventRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventRegistration.Services.Sql
{
    public class RegistrationRepository:IRepository<Registration>
    {
        private EventRegistrationDbContext _context;

        public RegistrationRepository(EventRegistrationDbContext context)
        {
            _context = context;
        }

        public Registration Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Registration> GetAll()
        {
            var registrations = _context.Registration.ToList();
            foreach (var registration in registrations)
            {
                registration.User = _context.User.FirstOrDefault(f => f.Id == registration.UserId);
                registration.RegistrationDay =
                    _context.RegistrationDay.Where(w => w.RegistrationId == registration.Id).ToList();
            }
            return registrations;
        }

        public bool Add(Registration item)
        {
            try
            {
                item.User.Gender = _context.Gender.SingleOrDefault(s => s.Value == item.User.Gender.Value);
                _context.Registration.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception exception)
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

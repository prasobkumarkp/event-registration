using EventRegistration.Data;
using EventRegistration.Models;
using System;
using System.Collections.Generic;

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
            return _context.EventRegistrations;
        }

        public bool Add(Registration item)
        {
            try
            {
                _context.EventRegistrations.Add(item);
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

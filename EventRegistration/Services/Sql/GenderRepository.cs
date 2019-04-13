using EventRegistration.Data;
using EventRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventRegistration.Services.Sql
{
    public class GenderRepository : IRepository<Gender>
    {
        private EventRegistrationDbContext _context;

        public GenderRepository(EventRegistrationDbContext context)
        {
            _context = context;
            if ((this.GetAll()?.Count() <= 0))
            {
                _context.Gender.AddRange(new List<Gender>
                {
                    new Gender
                    {
                        Label = "Male",
                        Value = "M"
                    },
                    new Gender
                    {
                        Label = "Female",
                        Value = "F"
                    }
                });
                _context.SaveChanges();
            }
        }

        public Gender Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Gender> GetAll()
        {
            return _context.Gender;
        }

        public bool Add(Gender item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Gender item)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Gender item)
        {
            throw new NotImplementedException();
        }
    }
}

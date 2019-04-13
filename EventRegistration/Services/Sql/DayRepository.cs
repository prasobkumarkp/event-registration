using EventRegistration.Data;
using EventRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventRegistration.Services.Sql
{
    public class DayRepository:IRepository<Day>
    {
        private EventRegistrationDbContext _context;

        public DayRepository(EventRegistrationDbContext context)
        {
            _context = context;
            if ((this.GetAll()?.Count() <= 0))
            {
                _context.Day.AddRange(new List<Day>
                {
                    new Day
                    {
                        Label = "Day 1"
                    },
                    new Day
                    {
                        Label = "Day 2"
                    },
                    new Day
                    {

                        Label = "Day 3"
                    }
                });
                _context.SaveChanges();
            }
        }

        public Day Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Day> GetAll()
        {
            return _context.Day;
        }

        public bool Add(Day item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Day item)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Day item)
        {
            throw new NotImplementedException();
        }
    }
}

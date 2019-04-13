using EventRegistration.Models;
using System;
using System.Collections.Generic;

namespace EventRegistration.Services.Mocks
{
    public class MockDayRepository : IRepository<Day>
    {
        private List<Day> _eventDays;
        public MockDayRepository()
        {
            _eventDays = new List<Day>
            {
                new Day
                {
                    Id = 1,
                    Label = "Day 1"
                },
                new Day
                {
                    Id = 1,
                    Label = "Day 2"
                },
                new Day
                {
                    Id = 1,
                    Label = "Day 3"
                }
            };
        }
        public Day Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Day> GetAll()
        {
            return _eventDays;
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

using EventRegistration.Models;
using System;
using System.Collections.Generic;

namespace EventRegistration.Services.Mocks
{
    public class MockGenderRepository:IRepository<Gender>
    {
        private List<Gender> _genders;
        public MockGenderRepository()
        {
            _genders = new List<Gender>
            {
                new Gender
                {
                    Id = 1,
                    Label = "Male",
                    Value = "M"
                },
                new Gender
                {
                    Id = 2,
                    Label = "Female",
                    Value = "F"
                }
            };
        }

        public Gender Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Gender> GetAll()
        {
            return _genders;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Housing.Data.Domain;
using Housing.Data.Client;
using Housing.Data.Domain.CRUD;
using Housing.Data.Domain.DataAccessObjects;

namespace Housing.Data.Test
{

    public class InsertTest
    {
        //private readonly HousingDB_DevEntities db;
        public AccessMapper mapper = new AccessMapper();
        private AccessHelper ah = new AccessHelper();


        [Fact]
        public void InsertGenderTest()
        {
            var expected = true;
            var actual = ah.InsertGender(new GenderDao { Name = "Alien" });
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InsertBatchTest()
        {
            var newBatch = new BatchDao
            {
                Name = "name",
                Instructor = "instructor",
                StartDate = new DateTime(),
                EndDate = new DateTime(),
                Technology = "technology"
            };
            var expected = true;
            var actual = ah.InsertBatch(newBatch);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InsertAssociateTest()
        {
            var newAss = new AssociateDao
            {
                FirstName = "fn",
                LastName = "ln",
                Gender = new GenderDao { Name = "male" },
                Batch = new BatchDao
                {
                    Name = "name",
                    Instructor = "instructor",
                    StartDate = new DateTime(),
                    EndDate = new DateTime(),
                    Technology = "technology"
                },
                PhoneNumber = "1234567890",
                Email = "a@b.c",
                DateOfBirth = new DateTime(),
                HasCar = true,
                HasKeys = true
            };
            var expected = true;
            var actual = ah.InsertAssociate(newAss);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InsertHousingComplexTest()
        {
            var newBatch = new BatchDao
            {
                Name = "name",
                Instructor = "instructor",
                StartDate = new DateTime(),
                EndDate = new DateTime(),
                Technology = "technology"
            };
            var expected = true;
            var actual = ah.InsertGender(new GenderDao { Name = "Alien" });
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InsertHousingDataTest()
        {
            var newBatch = new BatchDao
            {
                Name = "name",
                Instructor = "instructor",
                StartDate = new DateTime(),
                EndDate = new DateTime(),
                Technology = "technology"
            };
            var expected = true;
            var actual = ah.InsertGender(new GenderDao { Name = "Alien" });
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InsertHousingUnitTest()
        {
            var newBatch = new BatchDao
            {
                Name = "name",
                Instructor = "instructor",
                StartDate = new DateTime(),
                EndDate = new DateTime(),
                Technology = "technology"
            };
            var expected = true;
            var actual = ah.InsertGender(new GenderDao { Name = "Alien" });
            Assert.Equal(expected, actual);
        }
    }
}

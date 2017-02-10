using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Housing.Data;
using Housing.Data.Domain.DataAccessObjects;
using Housing.Data.Domain;

namespace Housing.Data.Test.Data.Domain.Tests.CRUD
{
    public class InsertionTests
    {
        private Housing.Data.Domain.AccessMapper map = new Housing.Data.Domain.AccessMapper();
        private Housing.Data.Domain.CRUD.AccessHelper ah = new Housing.Data.Domain.CRUD.AccessHelper();

        // To run test to pass, must have a unique name.

        [Fact]
        public void Test_InsertGender()
        {
            var expected = true;
            var actual = ah.InsertGender(new GenderDao { Name = "random test gender" });
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_InsertBatch()
        {
            var expected = true;
            var actual = ah.InsertBatch(new BatchDao { Name = "Test1", Instructor = "Test", Technology = "Test" });
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_InsertAssociate()
        {
            DateTime theDate = DateTime.Now;
            var expected = true;
            var actual = ah.InsertAssociate(new AssociateDao
            {
                FirstName = "Test1",
                LastName = "Test1",
                GenderName = "female",
                BatchName = "1702-feb6-net",
                Email = "stuff",
                PhoneNumber = "5555555555",
                DateOfBirth = theDate,
                HasCar = true,
                HasKeys = true
            });
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_InsertHousingComplex()
        {
            var expected = true;
            var actual = ah.InsertHousingComplex(new HousingComplexDao
            { Name = "Test", Address = "test", PhoneNumber = "5555555555" });
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Test_InsertHousingUnit()
        {
            var expected = true;
            var actual = ah.InsertHousingUnit(new HousingUnitDao
            {
                HousingUnitName = "Test22",
                AptNumber = "1800",
                MaxCapacity = 5,
                GenderName = "Female",
                HousingComplexName = "Test"
            });
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Test_InsertHousingData()     // System.NullReferenceException error : 
        {                                       // Object reference not set to an instance of an object
            DateTime theDate = DateTime.Now;
            var expected = true;
            var actual = ah.InsertHousingData(new HousingDataDao
            {
                HousingDataAltId = "q24ag1",
                AssociateEmail = "stuff",
                HousingUnitName = "Test22",
                MoveInDate = theDate,
                MoveOutDate = theDate
            });
            Assert.Equal(expected, actual);
        }

    }
}

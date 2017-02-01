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
        // Cannot use same name even after using ANY of the delete functions. Must be a manual removal from the db
        [Fact]
        public void Test_InsertGender()
        {
            var expected = true;
            var actual = ah.InsertGender(new GenderDao { Name = "undefinedtest4" });
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_InsertBatch()
        {
            var expected = true;
            var actual = ah.InsertBatch(new BatchDao { Name = "Test1", Instructor = "Test", Technology = "Test" });
            Assert.Equal(expected, actual);
        }

        //InsertAssociate
        Associate associate = new Associate()
        {
            FirstName = "First",
            LastName = "Last",
            GenderId = 1,
            BatchId = 1,
            PhoneNumber = "7321231233",
            Email = "come@me.net",
            HasCar = true,
            HasKeys = true
        };
        //[Fact]
        //public void Test_InsertAssociate()
        //{

        //    var actual = ah.InsertAssociate(associate);
        //}
        /*
         Error happening 
        [Fact]
        public void Test_InsertAssociate()
        {
            DateTime theDate = DateTime.Now;
            var expected = true;
            var actual = ah.InsertAssociate(new AssociateDao { FirstName = "Test1",
                LastName ="Test1", GenderName="female", BatchName= "1702-feb6-net", Email="stuff",
                PhoneNumber ="5555555555", DateOfBirth= theDate, HasCar=true, HasKeys=true });
            Assert.Equal(expected, actual);
        }

    */
        //InsertHousingComplex

        [Fact]
        public void Test_InsertHousingComplex()
        {
            var expected = true;
            var actual = ah.InsertHousingComplex(new HousingComplexDao
            { Name = "Test", Address = "test", PhoneNumber = "5555555555" });
            Assert.Equal(expected, actual);
        }

        //InsertHousingUnit
        /*
                 Error happening 
        [Fact]
        public void Test_InsertHousingUnit()
        {
            var expected = true;
            var actual = ah.InsertHousingUnit(new HousingUnitDao
            { HousingUnitName="Test", HousingComplexName="Test", AptNumber="1999" });
            Assert.Equal(expected, actual);
        }

    */
        //InsertHousingData
        /*
         Error happening 
        [Fact]
        public void Test_InsertHousingData()
        {
            var expected = true;
            var actual = ah.InsertHousingData(new HousingDataDao
            { HousingUnitName = "Camden Dulles Station 1409", HousingDataAltId="q24tqgag", AssociateEmail="something" });
            Assert.Equal(expected, actual);
        }
        */
    }
}

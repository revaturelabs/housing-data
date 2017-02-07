using Housing.Data.Domain.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Housing.Data.Test.Data.Domain.Tests.CRUD
{
    public class DeletionTests
    {
        private Housing.Data.Domain.AccessMapper map = new Housing.Data.Domain.AccessMapper();
        private Housing.Data.Domain.CRUD.AccessHelper ah = new Housing.Data.Domain.CRUD.AccessHelper();

        // Every Delete function changes the active bit to 0 and does not remove from database.
        // It does however add a long string at the end of the name,
        // to allow the insert tests to add the same name again.        
        

        [Fact]
        public void Test_DeleteGender()
        {
            var expected = true;
            var actual = ah.DeleteGender(new GenderDao { Name = "random test gender" });
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_DeleteBatch()
        {
            var expected = true;
            var actual = ah.DeleteBatch(new BatchDao { Name = "Test1" });
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_DeleteAssociate()      
        {
            var expected = true;
            var actual = ah.DeleteAssociate(new AssociateDao { Email = "stuff" });
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Test_DeleteHousingComplex()
        {
            var expected = true;
            var actual = ah.DeleteHousingComplex(new HousingComplexDao { Name = "Test" });
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_DeleteHousingUnit()
        {
            var expected = true;
            var actual = ah.DeleteHousingUnit(new HousingUnitDao { HousingUnitName = "Test", AptNumber = "1800",
                MaxCapacity = 5, GenderName = "Female", HousingComplexName = "Test" });
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_DeleteHousingData()
        {
            var expected = true;
            var actual = ah.DeleteHousingData(new HousingDataDao { HousingDataAltId = "q24tqgag",
                AssociateEmail = "stuff", HousingUnitName = "Test" });
            Assert.Equal(expected, actual);
        }
    }
}

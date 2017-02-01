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

        
        // DeleteGender only changes the active bit to 0, does not remove from database.
        // Tests will run even if the active bit is already at 0
        [Fact]
        public void Test_DeleteGender()
        {
            var expected = true;
            var actual = ah.DeleteGender(new GenderDao { Name = "undefinedtest3" });
            Assert.Equal(expected, actual);
        }

        // DeleteBatch only changes the active bit to 0, does not remove from database.
        [Fact]
        public void Test_DeleteBatch()
        {
            var expected = true;
            var actual = ah.DeleteBatch(new BatchDao { Name = "Test1" });
            Assert.Equal(expected, actual);
        }


        //DeleteAssociate


        //DeleteHousingComplex only changes the active bit to 0, does not remove from database.
        [Fact]
        public void Test_DeleteHousingComplex()
        {
            var expected = true;
            var actual = ah.DeleteHousingComplex(new HousingComplexDao { Name = "teset" });
            Assert.Equal(expected, actual);
        }

        //DeleteHousingUnit

        //DeleteHousingData
    }
}

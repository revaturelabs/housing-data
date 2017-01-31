using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Housing.Data;
using Housing.Data.Domain.DataAccessObjects;


namespace Housing.Data.Test.Data.Domain.Tests.CRUD
{
    public class InsertionTests
    {
        private Housing.Data.Domain.AccessMapper map = new Housing.Data.Domain.AccessMapper();
        private Housing.Data.Domain.CRUD.AccessHelper ah = new Housing.Data.Domain.CRUD.AccessHelper();

        // To run test to pass, must have a unique name.
        // Cannot use same name even after using the DeleteGender function
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
            var actual = ah.InsertBatch(new BatchDao { Name = "Test1", Instructor="Test", Technology="Test" });
            Assert.Equal(expected, actual);
        }

        //InsertAssociate

        //InsertHousingComplex

        //InsertHousingUnit

        //InsertHousingData
    }
}

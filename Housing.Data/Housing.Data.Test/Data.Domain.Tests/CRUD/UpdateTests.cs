using Housing.Data.Domain.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Housing.Data.Test.Data.Domain.Tests.CRUD
{
    public class UpdateTests
    {
        private Housing.Data.Domain.AccessMapper map = new Housing.Data.Domain.AccessMapper();
        private Housing.Data.Domain.CRUD.AccessHelper ah = new Housing.Data.Domain.CRUD.AccessHelper();

        [Fact]
        public void Test_UpdateGender()
        {
            var expected = true;
            var oldId = "random test gender";
            var actual = ah.UpdateGender(oldId, new GenderDao { Name = "UPDATE random test gender" });
            Assert.Equal(expected, actual);
        }

        /*
        [Fact]
        public void Test_UpdateBatch()
        {
            var expected = true;
            var oldId = "Test1";
            var actual = ah.UpdateBatch(oldId, new BatchDao { Name = "UPDATE Test1" });
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_UpdateAssociate()
        {
            var expected = true;
            var oldId = "random test gender";
            var actual = ah.UpdateAssociate(oldId, new AssociateDao {  });
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_UpdateHousingComplex()
        {
            var expected = true;
            var oldId = "random test gender";
            var actual = ah.UpdateHousingComplex(oldId, new HousingComplexDao {  });
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Test_UpdateHousingUnit()
        {
            var expected = true;
            var oldId = "random test gender";
            var actual = ah.UpdateHousingUnit(oldId, new HousingUnitDao {  });
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_UpdateHousingData()
        {
            var expected = true;
            var oldId = "random test gender";
            var actual = ah.UpdateHousingData(oldId, new HousingDataDao {  });
            Assert.Equal(expected, actual);
        }

    */
    }
}

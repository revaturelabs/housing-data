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
        public void Test_UpdateGender()     // no errors
        {
            var expected = true;
            var oldId = "UPDATE random test gender";
            var actual = ah.UpdateGender(oldId, new GenderDao { Name = "UPDATE2 random test gender" });
            Assert.Equal(expected, actual);
        }
                      
        
        [Fact]
        public void Test_UpdateBatch()      // Assert.Equal() Failure // It is getting false for some reason
        {
            var expected = true;
            var oldId = "Test1";
            var actual = ah.UpdateBatch(oldId, new BatchDao { Name = "UPDATE Test1" });
            Assert.Equal(expected, actual);
        }
      
        
        [Fact]
        public void Test_UpdateAssociate()      // Assert.Equal() Failure // It is getting false for some reason
        {
            var expected = true;
            var oldemail = "stuff";
            var actual = ah.UpdateAssociate(oldemail, new AssociateDao { Email = "UPDATE stuff"  });
            Assert.Equal(expected, actual);
        }
        
        
        [Fact]
        public void Test_UpdateHousingComplex()     // Assert.Equal() Failure // It is getting false for some reason
        {
            var expected = true;
            var oldName = "Test";
            var actual = ah.UpdateHousingComplex(oldName, new HousingComplexDao {Name = "UPDATE test"  });
            Assert.Equal(expected, actual);
        }
        
        
        [Fact]
        public void Test_UpdateHousingUnit()    // Assert.Equal() Failure // It is getting false for some reason
        {
            var expected = true;
            var oldname = "Test22";
            var actual = ah.UpdateHousingUnit(oldname, new HousingUnitDao { HousingUnitName ="UPDATE test22"  });
            Assert.Equal(expected, actual);
        }
        

        [Fact]
        public void Test_UpdateHousingData()
        {
            var expected = true;
            var oldId = "random test gender";
            var actual = ah.UpdateHousingData(oldId, new HousingDataDao { });
            Assert.Equal(expected, actual);
        } 

    }
}

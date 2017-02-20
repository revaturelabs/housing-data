using Housing.Data.Domain.DataAccessObjects;
using Housing.Data.Domain.Helper;
using Moq;
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
            var myRepositoryMock = new Mock<IEF>();

            var itemUpdated = new List<GenderDao>();

            myRepositoryMock
                .Setup(i => i.UpdateGender(It.IsAny<string>(),It.IsAny<GenderDao>()))
                .Callback((string name, GenderDao item) => itemUpdated.Add(item));
            
        }
                      
        
        [Fact]
        public void Test_UpdateBatch()      
        {
            var myRepositoryMock = new Mock<IEF>();

            var itemUpdated = new List<BatchDao>();

            myRepositoryMock
                .Setup(i => i.UpdateBatch(It.IsAny<string>(), It.IsAny<BatchDao>()))
                .Callback((string name, BatchDao item) => itemUpdated.Add(item));
        }
      
        
        [Fact]
        public void Test_UpdateAssociate()      
        {
            var myRepositoryMock = new Mock<IEF>();

            var itemUpdated = new List<AssociateDao>();

            myRepositoryMock
                .Setup(i => i.UpdateAssociate(It.IsAny<string>(), It.IsAny<AssociateDao>()))
                .Callback((string name, AssociateDao item) => itemUpdated.Add(item));
        }
        
        
        [Fact]
        public void Test_UpdateHousingComplex()     
        {
            var myRepositoryMock = new Mock<IEF>();

            var itemUpdated = new List<HousingComplexDao>();

            myRepositoryMock
                .Setup(i => i.UpdateHousingComplex(It.IsAny<string>(), It.IsAny<HousingComplexDao>()))
                .Callback((string name, HousingComplexDao item) => itemUpdated.Add(item));
        }
        
        
        [Fact]
        public void Test_UpdateHousingUnit()    
        {
            var myRepositoryMock = new Mock<IEF>();

            var itemUpdated = new List<HousingUnitDao>();

            myRepositoryMock
                .Setup(i => i.UpdateHousingUnit(It.IsAny<string>(), It.IsAny<HousingUnitDao>()))
                .Callback((string name, HousingUnitDao item) => itemUpdated.Add(item));
        }
        

        [Fact]
        public void Test_UpdateHousingData()
        {
            var myRepositoryMock = new Mock<IEF>();

            var itemUpdated = new List<HousingDataDao>();

            myRepositoryMock
                .Setup(i => i.UpdateHousingData(It.IsAny<string>(), It.IsAny<HousingDataDao>()))
                .Callback((string name, HousingDataDao item) => itemUpdated.Add(item));
        } 

    }
}

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
            var myRepositoryMock = new Mock<IEF>();

            var itemToDelete = new List<GenderDao>();

            myRepositoryMock
                .Setup(i => i.DeleteGender(It.IsAny<GenderDao>()))
                .Callback((GenderDao item) => itemToDelete.Remove(item));
        }

        [Fact]
        public void Test_DeleteBatch()
        {
            var myRepositoryMock = new Mock<IEF>();

            var itemToDelete = new List<BatchDao>();

            myRepositoryMock
                .Setup(i => i.DeleteBatch(It.IsAny<BatchDao>()))
                .Callback((BatchDao item) => itemToDelete.Remove(item));
        }

        [Fact]
        public void Test_DeleteAssociate()      
        {
            var myRepositoryMock = new Mock<IEF>();

            var itemToDelete = new List<AssociateDao>();

            myRepositoryMock
                .Setup(i => i.DeleteAssociate(It.IsAny<AssociateDao>()))
                .Callback((AssociateDao item) => itemToDelete.Remove(item));
        }


        [Fact]
        public void Test_DeleteHousingComplex()
        {
            var myRepositoryMock = new Mock<IEF>();

            var itemToDelete = new List<HousingComplexDao>();

            myRepositoryMock
                .Setup(i => i.DeleteHousingComplex(It.IsAny<HousingComplexDao>()))
                .Callback((HousingComplexDao item) => itemToDelete.Remove(item));
        }

        [Fact]
        public void Test_DeleteHousingUnit()
        {
            var myRepositoryMock = new Mock<IEF>();

            var itemToDelete = new List<HousingUnitDao>();

            myRepositoryMock
                .Setup(i => i.DeleteHousingUnit(It.IsAny<HousingUnitDao>()))
                .Callback((HousingUnitDao item) => itemToDelete.Remove(item));
        }

        [Fact]
        public void Test_DeleteHousingData()
        {
            var myRepositoryMock = new Mock<IEF>();

            var itemToDelete = new List<HousingDataDao>();

            myRepositoryMock
                .Setup(i => i.DeleteHousingData(It.IsAny<HousingDataDao>()))
                .Callback((HousingDataDao item) => itemToDelete.Remove(item));
        }
    }
}

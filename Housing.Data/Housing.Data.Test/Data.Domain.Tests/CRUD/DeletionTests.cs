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

        [Fact]
        public void Test_DeleteGender()
        {
            var mock = new Mock<IEF>();

            var itemToDelete = new List<GenderDao>();

            mock
                .Setup(i => i.DeleteGender(It.IsAny<GenderDao>()))
                .Callback((GenderDao item) => itemToDelete.Remove(item));
            Assert.NotNull(itemToDelete);
            mock.Verify(m => m.DeleteGender(It.IsAny<GenderDao>()), Times.Once());
        }

        [Fact]
        public void Test_DeleteBatch()
        {
            var mock = new Mock<IEF>();

            var itemToDelete = new List<BatchDao>();

            mock
                .Setup(i => i.DeleteBatch(It.IsAny<BatchDao>()))
                .Callback((BatchDao item) => itemToDelete.Remove(item));
            Assert.NotNull(itemToDelete);
            mock.Verify(m => m.DeleteBatch(It.IsAny<BatchDao>()), Times.Once());
        }

        [Fact]
        public void Test_DeleteAssociate()
        {
            var mock = new Mock<IEF>();

            var itemToDelete = new List<AssociateDao>();

            mock
                .Setup(i => i.DeleteAssociate(It.IsAny<AssociateDao>()))
                .Callback((AssociateDao item) => itemToDelete.Remove(item));
            Assert.NotNull(itemToDelete);
            mock.Verify(m => m.DeleteAssociate(It.IsAny<AssociateDao>()), Times.Once());
        }


        [Fact]
        public void Test_DeleteHousingComplex()
        {
            var mock = new Mock<IEF>();

            var itemToDelete = new List<HousingComplexDao>();

            mock
                .Setup(i => i.DeleteHousingComplex(It.IsAny<HousingComplexDao>()))
                .Callback((HousingComplexDao item) => itemToDelete.Remove(item));
            Assert.NotNull(itemToDelete);
            mock.Verify(m => m.DeleteHousingComplex(It.IsAny<HousingComplexDao>()), Times.Once());
        }

        [Fact]
        public void Test_DeleteHousingUnit()
        {
            var mock = new Mock<IEF>();

            var itemToDelete = new List<HousingUnitDao>();

            mock
                .Setup(i => i.DeleteHousingUnit(It.IsAny<HousingUnitDao>()))
                .Callback((HousingUnitDao item) => itemToDelete.Remove(item));
            Assert.NotNull(itemToDelete);
            mock.Verify(m => m.DeleteHousingUnit(It.IsAny<HousingUnitDao>()), Times.Once());
        }

        [Fact]
        public void Test_DeleteHousingData()
        {
            var mock = new Mock<IEF>();

            var itemToDelete = new List<HousingDataDao>();

            mock
                .Setup(i => i.DeleteHousingData(It.IsAny<HousingDataDao>()))
                .Callback((HousingDataDao item) => itemToDelete.Remove(item));
            Assert.NotNull(itemToDelete);
            mock.Verify(m => m.DeleteHousingData(It.IsAny<HousingDataDao>()), Times.Once());
        }
    }
}

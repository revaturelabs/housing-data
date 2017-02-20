using Housing.Data.Domain;
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

            var itemToDelete = new List<Gender>();

            mock
                .Setup(i => i.DeleteGender(It.IsAny<Gender>()))
                .Callback((Gender item) => itemToDelete.Remove(item));
            Assert.NotNull(itemToDelete);
            mock.Verify(m => m.DeleteGender(It.IsAny<Gender>()), Times.Once());
        }

        [Fact]
        public void Test_DeleteBatch()
        {
            var mock = new Mock<IEF>();

            var itemToDelete = new List<Batch>();

            mock
                .Setup(i => i.DeleteBatch(It.IsAny<Batch>()))
                .Callback((Batch item) => itemToDelete.Remove(item));
            Assert.NotNull(itemToDelete);
            mock.Verify(m => m.DeleteBatch(It.IsAny<Batch>()), Times.Once());
        }

        [Fact]
        public void Test_DeleteAssociate()
        {
            var mock = new Mock<IEF>();

            var itemToDelete = new List<Associate>();

            mock
                .Setup(i => i.DeleteAssociate(It.IsAny<Associate>()))
                .Callback((Associate item) => itemToDelete.Remove(item));
            Assert.NotNull(itemToDelete);
            mock.Verify(m => m.DeleteAssociate(It.IsAny<Associate>()), Times.Once());
        }


        [Fact]
        public void Test_DeleteHousingComplex()
        {
            var mock = new Mock<IEF>();

            var itemToDelete = new List<HousingComplex>();

            mock
                .Setup(i => i.DeleteHousingComplex(It.IsAny<HousingComplex>()))
                .Callback((HousingComplex item) => itemToDelete.Remove(item));
            Assert.NotNull(itemToDelete);
            mock.Verify(m => m.DeleteHousingComplex(It.IsAny<HousingComplex>()), Times.Once());
        }

        [Fact]
        public void Test_DeleteHousingUnit()
        {
            var mock = new Mock<IEF>();

            var itemToDelete = new List<HousingUnit>();

            mock
                .Setup(i => i.DeleteHousingUnit(It.IsAny<HousingUnit>()))
                .Callback((HousingUnit item) => itemToDelete.Remove(item));
            Assert.NotNull(itemToDelete);
            mock.Verify(m => m.DeleteHousingUnit(It.IsAny<HousingUnit>()), Times.Once());
        }

        [Fact]
        public void Test_DeleteHousingData()
        {
            var mock = new Mock<IEF>();

            var itemToDelete = new List<HousingData>();

            mock
                .Setup(i => i.DeleteHousingData(It.IsAny<HousingData>()))
                .Callback((HousingData item) => itemToDelete.Remove(item));
            Assert.NotNull(itemToDelete);
            mock.Verify(m => m.DeleteHousingData(It.IsAny<HousingData>()), Times.Once());
        }
    }
}

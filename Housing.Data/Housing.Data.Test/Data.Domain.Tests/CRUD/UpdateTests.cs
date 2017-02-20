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
    public class UpdateTests
    {
        private Housing.Data.Domain.AccessMapper map = new Housing.Data.Domain.AccessMapper();
        private Housing.Data.Domain.CRUD.AccessHelper ah = new Housing.Data.Domain.CRUD.AccessHelper();

        [Fact]
        public void Test_UpdateGender()
        {
            var mock = new Mock<IEF>();

            var itemUpdated = new List<Gender>();

            mock
                .Setup(i => i.UpdateGender(It.IsAny<Gender>(), It.IsAny<Gender>()))
                .Callback((string name, Gender item) => itemUpdated.Add(item));
            Assert.NotNull(itemUpdated);
            mock.Verify(m => m.UpdateGender(It.IsAny<Gender>(), It.IsAny<Gender>()), Times.Once());
        }

        [Fact]
        public void Test_UpdateBatch()
        {
            var mock = new Mock<IEF>();

            var itemUpdated = new List<Batch>();

            mock
                .Setup(i => i.UpdateBatch(It.IsAny<Batch>(), It.IsAny<Batch>()))
                .Callback((string name, Batch item) => itemUpdated.Add(item));
            Assert.NotNull(itemUpdated);
            mock.Verify(m => m.UpdateBatch(It.IsAny<Batch>(), It.IsAny<Batch>()), Times.Once());
        }

        [Fact]
        public void Test_UpdateAssociate()
        {
            var mock = new Mock<IEF>();

            var itemUpdated = new List<Associate>();

            mock
                .Setup(i => i.UpdateAssociate(It.IsAny<Associate>(), It.IsAny<Associate>()))
                .Callback((string name, Associate item) => itemUpdated.Add(item));
            Assert.NotNull(itemUpdated);
            mock.Verify(m => m.UpdateAssociate(It.IsAny<Associate>(), It.IsAny<Associate>()), Times.Once());
        }

        [Fact]
        public void Test_UpdateHousingComplex()
        {
            var mock = new Mock<IEF>();

            var itemUpdated = new List<HousingComplex>();

            mock
                .Setup(i => i.UpdateHousingComplex(It.IsAny<HousingComplex>(), It.IsAny<HousingComplex>()))
                .Callback((string name, HousingComplex item) => itemUpdated.Add(item));
            Assert.NotNull(itemUpdated);
            mock.Verify(m => m.UpdateHousingComplex(It.IsAny<HousingComplex>(), It.IsAny<HousingComplex>()), Times.Once());
        }

        [Fact]
        public void Test_UpdateHousingUnit()
        {
            var mock = new Mock<IEF>();

            var itemUpdated = new List<HousingUnit>();

            mock
                .Setup(i => i.UpdateHousingUnit(It.IsAny<HousingUnit>(), It.IsAny<HousingUnit>()))
                .Callback((string name, HousingUnit item) => itemUpdated.Add(item));
            Assert.NotNull(itemUpdated);
            mock.Verify(m => m.UpdateHousingUnit(It.IsAny<HousingUnit>(), It.IsAny<HousingUnit>()), Times.Once());
        }

        [Fact]
        public void Test_UpdateHousingData()
        {
            var mock = new Mock<IEF>();

            var itemUpdated = new List<HousingData>();

            mock
                .Setup(i => i.UpdateHousingData(It.IsAny<HousingData>(), It.IsAny<HousingData>()))
                .Callback((string name, HousingData item) => itemUpdated.Add(item));
            Assert.NotNull(itemUpdated);
            mock.Verify(m => m.UpdateHousingData(It.IsAny<HousingData>(), It.IsAny<HousingData>()), Times.Once());
        }
    }
}

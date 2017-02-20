using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Housing.Data;
using Housing.Data.Domain.DataAccessObjects;
using Housing.Data.Domain;
using Moq;
using System.Data.Entity;
using Housing.Data.Domain.Helper;
using Housing.Data.Domain.CRUD;

namespace Housing.Data.Test.Data.Domain.Tests.CRUD
{
    public class InsertionTests
    {
        private Housing.Data.Domain.AccessMapper map = new Housing.Data.Domain.AccessMapper();
        private Housing.Data.Domain.CRUD.AccessHelper ah = new Housing.Data.Domain.CRUD.AccessHelper();

        [Fact]
        public void Test_InsertGender()
        {
            var mock = new Mock<IEF>();

            var itemsInserted = new List<Gender>();

            mock
                .Setup(i => i.InsertGender(It.IsAny<Gender>()))
                .Callback((Gender item) => itemsInserted.Add(item));
            Assert.NotNull(itemsInserted);
            mock.Verify(m => m.InsertGender(It.IsAny<Gender>()), Times.Once());
        }

        [Fact]
        public void Test_InsertBatch()
        {
            var mock = new Mock<IEF>();

            var itemsInserted = new List<Batch>();

            mock
                .Setup(i => i.InsertBatch(It.IsAny<Batch>()))
                .Callback((Batch item) => itemsInserted.Add(item));
            Assert.NotNull(itemsInserted);
            mock.Verify(m => m.InsertBatch(It.IsAny<Batch>()), Times.Once());
        }

        [Fact]
        public void Test_InsertAssociate()
        {
            var mock = new Mock<IEF>();

            var itemsInserted = new List<Associate>();

            mock
                .Setup(i => i.InsertAssociate(It.IsAny<Associate>()))
                .Callback((Associate item) => itemsInserted.Add(item));
            Assert.NotNull(itemsInserted);
            mock.Verify(m => m.InsertAssociate(It.IsAny<Associate>()), Times.Once());
        }

        [Fact]
        public void Test_InsertHousingComplex()
        {
            var mock = new Mock<IEF>();

            var itemsInserted = new List<HousingComplex>();

            mock
                .Setup(i => i.InsertHousingComplex(It.IsAny<HousingComplex>()))
                .Callback((HousingComplex item) => itemsInserted.Add(item));
            Assert.NotNull(itemsInserted);
            mock.Verify(m => m.InsertHousingComplex(It.IsAny<HousingComplex>()), Times.Once());
        }

        [Fact]
        public void Test_InsertHousingUnit()
        {
            var mock = new Mock<IEF>();

            var itemsInserted = new List<HousingUnit>();

            mock
                .Setup(i => i.InsertHousingUnit(It.IsAny<HousingUnit>()))
                .Callback((HousingUnit item) => itemsInserted.Add(item));
            Assert.NotNull(itemsInserted);
            mock.Verify(m => m.InsertHousingUnit(It.IsAny<HousingUnit>()), Times.Once());
        }

        [Fact]
        public void Test_InsertHousingData()
        {
            var mock = new Mock<IEF>();

            var itemsInserted = new List<HousingData>();

            mock
                .Setup(i => i.InsertHousingData(It.IsAny<HousingData>()))
                .Callback((HousingData item) => itemsInserted.Add(item));
            Assert.NotNull(itemsInserted);
            mock.Verify(m => m.InsertHousingData(It.IsAny<HousingData>()), Times.Once());
        }
    }
}

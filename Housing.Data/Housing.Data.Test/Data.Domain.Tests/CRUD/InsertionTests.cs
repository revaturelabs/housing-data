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

        // To run test to pass, must have a unique name.

        [Fact]
        public void Test_InsertGender()
        {
            var myRepositoryMock = new Mock<IEF>();

            var itemsInserted = new List<GenderDao>();

            myRepositoryMock
                .Setup(i => i.InsertGender(It.IsAny<GenderDao>()))
                .Callback((GenderDao item) => itemsInserted.Add(item));
        }

        [Fact]
        public void Test_InsertBatch()
        {
            var myRepositoryMock = new Mock<IEF>();

            var itemsInserted = new List<BatchDao>();

            myRepositoryMock
                .Setup(i => i.InsertBatch(It.IsAny<BatchDao>()))
                .Callback((BatchDao item) => itemsInserted.Add(item));
        }

        [Fact]
        public void Test_InsertAssociate()
        {
            var myRepositoryMock = new Mock<IEF>();

            var itemsInserted = new List<AssociateDao>();

            myRepositoryMock
                .Setup(i => i.InsertAssociate(It.IsAny<AssociateDao>()))
                .Callback((AssociateDao item) => itemsInserted.Add(item));
        }

        [Fact]
        public void Test_InsertHousingComplex()
        {
            var myRepositoryMock = new Mock<IEF>();

            var itemsInserted = new List<HousingComplexDao>();

            myRepositoryMock
                .Setup(i => i.InsertHousingComplex(It.IsAny<HousingComplexDao>()))
                .Callback((HousingComplexDao item) => itemsInserted.Add(item));
        }


        [Fact]
        public void Test_InsertHousingUnit()
        {
            var myRepositoryMock = new Mock<IEF>();

            var itemsInserted = new List<HousingUnitDao>();

            myRepositoryMock
                .Setup(i => i.InsertHousingUnit(It.IsAny<HousingUnitDao>()))
                .Callback((HousingUnitDao item) => itemsInserted.Add(item));
        }


        [Fact]
        public void Test_InsertHousingData()
        {
            var myRepositoryMock = new Mock<IEF>();

            var itemsInserted = new List<HousingDataDao>();

            myRepositoryMock
                .Setup(i => i.InsertHousingData(It.IsAny<HousingDataDao>()))
                .Callback((HousingDataDao item) => itemsInserted.Add(item));
        }

    }
}

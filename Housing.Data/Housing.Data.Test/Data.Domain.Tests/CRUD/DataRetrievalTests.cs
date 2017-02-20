using Housing.Data.Domain.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Housing.Data.Domain.Helper;
using Moq;
using Housing.Data.Domain.DataAccessObjects;
using Housing.Data.Domain;

namespace Housing.Data.Test.Data.Domain.Tests.CRUD
{

    public class DataRetrievalTests
    {
        
        

        [Fact]
        public void Test_GetAssociates()
        {
            var mock = new Mock<IEF>();
            mock.Setup(m => m.GetAssociates()).Returns(new List<Associate>());
            AccessHelper ah = new AccessHelper(mock.Object);
            var associates = ah.GetAssociates();
            Assert.NotNull(associates);
            mock.Verify(m => m.GetAssociates(), Times.Once);
        }


        [Fact]
        public void Test_GetBatches()
        {
            var mock = new Mock<IEF>();
            mock.Setup(m => m.GetBatches()).Returns(new List<Batch>());
            AccessHelper ah = new AccessHelper(mock.Object);
            var batch = ah.GetBatches();
            Assert.NotNull(batch);
            mock.Verify(m => m.GetBatches(), Times.Once);
        }

        [Fact]
        public void Test_GetGenders()
        {
            var mock = new Mock<IEF>();
            mock.Setup(m => m.GetGenders()).Returns(new List<Gender>());
            AccessHelper ah = new AccessHelper(mock.Object);
            var gender = ah.GetGenders();
            Assert.NotNull(gender);
            mock.Verify(m => m.GetGenders(), Times.Once);
        }

        [Fact]
        public void Test_GetHousingComplexes()
        {
            var mock = new Mock<IEF>();
            mock.Setup(m => m.GetHousingComplexes()).Returns(new List<HousingComplex>());
            AccessHelper ah = new AccessHelper(mock.Object);
            var hc = ah.GetHousingComplexes();
            Assert.NotNull(hc);
            mock.Verify(m => m.GetHousingComplexes(), Times.Once);
        }

        [Fact]
        public void Test_GetHousingUnits()
        {
            var mock = new Mock<IEF>();
            mock.Setup(m => m.GetHousingUnits()).Returns(new List<HousingUnit>());
            AccessHelper ah = new AccessHelper(mock.Object);
            var hu = ah.GetHousingUnits();
            Assert.NotNull(hu);
            mock.Verify(m => m.GetHousingUnits(), Times.Once);
        }

        [Fact]
        public void Test_GetHousingData()
        {
            var mock = new Mock<IEF>();
            mock.Setup(m => m.GetHousingData()).Returns(new List<HousingData>());
            AccessHelper ah = new AccessHelper(mock.Object);
            var hd = ah.GetHousingData();
            Assert.NotNull(hd);
            mock.Verify(m => m.GetHousingData(), Times.Once);
        }

        //[Fact]
        //public void Test_GetUnitsByComplexName()
        //{
        //    AccessHelper db = new AccessHelper();
        //    string Name = "Camden Dulles Station";
        //    var units = db.GetUnitsByComplex(Name);
        //    Assert.NotEmpty(units);
        //}

        //[Fact]
        //public void Test_GetDataByUnitName()
        //{
        //    AccessHelper db = new AccessHelper();
        //    string Name = "Camden Dulles Station 1409";
        //    var data = db.GetDataByUnit(Name);
        //    Assert.NotEmpty(data);
        //}


    }
}

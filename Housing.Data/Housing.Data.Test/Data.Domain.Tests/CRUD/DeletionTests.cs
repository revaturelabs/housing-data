using Housing.Data.Domain;
using Housing.Data.Domain.CRUD;
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
    public partial class UnitTests
    {

        [Fact]
        public void Test_DeleteGender()
        {
            AccessHelper a = new AccessHelper();
            var x = a.GetGenders().Where(i => i.Name == gender.Name).FirstOrDefault();
            var mock = new Mock<IEF>();

            mock.Setup(i => i.DeleteGender(It.IsAny<Gender>())).Returns(true);
            AccessHelper ah = new AccessHelper(mock.Object);
            
            var g = ah.DeleteGender(x);
            Assert.True(g);
            mock.Verify(m => m.DeleteGender(It.IsAny<Gender>()), Times.Once());
        }

        [Fact]
        public void Test_DeleteBatch()
        {
            AccessHelper a = new AccessHelper();
            var x = a.GetBatches().Where(i => i.Name == batch.Name).FirstOrDefault();
            var mock = new Mock<IEF>();

            mock.Setup(i => i.DeleteBatch(It.IsAny<Batch>())).Returns(true);
            AccessHelper ah = new AccessHelper(mock.Object);
            var b = ah.DeleteBatch(batch);
            Assert.True(b);
            mock.Verify(m => m.DeleteBatch(It.IsAny<Batch>()), Times.Once());
        }

        [Fact]
        public void Test_DeleteAssociate()
        {
            AccessHelper h = new AccessHelper();
            var x = h.GetAssociates().Where(i => i.Email == associate.Email).FirstOrDefault();
            var mock = new Mock<IEF>();

            mock.Setup(i => i.DeleteAssociate(It.IsAny<Associate>())).Returns(true);
            AccessHelper ah = new AccessHelper(mock.Object);
            var a = ah.DeleteAssociate(associate);
            Assert.True(a);
            mock.Verify(m => m.DeleteAssociate(It.IsAny<Associate>()), Times.Once());
        }


        [Fact]
        public void Test_DeleteHousingComplex()
        {
            AccessHelper a = new AccessHelper();
            var x = a.GetHousingComplexes().Where(i => i.Name == hc.Name).FirstOrDefault();
            var mock = new Mock<IEF>();

            mock.Setup(i => i.DeleteHousingComplex(It.IsAny<HousingComplex>())).Returns(true);
            AccessHelper ah = new AccessHelper(mock.Object);
            var h = ah.DeleteHousingComplex(hc);
            Assert.True(h);
            mock.Verify(m => m.DeleteHousingComplex(It.IsAny<HousingComplex>()), Times.Once());
        }

        [Fact]
        public void Test_DeleteHousingUnit()
        {
            AccessHelper a = new AccessHelper();
            var x = a.GetHousingUnits().Where(i => i.HousingUnitName == hu.HousingUnitName).FirstOrDefault();
            var mock = new Mock<IEF>();

            mock.Setup(i => i.DeleteHousingUnit(It.IsAny<HousingUnit>())).Returns(true);
            AccessHelper ah = new AccessHelper(mock.Object);
            var u = ah.DeleteHousingUnit(hu);
            Assert.True(u);
            mock.Verify(m => m.DeleteHousingUnit(It.IsAny<HousingUnit>()), Times.Once());
        }

        [Fact]
        public void Test_DeleteHousingData()
        {
            AccessHelper a = new AccessHelper();
            var x = a.GetHousingData().Where(i => i.HousingDataAltId == hd.HousingDataAltId).FirstOrDefault();
            var mock = new Mock<IEF>();

            mock.Setup(i => i.DeleteHousingData(It.IsAny<HousingData>())).Returns(true);
            AccessHelper ah = new AccessHelper(mock.Object);
            var d = ah.DeleteHousingData(hd);
            Assert.True(d);
            mock.Verify(m => m.DeleteHousingData(It.IsAny<HousingData>()), Times.Once());
        }
    }
}

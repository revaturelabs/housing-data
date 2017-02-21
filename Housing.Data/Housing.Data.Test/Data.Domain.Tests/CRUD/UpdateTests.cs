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
        public void Test_UpdateGender()
        {
            AccessHelper h = new AccessHelper();
            var gold = h.GetGenders().FirstOrDefault(i => i.Name == gender.Name).ToString();
            var mock = new Mock<IEF>();

            mock.Setup(i => i.UpdateGender(It.IsAny<Gender>(), It.IsAny<Gender>())).Returns(true);
            AccessHelper ah = new AccessHelper(mock.Object);
            
            var g = ah.UpdateGender(gold, gender);
            Assert.True(g);
            mock.Verify(m => m.UpdateGender(It.IsAny<Gender>(), It.IsAny<Gender>()), Times.Once());
        }

        [Fact]
        public void Test_UpdateBatch()
        {
            AccessHelper a = new AccessHelper();
            var bold = a.GetBatches().FirstOrDefault(i => i.Name == batch.Name).ToString();
            var mock = new Mock<IEF>();

            mock.Setup(i => i.UpdateBatch(It.IsAny<Batch>(), It.IsAny<Batch>())).Returns(true);
            AccessHelper ah = new AccessHelper(mock.Object);
            
            var b = ah.UpdateBatch(bold, batch);
            Assert.True(b);
            mock.Verify(m => m.UpdateBatch(It.IsAny<Batch>(), It.IsAny<Batch>()), Times.Once());
        }

        [Fact]
        public void Test_UpdateAssociate()
        {
            AccessHelper h = new AccessHelper();
            var old = h.GetAssociates().FirstOrDefault(i => i.Email == associate.Email).ToString();
            var mock = new Mock<IEF>();

            mock.Setup(i => i.UpdateAssociate(It.IsAny<Associate>(), It.IsAny<Associate>())).Returns(true);
            AccessHelper ah = new AccessHelper(mock.Object);
            
            var a = ah.UpdateAssociate(old, associate);
            Assert.True(a);
            mock.Verify(m => m.UpdateAssociate(It.IsAny<Associate>(), It.IsAny<Associate>()), Times.Once());
        }

        [Fact]
        public void Test_UpdateHousingComplex()
        {
            AccessHelper a = new AccessHelper();
            var cold = a.GetHousingComplexes().FirstOrDefault(i => i.Name == hc.Name).ToString();
            var mock = new Mock<IEF>();

            mock.Setup(i => i.UpdateHousingComplex(It.IsAny<HousingComplex>(), It.IsAny<HousingComplex>())).Returns(true);
            AccessHelper ah = new AccessHelper(mock.Object);
            
            var h = ah.UpdateHousingComplex(cold, hc);
            Assert.True(h);
            mock.Verify(m => m.UpdateHousingComplex(It.IsAny<HousingComplex>(), It.IsAny<HousingComplex>()), Times.Once());
        }

        [Fact]
        public void Test_UpdateHousingUnit()
        {
            AccessHelper a = new AccessHelper();
            var uold = a.GetHousingUnits().FirstOrDefault(i => i.HousingUnitName == hu.HousingUnitName).ToString();
            var mock = new Mock<IEF>();

            mock.Setup(i => i.UpdateHousingUnit(It.IsAny<HousingUnit>(), It.IsAny<HousingUnit>())).Returns(true);
            AccessHelper ah = new AccessHelper(mock.Object);
            
            var u = ah.UpdateHousingUnit(uold, hu);
            Assert.True(u);
            mock.Verify(m => m.UpdateHousingUnit(It.IsAny<HousingUnit>(), It.IsAny<HousingUnit>()), Times.Once());
        }

        [Fact]
        public void Test_UpdateHousingData()
        {
            AccessHelper a = new AccessHelper();
            var dold = a.GetHousingData().FirstOrDefault(i => i.HousingDataAltId == hd.HousingDataAltId).ToString();
            var mock = new Mock<IEF>();

            mock.Setup(i => i.UpdateHousingData(It.IsAny<HousingData>(), It.IsAny<HousingData>())).Returns(true);
            AccessHelper ah = new AccessHelper(mock.Object);
            
            var d = ah.UpdateHousingData(dold, hd);
            Assert.True(d);
            mock.Verify(m => m.UpdateHousingData(It.IsAny<HousingData>(), It.IsAny<HousingData>()), Times.Once());
        }
    }
}

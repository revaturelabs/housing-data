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
            var mock = new Mock<IEF>();

            mock
                .Setup(i => i.DeleteGender(It.IsAny<Gender>())).Returns(true);
            AccessHelper ah = new AccessHelper(mock.Object);
            var g = ah.DeleteGender(gender);
            Assert.True(g);
            mock.Verify(m => m.DeleteGender(It.IsAny<Gender>()), Times.Once());
        }

        [Fact]
        public void Test_DeleteBatch()
        {
            var mock = new Mock<IEF>();

            mock
                .Setup(i => i.DeleteBatch(It.IsAny<Batch>())).Returns(true);
            AccessHelper ah = new AccessHelper(mock.Object);
            var b = ah.DeleteBatch(batch);
            Assert.True(b);
            mock.Verify(m => m.DeleteBatch(It.IsAny<Batch>()), Times.Once());
        }

        [Fact]
        public void Test_DeleteAssociate()
        {
            var mock = new Mock<IEF>();

            mock
                .Setup(i => i.DeleteAssociate(It.IsAny<Associate>())).Returns(true);
            AccessHelper ah = new AccessHelper(mock.Object);
            var a = ah.DeleteAssociate(associate);
            Assert.True(a);
            mock.Verify(m => m.DeleteAssociate(It.IsAny<Associate>()), Times.Once());
        }


        [Fact]
        public void Test_DeleteHousingComplex()
        {
            var mock = new Mock<IEF>();

            mock
                .Setup(i => i.DeleteHousingComplex(It.IsAny<HousingComplex>())).Returns(true);
            AccessHelper ah = new AccessHelper(mock.Object);
            var h = ah.DeleteHousingComplex(hc);
            Assert.True(h);
            mock.Verify(m => m.DeleteHousingComplex(It.IsAny<HousingComplex>()), Times.Once());
        }

        [Fact]
        public void Test_DeleteHousingUnit()
        {
            var mock = new Mock<IEF>();

            mock
                .Setup(i => i.DeleteHousingUnit(It.IsAny<HousingUnit>())).Returns(true);
            AccessHelper ah = new AccessHelper(mock.Object);
            var u = ah.DeleteHousingUnit(hu);
            Assert.True(u);
            mock.Verify(m => m.DeleteHousingUnit(It.IsAny<HousingUnit>()), Times.Once());
        }

        [Fact]
        public void Test_DeleteHousingData()
        {
            var mock = new Mock<IEF>();

            mock
                .Setup(i => i.DeleteHousingData(It.IsAny<HousingData>())).Returns(true);
            AccessHelper ah = new AccessHelper(mock.Object);
            var d = ah.DeleteHousingData(hd);
            Assert.True(d);
            mock.Verify(m => m.DeleteHousingData(It.IsAny<HousingData>()), Times.Once());
        }
    }
}

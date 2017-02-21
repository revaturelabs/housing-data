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
using Housing.Data.Domain.Helper;
using Housing.Data.Domain.CRUD;

namespace Housing.Data.Test.Data.Domain.Tests.CRUD
{
    public partial class UnitTests
    {
        private Housing.Data.Domain.AccessMapper map = new Housing.Data.Domain.AccessMapper();
        private Housing.Data.Domain.CRUD.AccessHelper ah = new Housing.Data.Domain.CRUD.AccessHelper();

        public GenderDao gender = new GenderDao()
        {
            Name = "male"
        };

        public BatchDao batch = new BatchDao()
        {
            Name = "Dot net",
            Instructor = "Fred",
            Technology = "C#",
            StartDate = DateTime.Parse("03/03/2017"),
            EndDate = DateTime.Parse("06/15/2017")
        };

        public AssociateDao associate = new AssociateDao()
        {
            FirstName = "Joe",
            LastName = "Blow",
            GenderName = "Male",
            BatchName = "Dot net",
            PhoneNumber = "7321231233",
            DateOfBirth = DateTime.Parse("01/10/1990"),
            Email = "test@test.com",
            HasCar = true,
            HasKeys = true,
            NeedsHousing = true
        };

        public HousingComplexDao hc = new HousingComplexDao()
        {
            Name = "The Townes",
            PhoneNumber = "555-555-5555",
            Address = "506 Pride Ave"
        };

        public HousingUnitDao hu = new HousingUnitDao()
        {
            HousingUnitName = "test",
            HousingComplexName = "The Townes",
            AptNumber = "600",
            GenderName = "Male",
            MaxCapacity = 6,
            LeaseEndDate = DateTime.Parse("06/30/2017")
        };

        public HousingDataDao hd = new HousingDataDao()
        {
            HousingDataAltId = "The Townes test",
            HousingUnitName = "test",
            AssociateEmail = "test@test.com",
            MoveInDate = DateTime.Parse("02/28/2017"),
            MoveOutDate = DateTime.Parse("06/30/2017")
        };


        [Fact]
        public void Test_InsertGender()
        {
            var mock = new Mock<IEF>();

            mock.Setup(i => i.InsertGender(It.IsAny<Gender>())).Returns(true);
            AccessHelper ah = new AccessHelper(mock.Object);
            var g = ah.InsertGender(gender);
            Assert.True(g);
            mock.Verify(m => m.InsertGender(It.IsAny<Gender>()), Times.Once());
        }

        [Fact]
        public void Test_InsertBatch()
        {
            var mock = new Mock<IEF>();

            mock.Setup(i => i.InsertBatch(It.IsAny<Batch>())).Returns(true);
            AccessHelper ah = new AccessHelper(mock.Object);
            var b = ah.InsertBatch(batch);
            Assert.True(b);
            mock.Verify(m => m.InsertBatch(It.IsAny<Batch>()), Times.Once());
        }

        [Fact]
        public void Test_InsertAssociate()
        {

            var mock = new Mock<IEF>();

            mock.Setup(i => i.InsertAssociate(It.IsAny<Associate>())).Returns(true);

            AccessHelper ah = new AccessHelper(mock.Object);
         
            var a = ah.InsertAssociate(associate);
            Assert.True(a);
            mock.Verify(m => m.InsertAssociate(It.IsAny<Associate>()), Times.Once());
        }

        [Fact]
        public void Test_InsertHousingComplex()
        {
            var mock = new Mock<IEF>();

            mock.Setup(i => i.InsertHousingComplex(It.IsAny<HousingComplex>())).Returns(true);
            AccessHelper ah = new AccessHelper(mock.Object);
            var h = ah.InsertHousingComplex(hc);
            Assert.True(h);
            mock.Verify(m => m.InsertHousingComplex(It.IsAny<HousingComplex>()), Times.Once());
        }

        [Fact]
        public void Test_InsertHousingUnit()
        {
            var mock = new Mock<IEF>();
            
            mock.Setup(i => i.InsertHousingUnit(It.IsAny<HousingUnit>())).Returns(true);
            AccessHelper ah = new AccessHelper(mock.Object);
            var h = ah.InsertHousingUnit(hu);
            Assert.True(h);
            mock.Verify(m => m.InsertHousingUnit(It.IsAny<HousingUnit>()), Times.Once());
        }

        [Fact]
        public void Test_InsertHousingData()
        {
            var mock = new Mock<IEF>();
            
            mock.Setup(i => i.InsertHousingData(It.IsAny<HousingData>())).Returns(true);
            AccessHelper ah = new AccessHelper(mock.Object);
            var h = ah.InsertHousingData(hd);
            Assert.True(h);
            mock.Verify(m => m.InsertHousingData(It.IsAny<HousingData>()), Times.Once());
        }
    }
}

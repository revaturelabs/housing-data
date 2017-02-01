using System;
using Xunit;
using System.Linq;
using Housing.Data.Domain.DataAccessObjects;
using Housing.Data.Domain.CRUD;

namespace Housing.Data.Test
{
    // This is just used for referencing different types of tests
    // and none of these tests should/would work in the actual app
   
    public class TestReferences
    {
        //using xunit
        #region workforce.data.associates2.accesstests
        /*
             AccessHelper ah = new AccessHelper();
        Address address = new Address()
        {
          City = "Perth Amboy",
          State = "New Jersery",
          Country = "USA",
          zipcode = "08861",
          address1 = "500 High st",
          address2 = "apt 4",
          Primary = true,
        };
        Batch batch = new Batch()
        {
          Name = "C#",
          Instructor = 1,
          StartDate = DateTime.Now,
          EndDate = DateTime.Now,
          Section = "1B" + DateTime.Now,
        };
        Gender gender = new Gender()
        {
          Name = "Male"
        };
        AssociateAddress associateAddress = new AssociateAddress()
        {
          AssociateID = 2,
          AddressID = 1
        };
        Instructor instructor = new Instructor()
        {
          FirstName = "Jimmy",
          LastName = "Johns"
        };
        Associate associate = new Associate()
        {
          FirstName = "First",
          LastName = "Last",
          GenderID = 1,
          BatchID = 1,
          PhoneNumber = "7321231233",
          Email = "come@me.net" + DateTime.Now,
          HasCar = true,
          HasKeys = true
        };
        */
        #region gets
        /*
      [Fact]
      public void Test_GetAssociates()
      {
        Assert.True(ah.GetAssociates().Count >= 1);
      }
      [Fact]
      public void Test_GetAddress()
      {
        Assert.True(ah.GetAddress().Count >= 0);
      }
      [Fact]
      public void Test_GetAssociateAddress()
      {
        Assert.True(ah.GetAssociateAddress().Count >= 0);
      }
      [Fact]
      public void Test_GetBatch()
      {
        Assert.True(ah.GetBatch().Count >= 1);
      }
      [Fact]
      public void Test_GetGender()
      {
        Assert.True(ah.GetGender().Count >= 1);
      }
      [Fact]
      public void Test_GetInstructor()
      {
        Assert.True(ah.GetInstructor().Count >= 1);
      }
      */
        #endregion

        #region inserts
        /*
        [Fact]
        public void Test_InsertAddress()
        {
          Assert.True(ah.InsertAddress(address));
        }
        [Fact]
        public void Test_InsertBatch()
        {
          batch.Section = "string" + DateTime.Now;
          Assert.True(ah.InsertBatch(batch));
        }
        [Fact]
        public void Test_InsertAssociateAddress()
        {
          Assert.True(ah.InsertAssociateAddress(associateAddress));
        }
        [Fact]
        public void Test_InsertGender()
        {
          Assert.True(ah.InsertGender(gender));
        }
        [Fact]
        public void Test_InsertInstructor()
        {
          Assert.True(ah.InsertInstructor(instructor));
        }
        [Fact]
        public void Test_InsertAssociate()
        {
          Assert.True(ah.InsertAssociate(associate));
        }
        */
        #endregion

        #region updates
        /*
      [Fact]
      public void Test_UpdateAddress()
      {
        address.AddressId = 1;
        address.address1 = "update address" + DateTime.Now;
        Assert.True(ah.UpdateAddress(address));
      }
      [Fact]
      public void Test_UpdateBatch()
      {
        batch.BatchId = 1;
        batch.Name = "C# Update";
        Assert.True(ah.UpdateBatch(batch));
      }
      [Fact]
      public void Test_UpdateAssociateAddress()
      {
        associateAddress.AssociateAddressID = 1;
        associateAddress.AssociateID = 2;
        Assert.True(ah.UpdateAssociateAddress(associateAddress));
      }
      [Fact]
      public void Test_UpdateGender()
      {
        gender.GenderId = 3;
        gender.Name = "updated" + DateTime.Now;
        Assert.True(ah.UpdateGender(gender));
      }
      [Fact]
      public void Test_UpdateInstructor()
      {
        instructor.InstructorId = 1;
        instructor.FirstName = "updated" + DateTime.Now;
        Assert.True(ah.UpdateInstructor(instructor));
      }
      [Fact]
      public void Test_UpdateAssociate()
      {
        associate.AssociateID = 20;
        associate.FirstName = "updated";
        Assert.True(ah.UpdateAssociate(associate));
      }
      */
        #endregion

        #region deletes
        /*
      [Fact]
      public void Test_DeleteAddress()
      {
        address.AddressId = 1;
        Assert.True(ah.DeleteAddress(address));
      }
      [Fact]
      public void Test_DeleteBatch()
      {
        Assert.True(ah.DeleteBatch(batch));
      }
      [Fact]
      public void Test_DeleteAssociateAddress()
      {
        associateAddress.AssociateAddressID = 1;
        Assert.True(ah.DeleteAssociateAddress(associateAddress));
      }
      [Fact]
      public void Test_DeleteGender()
      {
        gender.GenderId = 3;
        Assert.True(ah.DeleteGender(gender));
      }
      [Fact]
      public void Test_DeleteInstructor()
      {
        instructor.InstructorId = 1;
        Assert.True(ah.DeleteInstructor(instructor));
      }
      [Fact]
      public void Test_DeleteAssociate()
      {
        associate.AssociateID = 2;
        Assert.True(ah.DeleteAssociate(associate));
      }
      */
        #endregion

        #endregion

        //using xunit
        #region workforce.data.associates2.soaptests
        /*
        AssociateService fs = new AssociateService();
        AddressDao address = new AddressDao()
        {
          City = "Perth Amboy",
          State = "New Jersery",
          Country = "USA",
          Zipcode = "08861",
          Address1 = "500 High st",
          Address2 = "apt 4",
          Primary = true,
        };
        BatchDao batch = new BatchDao()
        {
          Name = "C#",
          Instructor = 1,
          StartDate = DateTime.Now,
          EndDate = DateTime.Now,
          Section = "1B" + DateTime.Now,
        };
        GenderDao gender = new GenderDao()
        {
          Name = "Male"
        };

        AssociateAddressDao associateAddress = new AssociateAddressDao()
        {
          AssociateID = 2,
          AddressID = 1
        };
        InstructorDao instructor = new InstructorDao()
        {
          InstructorId = 2,
          FirstName = "Jimmy",
          LastName = "Johns"
        };
        AssociateDao associate = new AssociateDao()
        {
          FirstName = "First",
          LastName = "Last",
          GenderID = 1,
          BatchID = 1,
          PhoneNumber = "7321231233",
          Email = "come@me.net" + DateTime.Now,
          HasCar = true,
          HasKeys = true
        };
        */

        #region gets
        /*
        [Fact]
        public void Test_GetInstructor()
        {
          var instructors = fs.GetInstructor();
          Assert.True(instructors.Count > 0);
        }
        [Fact]
        public void Test_GetAddress()
        {
          var address = fs.GetAddress();
          Assert.True(address.Count > 0);
        }
        [Fact]
        public void Test_GetAssociateAddress()
        {
          var aa = fs.GetAssociateAddress();
          Assert.True(aa.Count > 0);
        }
        [Fact]
        public void Test_GetAssocaite()
        {
          var a = fs.GetAssociates();
          Assert.True(a.Count > 0);
        }
        */
        #endregion

        #region inserts
        /*
        [Fact]
        public void Test_InsertAddress()
        {
          var a = fs.InsertAddress(address);
        }
        [Fact]
        public void Test_InsertAssociateAddress()
        {
          var a = fs.InsertAssociateAddress(associateAddress);
        }
        [Fact]
        public void Test_InsertAssociate()
        {
          var a = fs.InsertAssociate(associate);
        }
        [Fact]
        public void Test_InsertBatch()
        {
          var a = fs.InsertBatch(batch);
        }
        [Fact]
        public void Test_InsertGender()
        {
          var a = fs.InsertGender(gender);
        }
        [Fact]
        public void Test_InsertInstructor()
        {
          var a = fs.InsertInstructor(instructor);
        }
        */
        #endregion

        #region updates
        /*
        [Fact]
        public void Test_UpdateBatch()
        {
          var a = fs.UpdateBatch(batch);
          Assert.True(a);
        }
        [Fact]
        public void Test_UpdateGender()
        {
          var a = fs.UpdateGender(gender);
          Assert.True(a);
        }
        [Fact]
        public void Test_UpdateAddress()
        {
          var a = fs.UpdateAddress(address);
          Assert.True(a);
        }
        [Fact]
        public void Test_UpdateInstructor()
        {
          instructor.FirstName = "updated" + DateTime.Now;
          var a = fs.UpdateInstructor(instructor);
          Assert.True(a);
        }
        [Fact]
        public void Test_UpdateAssociate()
        {
          var a = fs.UpdateAssociate(associate);
          Assert.True(a);
        }
        [Fact]
        public void Test_UpdateAssociateAddress()
        {
          var a = fs.UpdateAssociateAddress(associateAddress);
          Assert.True(a);
        }
        */
        #endregion

        #region deletes
        /*
        public void Test_DeleteAddress()
        {
          var a = fs.DeleteAddress(address);
          Assert.True(a);
        }
        public void Test_DeleteAssociate()
        {
          var a = fs.DeleteAssociate(associate);
          Assert.True(a);
        }
        public void Test_DeleteAssociateAddress()
        {
          var a = fs.DeleteAssociateAddress(associateAddress);
          Assert.True(a);
        }
        public void Test_DeleteBatch()
        {
          var a = fs.DeleteBatch(batch);
          Assert.True(a);
        }
        public void Test_DeleteGender()
        {
          var a = fs.DeleteGender(gender);
          Assert.True(a);
        }
        public void Test_DeleteInstructor()
        {
          var a = fs.DeleteInstructor(instructor);
          Assert.True(a);
        }
        */
        #endregion

        #endregion

        //using moq & xunit
        #region workforce.data.housing.tests
        /*
      AccessHelper ah = new AccessHelper();
      Apartment apt = new Apartment()
      {
        HotelID = 1,
        RoomNumber = 1,
        CurrentCapacity = 5,
        MaxCapacity = 6,
        GenderID = 1,
        ActiveBit = true,
      };
      HousingComplex hc = new HousingComplex()
      {
        HotelID = 100,
        Name = "some name",
        Address = "some address",
        IsHotel = false,
        PhoneNumber = "7325555555",
        ActiveBit = true
      };
      HousingData hd = new HousingData()
      {
        AssociateID = 100,
        MoveInDate = DateTime.Today,
        MoveOutDate = DateTime.Today
      };
      Status status = new Status()
      {
        StatusID = 100,
        StatusColor = "red",
        StatusMessage = "mess",
        ActiveBit = true
      };
      */
        #region gets
        /*
        [Fact]
        public void Test_GetApartments()
        {
          var data = new List<Apartment>
                {
                    apt
                }.AsQueryable();

          var mockSet = new Mock<DbSet<Apartment>>();
          mockSet.As<IQueryable<Apartment>>().Setup(m => m.Provider).Returns(data.Provider);
          mockSet.As<IQueryable<Apartment>>().Setup(m => m.Expression).Returns(data.Expression);
          mockSet.As<IQueryable<Apartment>>().Setup(m => m.ElementType).Returns(data.ElementType);
          mockSet.As<IQueryable<Apartment>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

          var mockContext = new Mock<WorkforceHousingDB_Entities>();
          mockContext.Setup(c => c.Apartment).Returns(mockSet.Object);

          var access = new AccessHelper(mockContext.Object);
          var apts = access.GetApartments();

          Assert.Equal(1, apts.Count);
          Assert.Equal(6, apts[0].MaxCapacity);
          Assert.Equal(5, apts[0].CurrentCapacity);
        }
        [Fact]
        public void Test_GetHousingComplexes()
        {
          var data = new List<HousingComplex>
                {
                    hc
                }.AsQueryable();

          var mockSet = new Mock<DbSet<HousingComplex>>();
          mockSet.As<IQueryable<HousingComplex>>().Setup(m => m.Provider).Returns(data.Provider);
          mockSet.As<IQueryable<HousingComplex>>().Setup(m => m.Expression).Returns(data.Expression);
          mockSet.As<IQueryable<HousingComplex>>().Setup(m => m.ElementType).Returns(data.ElementType);
          mockSet.As<IQueryable<HousingComplex>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

          var mockContext = new Mock<WorkforceHousingDB_Entities>();
          mockContext.Setup(c => c.HousingComplex).Returns(mockSet.Object);

          var access = new AccessHelper(mockContext.Object);
          var housingComplexes = access.GetComplexes();

          Assert.Equal(1, housingComplexes.Count);
          Assert.Equal("some name", housingComplexes[0].Name);
          Assert.Equal("some address", housingComplexes[0].Address);
        }
        [Fact]
        public void Test_GetHousingData()
        {
          var data = new List<HousingData>
                {
                    hd
                }.AsQueryable();

          var mockSet = new Mock<DbSet<HousingData>>();
          mockSet.As<IQueryable<HousingData>>().Setup(m => m.Provider).Returns(data.Provider);
          mockSet.As<IQueryable<HousingData>>().Setup(m => m.Expression).Returns(data.Expression);
          mockSet.As<IQueryable<HousingData>>().Setup(m => m.ElementType).Returns(data.ElementType);
          mockSet.As<IQueryable<HousingData>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

          var mockContext = new Mock<WorkforceHousingDB_Entities>();
          mockContext.Setup(c => c.HousingData).Returns(mockSet.Object);

          var access = new AccessHelper(mockContext.Object);
          var housingData = access.GetHousingData();

          Assert.Equal(1, housingData.Count);
          Assert.Equal(DateTime.Today, housingData[0].MoveInDate);
          Assert.Equal(DateTime.Today, housingData[0].MoveOutDate);
        }
        [Fact]
        public void Test_GetStatus()
        {
          var data = new List<Status>
                {
                    status
                }.AsQueryable();

          var mockSet = new Mock<DbSet<Status>>();
          mockSet.As<IQueryable<Status>>().Setup(m => m.Provider).Returns(data.Provider);
          mockSet.As<IQueryable<Status>>().Setup(m => m.Expression).Returns(data.Expression);
          mockSet.As<IQueryable<Status>>().Setup(m => m.ElementType).Returns(data.ElementType);
          mockSet.As<IQueryable<Status>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

          var mockContext = new Mock<WorkforceHousingDB_Entities>();
          mockContext.Setup(c => c.Status).Returns(mockSet.Object);

          var access = new AccessHelper(mockContext.Object);
          var statuses = access.GetStatuses();

          Assert.Equal(1, statuses.Count);
          Assert.Equal("mess", statuses[0].StatusMessage);
          Assert.Equal("red", statuses[0].StatusColor);
        }
        */
        #endregion

        #region inserts
        /*
        [Fact]
        public void Test_InsertApartments()
        {
          var mockSet = new Mock<DbSet<Apartment>>();

          var mockContext = new Mock<WorkforceHousingDB_Entities>();
          mockContext.Setup(m => m.Apartment).Returns(mockSet.Object);

          var access = new AccessHelper(mockContext.Object);
          access.InsertApartment(apt);

          mockSet.Verify(m => m.Add(It.IsAny<Apartment>()), Times.Once());
          mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        [Fact]
        public void Test_InsertHousingComplex()
        {
          var mockSet = new Mock<DbSet<HousingComplex>>();

          var mockContext = new Mock<WorkforceHousingDB_Entities>();
          mockContext.Setup(m => m.HousingComplex).Returns(mockSet.Object);

          var access = new AccessHelper(mockContext.Object);
          access.InsertHousingComplex(hc);

          mockSet.Verify(m => m.Add(It.IsAny<HousingComplex>()), Times.Once());
          mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        [Fact]
        public void Test_InsertHousingData()
        {
          var mockSet = new Mock<DbSet<HousingData>>();

          var mockContext = new Mock<WorkforceHousingDB_Entities>();
          mockContext.Setup(m => m.HousingData).Returns(mockSet.Object);

          var access = new AccessHelper(mockContext.Object);
          access.InsertHousingData(hd);

          mockSet.Verify(m => m.Add(It.IsAny<HousingData>()), Times.Once());
          mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        [Fact]
        public void Test_InsertStatus()
        {
          var mockSet = new Mock<DbSet<Status>>();

          var mockContext = new Mock<WorkforceHousingDB_Entities>();
          mockContext.Setup(m => m.Status).Returns(mockSet.Object);

          var access = new AccessHelper(mockContext.Object);
          access.InsertStatus(status);

          mockSet.Verify(m => m.Add(It.IsAny<Status>()), Times.Once());
          mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        */
        #endregion

        #region updates
        /*
        [Fact]
        public void Test_UpdateApartments()
        {
          Assert.True(ah.UpdateApartment(apt));
        }
        [Fact]
        public void Test_UpdateHousingComplex()
        {
          Assert.True(ah.UpdateHousingComplex(hc));
        }
        [Fact]
        public void Test_UpdateHousingData()
        {
          Assert.True(ah.UpdateHousingData(hd));
        }
        [Fact]
        public void Test_UpdateStatus()
        {
          Assert.True(ah.UpdateStatus(status));
        }
        */
        #endregion

        #region deletes
        /*
        [Fact]
        public void Test_DeleteApartments()
        {
          Assert.True(ah.DeleteApartment(apt));
        }
        [Fact]
        public void Test_DeleteHousingComplex()
        {
          Assert.True(ah.DeleteHousingComplex(hc));
        }
        [Fact]
        public void Test_DeleteHousingData()
        {
          Assert.True(ah.DeleteHousingData(hd));
        }
        [Fact]
        public void Test_DeleteStatus()
        {
          Assert.True(ah.DeleteStatus(status));
        }
        */
        #endregion



        #endregion

        //using xunit

        #region revashare-db tests

        private AccessHelper ah = new AccessHelper();
        #region inserts

        [Fact]
        public void insertGenderTest()
        {
            var actual = ah.InsertGender(new GenderDao { Name = "Pangender" });
            Assert.True(actual);
        }
        [Fact]
        public void insertBatchTest()
        {
            var actual = ah.InsertBatch(new BatchDao {EndDate=DateTime.Now, Instructor="test instructor", Name="new test batch",
                                                        StartDate=DateTime.Now, Technology="test technology"});
            Assert.True(actual);
        }
        [Fact]
        public void insertAssocTest()
        {
            var assoc = new AssociateDao();
            assoc.BatchName = "new test batch";
            assoc.DateOfBirth = DateTime.MinValue;
            assoc.Email = "a@b.c";
            assoc.FirstName = "fname";
            assoc.GenderName = "Pangender";
            assoc.HasCar = true;
            assoc.HasKeys = true;
            assoc.LastName = "lname";
            assoc.PhoneNumber = "123456789";
            var actual = ah.InsertAssociate(assoc);
            Assert.True(actual);
        }
        [Fact]
        public void insertHousingDataTest()
        {
            var data = new HousingDataDao();
            data.AssociateEmail = "a@b.c";
            data.HousingDataAltId = "A123B456";
            data.HousingUnitName = "test complex name 88888";
            data.MoveInDate = DateTime.Now;
            data.MoveOutDate = DateTime.Now;
            var actual = ah.InsertHousingData(data);
            Assert.True(actual);
        }
        [Fact]
        public void insertComplexTest()
        {
            var complex = new HousingComplexDao();
            complex.Address = "test address";
            complex.Name = "test complex name";
            complex.PhoneNumber = "9876543210"; 
            var actual = ah.InsertHousingComplex(complex);
            Assert.True(actual);
        }
        [Fact]
        public void insertUnitTest()
        {
            var unit = new HousingUnitDao();
            unit.AptNumber = "88888";
            unit.GenderName = "Pangender";
            unit.HousingComplexName = "test complex name";
            unit.HousingUnitName = "test complex name 88888";
            unit.MaxCapacity = 6;
            var actual = ah.InsertHousingUnit(unit);
            Assert.True(actual);
        }
        #endregion

        #region gets

        [Fact]
        public void GetGenderTest()
        {
            var actual = ah.GetGenders();
            Assert.NotEmpty(actual);
        }

        [Fact]
        public void GetBatchTest()
        {
            var actual = ah.GetBatches();
            Assert.NotEmpty(actual);
        }
        [Fact]
        public void GetAssociatesTest()
        {
            var actual = ah.GetAssociates();
            Assert.NotEmpty(actual);
        }
        [Fact]
        public void GetHousingDataTest()
        {
            var actual = ah.GetHousingData();
            Assert.NotEmpty(actual);
        }
        [Fact]
        public void GetComplexTest()
        {
            var actual = ah.GetHousingComplexes();
            Assert.NotEmpty(actual);
        }
        [Fact]
        public void GetHousingUnitsTest()
        {
            var actual = ah.GetHousingUnits();
            Assert.NotEmpty(actual);
        }

        #endregion

        #region deletes
        [Fact]
        public void deleteGenderTest()
        {
            var toDelete = ah.GetGenders().Where(m => m.Name.Equals("Alien")).FirstOrDefault();
            var actual = ah.DeleteGender(toDelete);
            Assert.True(actual);
        }
        #endregion  

        /*
        #region Ride Tests
        RevaShareData Data = new RevaShareData();
        private RevaShareDataService svc = new RevaShareDataService();

        //Create and Delete Related Methods
        [Fact]
        public void AddRideDeleteRide_Test()
        {
          RevaShareDataService svc = new RevaShareDataService();

          TimeSpan testTime = new TimeSpan(8, 30, 00);
          DateTime testStartDate = new DateTime(2016, 11, 22);
          VehicleDAO testVehicle = svc.GetVehicles().ToList().Where(v => v.Owner.UserName == "jimbob").First();
          UserDAO testUser = svc.GetUserByUsername(testVehicle.Owner.UserName);

          RideDAO rideToAdd = new RideDAO { DepartureTime = testTime, IsAmRide = true, StartOfWeek = testStartDate, Vehicle = testVehicle };
          bool resultAddRide = svc.AddRide(rideToAdd);

          RideDAO rideToRemove = svc.GetAllRides().Where(r => r.Vehicle.Owner.UserName == testUser.UserName && r.StartOfWeek == testStartDate).First();
          bool resultDeleteRide = svc.DeleteRide(rideToRemove);

          Assert.True(resultAddRide);
        }


        //Read Related Methods
        [Fact]
        public void GetAllRides_Test()
        {
          RevaShareDataService svc = new RevaShareDataService();
          var actual = svc.GetAllRides();

          foreach (RideDAO ride in actual)
          {
            Debug.WriteLine("Driver: " + ride.Vehicle.Owner.Name + ", Car Model: " + ride.Vehicle.Model + ", Departure Time: " + ride.DepartureTime);
          }

          Assert.NotNull(actual);
        }

        [Fact]
        public void ListRidesAtApartment_Test()
        {
          RevaShareDataService svc = new RevaShareDataService();
          ApartmentDAO existingApt = svc.ListApartments().First();

          var actual = svc.ListRidesAtApartment(existingApt.Name);

          foreach (RideDAO ride in actual)
          {
            Debug.WriteLine("Driver: " + ride.Vehicle.Owner.Name + ", Car Model: " + ride.Vehicle.Model + ", Departure Time: " + ride.DepartureTime);
          }

          Assert.NotNull(actual);
        }

        [Fact]
        public void GetRidesByLocationAM_Test()
        {
          var actual = svc.ListRidesAtApartmentAM("abc");
          Assert.NotNull(actual);
        }

        [Fact]
        public void GetRidesByLocationPM_Test()
        {
          var actual = svc.ListRidesAtApartmentPM("abc");
          Assert.Empty(actual);
        }

        [Fact]
        public void availableSeats_TEST()
        {
          var ride = svc.ListRidesAtApartment("dddd").FirstOrDefault();
          var actual = svc.GetOpenSeats(ride);
          Assert.InRange<int>(actual, 0, ride.Vehicle.Capacity - 1);
        }

        [Fact]
        public void getRide_test()
        {
          var firstride = svc.ListRidesAtApartment("abc").FirstOrDefault();
          var actual = svc.GetRide(firstride);
          Assert.NotNull(actual);
        }


        //Update Related Methods
        [Fact]
        public void UpdateRide_Test()
        {
          RevaShareDataService svc = new RevaShareDataService();

          RideDAO rideToUpdate = svc.GetAllRides().FirstOrDefault();

          rideToUpdate.DepartureTime = new TimeSpan(7, 15, 00);

          bool actual = svc.UpdateRide(rideToUpdate);

          Assert.True(actual);
        }
        */
        #endregion


    }
}

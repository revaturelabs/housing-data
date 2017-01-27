﻿using Housing.Data.Domain.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Housing.Data.Test.Data.Domain.Tests.CRUD
{

    public class DataRetrievalTests
    {
        [Fact]
        public void Test_GetAssociates()
        {
            AccessHelper db = new AccessHelper();

            var associates = db.GetAssociates();
            Assert.NotEmpty(associates);
        }

        [Fact]
        public void Test_GetBatches()
        {
            AccessHelper db = new AccessHelper();

            var batches = db.GetBatches();
            Assert.NotEmpty(batches);
        }

        [Fact]
        public void Test_GetGenders()
        {
            AccessHelper db = new AccessHelper();

            var genders = db.GetGenders();
            Assert.NotEmpty(genders);
        }

        [Fact]
        public void Test_GetHousingComplexes()
        {
            AccessHelper db = new AccessHelper();

            var housingcomplex = db.GetHousingComplexes();
            Assert.NotEmpty(housingcomplex);
        }

        [Fact]
        public void Test_GetHousingUnits()
        {
            AccessHelper db = new AccessHelper();

            var housingunit = db.GetHousingUnits();
            Assert.NotEmpty(housingunit);
        }

        [Fact]
        public void Test_GetHousingData()
        {
            AccessHelper db = new AccessHelper();

            var housingdata = db.GetHousingData();
            Assert.NotEmpty(housingdata);
        }
        
        [Fact]
        public void Test_GetUnitsByComplexID()
        {
            AccessHelper db = new AccessHelper();
            int ID = 1;
            var units = db.GetUnitsByComplex(ID);
            Assert.NotEmpty(units);
        }
        
        [Fact]
        public void Test_GetDataByUnitID()
        {
            AccessHelper db = new AccessHelper();
            int ID = 1;
            var data = db.GetDataByUnit(ID);
            Assert.NotEmpty(data);
        }
        

    }
}
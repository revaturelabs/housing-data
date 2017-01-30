using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Housing.Data;
using Housing.Data.Domain.DataAccessObjects;


namespace Housing.Data.Test.Data.Domain.Tests.CRUD
{
    public class InsertionTests
    {
        private Housing.Data.Domain.AccessMapper map = new Housing.Data.Domain.AccessMapper();
        private Housing.Data.Domain.CRUD.AccessHelper ah = new Housing.Data.Domain.CRUD.AccessHelper();

        [Fact]
        public void insertGenderTest()
        {
            var expected = true;
            var actual = ah.InsertGender(new GenderDao { Name = "undefined" });
            Assert.Equal(expected, actual);
        }
    }
}

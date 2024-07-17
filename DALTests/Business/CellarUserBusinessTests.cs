using DAL.Interfaces;
using DALTests.Business;

namespace DAL.Business.Tests
{
    [TestClass()]
    public class CellarUserBusinessTests
    {
        //[TestMethod()]
        //public void IsAgeValidAsyncTest()
        //{
        //    int age = 10;
        //    ICellarUserBusiness cellarUserBusiness = new CellarUserBusiness();
        //    var isValid = cellarUserBusiness.IsAgeValidAsync(age);
        //    Assert.Equals(isValid, "Valid");
        //}

        [TestMethod()]
        public async Task IsAgeValidAsyncTest()
        {
            // Arrange
            string FirstName = "John";
            DateOnly dob= new DateOnly(1986, 01, 05);

            IUserRepository userRepository = new MockUserRepository();
            ICellarUserBusiness userBusiness = new CellarUserBusiness(userRepository);
     

            // Act
            var valid = await userBusiness.IsAgeValidAsync(dob);

            // Assert
            Assert.AreEqual(valid, "Valid");
        }
    }
}
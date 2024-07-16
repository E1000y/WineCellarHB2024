using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DALTests.Business;
using Models;
using Models.DTOs;

namespace DAL.Business.Tests
{
    [TestClass()]
    public class BottleBusinessTests
    {
        [TestMethod()]
        public async Task IsBottleExistingForDrawerIdAndDrawerPositionAsyncTestTrue()
        {
            //Arrange
            BottleBusiness btbiz = new BottleBusiness(new MockBottleRepository());

            //Act
            var result = await btbiz.IsBottleExistingForDrawerIdAndDrawerPositionAsync(1, 1);


            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public async Task IsBottleExistingForDrawerIdAndDrawerPositionAsyncTestFalse()
        {
            //Arrange

            BottleBusiness btbiz = new BottleBusiness(new MockBottleRepository());

            //Act
            var result = await btbiz.IsBottleExistingForDrawerIdAndDrawerPositionAsync(2, 2);


            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public async Task IsBottleExistingForDrawerIdAndDrawerPositionAndIsNotItselfAsyncTest()
        {

            //Arrange
            BottlePutDTO bottle = new BottlePutDTO()
            {
                Id = 2,
                DrawerId = 1,
                DrawerPosition = 1,
            };
            BottleBusiness btbiz = new BottleBusiness(new MockBottleRepository());
            
            //Act

                bool result = await btbiz.IsBottleExistingForDrawerIdAndDrawerPositionAndIsNotItselfAsync(bottle);

            //Assert
            Assert.IsTrue(result);

        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALTests.Business;
using DAL.Interfaces;
using Models;
using Models.DTOs;

namespace DAL.Business.Tests
{
    [TestClass()]
    public class DrawerBusinessTests
    {
        [TestMethod()]
        public void CheckNoDrawerHasSameNumberThanInDrawerPostDTOTestFailed()
        {


            List<Drawer> drawers = new List<Drawer>()
        {
            new Drawer() { Id = 1, Number = 1, NbOfBottlesPerDrawer = 20, CellarId =1  },
            new Drawer() { Id = 2, Number = 2, NbOfBottlesPerDrawer = 20, CellarId =1  },
            new Drawer() { Id = 3, Number = 3, NbOfBottlesPerDrawer = 20, CellarId =1  },
            new Drawer() { Id = 4, Number = 1, NbOfBottlesPerDrawer = 20, CellarId =2  },
        };

            DrawerPostDTO drawerPostDTO = new DrawerPostDTO()
            {
                Number = 1,
                NbOfBottlesPerDrawer = 15,
                CellarId = 1,
            };

            //Arrange
            DrawerBusiness dbz = new DrawerBusiness(new MockDrawerRepository());



            //Act
            var value = dbz.CheckNoDrawerHasSameNumberThanInDrawerPostDTO(drawerPostDTO, drawers);

            //Assert
            Assert.IsTrue(value);
        }

        [TestMethod()]
        public void CheckNoDrawerHasSameNumberThanInDrawerPostDTOTestPassed()
        {

            //Arrange

            List<Drawer> drawers = new List<Drawer>()
        {
            new Drawer() { Id = 1, Number = 1, NbOfBottlesPerDrawer = 20, CellarId =1  },
            new Drawer() { Id = 2, Number = 2, NbOfBottlesPerDrawer = 20, CellarId =1  },
            new Drawer() { Id = 3, Number = 3, NbOfBottlesPerDrawer = 20, CellarId =1  },
            new Drawer() { Id = 4, Number = 1, NbOfBottlesPerDrawer = 20, CellarId =2  },
        };

            DrawerPostDTO drawerPostDTO = new DrawerPostDTO()
            {
                Number = 4,
                NbOfBottlesPerDrawer = 15,
                CellarId = 1,
            };


            DrawerBusiness dbz = new DrawerBusiness(new MockDrawerRepository());



            //Act
            var value = dbz.CheckNoDrawerHasSameNumberThanInDrawerPostDTO(drawerPostDTO, drawers);

            //Assert
            Assert.IsFalse(value);
        }

        [TestMethod()]
        public async Task IsTrueWhenDrawerWithCellarIdAndNumberExistsAsyncTestTrue()
        {
            DrawerPutDTO drawerPutDTO = new DrawerPutDTO()
            {
                Id = 1,
                Number = 1,
                NbOfBottlesPerDrawer = 20,
                CellarId = 1,

            };
            //Arrange
            DrawerBusiness dbz = new DrawerBusiness(new MockDrawerRepository());


            //Act
            bool value = await dbz.IsTrueWhenDrawerWithCellarIdAndNumberExistsAsync(drawerPutDTO);

            //Assert
            Assert.IsTrue(value);
        }

        [TestMethod()]
        public async Task IsTrueWhenDrawerWithCellarIdAndNumberExistsAsyncTestFalse()
        {
            DrawerPutDTO drawerPutDTO = new DrawerPutDTO()
            {
                Id = 1,
                Number = 5,
                NbOfBottlesPerDrawer = 20,
                CellarId = 1,

            };
            //Arrange
            DrawerBusiness dbz = new DrawerBusiness(new MockDrawerRepository());


            //Act
            bool value = await dbz.IsTrueWhenDrawerWithCellarIdAndNumberExistsAsync(drawerPutDTO);

            //Assert
            Assert.IsFalse(value);
        }

    }
}
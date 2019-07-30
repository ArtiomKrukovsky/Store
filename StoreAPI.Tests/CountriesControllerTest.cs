using System;
using Xunit;
using Moq;
using Store.Domain.Interfaces;
using System.Collections.Generic;
using Store.Domain.Models;
using Store.Controllers;
using System.Web.Mvc;

namespace StoreAPI.Tests
{
    public class CountriesControllerTest
    {
        
        [Fact]
        public void ValidMockSetup()
        {
            Country _country = new Country { CountryId = 3, Name = "China", Continent_Name = "Eurasia" };
            var countryRepositoryMock = new Mock<IRepository<Country>>();
            countryRepositoryMock.Setup(u=> u.Get(It.IsAny<int>())).Returns(()=> null);
            countryRepositoryMock.Setup(u => u.Get(_country.CountryId)).Returns(_country);

            var unitofworkMock = new Mock<IUnitOfWork>();
            unitofworkMock.Setup(s => s.Countries).Returns(countryRepositoryMock.Object);

            var UnitOfWork = unitofworkMock.Object;
            var result = UnitOfWork.Countries.Get(3);

            Assert.Equal(_country, result);
        }

        [Fact]
        public void GetCountriesViewModelIsNot()
        {
            // Arrange
            var mock = new Mock<IRepository<Country>>();
            mock.Setup(a=> a.GetAll()).Returns(new List<Country>());

            var unitofworkMock = new Mock<IUnitOfWork>();
            unitofworkMock.Setup(s => s.Countries).Returns(mock.Object);

            var UnitOfWork = unitofworkMock.Object;
            var result = UnitOfWork.Countries.GetAll();

            Assert.NotNull(result);
        }
    }
}

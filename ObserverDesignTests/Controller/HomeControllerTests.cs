using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ObserverDesign.Deparments;
using ObserverDesign.Subject;
using Moq;
using Xunit;
using ObserverDesign.Controllers;

namespace ObserverDesignTests.Controller
{
    // followed AAA method 
    // Arrange
    // Act
    // Assert
    public class HomeControllerTests
    {
        private readonly Mock<IAsset> _itMock;
        private readonly Mock<IFinance> _financeMock;
        private readonly Mock<IResignation> _resignationMock;
        private readonly Mock<IHR> _hrMock;
        private readonly Mock<Imanager> _managerMock;
        private readonly HomeController _controller;

        public HomeControllerTests()
        {
            _itMock = new Mock<IAsset>();
            _financeMock = new Mock<IFinance>();
            _resignationMock = new Mock<IResignation>();
            _hrMock = new Mock<IHR>();
            _managerMock = new Mock<Imanager>();

            _controller = new HomeController(
                _managerMock.Object,
                _financeMock.Object,
                _itMock.Object,
                _resignationMock.Object,
                _hrMock.Object
            );
        }

        [Fact]
        public void Index_Returns_ViewResult()
        {
            var result = _controller.Index();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void ITDept_Calls_AllocateAsset_And_Returns_ViewResult()
        {
            var result = _controller.ITDept();

            _itMock.Verify(it => it.AllocateAsset(), Times.Once);
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Index", viewResult.ViewName);
        }

        [Fact]
        public void Finance_Calls_CalculateSalary_And_Returns_ViewResult()
        {
            var result = _controller.Finance();
            _financeMock.Verify(finance => finance.CalculateSalary(), Times.Once);
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Index", viewResult.ViewName);
        }

        [Fact]
        public void Hr_Calls_HrLocated_And_Returns_ViewResult()
        {
            var result = _controller.Hr();
            _hrMock.Verify(hr => hr.HrLocated(), Times.Once);
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Index", viewResult.ViewName);
        }

        [Fact]
        public void EmployeeSeprate_Calls_NotifyObserver_And_Returns_ViewResult()
        {
            string employeeId = "123451212";
            var result = _controller.EmployeeSeprate(employeeId);
            _resignationMock.Verify(resignation => resignation.NotifyObserver(employeeId), Times.Once);
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Index", viewResult.ViewName);
        }

        [Fact]
        public void Manager_Returns_Index_View_With_Manager_Message()
        {
            _managerMock.Setup(m => m.AllocateImanager());
            var result = _controller.Manager() as ViewResult;
            _managerMock.Verify(m => m.AllocateImanager(), Times.Once);
            Assert.NotNull(result);
            Assert.Equal("Index", result.ViewName);
            Assert.Equal("Manager - Task Completed", result.ViewData["Dept"]);
        }
    }
}

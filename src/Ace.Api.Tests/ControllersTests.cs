using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tcraft.Ace.Api.Controllers;

namespace Ace.Api.Tests
{
    public class ControllersTests
    {
        private readonly NumberController _numberController;
        private readonly PrimeController _primeController;
        private readonly TempController _tempController;

        public ControllersTests()
        {
            _numberController = new NumberController();
            _primeController = new PrimeController();
            _tempController = new TempController();

            var numberContext = new DefaultHttpContext
            {
                Request =
                {
                    Scheme = "http",
                    Host = new HostString("localhost"),
                    Path = "/api/number"
                }
            };
            _numberController.ControllerContext.HttpContext = numberContext;

            var primeContext = new DefaultHttpContext
            {
                Request =
                {
                    Scheme = "http",
                    Host = new HostString("localhost"),
                    Path = "/api/prime"
                }
            };
            _primeController.ControllerContext.HttpContext = primeContext;

            var tempContext = new DefaultHttpContext
            {
                Request =
                {
                    Scheme = "http",
                    Host = new HostString("localhost"),
                    Path = "/api/temp"
                }
            };
            _tempController.ControllerContext.HttpContext = tempContext;
        }

        // NumberController tests
        [Fact]
        public void GetNumber_ReturnsBadRequest_WhenNIsOutOfRange()
        {
            var result = _numberController.GetNumber(-1);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void GetNumber_ReturnsOk_WhenNIsValid()
        {
            var result = _numberController.GetNumber(10);
            Assert.IsType<OkObjectResult>(result);
        }

        // PrimeController tests
        [Fact]
        public void GetPrimes_ReturnsBadRequest_WhenLimitIsOutOfRange()
        {
            var result = _primeController.GetPrimes(0);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void GetPrimes_ReturnsOk_WhenLimitIsValid()
        {
            var result = _primeController.GetPrimes(100);
            Assert.IsType<OkObjectResult>(result);
        }

        // TempController tests
        [Fact]
        public void GetTemp_ReturnsBadRequest_WhenNeitherCelsiusNorKelvinIsProvided()
        {
            var result = _tempController.GetTemp(null, null);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void GetTemp_ReturnsOk_WhenCelsiusIsProvided()
        {
            var result = _tempController.GetTemp(25, null);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetTemp_ReturnsOk_WhenKelvinIsProvided()
        {
            var result = _tempController.GetTemp(null, 298.15);
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
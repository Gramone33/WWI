using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using WarehouseAPI.Controllers;
using WarehouseAPI.Models;

namespace WarehouseAPITest
{
    public class Tests
    {
        private readonly StockItemDto[] predefinedStockItems = new StockItemDto[] {
            new StockItemDto(){ StockItemID=1, SupplierID=125, StockItemName="A", ColorID=1, ColorName="C1", Barcode="A1", Brand="AA" },
            new StockItemDto(){ StockItemID=2, SupplierID=125, StockItemName="B", ColorID=3, ColorName="C3", Barcode="B2", Brand="AA" },
            new StockItemDto(){ StockItemID=3, SupplierID=125, StockItemName="C", ColorID=2, ColorName="C2", Barcode="C3", Brand="BB" }
        };

        private readonly HoldingDto[] predefinedHoldings = new HoldingDto[] {
            new HoldingDto(){ StockItemID=2, QuantityOnHand=15 },
            new HoldingDto(){ StockItemID=2, QuantityOnHand=13 },
            new HoldingDto(){ StockItemID=2, QuantityOnHand=14 }
        };

        [Test]
        public void ListStockItems_Standard()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<StockItemsController>>();
            var mockRepo = new Mock<IStockRepository>();

            mockRepo.Setup(repo => repo.ListStockItems(125, 1, 3)).Returns(predefinedStockItems);

            var test = new StockItemsController(mockLogger.Object, mockRepo.Object) {
                ControllerContext = new ControllerContext() { 
                    HttpContext = new DefaultHttpContext()
                }
            };
            test.HttpContext.Request.Scheme = "https";
            test.HttpContext.Request.Host = new HostString("api.example.com");
            
            // Act
            var actual = test.ListStockItems(125, new ListStockRequest() { PageSize = 3, PageToken = 1 });

            // Assert
            CollectionAssert.AreEqual(predefinedStockItems, actual.Value.StockItems);
            Assert.AreEqual("https://api.example.com/suppliers/125/stockitems?pageToken=2&pageSize=3", actual.Value.NextPage);
        }

        [Test]
        public void ListStockItems_LastPage()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<StockItemsController>>();
            var mockRepo = new Mock<IStockRepository>();

            mockRepo.Setup(repo => repo.ListStockItems(125, 1, 4)).Returns(predefinedStockItems);

            var test = new StockItemsController(mockLogger.Object, mockRepo.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
            test.HttpContext.Request.Scheme = "https";
            test.HttpContext.Request.Host = new HostString("api.example.com");

            // Act
            var actual = test.ListStockItems(125, new ListStockRequest() { PageSize = 4, PageToken = 1 });

            // Assert
            CollectionAssert.AreEqual(predefinedStockItems, actual.Value.StockItems);
            //Assert.AreEqual(null, actual.Value.NextPage);
            Assert.IsNull(actual.Value.NextPage);
        }

        [Test]
        public void ListStockItems_InvalidPageToken()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<StockItemsController>>();
            var mockRepo = new Mock<IStockRepository>();
            var test = new StockItemsController(mockLogger.Object, mockRepo.Object);

            // Act
            var actual = test.ListStockItems(125, new ListStockRequest() { PageSize = 4, PageToken = -1 });
            var result = actual.Result as ObjectResult;
            
            // Assert
            Assert.AreEqual(StatusCodes.Status400BadRequest, result.StatusCode);
            // ou Assert.IsInstanceOf<BadRequestObjectResult>(actual.Result);
        }

        [Test]
        public void ListHoldings_Standard()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<StockItemsController>>();
            var mockRepo = new Mock<IStockRepository>();

            mockRepo.Setup(repo => repo.ListHoldings(2, 1, 3)).Returns(predefinedHoldings);

            var test = new StockItemsController(mockLogger.Object, mockRepo.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
            test.HttpContext.Request.Scheme = "https";
            test.HttpContext.Request.Host = new HostString("api.example.com");

            // Act
            var actual = test.ListHoldings(2, new ListStockRequest() { PageSize = 3, PageToken = 1 });

            // Assert
            CollectionAssert.AreEqual(predefinedHoldings, actual.Value.Holdings);
            Assert.AreEqual("https://api.example.com/stockitems/2/holdings?pageToken=2&pageSize=3", actual.Value.NextPage);
        }

        [Test]
        public void ListHoldings_LastPage()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<StockItemsController>>();
            var mockRepo = new Mock<IStockRepository>();

            mockRepo.Setup(repo => repo.ListHoldings(2, 1, 4)).Returns(predefinedHoldings);

            var test = new StockItemsController(mockLogger.Object, mockRepo.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
            test.HttpContext.Request.Scheme = "https";
            test.HttpContext.Request.Host = new HostString("api.example.com");

            // Act
            var actual = test.ListHoldings(2, new ListStockRequest() { PageSize = 4, PageToken = 1 });

            // Assert
            CollectionAssert.AreEqual(predefinedHoldings, actual.Value.Holdings);
            Assert.IsNull(actual.Value.NextPage);
        }

        [Test]
        public void ListHoldings_InvalidPageToken()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<StockItemsController>>();
            var mockRepo = new Mock<IStockRepository>();
            var test = new StockItemsController(mockLogger.Object, mockRepo.Object);

            // Act
            var actual = test.ListHoldings(2, new ListStockRequest() { PageSize = 4, PageToken = -1 });
            var result = actual.Result as ObjectResult;

            // Assert
            Assert.AreEqual(StatusCodes.Status400BadRequest, result.StatusCode);
        }

    }
}
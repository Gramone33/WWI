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
            new StockItemDto(){ StockItemID=1, SupplierID=1, StockItemName="A", ColorID=1, ColorName="C1", Barcode="A1", Brand="AA" },
            new StockItemDto(){ StockItemID=2, SupplierID=1, StockItemName="B", ColorID=3, ColorName="C3", Barcode="B2", Brand="AA" },
            new StockItemDto(){ StockItemID=3, SupplierID=1, StockItemName="C", ColorID=2, ColorName="C2", Barcode="C3", Brand="BB" }
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
    }
}
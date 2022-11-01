using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReceiptWebApi.Controllers;
using ReceiptWebApi.Core;
using ReceiptWebApi.Data;
using System;
using System.Collections.Generic;

namespace ReceiptWebApi.Tests
{
    [TestClass]
    public class ReceiptControllerTests
    {
        private Receipt _receipt;
        private Receipt _receipt2;
        private Receipt _receipt3;
        private DateTime _created;
        private DateTime _created2;
        private DateTime _created3;

        private ReceiptWebApiController _controller;
        private IReceiptStorage _receiptStorage;

        [TestInitialize]
        public void Setup()
        {
            _receiptStorage = new ReceiptStorage();
            _controller = new ReceiptWebApiController(_receiptStorage);
            _receipt = new Receipt();
            _created = new DateTime(2019, 1, 1, 23, 30, 00);
            var items = new List<Product>() { new Product("cat"), new Product("dog") };
            _receipt.CreatedOn = _created;
            _receipt.Items = items;

            _receipt2 = new Receipt();
            _created2 = new DateTime(2021, 1, 1, 11, 00, 00);
            var items2 = new List<Product>() { new Product("candy"), new Product("chocolate") };
            _receipt2.CreatedOn = _created2;
            _receipt2.Items = items2;

            _receipt3 = new Receipt();
            _created3 = new DateTime(2022, 5, 1);
            var items3 = new List<Product>() { new Product("saw"), new Product("knife") };
            _receipt3.CreatedOn = _created3;
            _receipt3.Items = items3;
        }

        [TestMethod]
        public void PutReceipt_TestControllerAbilityToPutReceipt_ResultIsNotNull()
        {
            // Act
            var result = _controller.PutReceipt(_receipt);
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteReceip_AddAndDeleteReceipt_ReturnsOkObjectResult()
        {
            // Act
            _controller.PutReceipt(_receipt2);
            IActionResult actionResult = _controller.DeleteReceipt(2);
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetReceipt_AddAndGetReceipt_ReturnsOkObjectResult()
        {
            // Act
            _controller.PutReceipt(_receipt);
            IActionResult actionResult = _controller.GetReceipt(1);
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetListOfReceipts_AddAndGetAllReceipts_ReturnsOkObjectResult()
        {
            // Act
            _controller.PutReceipt(_receipt);
            _controller.PutReceipt(_receipt2);
            _controller.PutReceipt(_receipt3);
            IActionResult actionResult = _controller.GetListOfReceipts();
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetListOfReceiptsByCreationDate_AddReceiptsAndGetByDate_ReturnsOkObjectResult()
        {
            // Arrange
            var from = new DateTime(2020, 1, 1);
            var to = new DateTime(2021, 10, 10);
            // Arrange
            _controller.PutReceipt(_receipt);
            _controller.PutReceipt(_receipt2);
            _controller.PutReceipt(_receipt3);
            IActionResult actionResult = _controller.GetListOfReceiptsByCreationDate(from,to);
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetFilteredReceiptsByProductName_AddReceiptsAndGetByProductName_ReturnsOkObjectResult()
        {
            // Arrange
            _controller.PutReceipt(_receipt);
            _controller.PutReceipt(_receipt2);
            _controller.PutReceipt(_receipt3);
            IActionResult actionResult = _controller.GetFilteredReceiptsByProductName("cat");
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
        }
    }
}

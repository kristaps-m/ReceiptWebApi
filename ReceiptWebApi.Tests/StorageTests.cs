using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReceiptWebApi.Core;
using ReceiptWebApi.Data;
using System;
using System.Collections.Generic;

namespace ReceiptWebApi.Tests
{
    [TestClass]
    public class StorageTests
    {
        private Receipt _receipt;
        private Receipt _receipt2;
        private Receipt _receipt3;
        private DateTime _created;
        private DateTime _created2;
        private DateTime _created3;

        [TestInitialize]
        public void Setup()
        {
            _receipt = new Receipt();
            _created = new DateTime(2019, 1, 1, 23, 30, 00);
            var items = new List<Product>() { new Product("cat"), new Product("dog") };
            _receipt.Id = 1;
            _receipt.CreatedOn = _created;
            _receipt.Items = items;

            _receipt2 = new Receipt();
            _created2 = new DateTime(2021, 1, 1, 11, 00, 00);
            var items2 = new List<Product>() { new Product("candy"), new Product("chocolate") };
            _receipt2.Id = 2;
            _receipt2.CreatedOn = _created2;
            _receipt2.Items = items2;

            _receipt3 = new Receipt();
            _created3 = new DateTime(2022, 5, 1);
            var items3 = new List<Product>() { new Product("saw"), new Product("knife") };
            _receipt3.Id = 3;
            _receipt3.CreatedOn = _created3;
            _receipt3.Items = items3;
        }

        [TestMethod]
        public void AddReceipt_AddValidReceipt_ReceiptAdded()
        {
            // Act
            ReceiptStorage.AddReceipt(_receipt);
            // Assert
            Action action = () => ReceiptStorage.GetReceipt(1);
            action.Should().NotBeNull();
        }

        [TestMethod]
        public void AddReceipt_AddValidReceipt_ReceiptAdded2()
        {
            // Act
            ReceiptStorage.ClearReceiptStorage();
            ReceiptStorage.AddReceipt(_receipt);
            ReceiptStorage.AddReceipt(_receipt2);
            // Assert
            var listOfReceipts = ReceiptStorage.GetListOfReceipts();
            listOfReceipts.Count.Should().Be(2);
        }

        [TestMethod]
        public void AddReceipt_AddValidReceipt_StorageContainsValidReceipts()
        {
            // Act
            ReceiptStorage.ClearReceiptStorage();
            ReceiptStorage.AddReceipt(_receipt);
            ReceiptStorage.AddReceipt(_receipt2);
            // Assert
            var listOfReceipts = ReceiptStorage.GetListOfReceipts();
            listOfReceipts.Count.Should().Be(2);
            listOfReceipts.Should().ContainEquivalentOf(_receipt);
            listOfReceipts.Should().ContainEquivalentOf(_receipt2);
        }

        [TestMethod]
        public void Delete_DeleteReceipt_ReceiptShouldBeDeleted()
        {
            // Act
            ReceiptStorage.ClearReceiptStorage();
            ReceiptStorage.AddReceipt(_receipt);
            ReceiptStorage.AddReceipt(_receipt2);
            // Assert
            ReceiptStorage.Delete(1);
            var listOfReceipts = ReceiptStorage.GetListOfReceipts();
            listOfReceipts.Count.Should().Be(1);
        }

        [TestMethod]
        public void GetByCreationDate()
        {
            // Arrange
            var from = new DateTime(2020, 1, 1);
            var to = new DateTime(2021, 10, 10);
            // Act
            ReceiptStorage.ClearReceiptStorage();
            ReceiptStorage.AddReceipt(_receipt);
            ReceiptStorage.AddReceipt(_receipt2);
            ReceiptStorage.AddReceipt(_receipt3);
            // Assert
            var listOfReceipts = ReceiptStorage.GetByCreationDate(from,to);
            listOfReceipts.Count.Should().Be(1);
            listOfReceipts.Should().ContainEquivalentOf(_receipt2);
        }

        [TestMethod]
        public void GetByCreationDate2()
        {
            // Arrange
            var from = new DateTime(2017, 1, 1);
            var to = new DateTime(2023, 10, 10);
            // Act
            ReceiptStorage.ClearReceiptStorage();
            ReceiptStorage.AddReceipt(_receipt);
            ReceiptStorage.AddReceipt(_receipt2);
            ReceiptStorage.AddReceipt(_receipt3);
            // Assert
            var listOfReceipts = ReceiptStorage.GetByCreationDate(from, to);
            listOfReceipts.Count.Should().Be(3);
            listOfReceipts.Should().ContainEquivalentOf(_receipt);
            listOfReceipts.Should().ContainEquivalentOf(_receipt2);
            listOfReceipts.Should().ContainEquivalentOf(_receipt3);
        }

        [TestMethod]
        public void GetFilteredReceiptsByProductName()
        {
            // Arrange
            var searchProduct = "knife";
            // Act
            ReceiptStorage.ClearReceiptStorage();
            ReceiptStorage.AddReceipt(_receipt);
            ReceiptStorage.AddReceipt(_receipt2);
            ReceiptStorage.AddReceipt(_receipt3);
            // Assert
            var listOfReceipts = ReceiptStorage.GetFilteredReceiptsByProductName(searchProduct);
            listOfReceipts.Count.Should().Be(1);
            listOfReceipts.Should().ContainEquivalentOf(_receipt3);
        }

        [TestMethod]
        public void GetFilteredReceiptsByProductName_ProductDoesNotExist()
        {
            // Arrange
            var searchProduct = "Bred Pit";
            // Act
            ReceiptStorage.ClearReceiptStorage();
            ReceiptStorage.AddReceipt(_receipt);
            ReceiptStorage.AddReceipt(_receipt2);
            ReceiptStorage.AddReceipt(_receipt3);
            // Assert
            var listOfReceipts = ReceiptStorage.GetFilteredReceiptsByProductName(searchProduct);
            listOfReceipts.Count.Should().Be(0);
            listOfReceipts.Should().BeEmpty();
        }
    }
}

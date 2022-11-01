using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReceiptWebApi.Core;
using ReceiptWebApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptWebApi.Tests
{
    [TestClass]
    public class StorageTests
    {
        private Receipt _receipt;
        private Receipt _receipt2;

        [TestInitialize]
        public void Setup()
        {
            _receipt = new Receipt();
            var created = new DateTime(2020, 1, 1, 23, 30, 00);
            var items = new List<Product>() { new Product("cat"), new Product("dog") };
            _receipt.Id = 1;
            _receipt.CreatedOn = created;
            _receipt.Items = items;

            _receipt2 = new Receipt();
            var created2 = new DateTime(2021, 1, 1, 23, 30, 00);
            var items2 = new List<Product>() { new Product("candy"), new Product("chocolate") };
            _receipt2.Id = 1;
            _receipt2.CreatedOn = created;
            _receipt2.Items = items;
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


    }
}

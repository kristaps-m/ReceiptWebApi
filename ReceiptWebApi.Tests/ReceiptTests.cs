using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReceiptWebApi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptWebApi.Tests
{
    [TestClass]
    public class ReceiptTests
    {
        private Receipt _receipt;

        [TestMethod]
        public void ReceiptCreation_ReceiptCreatedCorectly()
        {
            // Arrange
            var created = new DateTime(2020, 1, 1, 23, 30, 00);
            var items = new List<Product>() { new Product("cat"), new Product("dog") };
            _receipt = new Receipt();
            _receipt.Id = 1;
            _receipt.CreatedOn = created;
            _receipt.Items = items;

            // Assert
            _receipt.Id.Should().Be(1);
            _receipt.CreatedOn.Should().Be(created);
            _receipt.Items.Count.Should().Be(2);            
        }

        /**
         *         public int Id { get; set; }
        public DateTime CreatedOn { get; set; }

        public List<string> Items { get; set; }

        public string ProductName { get; set; }
         */
    }
}

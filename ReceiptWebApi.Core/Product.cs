using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptWebApi.Core
{
    public class Product
    {
        public string ProductName { get; set; }

        public Product(string productName)
        {
            ProductName = productName;
        }
    }
}

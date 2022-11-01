using System;
using System.Collections.Generic;

namespace ReceiptWebApi.Core
{
    public class Receipt
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<Product> Items { get; set; }
    }
}

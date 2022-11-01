using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptWebApi.Core
{
    public class Receipt
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }

        public List<Product> Items { get; set; }        

        //public Receipt(DateTime createdOn, string itemsList, string productName)
        //{
        //    CreatedOn = createdOn;
        //    Items = itemsList;
        //    ProductName = productName;
        //}
    }
}

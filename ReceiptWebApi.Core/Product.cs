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

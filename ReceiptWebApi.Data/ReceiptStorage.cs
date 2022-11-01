using ReceiptWebApi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptWebApi.Data
{
    public class ReceiptStorage
    {
        private static List<Receipt> _receiptStorage = new List<Receipt>();
        private static int _id = 1;

        public static Receipt AddReceipt(Receipt receipt)
        {
            receipt.Id = _id++;
            _receiptStorage.Add(receipt);
            
            return receipt;
        }

        public static void Delete(int id)
        {
          
            var receiptListRange = _receiptStorage.Count;
            var theReceiptIndex = 0;

            if (id <= receiptListRange && id >= 0)
            {
                for (int i = 0; i < receiptListRange; i++)
                {
                    if (_receiptStorage[i].Id == id)
                    {
                        theReceiptIndex = i;
                    }
                }

                _receiptStorage.RemoveAt(theReceiptIndex);
            }            
        }

        public static Receipt GetReceipt(int id)
        {         
            if (id <= _receiptStorage.Count && id >= 0)
            {
                return _receiptStorage.FirstOrDefault(f => f.Id == id);
            }            

            return null;
        }

        public static List<Receipt> GetListOfReceipts()
        {
            return _receiptStorage;
        }

        public static List<Receipt> GetByCreationDate(DateTime from, DateTime to)
        {
            var receiptList = new List<Receipt>();

            foreach (var receipt in _receiptStorage)
            {
                if (receipt.CreatedOn >= from && 
                    receipt.CreatedOn <= to)
                {
                    receiptList.Add(receipt);
                }
            }

            return receiptList;
        }

        public static void ClearReceiptStorage()
        {
            _receiptStorage.Clear();
            _id = 0;
        }

        public static List<Receipt> GetFilteredReceiptsByProductName(string theProduct)
        {
            var receiptList = new List<Receipt>();

            foreach (var receipt in _receiptStorage)
            {
                foreach (var item in receipt.Items)
                {
                    if (item.ProductName.ToLower().Trim() == theProduct.ToLower().Trim())
                    {
                        receiptList.Add(receipt);
                    }
                }
            }
            return receiptList;
        }
    }
}

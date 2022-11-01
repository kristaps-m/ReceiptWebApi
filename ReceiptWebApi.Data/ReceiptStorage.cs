using ReceiptWebApi.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReceiptWebApi.Data
{
    public class ReceiptStorage : IReceiptStorage
    {
        private List<Receipt> _receiptsStorage = new List<Receipt>();
        private int _id = 1;

        public Receipt AddReceipt(Receipt receipt)
        {
            receipt.Id = _id++;
            _receiptsStorage.Add(receipt);

            return receipt;
        }

        public void DeleteReceiptById(int id)
        {
            var receiptListRange = _receiptsStorage.Count;
            var theReceiptIndex = 0;

            if (id <= receiptListRange && id >= 0)
            {
                for (int i = 0; i < receiptListRange; i++)
                {
                    if (_receiptsStorage[i].Id == id)
                    {
                        theReceiptIndex = i;
                    }
                }

                _receiptsStorage.RemoveAt(theReceiptIndex);
            }
        }

        public Receipt GetReceipt(int id)
        {
            if (id <= _receiptsStorage.Count && id >= 0)
            {
                return _receiptsStorage.FirstOrDefault(f => f.Id == id);
            }

            return null;
        }

        public List<Receipt> GetListOfReceipts()
        {
            return _receiptsStorage;
        }

        public List<Receipt> GetByCreationDate(DateTime from, DateTime to)
        {
            var receiptList = new List<Receipt>();

            foreach (var receipt in _receiptsStorage)
            {
                if (receipt.CreatedOn >= from &&
                    receipt.CreatedOn <= to)
                {
                    receiptList.Add(receipt);
                }
            }

            return receiptList;
        }

        public void ClearReceiptStorage()
        {
            _receiptsStorage.Clear();
            _id = 1;
        }

        public List<Receipt> GetFilteredReceiptsByProductName(string theProduct)
        {
            var receiptList = new List<Receipt>();

            foreach (var receipt in _receiptsStorage)
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

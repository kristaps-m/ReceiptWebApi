using ReceiptWebApi.Core;
using System;
using System.Collections.Generic;

namespace ReceiptWebApi.Data
{
    public interface IReceiptStorage
    {
        Receipt AddReceipt(Receipt receipt);
        void ClearReceiptStorage();
        void DeleteReceiptById(int id);
        List<Receipt> GetByCreationDate(DateTime from, DateTime to);
        List<Receipt> GetFilteredReceiptsByProductName(string theProduct);
        List<Receipt> GetListOfReceipts();
        Receipt GetReceipt(int id);
    }
}
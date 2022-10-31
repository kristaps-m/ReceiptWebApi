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
        private static int _id = 0;

        public static Receipt AddReceipt(Receipt receipt)
        {
            receipt.Id = ++_id;
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
    }
}

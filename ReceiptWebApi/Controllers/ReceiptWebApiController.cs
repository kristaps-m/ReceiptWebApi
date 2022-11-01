using Microsoft.AspNetCore.Mvc;
using ReceiptWebApi.Core;
using ReceiptWebApi.Data;
using System;

namespace ReceiptWebApi.Controllers
{
    [Route("receipts")]
    [ApiController]
    public class ReceiptWebApiController : ControllerBase
    {
        private readonly IReceiptStorage _receiptStorage;

        public ReceiptWebApiController(IReceiptStorage receiptStorage)
        {
            _receiptStorage = receiptStorage;
        }

        [Route("add")]
        [HttpPut]
        public IActionResult PutReceipt(Receipt receipt)
        {
            receipt = _receiptStorage.AddReceipt(receipt);

            return Created("", receipt);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult DeleteReceipt(int id)
        {
            _receiptStorage.DeleteReceiptById(id);
            return Ok($"Receipt with {id} is deleted!");
        }

        [Route("receipt/{id}")]
        [HttpGet]
        public IActionResult GetReceipt(int id)
        {
            var receipt = _receiptStorage.GetReceipt(id);

            if (receipt == null)
            {
                return NotFound();
            }

            return Ok(receipt);
        }

        [Route("getall")]
        [HttpGet]
        public IActionResult GetListOfReceipts()
        {
            var receiptList = _receiptStorage.GetListOfReceipts();

            return Ok(receiptList);
        }

        [Route("getbydate")]
        [HttpGet]
        public IActionResult GetListOfReceiptsByCreationDate(DateTime from, DateTime to)
        {
            var receiptList = _receiptStorage.GetByCreationDate(from, to);

            return Ok(receiptList);
        }

        [Route("getbyproduct")]
        [HttpGet]
        public IActionResult GetFilteredReceiptsByProductName(string product)
        {
            var receiptList = _receiptStorage.GetFilteredReceiptsByProductName(product);

            return Ok(receiptList);
        }
    }
}

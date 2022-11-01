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
        /// <summary>
        /// OK - Create a new Receipt
        /// OK - Delete the Receipt by its id
        /// OK - Get the Receipt by its id
        /// ______ Get the list of Receipts
        /// ______ OK - Get all Receipts
        /// ______ OK - Get filtered Receipts by creation date range
        /// ______ OK - Get filtered Receipts by product name
        /// </summary>
        /// <param name="receipt"></param>
        /// <returns></returns>
        [Route("add")]
        [HttpPut]
        public IActionResult PutReceipt(Receipt receipt)
        {
            //if (FlightStorage.IsThereSameFlightInStorage(flight))
            //{
            //    return Conflict();
            //}

            receipt = ReceiptStorage.AddReceipt(receipt);

            return Created("", receipt);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult DeleteReceipt(int id)
        {
            ReceiptStorage.Delete(id);
            return Ok($"Receipt with {id} is deleted!");
        }

        [Route("receipt/{id}")]
        [HttpGet]
        public IActionResult GetFlight(int id)
        {
            var receipt = ReceiptStorage.GetReceipt(id);

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
            var receiptList = ReceiptStorage.GetListOfReceipts();
            return Ok(receiptList);
        }

        [Route("getbydate")]
        [HttpGet]
        public IActionResult GetListOfReceiptsByCreationDate(DateTime from, DateTime to)
        {
            var receiptList = ReceiptStorage.GetByCreationDate(from, to);
            return Ok(receiptList);
        }

        [Route("getbyproduct")]
        [HttpGet]
        public IActionResult GetFilteredReceiptsByProductName(string product)
        {
            var receiptList = ReceiptStorage.GetFilteredReceiptsByProductName(product);
            return Ok(receiptList);
        }
    }
}

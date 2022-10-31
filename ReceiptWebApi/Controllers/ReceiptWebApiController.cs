using Microsoft.AspNetCore.Mvc;
using ReceiptWebApi.Core;
using ReceiptWebApi.Data;

namespace ReceiptWebApi.Controllers
{
    [Route("receipts")]
    [ApiController]
    public class ReceiptWebApiController : ControllerBase
    {
        [Route("add")]
        [HttpPut]
        public IActionResult PutFlight(Receipt receipt)
        {
            //if (FlightStorage.IsThereSameFlightInStorage(flight))
            //{
            //    return Conflict();
            //}

            receipt = ReceiptStorage.AddReceipt(receipt);

            return Created("", receipt);
        }
    }
}

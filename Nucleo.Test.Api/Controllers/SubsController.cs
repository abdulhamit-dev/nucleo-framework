using DotNetCore.CAP;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nucleo.EventBus.Cap;

namespace Nucleo.Test.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubsController : ControllerBase
    {

        [CapSubscribe("order.created")]
        public void OrderProcess(OrderCreatedEvent orderCreatedEvent)
        {
            try
            {
                Console.WriteLine($"Order Id: {orderCreatedEvent.OrderId}");
                Console.WriteLine($"Created At: {orderCreatedEvent.CreatedAt.ToShortDateString()}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

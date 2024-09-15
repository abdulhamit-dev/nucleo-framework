using System;
using Microsoft.AspNetCore.Mvc;
using Nucleo.EventBus;
using Nucleo.EventBus.Cap;

namespace Nucleo.Test.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PublishController : ControllerBase
{
    private readonly IEventBus _eventBus;

    public PublishController(IEventBus eventBus)
    {
        _eventBus = eventBus;
    }

    [HttpGet("publish")]
    public IActionResult Publish()
    {
        var orderCreatedEvent = new OrderCreatedEvent
        {
            OrderId = 123,
            CreatedAt = DateTime.UtcNow
        };
        _eventBus.Publish(orderCreatedEvent, "order.created");
        return Ok();
    }


}

public class OrderCreatedEvent
{
    public int OrderId { get; set; }
    public DateTime CreatedAt { get; set; }
}
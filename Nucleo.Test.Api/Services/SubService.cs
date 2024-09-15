using System;
using DotNetCore.CAP;
using Nucleo.Test.Api.Controllers;

namespace Nucleo.Test.Api.Services;

public class SubService
{
    // [CapSubscribe("order.created")]
    // public void Handle(OrderCreatedEvent orderCreatedEvent)
    // {
    //     try
    //     {
    //         Console.WriteLine($"Order Id: {orderCreatedEvent.OrderId}");
    //         Console.WriteLine($"Created At: {orderCreatedEvent.CreatedAt}");
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine(e);
    //     }
    // }
}

using System;
using DotNetCore.CAP;

namespace Nucleo.EventBus.Cap;

public class CapEventBusSubscribeAttribute : CapSubscribeAttribute
{
    public CapEventBusSubscribeAttribute(string name, bool isPartial = false) 
    : base(name, isPartial)
    {
    }
}

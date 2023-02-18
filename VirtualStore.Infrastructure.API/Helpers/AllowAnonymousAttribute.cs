using System;

namespace VirtualStore.Infrastructure.API.Helpers
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymousAttribute : Attribute
    {
    }
}


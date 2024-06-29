using System;
using System.Collections.Generic;
using System.Text;

namespace Music.IO.UserContext
{
    public interface IUserContextAccessorFactoryResolver
    {
        IUserContextAccessor Create(IServiceProvider provider);
    }
}

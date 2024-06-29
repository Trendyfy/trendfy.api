using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.IO.UserContext
{
    public interface IUserContextAccessor
    {
        string Id { get; }
        string UserName { get; }
        string Name { get; }
        string Email { get; }
        string Jti { get; }
    }
}

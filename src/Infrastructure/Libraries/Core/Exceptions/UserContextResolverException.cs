using System;
using System.IO;
using System.Runtime.Serialization;

namespace Music.IO.TenantContext.Exceptions
{
    [Serializable]
    public class UserContextResolverException : IOException
    {
        public UserContextResolverException(string message) : base(message)
        {
        }
        public UserContextResolverException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserContextResolverException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

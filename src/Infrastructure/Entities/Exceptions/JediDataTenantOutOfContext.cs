using Music.IO.Core.Exceptions;
using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;

namespace Music.IO.Data.Entities.Exceptions
{
    public class IODataTenantOutOfContext : IOException
    {
        public const string Music_DETAUL_MESSAGE = "Tenant of entity '{0}' is out of context of thread or request";
        public const string Music_ERROR_CODE = "ERROR_TENANT_OUT_OF_CONTEXT";

        public string EntityName { get; }
        public IODataTenantOutOfContext(string entityName) 
            : base(string.Format(Music_DETAUL_MESSAGE, entityName))
        {
            EntityName = entityName;
            Init();
        }
        public IODataTenantOutOfContext(string entityName, string message)
            : base($"{string.Format(Music_DETAUL_MESSAGE, entityName)}. {message}")
        {
            EntityName = entityName;
            Init();
        }
        public IODataTenantOutOfContext(string entityName, Exception innerException) 
            : base(string.Format(Music_DETAUL_MESSAGE, entityName), innerException)
        {
            EntityName = entityName;
            Init();
        }

        protected IODataTenantOutOfContext(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            EntityName = string.Empty;
        }

        private void Init()
        {
            ErrorCode = Music_ERROR_CODE;
            HttpStatusCode = 400;
        }
    }
}

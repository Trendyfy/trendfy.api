using Rabbot.Jedi.Core.Exceptions;
using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Rabbot.Jedi.Data.Entities.Exceptions
{
    public class JediDataTenantOutOfContext : JediException
    {
        public const string RABBOT_DETAUL_MESSAGE = "Tenant of entity '{0}' is out of context of thread or request";
        public const string RABBOT_ERROR_CODE = "ERROR_TENANT_OUT_OF_CONTEXT";

        public string EntityName { get; }
        public JediDataTenantOutOfContext(string entityName) 
            : base(string.Format(RABBOT_DETAUL_MESSAGE, entityName))
        {
            EntityName = entityName;
            Init();
        }
        public JediDataTenantOutOfContext(string entityName, string message)
            : base($"{string.Format(RABBOT_DETAUL_MESSAGE, entityName)}. {message}")
        {
            EntityName = entityName;
            Init();
        }
        public JediDataTenantOutOfContext(string entityName, Exception innerException) 
            : base(string.Format(RABBOT_DETAUL_MESSAGE, entityName), innerException)
        {
            EntityName = entityName;
            Init();
        }

        protected JediDataTenantOutOfContext(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            EntityName = string.Empty;
        }

        private void Init()
        {
            ErrorCode = RABBOT_ERROR_CODE;
            HttpStatusCode = 400;
        }
    }
}

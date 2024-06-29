using Rabbot.Jedi.Core.Exceptions;
using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Rabbot.Jedi.Data.Entities.Exceptions
{
    public class JediDataConflictException : JediException
    {
        public const string RABBOT_DETAUL_MESSAGE = "A conflict was encountered when attempting to write the requested data to entity '{0}'";
        public const string RABBOT_ERROR_CODE = "ERROR_DATA_CONFLICT";

        public string EntityName { get; }
        public JediDataConflictException(string entityName) 
            : base(string.Format(RABBOT_DETAUL_MESSAGE, entityName))
        {
            EntityName = entityName;
            Init();
        }
        public JediDataConflictException(string entityName, string message)
            : base($"{string.Format(RABBOT_DETAUL_MESSAGE, entityName)}. {message}")
        {
            EntityName = entityName;
            Init();
        }
        public JediDataConflictException(string entityName, Exception innerException) 
            : base(string.Format(RABBOT_DETAUL_MESSAGE, entityName), innerException)
        {
            EntityName = entityName;
            Init();
        }

        protected JediDataConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            EntityName = string.Empty;
        }

        private void Init()
        {
            ErrorCode = RABBOT_ERROR_CODE;
            HttpStatusCode = 409;
        }
    }
}

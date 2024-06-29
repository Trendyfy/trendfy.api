using System;
using System.Runtime.Serialization;

namespace Rabbot.Jedi.Data.Entities.Exceptions
{
    public class JediDataTooManyEntityForOperationException : JediException
    {
        public const string RABBOT_DETAUL_MESSAGE = "Too many entities affect for operation '{0}'";
        public const string RABBOT_ERROR_CODE = "ERROR_ENTITY_NOT_FOUND";

        public string EntityName { get; }
        public DataOperation? Operation { get; }
        public JediDataTooManyEntityForOperationException(string entityName, DataOperation operation)
            : base(string.Format(RABBOT_DETAUL_MESSAGE, operation))
        {
            EntityName = entityName;
            Operation = operation;
            Init();
        }
        public JediDataTooManyEntityForOperationException(string entityName, DataOperation operation, string message)
            : base($"{string.Format(RABBOT_DETAUL_MESSAGE, operation)}. {message}")
        {
            EntityName = entityName;
            Operation = operation;
            Init();
        }
        public JediDataTooManyEntityForOperationException(string entityName, DataOperation operation, Exception innerException)
            : base(string.Format(RABBOT_DETAUL_MESSAGE, operation), innerException)
        {
            EntityName = entityName;
            Operation = operation;
            Init();
        }

        protected JediDataTooManyEntityForOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            EntityName = string.Empty;
            Operation = null;
        }

        private void Init()
        {
            ErrorCode = RABBOT_ERROR_CODE;
            HttpStatusCode = 404;
        }
    }
}

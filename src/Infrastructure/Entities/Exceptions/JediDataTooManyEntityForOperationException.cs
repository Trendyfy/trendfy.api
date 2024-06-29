using Music.IO.Core.Exceptions;
using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Music.IO.Data.Entities.Exceptions
{
    public class IODataTooManyEntityForOperationException : IOException
    {
        public const string Music_DETAUL_MESSAGE = "Too many entities affect for operation '{0}'";
        public const string Music_ERROR_CODE = "ERROR_ENTITY_NOT_FOUND";

        public string EntityName { get; }
        public DataOperation? Operation { get; }
        public IODataTooManyEntityForOperationException(string entityName, DataOperation operation) 
            : base(string.Format(Music_DETAUL_MESSAGE, operation))
        {
            EntityName = entityName;
            Operation = operation;
            Init();
        }
        public IODataTooManyEntityForOperationException(string entityName, DataOperation operation, string message) 
            : base($"{string.Format(Music_DETAUL_MESSAGE, operation)}. {message}")
        {
            EntityName = entityName;
            Operation = operation;
            Init();
        }
        public IODataTooManyEntityForOperationException(string entityName, DataOperation operation, Exception innerException) 
            : base(string.Format(Music_DETAUL_MESSAGE, operation), innerException)
        {
            EntityName = entityName;
            Operation = operation;
            Init();
        }

        protected IODataTooManyEntityForOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            EntityName = string.Empty;
            Operation = null;
        }

        private void Init()
        {
            ErrorCode = Music_ERROR_CODE;
            HttpStatusCode = 404;
        }
    }
}

using Music.IO.Core.Exceptions;
using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;

namespace Music.IO.Data.Entities.Exceptions
{
    public class IODataConflictException : IOException
    {
        public const string Music_DETAUL_MESSAGE = "A conflict was encountered when attempting to write the requested data to entity '{0}'";
        public const string Music_ERROR_CODE = "ERROR_DATA_CONFLICT";

        public string EntityName { get; }
        public IODataConflictException(string entityName) 
            : base(string.Format(Music_DETAUL_MESSAGE, entityName))
        {
            EntityName = entityName;
            Init();
        }
        public IODataConflictException(string entityName, string message)
            : base($"{string.Format(Music_DETAUL_MESSAGE, entityName)}. {message}")
        {
            EntityName = entityName;
            Init();
        }
        public IODataConflictException(string entityName, Exception innerException) 
            : base(string.Format(Music_DETAUL_MESSAGE, entityName), innerException)
        {
            EntityName = entityName;
            Init();
        }

        protected IODataConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            EntityName = string.Empty;
        }

        private void Init()
        {
            ErrorCode = Music_ERROR_CODE;
            HttpStatusCode = 409;
        }
    }
}

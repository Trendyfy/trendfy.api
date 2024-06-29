using Music.IO.Core.Exceptions;
using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Music.IO.Data.Entities.Exceptions
{
    public class IODataEntityNotFoundException : IOException
    {
        public const string Music_DETAUL_MESSAGE = "Id '{0}' not found for entity '{1}'";
        public const string Music_ERROR_CODE = "ERROR_ENTITY_NOT_FOUND";

        public string EntityName { get; }
        public string Id { get; }
        public IODataEntityNotFoundException(string entityName, string id) 
            : base(string.Format(Music_DETAUL_MESSAGE, id, entityName))
        {
            EntityName = entityName;
            Id = id;
            Init();
        }
        public IODataEntityNotFoundException(string entityName, string id, string message)
            : base($"{string.Format(Music_DETAUL_MESSAGE, id, entityName)}. {message}")
        {
            EntityName = entityName;
            Id = id;
            Init();
        }
        public IODataEntityNotFoundException(string entityName, string id, Exception innerException) 
            : base(string.Format(Music_DETAUL_MESSAGE, id, entityName), innerException)
        {
            EntityName = entityName;
            Id = id;
            Init();
        }

        protected IODataEntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            EntityName = string.Empty;
            Id = string.Empty;
        }

        private void Init()
        {
            ErrorCode = Music_ERROR_CODE;
            HttpStatusCode = 404;
        }
    }
}

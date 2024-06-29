using System;
using System.Runtime.Serialization;

namespace Rabbot.Jedi.Data.Entities.Exceptions
{
    public class JediDataEntityNotFoundException : JediException
    {
        public const string RABBOT_DETAUL_MESSAGE = "Id '{0}' not found for entity '{1}'";
        public const string RABBOT_ERROR_CODE = "ERROR_ENTITY_NOT_FOUND";

        public string EntityName { get; }
        public string Id { get; }
        public JediDataEntityNotFoundException(string entityName, string id)
            : base(string.Format(RABBOT_DETAUL_MESSAGE, id, entityName))
        {
            EntityName = entityName;
            Id = id;
            Init();
        }
        public JediDataEntityNotFoundException(string entityName, string id, string message)
            : base($"{string.Format(RABBOT_DETAUL_MESSAGE, id, entityName)}. {message}")
        {
            EntityName = entityName;
            Id = id;
            Init();
        }
        public JediDataEntityNotFoundException(string entityName, string id, Exception innerException)
            : base(string.Format(RABBOT_DETAUL_MESSAGE, id, entityName), innerException)
        {
            EntityName = entityName;
            Id = id;
            Init();
        }

        protected JediDataEntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            EntityName = string.Empty;
            Id = string.Empty;
        }

        private void Init()
        {
            ErrorCode = RABBOT_ERROR_CODE;
            HttpStatusCode = 404;
        }
    }
}

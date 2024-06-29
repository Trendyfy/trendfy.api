using System;
using System.Runtime.Serialization;

namespace Rabbot.Jedi.Data.Entities.Exceptions
{
    public class JediDataDuplicateKeyException : JediException
    {
        public const string RABBOT_DETAUL_MESSAGE = "Duplicate key error.  Key {0} already exist in database";
        public const string RABBOT_ERROR_CODE = "ERROR_DUPLICATE_KEY";

        public string? Key { get; }
        public JediDataDuplicateKeyException(string? key)
            : base(string.Format(RABBOT_DETAUL_MESSAGE, key))
        {
            Key = key;
            Init();
        }
        public JediDataDuplicateKeyException(string? key, string message)
            : base($"{string.Format(RABBOT_DETAUL_MESSAGE, key)}. {message}")
        {
            Key = key;
            Init();
        }
        public JediDataDuplicateKeyException(string? key, Exception innerException)
            : base(string.Format(RABBOT_DETAUL_MESSAGE, key), innerException)
        {
            Key = key;
            Init();
        }

        protected JediDataDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Init();
        }

        private void Init()
        {
            ErrorCode = RABBOT_ERROR_CODE;
            HttpStatusCode = 400;
        }
    }
}

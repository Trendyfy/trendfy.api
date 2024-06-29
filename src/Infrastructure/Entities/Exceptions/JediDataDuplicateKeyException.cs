using Music.IO.Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Music.IO.Data.Entities.Exceptions
{
    public class IODataDuplicateKeyException : IOException
    {
        public const string Music_DETAUL_MESSAGE = "Duplicate key error.  Key {0} already exist in database";
        public const string Music_ERROR_CODE = "ERROR_DUPLICATE_KEY";

        public string? Key { get; }
        public IODataDuplicateKeyException(string? key) 
            : base(string.Format(Music_DETAUL_MESSAGE, key))
        {
            Key = key;
            Init();
        }
        public IODataDuplicateKeyException(string? key, string message)
            : base($"{string.Format(Music_DETAUL_MESSAGE, key)}. {message}")
        {
            Key = key;
            Init();
        }
        public IODataDuplicateKeyException(string? key, Exception innerException) 
            : base(string.Format(Music_DETAUL_MESSAGE, key), innerException)
        {
            Key = key;
            Init();
        }

        protected IODataDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Init();
        }

        private void Init()
        {
            ErrorCode = Music_ERROR_CODE;
            HttpStatusCode = 400;
        }
    }
}

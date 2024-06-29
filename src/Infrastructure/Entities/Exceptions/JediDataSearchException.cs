using Music.IO.Core.Exceptions;
using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Music.IO.Data.Entities.Exceptions
{
    public class IODataSearchException : IOException
    {
        public const string Music_DETAUL_MESSAGE = "Search data arguments are invalid. Error: '{0}'";
        public const string Music_ERROR_CODE = "ERROR_SEARCH_DATA_ARGUMENT";

        public IODataSearchException(string message) 
            : base(string.Format(Music_DETAUL_MESSAGE, message))
        {
            Init();
        }
        private void Init()
        {
            ErrorCode = Music_ERROR_CODE;
            HttpStatusCode = 409;
        }
    }
}

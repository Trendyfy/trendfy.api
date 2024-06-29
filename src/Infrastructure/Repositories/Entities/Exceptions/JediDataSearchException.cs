namespace Rabbot.Jedi.Data.Entities.Exceptions
{
    public class JediDataSearchException : JediException
    {
        public const string RABBOT_DETAUL_MESSAGE = "Search data arguments are invalid. Error: '{0}'";
        public const string RABBOT_ERROR_CODE = "ERROR_SEARCH_DATA_ARGUMENT";

        public JediDataSearchException(string message)
            : base(string.Format(RABBOT_DETAUL_MESSAGE, message))
        {
            Init();
        }
        private void Init()
        {
            ErrorCode = RABBOT_ERROR_CODE;
            HttpStatusCode = 409;
        }
    }
}

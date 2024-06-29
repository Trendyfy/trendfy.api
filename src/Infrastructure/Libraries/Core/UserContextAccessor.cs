using System;

namespace Music.IO.UserContext
{
    public class UserContextAccessor : IUserContextAccessor
    {
        public UserContextAccessor(string id, string userName, string name, string email, string jti)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException(nameof(userName));
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));
            if (string.IsNullOrEmpty(jti))
                throw new ArgumentNullException(nameof(jti));
            //
            Id = id;
            UserName = userName;
            Name = name;
            Email = email;
            Jti = jti;
        }

        public string Id { get; private set; }
        public string UserName { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Jti { get; private set; }
    }
}

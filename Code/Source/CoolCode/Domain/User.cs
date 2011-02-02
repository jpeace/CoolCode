using CoolCode.Domain.Exceptions;
using CoolCode.Fx;

namespace CoolCode.Domain
{
    public class User
    {
        public virtual int UserId { get; protected set; }
        public virtual string Username { get; protected set; }
        public virtual string Password { get; protected set; }
        public virtual UserProfile Profile { get; protected set; }

        protected User() {}

        public static User CreateNew(string username, string password)
        {
            var user = new User {Username = username};
            user.SetPassword(password);
            return user;
        }

        // TODO - Move operations to partial class?
        public virtual void ChangePassword(string oldPassword, string newPassword)
        {
            if (Password != CalculatePasswordHash(oldPassword))
            {
                throw new DomainOperationException("The old password specified did not match.");
            }
            SetPassword(newPassword);
        }

        protected virtual void SetPassword(string password)
        {
            Password = CalculatePasswordHash(password);
        }

        protected virtual string CalculatePasswordHash(string password)
        {
            const int SaltLength = 8;

            var salt = Username;
            while (salt.Length <= SaltLength)
            {
                salt += Username;
            }
            salt = salt.Substring(0, SaltLength);
            return new PasswordHash(salt, password).Value;
        }
    }
}
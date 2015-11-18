using Microsoft.AspNet.Identity;
using RayToDo.Data.EntityFramework;
using RayToDo.Data.EntityFramework.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace RayToDo.Services.Auth
{
    public class UserStore :
        IUserStore<User, int>,
        IUserPasswordStore<User, int>,
        IUserEmailStore<User, int>,
        IUserSecurityStampStore<User, int>,
        IUserLoginStore<User, int>
    {
        private IAppDbContext db;

        public UserStore(IAppDbContext db)
        {
            this.db = db;
        }

        #region IUserStore Implementation

        public System.Threading.Tasks.Task UpdateAsync(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            return db.SaveChangesAsync();
        }

        public System.Threading.Tasks.Task CreateAsync(User user)
        {
            db.Users.Add(user);
            return db.SaveChangesAsync();
        }

        public System.Threading.Tasks.Task DeleteAsync(User user)
        {
            db.Users.Remove(user);
            return db.SaveChangesAsync();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public Task<User> FindByIdAsync(int userId)
        {
            var user = db.Users.Find(userId);
            return System.Threading.Tasks.Task.FromResult(user);
        }

        public Task<User> FindByNameAsync(string userName)
        {
            var user = db.Users.FirstOrDefault(x => x.UserName == userName);
            return System.Threading.Tasks.Task.FromResult(user);
        }

        #endregion IUserStore Implementation

        #region IUserPasswordStore Implementation

        public Task<string> GetPasswordHashAsync(User user)
        {
            return System.Threading.Tasks.Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return System.Threading.Tasks.Task.FromResult(user.PasswordHash != null);
        }

        public System.Threading.Tasks.Task SetPasswordHashAsync(User user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return System.Threading.Tasks.Task.FromResult(0);
        }

        #endregion IUserPasswordStore Implementation

        #region IUserEmailStore Implementation

        public System.Threading.Tasks.Task SetEmailAsync(User user, string email)
        {
            user.Email = email;
            return System.Threading.Tasks.Task.FromResult(0);
        }

        public Task<string> GetEmailAsync(User user)
        {
            return System.Threading.Tasks.Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(User user)
        {
            return System.Threading.Tasks.Task.FromResult(user.EmailConfirmed);
        }

        public System.Threading.Tasks.Task SetEmailConfirmedAsync(User user, bool confirmed)
        {
            user.EmailConfirmed = confirmed;
            return System.Threading.Tasks.Task.FromResult(0);
        }

        public Task<User> FindByEmailAsync(string email)
        {
            var user = db.Users.FirstOrDefault(x => x.Email == email);
            return System.Threading.Tasks.Task.FromResult(user);
        }

        #endregion IUserEmailStore Implementation

        #region IUserSecurityStampStore Implementation

        public System.Threading.Tasks.Task SetSecurityStampAsync(User user, string stamp)
        {
            user.SecurityStamp = stamp;
            return System.Threading.Tasks.Task.FromResult(0);
        }

        public Task<string> GetSecurityStampAsync(User user)
        {
            return System.Threading.Tasks.Task.FromResult(user.SecurityStamp);
        }

        #endregion IUserSecurityStampStore Implementation

        #region IUserLoginStore Implementation

        public System.Threading.Tasks.Task AddLoginAsync(User user, UserLoginInfo login)
        {
            user.Logins.Add(new UserLogin
            {
                Provider = login.LoginProvider,
                ProviderKey = login.ProviderKey,
                UserId = user.Id
            });
            return System.Threading.Tasks.Task.FromResult(0);
        }

        public System.Threading.Tasks.Task RemoveLoginAsync(User user, UserLoginInfo login)
        {
            UserLogin userLogin = user.Logins.FirstOrDefault(x => x.Provider == login.LoginProvider && x.ProviderKey == login.ProviderKey);
            user.Logins.Remove(userLogin);
            return System.Threading.Tasks.Task.FromResult(0);
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(User user)
        {
            var logins = (IList<UserLoginInfo>)user.Logins.Select(x => new UserLoginInfo(x.Provider, x.ProviderKey));
            return System.Threading.Tasks.Task.FromResult(logins);
        }

        public Task<User> FindAsync(UserLoginInfo login)
        {
            var userLogin = db.UserLogins.FirstOrDefault(x => x.Provider == login.LoginProvider && x.ProviderKey == login.ProviderKey);

            return FindByIdAsync(userLogin.UserId); ;
        }

        #endregion IUserLoginStore Implementation
    }
}
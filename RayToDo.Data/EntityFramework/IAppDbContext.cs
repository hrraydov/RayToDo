using RayToDo.Data.EntityFramework.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace RayToDo.Data.EntityFramework
{
    public interface IAppDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<TaskList> TaskLists { get; set; }

        IDbSet<MemberRight> MemberRights { get; set; }

        IDbSet<Models.Task> Tasks { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<UserLogin> UserLogins { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
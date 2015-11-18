using RayToDo.Data.EntityFramework.Models;
using RayToDo.Data.EntityFramework.Models.Common;
using System;
using System.Data.Entity;
using System.Linq;

namespace RayToDo.Data.EntityFramework
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext()
            : base("DefaultConnection")
        {
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<MemberRight> MemberRights { get; set; }

        public IDbSet<TaskList> TaskLists { get; set; }

        public IDbSet<Task> Tasks { get; set; }

        public IDbSet<UserLogin> UserLogins { get; set; }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskList>().HasRequired(x => x.Creator).WithMany(x => x.TaskLists).WillCascadeOnDelete(false);
            modelBuilder.Entity<TaskList>().HasMany(x => x.Invited).WithMany(x => x.InvitedFor).Map(x => x.ToTable("Invitations"));
            modelBuilder.Entity<TaskList>().HasMany(x => x.Members).WithMany(x => x.MemberOf).Map(x => x.ToTable("Membership"));
            modelBuilder.Entity<User>().HasMany(x => x.Rights).WithRequired(x => x.Member).WillCascadeOnDelete(false);
            modelBuilder.Entity<Task>().HasOptional(x => x.WorkingOn).WithMany(x => x.WorkingOn).WillCascadeOnDelete(false);
        }

        public override int SaveChanges()
        {
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditableEntity && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditableEntity)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.UpdatedOn = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}
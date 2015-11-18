using RayToDo.Data.EntityFramework;
using RayToDo.Data.EntityFramework.Models;
using RayToDo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RayToDo.Services
{
    public class TaskListService : ITaskListService
    {
        private IAppDbContext db;

        public TaskListService(IAppDbContext db)
        {
            this.db = db;
        }

        public void AcceptInvitation(TaskList taskList, string username)
        {
            var user = db.Users.FirstOrDefault(x => x.UserName == username);
            if (user == null)
            {
                throw new Exception("User does not exist");
            }
            if (!taskList.Invited.Contains(user))
            {
                throw new Exception("User is not invited");
            }
            taskList.Invited.Remove(user);
            taskList.Members.Add(user);
            Update(taskList);
        }

        public void Add(TaskList item)
        {
            db.TaskLists.Add(item);
            db.SaveChanges();
        }

        public void AddRight(TaskList taskList, string username, string right)
        {
            var user = db.Users.FirstOrDefault(x => x.UserName == username);
            if (user == null)
            {
                throw new Exception("User does not exist");
            }
            if (taskList.Members.Count(x => x.Id == user.Id) == 0)
            {
                throw new Exception("User is not a member");
            }
            if (user.Rights.Count(x => x.Right == right && x.TaskListId == taskList.Id) > 0)
            {
                throw new Exception("User already has this right");
            }
            MemberRight dbRight = new MemberRight
            {
                MemberId = user.Id,
                Right = right,
                TaskListId = taskList.Id
            };
            db.MemberRights.Add(dbRight);
            db.SaveChanges();
        }

        public bool CheckRight(TaskList taskList, string username, string right)
        {
            var user = db.Users.FirstOrDefault(x => x.UserName == username);
            if (user == null)
            {
                throw new Exception("User does not exist");
            }
            if (taskList.CreatorId == user.Id)
            {
                return true;
            }
            return db.MemberRights.Count(x => x.TaskListId == taskList.Id && x.MemberId == user.Id && x.Right == right) > 0;
        }

        public void DeclineInvitation(TaskList taskList, string username)
        {
            var user = db.Users.FirstOrDefault(x => x.UserName == username);
            if (user == null)
            {
                throw new Exception("User does not exist");
            }
            if (!taskList.Invited.Contains(user))
            {
                throw new Exception("User is not invited");
            }
            taskList.Invited.Remove(user);
            Update(taskList);
        }

        public void Delete(TaskList item)
        {
            db.TaskLists.Remove(item);
            db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var item = db.TaskLists.Find(id);
            Delete(item);
        }

        public IEnumerable<TaskList> GetAll()
        {
            return db.TaskLists.ToList();
        }

        public IEnumerable<TaskList> GetByCreatorId(int creatorId)
        {
            return db.TaskLists.Where(x => x.CreatorId == creatorId).ToList();
        }

        public TaskList GetById(int id)
        {
            return db.TaskLists.Find(id);
        }

        public IEnumerable<TaskList> GetInvolvedInto(int userId)
        {
            var user = db.Users.Find(userId);
            return db.TaskLists.Where(x => x.CreatorId == userId || x.Members.Contains(user)).ToList();
        }

        public void Invite(TaskList taskList, string username)
        {
            var user = db.Users.FirstOrDefault(x => x.UserName == username);
            if (user == null)
            {
                throw new Exception("User does not exist");
            }
            if (taskList.Invited.Contains(user))
            {
                throw new Exception("User already invited");
            }
            if (taskList.Members.Contains(user))
            {
                throw new Exception("User is already member");
            }
            if (taskList.Creator.Id == user.Id)
            {
                throw new Exception("User is creator");
            }
            taskList.Invited.Add(user);
            Update(taskList);
        }

        public void RemoveRight(TaskList taskList, string username, string right)
        {
            var user = db.Users.FirstOrDefault(x => x.UserName == username);
            if (user == null)
            {
                throw new Exception("User does not exist");
            }
            if (taskList.Members.Count(x => x.Id == user.Id) == 0)
            {
                throw new Exception("User is not a member");
            }
            if (user.Rights.Count(x => x.Right == right && x.TaskListId == taskList.Id) == 0)
            {
                throw new Exception("User does not have this right");
            }
            var dbRight = db.MemberRights.FirstOrDefault(x => x.TaskListId == taskList.Id && x.MemberId == user.Id && x.Right == right);
            db.MemberRights.Remove(dbRight);
            db.SaveChanges();
        }

        public void Update(TaskList item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
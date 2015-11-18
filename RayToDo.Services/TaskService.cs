using RayToDo.Data.EntityFramework;
using RayToDo.Data.EntityFramework.Models;
using RayToDo.Services.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RayToDo.Services
{
    public class TaskService : ITaskService
    {
        private IAppDbContext db;

        public TaskService(IAppDbContext db)
        {
            this.db = db;
        }

        public void Add(Task item)
        {
            db.Tasks.Add(item);
            db.SaveChanges();
        }

        public void Delete(Task item)
        {
            db.Tasks.Remove(item);
            db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var task = GetById(id);
            Delete(task);
        }

        public IEnumerable<Task> GetAll()
        {
            return db.Tasks.ToList();
        }

        public Task GetById(int id)
        {
            return db.Tasks.Find(id);
        }

        public void Update(Task item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TaskManager.Models;
//mongodb
using MongoDB.Driver;
using TaskManager.Controllers;
using TaskManager.Helpers;
using Microsoft.Extensions.Options;

namespace TaskManager.Services
{
    public class TaskService : ITaskService
    {
        private readonly IMongoCollection<Tasks> _tasks;

        public TaskService(IOptions<TaskManagerDBSettings> op)
        {            
            var client = new MongoClient(op.Value.ConnectionString);
            var database = client.GetDatabase(op.Value.DatabaseName);

            _tasks = database.GetCollection<Tasks>(op.Value.TasksCollectionName);
        }

        public List<Tasks> GetAll() =>
            _tasks.Find(t => true).ToList();

        public Tasks GetTaskById(string id) =>
            _tasks.Find<Tasks>(t => t.Id == id).FirstOrDefault();

        public List<Tasks> GetTaskByOwnerID (string id)
        {
            return _tasks.Find<Tasks>(t => t.ownerID == id).ToList();
        }



        public Tasks Create(Tasks taskIn)
        {
            _tasks.InsertOne(taskIn);
            return taskIn;
        }

        public void Update(string id, Tasks taskIn) =>
            _tasks.ReplaceOne(t => t.Id == id, taskIn);

        public void Delete(string id) =>
            _tasks.DeleteOne(t => t.Id == id);
        

    }
}

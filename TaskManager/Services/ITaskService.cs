using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.Services
{
    public interface ITaskService
    {
        List<Tasks> GetAll();
        Tasks GetTaskById(string id);
        Tasks Create(Tasks taskIn);
        void Update(string id, Tasks taskIn);
        void Delete(string id);
    }
}

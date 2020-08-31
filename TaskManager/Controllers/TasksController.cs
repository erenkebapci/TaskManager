using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {

        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public ActionResult<List<Tasks>> GetAll()
        {
            return _taskService.GetAll();
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<Tasks> GetTaskById(string id)
        {
            var Task = _taskService.GetTaskById(id);
            if (Task == null)
            {
                return NotFound();
            }
            return Task;
        }

        [HttpPost]
        public ActionResult<Tasks> Create([FromBody]Tasks task)
        {

            _taskService.Create(task);

            return task;
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult<Tasks> Update(string id,Tasks task)
        {
            if (_taskService.GetTaskById(id) == null)
            {
                return NotFound();
            }

            _taskService.Update(id, task);
            return task;
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult<Tasks> Delete(string id)
        {
            if (_taskService.GetTaskById(id)==null)
            {
                return NotFound();
            }

            _taskService.Delete(id);
            return NoContent();
        }
    }
}

using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.Helpers
{
    public class ConfigurationHelper : IConfigurationHelper
    {
        private readonly IConfiguration _configuration;
        public ConfigurationHelper(IConfiguration configuration)
        {
            _configuration=configuration;
        }
        public TaskManagerDBSettings GetDBConfig()
        {
            return JsonConvert.DeserializeObject<TaskManagerDBSettings>(_configuration.GetSection("TaskManagerDBSettings").Value);
        }
    }
}

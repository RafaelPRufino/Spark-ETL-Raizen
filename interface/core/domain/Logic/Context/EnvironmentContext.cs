using Domain.Interfaces.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Logic.Context
{
    public class EnvironmentContext : IEnvironmentContext
    {
        public string ENV_RABBIT_QUEUE => System.Environment.GetEnvironmentVariable("RABBIT_QUEUE");

        public string ENV_RABBIT_HOST => System.Environment.GetEnvironmentVariable("RABBIT_HOST");

        public string ENV_RABBIT_USER => System.Environment.GetEnvironmentVariable("RABBIT_USER");

        public string ENV_RABBIT_PASSWORD => System.Environment.GetEnvironmentVariable("RABBIT_PASSWORD");

        public int ENV_RABBIT_SLEEP
        {
            get
            {
                string? raw = System.Environment.GetEnvironmentVariable("RABBIT_SLEEP");
                int value;
                return int.TryParse(raw, out value) ? value : 3600;
            }
        }
        public int ENV_WATCH_SLEEP
        {
            get
            {
                string? raw = System.Environment.GetEnvironmentVariable("WATCH_SLEEP");
                int value;
                return int.TryParse(raw, out value) ? value : 3600;
            }
        }

        public string ENV_WATCH_FOLDER_DATA => System.Environment.GetEnvironmentVariable("WATCH_FOLDER_DATA");

        public string ENV_WATCH_FOLDER_TEMP => System.Environment.GetEnvironmentVariable("WATCH_FOLDER_TEMP");
    }
}

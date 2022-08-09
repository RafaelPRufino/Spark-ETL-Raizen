using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Context
{
    public interface IEnvironmentContext
    {
        string ENV_RABBIT_QUEUE { get; }
        string ENV_RABBIT_HOST { get; }
        string ENV_RABBIT_USER { get; }
        string ENV_RABBIT_PASSWORD { get; }
        int ENV_RABBIT_SLEEP { get; }
        int ENV_WATCH_SLEEP { get; }
        string ENV_WATCH_FOLDER_DATA { get; }
        string ENV_WATCH_FOLDER_TEMP { get; }
    }
}

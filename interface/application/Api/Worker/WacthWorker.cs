using Domain.Interfaces.Context;
using Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Worker
{
    public class WacthWorker : BackgroundService
    {
        private readonly ILogger<WacthWorker> _logger;
        private readonly IWacthService _wacth;
        private readonly IEnvironmentContext _environment;
        public WacthWorker(ILogger<WacthWorker> logger,  IEnvironmentContext environment, IWacthService wacth)
        {
            _logger = logger;
            _wacth = wacth;
            _environment = environment;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("ENV_WATCH_FOLDER_DATA: {1}", _environment.ENV_WATCH_FOLDER_DATA);
            _logger.LogInformation("ENV_WATCH_FOLDER_TEMP: {1}", _environment.ENV_WATCH_FOLDER_TEMP);

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker executando em: {time}", DateTimeOffset.Now);

                _logger.LogInformation(_wacth.Process()); 

                await Task.Delay(_environment.ENV_WATCH_SLEEP, stoppingToken);
            }
        }
    }

}

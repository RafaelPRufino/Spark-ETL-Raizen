using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.Context;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WatchController : ControllerBase
    {
        private readonly ILogger<WatchController> _logger;
        private readonly IWacthService _wacth;
        public WatchController(ILogger<WatchController> logger, IWacthService wacth)
        {
            _logger = logger;
            _wacth = wacth;
        }

        [HttpGet]
        public string Get()
        {
            return _wacth.Process();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApiTest.Configuration;

namespace WebApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IOptions<ConnectionStringsConfiguration> _connectionStringsConfiguration;


        public WeatherForecastController(
            ILogger<WeatherForecastController> logger, 
            IConfiguration configuration,
            IOptions<ConnectionStringsConfiguration> connectionStringsConfiguration)
        {
            _logger = logger;
            _configuration = configuration;
            _connectionStringsConfiguration = connectionStringsConfiguration; 
        }

        [HttpGet]
        public string  Get()
        {
            string connectionString1 = _configuration.GetSection("ConnectionStrings").GetSection("sqlConnectionOracle").Value;
            string connectionString2 = _configuration.GetValue<string>("ConnectionStrings:sqlConnectionOracle");
            string serilogFilePath = _configuration.GetSection("SerilogFilePath").Value;

            string connectionString3 = _connectionStringsConfiguration.Value.SqlConnectionOracle; 

            return "Hello John"; 
        }
    }
}

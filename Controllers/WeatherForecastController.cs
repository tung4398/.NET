using Demo.Databases.Master;
using Demo.Params;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
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
        private readonly MasterDBContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, MasterDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("Login1")]
        public IActionResult Login1(string strParam1, string strParam2, int nInt1)
        {
            return Ok(strParam1);
        }

        [HttpPost("PostDemo")]
        public IActionResult Login2([FromBody] LoginRequestMessage requestMessage)
        {
            var account = _context.Account
                .Select(x => new
                {
                    x.Username
                })
                .Where(x => x.Username == requestMessage.Username).FirstOrDefault();


            // async 

            //if(account == null)
            //{
            //    // ACCOUNT NOT EXISTS
            //}
            //else if(account.Password != requestMessage.Password)
            //{
            //    // IN VALID PASSWORD
            //}
            //else
            //{
            //    // SUCCESS
            //}

            return Unauthorized(requestMessage);
        }
    }
}
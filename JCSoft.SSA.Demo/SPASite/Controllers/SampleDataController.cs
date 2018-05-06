using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JCSoft.SSA.Configurations;
using JCSoft.SSA.Tools.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace SPASite.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly SSAConfiguration _configuration;
        private readonly IHttpHelper _httpHelper;
        public SampleDataController(IOptions<SSAConfiguration> options,
            IHttpHelper httpHelper)
        {
            _configuration = options.Value;
            _httpHelper = httpHelper;
        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public async Task<IEnumerable<WeatherForecast>> WeatherForecasts()
        {
            var uri = $"{_configuration.ServicesUri}/api/values";
            var response = await _httpHelper.GetAsync(uri);
            var values = JsonConvert.DeserializeObject<string[]>(response);

            return values.Select(w => new WeatherForecast
            {
                Summary = w,
                DateFormatted = DateTime.Today.ToString("yyyy-MM-dd")
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}

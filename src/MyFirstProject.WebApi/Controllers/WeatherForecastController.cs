using Microsoft.AspNetCore.Mvc;

namespace MyFirstProject.WebApi.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
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

        private bool GetEmployeePostgreSql(int id)
        {
            try
            {
                string conexao = "User ID=leandro;Password=testeLeandroPrado;Host=postgresqlserver-platinst02sandbox.postgres.database.azure.com;Port=5432;Database=Employee;Pooling=true;";
                
                using NpgsqlConnection connection = new NpgsqlConnection(conexao);
                connection.OpenAsync();
                
                string selectCommand = "SELECT * FROM Employee WHERE id = " + id.ToString();

                NpgsqlCommand command = new NpgsqlCommand(selectCommand, connection);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int key = reader.GetInt32(0);
                        string name = reader.GetString(1);
                    }
                }

                return true;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}

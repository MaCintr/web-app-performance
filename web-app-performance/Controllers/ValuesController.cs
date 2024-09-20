using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using web_app_performance.Model;

namespace web_app_performance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetUsuario()
        {
            String connectionString = "Server=localhost;Database=sys;User=root;Password=123;";
            using var connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();
            string query = "select id, name, email from users;";
            var usuarios = await connection.QueryAsync<User>(query);
            return Ok(usuarios);
        }
    }
}
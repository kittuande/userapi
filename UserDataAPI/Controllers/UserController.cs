using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using UserDataAPI.Models;

namespace UserDataAPI.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        [Authorize]
        [HttpGet("GetUserDetails")]
        public Data? GetUserDetails()
        {
            var data = new Data();
            using (StreamReader reader =  new StreamReader("Data/Data.json"))
            {        
                var jObject = reader.ReadToEnd();
                data = JsonSerializer.Deserialize<Data>(jObject);
            }
                return data;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(ILogger<AuthenticationController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> Validate(Loyalty loyalty)
        {
            if (loyalty.LoyaltyId == "abcd")
            {
                return Ok(new { promoCode = "danilo@example.com" });
            }

            return Conflict(new ResponseContent() { 
                version = "1.0.0",
                status = 409,
                userMessage = "There is an error from my api"
            });
        }
    }
    
    public class Loyalty
    {
        public string Email { get; set; }
        public string Language { get; set; }
        public string LoyaltyId { get; set; }
    }

    public class ResponseContent
    {
        public string version { get; set; }
        public int status { get; set; }
        public string code { get; set; }
        public string userMessage { get; set; }
        public string developerMessage { get; set; }
        public string requestId { get; set; }
        public string moreInfo { get; set; }
    }
}

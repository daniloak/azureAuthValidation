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

            return Conflict(new { userMessage = "There is an error coming from API" });
        }
    }
    
    public class Loyalty
    {
        public string Email { get; set; }
        public string Language { get; set; }
        public string LoyaltyId { get; set; }
    }
}

using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using RestSharp.Authenticators;

namespace ExpertClubTeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Create()
        {
            throw new ArgumentNullException("ARGUMENTO");
            var client = new RestClient("https://api.twitter.com/1.1")
            {
                Authenticator = new HttpBasicAuthenticator("username", "password")
            };

            var request = new RestRequest("statuses/home_timeline.json", DataFormat.Json);
            var response = client.Get(request);

            return Ok(response);
        }
        
        [HttpGet("{delay}")]
        public IActionResult Create(string delay)
        {
            // HTTP BIN
            var client = new RestClient("https://httpbin.org");
            var request = new RestRequest($"delay/{delay}", DataFormat.Json);
            var response = client.Get(request);
            
            // POSTMAN ECHO
            var clientPostman = new RestClient("https://postman-echo.com");
            var requestPostman = new RestRequest($"get?foo1=bar1&foo2=bar2", DataFormat.Json);
            var responsePostman = clientPostman.Get(requestPostman);
            
            // HTTP BIN
            var clientNew = new RestClient("https://httpbin.org");
            var requestNew = new RestRequest($"delay/{Convert.ToDecimal(delay) - 3}", DataFormat.Json);
            var responseNew = clientNew.Get(requestNew);

            // BORED API
            var clientBored = new RestClient("https://httpbin.org");
            var requestBored = new RestRequest($"delay/{Convert.ToDecimal(delay) - 3}", DataFormat.Json);
            var responseBored = clientBored.Get(requestBored);
            
            // BINANCE
            var clientBinance = new RestClient("https://api2.binance.com");
            var requestBinance = new RestRequest($"api/v3/ticker/24hr", DataFormat.Json);
            var responseBinance = clientBinance.Get(requestBinance);
            
            // COINBASE
            var clientCoinbase = new RestClient("https://api.coinbase.com");
            var requestCoinbase = new RestRequest($"v2/currencies", DataFormat.Json);
            var responseCoinbase = clientCoinbase.Get(requestCoinbase);
            
            // TECH
            var clientTech = new RestClient("https://techcrunch.com");
            var requestTech = new RestRequest($"wp-json/wp/v2/posts?per_page=100&context=embed", DataFormat.Json);
            var responseTech = clientTech.Get(requestTech);

            return Ok(new {
                response = response.Content,
                responsePostman = responsePostman.Content,
                responseBored = responseBored.Content,
                responseBinance = responseBinance.Content,
                responseCoinbase = responseCoinbase.Content,
                responseTechcrunch = responseTech.Content,
            });
        }
    }
}
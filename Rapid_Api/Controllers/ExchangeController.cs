using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rapid_Api.Models;

namespace Rapid_Api.Controllers
{
    public class ExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=USD&to_symbol=TRY&language=en"),
                Headers =
    {
        { "X-RapidAPI-Key", "8e7639e9d7msh014c646e6aaa9acp15e24bjsn5fe00f032feb" },
        { "X-RapidAPI-Host", "real-time-finance-data.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
                return View(values);
            }

        
        }
    }
}

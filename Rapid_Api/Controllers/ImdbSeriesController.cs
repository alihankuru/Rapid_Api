using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Rapid_Api.Models;

namespace Rapid_Api.Controllers
{
    public class ImdbSeriesController : Controller
    {
        public async Task<IActionResult> Index()
        {
           
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/series/"),
                Headers =
    {
        { "X-RapidAPI-Key", "8e7639e9d7msh014c646e6aaa9acp15e24bjsn5fe00f032feb" },
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ImdbSeriesViewModel>>(body);
                return View(values);
            }
          
        }
    }
}

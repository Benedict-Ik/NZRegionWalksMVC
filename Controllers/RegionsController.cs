using Microsoft.AspNetCore.Mvc;
using NZRegionWalksMVC.Models.DTOs;

namespace NZRegionWalksMVC.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegionsController(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            List<RegionDTO> response = new List<RegionDTO>();
            try
            {
                var client = _httpClientFactory.CreateClient();
                var httpResponseMessage = await client.GetAsync("https://localhost:7148/api/regions");
                httpResponseMessage.EnsureSuccessStatusCode();

                /* Extract the data from the response */
                // var bodyResponse = await httpResponseMessage.Content.ReadAsStringAsync();

                /* When retrieving the data, it's best to get it as an object rather than a string */
                response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<RegionDTO>>());

                /* Since we are getting the response as an object, the below line (ViewBag) won't
                be necessary anymore. Rather, we can directly parse the response in a view */
                //ViewBag.Response = bodyResponse;
                //return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
                //return NotFound();
            }
            return View(response);
        }
    }
}

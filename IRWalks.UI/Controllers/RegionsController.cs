using IRWalks.UI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace IRWalks.UI.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public RegionsController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            List<RegionDto> response = new List<RegionDto>();
            try
            {
                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.GetAsync("https://localhost:7220/api/regions");

                httpResponseMessage.EnsureSuccessStatusCode();
                 response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<RegionDto>>());  
                
            }
            catch (Exception ex)
            {

            }
       
            return View(response);
        }
    }
}
  
using Microsoft.AspNetCore.Mvc;
using ObscurusShop.UI.Models;
using System.Diagnostics;
using System.Net.Http.Json;

namespace ObscurusShop.UI.Controllers
{
    public class GuitarsController : Controller
    {
        private readonly HttpClient _http;

        public GuitarsController(IHttpClientFactory httpClientFactory)
        {
            _http = httpClientFactory.CreateClient("api");
        }

        // GET: /Guitars
        public async Task<IActionResult> Index()
        {
            var guitars = await _http.GetFromJsonAsync<List<Guitar>>("api/guitars");
            return View(guitars);
        }

        // POST: /Guitars/Create
        [HttpPost]
        public async Task<IActionResult> Create(Guitar guitar)
        {
            await _http.PostAsJsonAsync("api/guitars", guitar);
            return RedirectToAction(nameof(Index));
        }

        // POST: /Guitars/UpdatePrice
        [HttpPost]
        public async Task<IActionResult> UpdatePrice(int id, decimal newPrice)
        {
            var response = await _http.GetFromJsonAsync<Guitar>($"api/guitars/{id}");
            if (response != null)
                {
                response.Price = newPrice;
                await _http.PutAsJsonAsync($"api/guitars/{id}", response);
                }
            return RedirectToAction(nameof(Index));
        }

        // POST: /Guitars/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _http.DeleteAsync($"api/guitars/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}

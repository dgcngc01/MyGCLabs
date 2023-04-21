using DeckOfCards.Models;
using DeckOfCards.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeckOfCards.Controllers
{
    public class HomeController : Controller
    {
        private readonly DeckApiService _deckApiService;

        public HomeController(DeckApiService deckApiService)
        {
            _deckApiService = deckApiService;
        }

        public async Task<IActionResult> Index()
        {
            Deck result = await _deckApiService.DrawYourCards();
            return View(result);
        }

        public async Task<IActionResult> Draw()
        {
            Deck result = await _deckApiService.DrawYourCards();
            DrawResponse response = await _deckApiService.Draw(result);
            return View(response);
        }

    }
}
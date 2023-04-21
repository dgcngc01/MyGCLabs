using DeckOfCards.Models;
using System.Text;

namespace DeckOfCards.Services
{
    public class DeckApiService
    {
        // To make web requests from .NET we will use a built in class calles HttpClient
        // We will create a singleton of the HttpClient
        private readonly HttpClient _httpClient = null;

        public DeckApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Deck> DrawYourCards()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("new/shuffle/?deck_count=1");
            Deck result = await response.Content.ReadAsAsync<Deck>();

            return result;
        }

        public async Task<DrawResponse> Draw(Deck deck)

        {
			HttpResponseMessage response = await _httpClient.GetAsync($"{deck.deck_id}/draw/?count=5");
            DrawResponse result = await response.Content.ReadAsAsync<DrawResponse>();

            return result;
        }
    }
}

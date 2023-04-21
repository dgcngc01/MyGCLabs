namespace DeckOfCards.Models
{
    public class Deck 
    {
        public bool success { get; set; } // These property names MUST be the same as the JSON names
        public string deck_id { get; set; }
        public bool shuffled { get; set; }
        public int remaining { get; set; }
    }
}
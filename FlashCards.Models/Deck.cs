using System;
using FlashCards.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards.Models
{
    public class Deck 
    {
        public Deck()
        {

        }
        public Deck(int deckId, string deckName, string deckDescription)
        {
            DeckId = deckId;
            DeckName = deckName;
            DeckDescription = deckDescription;
            CreationTimeStamp = DateTime.UtcNow;
            Cards = new List<Card>();
        }
        public int DeckId { get; set; }

        public string DeckName { get; set; }

        public string DeckDescription { get; set; }

        public DateTime CreationTimeStamp { get; set; }

        public ICollection<Card> Cards { get; set; }
    }
}

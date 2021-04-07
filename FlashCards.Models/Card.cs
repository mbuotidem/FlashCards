using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FlashCards.Models
{
    public class Card
    {
        public Card()
        {

        }

        public Card(int cardId, string term, string definition)
        {
            CardId = cardId;
            Term = term;
            Definition = definition;
            CreationTimeStamp = DateTime.UtcNow;
        }
        public int CardId { get; set; }

        [Required]
        [ForeignKey("Deck")]
        public int DeckId { get; set; }

        [ForeignKey("DeckId")]
        public virtual Deck Deck { get; set; }

        public string Term { get; set; }

        public string Definition { get; set; }

        public bool Correct { get; set; }
        
        public DateTime CreationTimeStamp { get; set; }
    }
}

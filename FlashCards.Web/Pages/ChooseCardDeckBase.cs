using FlashCards.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashCards.Web.Pages
{
    public class ChooseCardDeckBase : ComponentBase
    {
        public List<Deck> Decks { get; set; } = new List<Deck>();

        protected override async Task OnInitializedAsync()
        {
            await Task.Run(LoadDecks);

        }

        private void LoadDecks()
        {

            // Retrieve data from the server and initialize
            // Deck property which the View will bind

            Deck D1 = new Deck
            {
                DeckId = 1,
                DeckName = "CSS Text Properties",
                DeckDescription = "n/a",
                CreationTimeStamp = DateTime.UtcNow

            };


            Deck D2 = new Deck
            {
                DeckId = 2,
                DeckName = "Korean Foods",
                DeckDescription = "n/a",
                CreationTimeStamp = DateTime.UtcNow,

            };

            Deck D3 = new Deck
            {
                DeckId = 3,
                DeckName = "Common Korean Words",
                DeckDescription = "n/a",
                CreationTimeStamp = DateTime.UtcNow,

            };

            Deck D4 = new Deck
            {
                DeckId = 4,
                DeckName = "Coding Questions",
                DeckDescription = "n/a",
                CreationTimeStamp = DateTime.UtcNow,

            };

            Decks = new List<Deck> { D1, D2, D3, D4 };
        }
    }
}

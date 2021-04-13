using FlashCards.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashCards.Web.Pages
{
    public class CardComponentBase : ComponentBase
    {
        public int Id { get; set; }
        public ElementReference testRef;
        [Parameter]
        public List<Card> Cards { get; set; } = new List<Card>();

        public Card Card { get; set; } = new Card();

        protected string ButtonText { get; set; } = "Show Answer";
        protected string CssClass { get; set; } = "HideFooter";

        public double score;

        protected override Task OnInitializedAsync()
        {
            //LoadCards();
            return base.OnInitializedAsync();
        }

        protected void Button_Click()
        {
            if (ButtonText== "Show Answer")
            {
                ButtonText = "Hide Answer";
                CssClass = null;
            }

            else  
            {
                CssClass = "HideFooter";
                ButtonText = "Show Answer";
            }
        }


    protected override void OnParametersSet()
    {
        Card = Cards.FirstOrDefault();
        //await testRef.FocusAsync();
        
        //currentCard = Deck.Cards.FirstOrDefault();
        //StateHasChanged();
    }
    }
}



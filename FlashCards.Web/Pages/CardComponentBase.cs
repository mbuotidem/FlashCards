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

        protected string Hide { get; set; } = "hide";
        protected string Show { get; set; } = "show";

        public double Right;
        public double Wrong;

        public string Flip { get; set; }

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }



        protected override void OnParametersSet()
        {
            Card = Cards.FirstOrDefault();
        }
    }
}



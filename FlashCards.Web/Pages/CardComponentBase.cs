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
        public List<Card> Cards { get; set; } = new List<Card>();

        protected string ButtonText { get; set; } = "Hide Answer";
        protected string CssClass { get; set; } = null;

        protected override Task OnInitializedAsync()
        {
            LoadCards();
            return base.OnInitializedAsync();
        }

        protected void Button_Click()
        {
            if (ButtonText== "Hide Answer")
            {
                ButtonText = "Show Answer";
                CssClass = "HideFooter";
            }

            else
            {
                CssClass = null;
                ButtonText = "Hide Answer";
            }
        }


        private void LoadCards()
        {
            Card c1 = new Card
            {
                CardId = 1,
                Term = "IT",
                Definition = "Information Technology",
                CreationTimeStamp = DateTime.UtcNow
            };

            Card c2 = new Card
            {
                CardId = 2,
                Term = "CIS",
                Definition = " Computer Information System",
                CreationTimeStamp = DateTime.UtcNow
            };
            Cards.Add(c1);
            Cards.Add(c2);

        }


    }

}

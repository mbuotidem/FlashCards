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

        protected string ButtonText { get; set; } = "Show Answer";
        protected string CssClass { get; set; } = "HideFooter";

        protected override Task OnInitializedAsync()
        {
            LoadCards();
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


        private void LoadCards()
        {
            Card c1 = new Card
            {
                CardId = 1,
                Term = "IT",
                Definition = "1.Information Technology \n" +
                             "2.Important Techniques \n" + 
                             "3.Interesting Technologies " ,
                CreationTimeStamp = DateTime.UtcNow
            };

            Card c2 = new Card
            {
                CardId = 2,
                Term = "CIS",
                Definition = "a) Computer Information System \n" +
                             "b) Computer Information sistem \n" +
                             " c) Computer Interesting subjects \n ",


                CreationTimeStamp = DateTime.UtcNow
            };
            Cards.Add(c1);
            Cards.Add(c2);



        }
    }
}



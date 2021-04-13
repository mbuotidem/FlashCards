using System;
using System.Collections.Generic;
using System.Linq;
using FlashCards.Models;
using FlashCards.Web;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace FlashCards.Web.Pages
{
    public class DeckDetailsBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }

        public Deck Deck { get; set; }

    }
}





using FlashCards.Api.Models;
using FlashCards.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashCards.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeckController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public DeckController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        [HttpPost]
        public async Task<ActionResult<Deck>> CreateDeck(Deck deck)
        {
            try
            {
                if (deck == null)
                {
                    return BadRequest();
                }

                var dk = await appDbContext.Decks.FirstOrDefaultAsync(d => d.DeckId == deck.DeckId);

                if (dk != null)
                {
                    ModelState.AddModelError("Deck", "Deck already exists");
                    return BadRequest(ModelState);
                }

                //Mark creation date of deck and its cards on the server in UTC to enable localization
                deck.CreationTimeStamp = DateTime.UtcNow;

                foreach (var card in deck.Cards)
                {
                    card.CreationTimeStamp = DateTime.UtcNow;
                }
                var result = await appDbContext.Decks.AddAsync(deck);
                await appDbContext.SaveChangesAsync();

                var createdDeck = result.Entity;
                return CreatedAtAction(nameof(GetDeck), new { id = createdDeck.DeckId }, createdDeck);



            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<Deck>>> GetDecks()
        {
            try
            {
                List<Deck> decks = new List<Deck>();

                decks = await appDbContext.Decks.Include(d=>d.Cards).ToListAsync();

                return Ok(decks);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Deck>> GetDeck(int id)
        {
            try
            {
                var result = await appDbContext.Decks.Include(d=> d.Cards).FirstOrDefaultAsync(d => d.DeckId == id);

                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Deck>> UpdateDeck(int id, Deck deck)
        {
            try
            {
                if (id != deck.DeckId)
                {
                    return BadRequest("Deck ID mismatch");
                }
                var deckToUpdate = await appDbContext.Decks.FirstOrDefaultAsync(d => d.DeckId == deck.DeckId);

                if(deckToUpdate == null)
                {
                    return NotFound($"Deck with Id = {id} not found");
                }

                deckToUpdate.DeckName = deck.DeckName;
                deckToUpdate.DeckDescription = deck.DeckDescription;

                await appDbContext.SaveChangesAsync();

                return deckToUpdate;
            }

            catch(Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Deck>> DeleteDeck(int id)
        {
            try
            {
                var deckToDelete = await appDbContext.Decks.FirstOrDefaultAsync(d => d.DeckId == id);

                if (deckToDelete == null)
                {
                    return NotFound($"Deck with {id} does not exist");
                }

                appDbContext.Decks.Remove(deckToDelete);
                await appDbContext.SaveChangesAsync();
                return deckToDelete;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }

        [HttpPost("/Card")]
        public async Task<ActionResult<Card>> CreateCard(Card card)
        {
            try
            {
                if (card == null || card.DeckId <= 0)
                {
                    return BadRequest();
                }

                var cd = await appDbContext.Cards.FirstOrDefaultAsync(c => c.CardId== card.CardId);

                if (cd != null)
                {
                    ModelState.AddModelError("Card", "Card already exists");
                    return BadRequest(ModelState);
                }

                //Mark creation date card on the server in UTC to enable localization
                card.CreationTimeStamp = DateTime.UtcNow;

                var result = await appDbContext.Cards.AddAsync(card);
                await appDbContext.SaveChangesAsync();

                var createdCard = result.Entity;
                return CreatedAtAction(nameof(GetDeck), new { id = createdCard.CardId }, createdCard);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpDelete("/Card/{id:int}")]
        public async Task<ActionResult<Card>> DeleteCard(int id)
        {
            try
            {
                var cardToDelete = await appDbContext.Cards.FirstOrDefaultAsync(d => d.CardId == id);

                if (cardToDelete == null)
                {
                    return NotFound($"Card with {id} does not exist");
                }

                appDbContext.Cards.Remove(cardToDelete);
                await appDbContext.SaveChangesAsync();
                return cardToDelete;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }

        [HttpPut("/Card/{id:int}")]
        public async Task<ActionResult<Card>> UpdateCard(int id, Card card)
        {
            try
            {
                if (id != card.CardId)
                {
                    return BadRequest("Card ID mismatch");
                }
                var cardToUpdate = await appDbContext.Cards.FirstOrDefaultAsync(c => c.CardId == card.CardId);

                if (cardToUpdate == null)
                {
                    return NotFound($"Card with Id = {id} not found");
                }

                cardToUpdate.Term = card.Term;
                cardToUpdate.Definition= card.Definition;

                await appDbContext.SaveChangesAsync();

                return cardToUpdate;
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }
    }

}

using FlashCards.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashCards.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Deck> Decks { get; set; }

        public DbSet<Card> Cards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Specify relationships
            modelBuilder.Entity<Card>().HasOne(cd => cd.Deck).WithMany(dk => dk.Cards).HasForeignKey(cd => cd.DeckId);

            //Seed Deck Table

            modelBuilder.Entity<Deck>().HasData(new Deck { DeckId = 1, CreationTimeStamp = DateTime.UtcNow, DeckName = "Seed Deck", DeckDescription = "Seed Deck" });
            modelBuilder.Entity<Deck>().HasData(new Deck { DeckId = 2, CreationTimeStamp = DateTime.UtcNow, DeckName = "Seed Deck 2", DeckDescription = "Seed Deck 2" });

            modelBuilder.Entity<Card>().HasData(new Card { CardId = 1, CreationTimeStamp = DateTime.UtcNow, DeckId = 1, Term = "Flashcard", Definition = "A tool for learning" });
            modelBuilder.Entity<Card>().HasData(new Card { CardId = 2, CreationTimeStamp = DateTime.UtcNow, DeckId = 1, Term = "Poker Card", Definition = "A tool for losing" });

            modelBuilder.Entity<Card>().HasData(new Card { CardId = 3, CreationTimeStamp = DateTime.UtcNow, DeckId = 2, Term = "Insurance card", Definition = "A tool for living" });

            base.OnModelCreating(modelBuilder);

        }
    }
}

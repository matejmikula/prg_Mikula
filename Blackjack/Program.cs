using System;
using System.Collections.Generic;

namespace Blackjack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the game of Blackjack");
            Console.Write("\n");

            Console.WriteLine("Goal: To get more close to Rank 21 of cards than the Dealer and dont over do it by having more than 21.");
            Console.Write("\n");

            Console.WriteLine("Ranks of cards:");
            Console.WriteLine("Ace: 1/11");
            Console.WriteLine("Jack, Queen, King: 10");
            Console.WriteLine("2-10: rank 2-10");
            Console.Write("\n");

            while (true)
            {
                Game();

                Console.Write("Do you want to play another game? (Y/N): ");
                string response = Console.ReadLine().ToLower();
                if (response != "y")
                {
                        break;
                }
                Console.Write("\n");
            }


    }

    static void Game()
        {
            Deck deck = new Deck();
            deck.Shuffle();

            Player nonDealer = new Player();
            Player dealer = new Player();

            nonDealer.AddCard(deck.DrawCard());
            dealer.AddCard(deck.DrawCard());
            nonDealer.AddCard(deck.DrawCard());
            dealer.AddCard(deck.DrawCard());

            while (true)
            {
                Console.WriteLine($"Your hand: {nonDealer.GetHand()}");
                Console.WriteLine($"Dealers hand: {dealer.GetHand()}");
                Console.WriteLine("What is your next move? (H = hit, S = stand)");
                string nDNextMove = Console.ReadLine().ToLower();

                if (nDNextMove == "h")
                {
                    nonDealer.AddCard(deck.DrawCard());
                    Console.Write("\n");

                    if (nonDealer.GetHandValue() > 21)
                    {
                        Console.WriteLine($"Your hand: {nonDealer.GetHand()}");
                        Console.WriteLine($"Dealers hand: {dealer.GetHand()}");
                        Console.WriteLine("You lose... Better luck next time!");
                        Console.Write("\n");
                        return;
                    }
                }
                else if (nDNextMove == "s")
                {
                    Console.Write("\n");
                    break;
                }
            }

            while (dealer.GetHandValue() <= 17)
            {
                dealer.AddCard(deck.DrawCard());
                Console.WriteLine($"Dealer's hand: {dealer.GetHand()}");
            }

            if (dealer.GetHandValue() > 21)
            {
                Console.WriteLine("Dealer loses... You win!");
            }
            else if (dealer.GetHandValue() > nonDealer.GetHandValue())
            {
                Console.WriteLine("Dealer wins!");
            }
            else if (dealer.GetHandValue() == nonDealer.GetHandValue())
            {
                Console.WriteLine("Its a draw nobody wins...");
            }
            else
            {
                Console.WriteLine("You win!");
            }
        }
    }

    public class Card
    {
        public Card(string suit, string rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public string Suit { get; set; }
        public string Rank { get; set; }

        public int GetValue()
        {
            if (Rank == "Ace")
                return 11;
            if (Rank == "Jack" || Rank == "Queen" || Rank == "King")
                return 10;

            return int.Parse(Rank);
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }

    public class Deck
    {
        public List<Card> cards;

        public Deck()
        {
            cards = new List<Card>();
            string[] suits = { "Spade", "Heart", "Clubs", "Diamond" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    Card card = new Card(suit, rank);
                    cards.Add(card);
                }
            }

        }

        public void Shuffle()
        {
            Random random = new Random();

            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);

                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        public Card DrawCard()
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
    }

    public class Player
    {
        public List<Card> hand;

        public Player()
        {
            hand = new List<Card>();
        }

        public void AddCard(Card card)
        {
            hand.Add(card);
        }

        public string GetHand()
        {
            string handString = string.Join(", ", hand);
            return $"Hand: {handString} (Total Value: {GetHandValue()})";
        }

        public int GetHandValue()
        {
            int value = 0;
            int numberOfAces = 0;

            foreach (var card in hand)
            {
                value += card.GetValue();

                if (card.Rank == "Ace")
                    numberOfAces++;
            }

            while (value > 21 && numberOfAces > 0)
            {
                value -= 10;
                numberOfAces--;
            }

            return value;
        }
    }
}

using System;
using System.CodeDom;
using System.Collections.Generic;

namespace Blackjack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the game of Blackjack"); //vysvětlení pravidel a hodnot v balckjacku
            Console.Write("\n");

            Console.WriteLine("Goal: To get more close to Rank 21 of cards than the Dealer and dont over do it by having more than 21.");
            Console.Write("\n");

            Console.WriteLine("Ranks of cards:");
            Console.WriteLine("Ace: 1/11");
            Console.WriteLine("Jack, Queen, King: 10");
            Console.WriteLine("2-10: rank 2-10");
            Console.Write("\n");

            

            while (true) // cyklus pro znovustpuštění hry pokud je zadaný spravný input (zde malé nebo velké y)
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

    static void Game() // zadefinování fungování hry
        {
            Deck deck = new Deck(); // zadefinování balíčku karet
            deck.Shuffle(); // funkce pro zamíchání karet

            Player nonDealer = new Player(); // zadefinování hráče a dealera
            Player dealer = new Player();

            nonDealer.AddCard(deck.DrawCard()); // funkce na přidávání karet dealerovi a hráči 
            dealer.AddCard(deck.DrawCard());
            nonDealer.AddCard(deck.DrawCard());
            dealer.AddCard(deck.DrawCard());

            while (true) // cyklus možností hráče 
            {
                Console.WriteLine($"Your hand: {nonDealer.GetHand()}"); // ukázání karet hráči (jak jeho tak dealerových)
                Console.WriteLine($"Dealers hand: {dealer.GetHand()}"); 
                Console.WriteLine("What is your next move? (H = hit, S = stand)"); // 2 možnosti co může hráč dělat
                string nDNextMove = Console.ReadLine().ToLower();

                if (nDNextMove == "h")
                {
                    nonDealer.AddCard(deck.DrawCard()); // pokud zvolí tuto možnost přidá se mu karta 
                    Console.Write("\n");

                    if (nonDealer.GetHandValue() > 21) // pokud po přidání karty má total value větší jak 21 tak prohrál, ukáže se jeho přestřelená value a value dealera 
                    {
                        Console.WriteLine($"Your hand: {nonDealer.GetHand()}");
                        Console.WriteLine($"Dealers hand: {dealer.GetHand()}");
                        Console.WriteLine("You lose... Better luck next time!");
                        Console.Write("\n");
                        return;
                    }
                }
                else if (nDNextMove == "s") // pokud zvolí tuto možnost zůstává mu value kterou viděl předtím a ukončuje hru
                {
                    Console.Write("\n");
                    break;
                }
            }

            while (dealer.GetHandValue() <= 17) // cyklus hry dealera
            {
                dealer.AddCard(deck.DrawCard()); //přidání karty 
                Console.WriteLine($"Dealer's hand: {dealer.GetHand()}"); //ukázání karet a total value hráči
            }

            if (dealer.GetHandValue() > 21) // if zajišťuje že dealer prohraje pokud přestřelí přes 21
            {
                Console.WriteLine("Dealer loses... You win!");
            }
            else if (dealer.GetHandValue() > nonDealer.GetHandValue()) // -||- pokud zajišťuje že dealer vyhraje pokud jeho karty mají větší jak hráčovi a zároveň menší nebo stejnou hodnotu jak 21
            {
                Console.WriteLine("Dealer wins!");
            }
            else if (dealer.GetHandValue() == nonDealer.GetHandValue()) // -||- pokud je value stejná je to remíza
            {
                Console.WriteLine("Its a draw nobody wins...");
            }
            else
            {
                Console.WriteLine("You win!");
            }
        }
    }

    public class Card //zadefinování classu Card
    {
        public Card(string suit, string rank)
        {
            Suit = suit; // zadefinování value a barvy
            Rank = rank;
        }

        public string Suit { get; set; }
        public string Rank { get; set; }

        public int GetValue()
        {
            if (Rank == "Ace") //value karet které nejsou pojmenované číslem
                return 11;
            if (Rank == "Jack" || Rank == "Queen" || Rank == "King")
                return 10;

            return int.Parse(Rank); // konvertování stringu (Ace/Jack, Queen, King) do intu (11/10)
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}"; // vrácení Ranku a Suit pro další funkce
        }
    }

    public class Deck // zadefinování classu Deck
    {
        public List<Card> cards; 

        public Deck()
        {
            cards = new List<Card>(); // zadefinování kombinace karet v balíčku
            string[] suits = { "Spade", "Heart", "Clubs", "Diamond" }; //všechny možnosti pro barvu (suit)
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" }; // všechny možnosti pro číslo/jméno (rank)

            foreach (string suit in suits) //cyklusy pro barvu a číslo/jméno pro vytvoření funkce na přidání nové karty 
            {
                foreach (string rank in ranks)
                {
                    Card card = new Card(suit, rank); 
                    cards.Add(card);
                }
            }

        }

        public void Shuffle() //funkce pro zamíchání karet
        {
            Random random = new Random(); // random funkce pro náhodný výběr karet

            for (int i = cards.Count - 1; i > 0; i--) // cyklus na zamíchání karet v balíčku prohazováním čísel na index na kterých jsou
            {
                int j = random.Next(0, i + 1);

                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        public Card DrawCard() // funkce pro class card na přidání další karty
        {
            Card card = cards[0]; //tyto dva řádky zajistí vyndání karty z balíčku po jejím použití
            cards.RemoveAt(0);
            return card;
        }
    }

    public class Player // zadefinování class Player
    {
        public List<Card> hand; // zadefinování karet hráče

        public Player()
        {
            hand = new List<Card>();
        }

        public void AddCard(Card card) // přidání karty do ruky hráče díky funkci AddCard
        {
            hand.Add(card);
        }

        public string GetHand() //ukázání karet na konzoli 
        {
            string handString = string.Join(", ", hand);
            return $"Hand: {handString} (Total Value: {GetHandValue()})";
        }

        public int GetHandValue() // zadefinování value všech karet v dané ruce
        {
            int value = 0;
            int numberOfAces = 0;

            foreach (var card in hand) //cyklus pro sčítání values karet 
            {
                value += card.GetValue();

                if (card.Rank == "Ace") //kontroluje počet es ve hře 
                    numberOfAces++;
            }

            while (value > 21 && numberOfAces > 0) //cyklus pro pro snížení value es pokud je total value > 21 nebo pokud má v ruce 2 a více es
            {
                value -= 10;
                numberOfAces--;
            }

            return value;
        }
    }
}

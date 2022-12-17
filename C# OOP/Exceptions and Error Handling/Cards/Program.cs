using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] deck = Console.ReadLine().Split(", ");
            List<Card> result = new List<Card>();          
            for (int i = 0; i < deck.Length; i++)
            {
                try
                { result.Add(CreateCard(deck[i].Split().First(), deck[i].Split().Last())); }              
                catch(FormatException formatEx)
                { Console.WriteLine(formatEx.Message); }                          
            }
            Console.WriteLine(string.Join(" ", result));
        }

        static Card CreateCard(string face, string suit)
        {
            if (!Regex.IsMatch(face, @"\b([2-9KJQA]|10)\b") && Regex.IsMatch(suit, @"[CSDH]"))
                throw new FormatException("Invalid card!");

            string newSuit = "";
            switch (suit)
            {
                case "S": newSuit = "\u2660"; break;
                case "H": newSuit = "\u2665"; break;
                case "D": newSuit = "\u2666"; break;
                case "C": newSuit = "\u2663"; break;
                default: throw new FormatException("Invalid card!");
            }
            return new Card(face, newSuit);
        }
    }
    public class Card
    {
        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }
        public string Face { get; set; }      
        public string Suit { get; set; }
        public override string ToString()
        {
            return $"[{Face}{Suit}]";          
        }
    }
}

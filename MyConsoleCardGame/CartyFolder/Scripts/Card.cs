using System;

namespace MyConsoleCardGame
{

	public enum CardSuit
	{
		Club, Diamond, Heart, Spade
	}

	public enum CardValue
	{
		Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace
	}

	public struct Card
	{
		public CardSuit Suit;
		public CardValue Value;
		public bool Played;
	}
}


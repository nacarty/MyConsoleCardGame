using System;

namespace MyConsoleCardGame
{
	public class CardPack
	{
		public static Card[] Pack = new Card[52];
		public CardSuit CS;
		public CardValue CV;

		public  Card[] Player1 = new Card[3]; //assume NumCards = 3 for now
		public  Card[] Player2 = new Card[3];
		public  Card[] Player3 = new Card[3];
		public  Card[] Player4 = new Card[3];


		public CardPack()
		{
			//initialise the pack of cards
			for (int i = 0; i < 13; i+=1) 
			{
				for (int j = 0; j < 4; j++) 
				{
					Pack [i * 4 + j].Value = CardValue.Two + i;
					Pack[i*4+j].Suit = CardSuit.Club + j;
					Pack [i * 4 + j].Played = false;
				}//end for

			} //end for

			ShowPack (52);
			ShuffleCards ();
			ShowPack (52);

		}//end cardPack constructor method


		public void ShuffleCards()
		{
			Random R = new Random ();
			Card C;
			int r;

			Console.WriteLine ("\n\n\n...Pack about to be shuffled...\n");
			for (int i = 0; i < 52; i++) 
			{
				C = Pack [i];
				r = R.Next (52);
				Pack [i] = Pack [r];
				Pack [r] = C;
			}

			Console.WriteLine ("\n...Pack has just been shuffled...\n");
		}

		public void ShowPack(int NumCards)
		{
			for (int i = 0; i < NumCards; i++) 
			{
				Console.WriteLine ("Card[{0}]: {1} of {2}. (Card Played -> {3})",
					i, Pack[i].Value, Pack[i].Suit, Pack[i].Played);
			}
		}
			

		public void DealCards(int NumPlayers, int NumCards, int Count)
		{
			int CardsLeft = 52 - Count;
			int CardsToShare = NumCards * NumPlayers;
			int Counter = Count;

			if ( CardsLeft >= CardsToShare)
			{
				Console.WriteLine("Cards are to be dealt...");

				for (int i=0; i < NumCards; i++)
				{
					Player1[i] = Pack[Counter++];
					Player2[i] = Pack[Counter++];
					Player3[i] = Pack[Counter++];
					Player4[i] = Pack[Counter++];
				}

				Console.WriteLine("Cards have been dealt...");

			}

			else
			{
				Console.WriteLine("There are only {0} cards left. These are not enough for {1} players each getting {2} cards...",
					CardsLeft, NumPlayers, NumCards);
				
			} //else

		}//DealCards()

		public void ShowPlayers()
		{
			Console.WriteLine("\nPlayer 1:");
			for (int i = 0; i < 3; i++) 
			{
				Console.WriteLine ("{0}. {1} of {2} (Played = {3})", i+1, Player1[i].Value, Player1[i].Suit, Player1[i].Played);
			}

			Console.WriteLine("\nPlayer 2:");
			for (int i = 0; i < 3; i++) 
			{
				Console.WriteLine ("{0}. {1} of {2} (Played = {3})", i+1, Player2[i].Value, Player2[i].Suit, Player2[i].Played);
			}

			Console.WriteLine("\nPlayer 3:");
			for (int i = 0; i < 3; i++) 
			{
				Console.WriteLine ("{0}. {1} of {2} (Played = {3})", i+1, Player3[i].Value, Player3[i].Suit, Player3[i].Played);
			}

			Console.WriteLine("\nPlayer 4:");
			for (int i = 0; i < 3; i++) 
			{
				Console.WriteLine ("{0}. {1} of {2} (Played = {3})", i+1, Player4[i].Value, Player4[i].Suit, Player4[i].Played);
			}
		}//end of ShowPlayers()



		}//end of class
	}//end of namespace
		



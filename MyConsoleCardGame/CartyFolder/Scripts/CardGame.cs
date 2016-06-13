using System;

namespace MyConsoleCardGame
{
	public class CardGame:CardPack
	{
		int TheWinner;

		public CardGame (int NumPlayers, int NumCards)
		{
			int Round = 0;  //which round in current game
			int Counter = 0;

		
			do 
			{
				DealCards (NumPlayers, NumCards, Counter);
				Round += 1;
				Counter += 12;

				Console.WriteLine("\n\n============= DEAL NUMBER {0} OF THE GAME ==============", Round);
				ShowPlayers ();	
				TheWinner = PlayHand (Round);
				ShowPlayers ();

				Console.WriteLine("\n Player {0} is the winner of the just-concluded hand of cards...", TheWinner );

				Console.ReadLine ();
			} while ( (52 - Counter) >= (NumPlayers * NumCards) );

			Console.WriteLine ("\nThe just-concluded game had {0} rounds... ", Round);
				
		} //end of constructor


		public int PlayHand(int WhoFirst)
		{
			int W = 0;

			PlayTurn (1, Player1, Player2, Player3, Player4);

			PlayTurn (2, Player2, Player3, Player4, Player1);

			PlayTurn (3, Player3, Player4, Player1, Player2);




			while ((W = Winner (Player1, Player2, Player3, Player4)) == 0) 
			{	
								 	
				PlayTurn (4, Player4, Player1, Player2, Player3);

				if ((W = Winner (Player1, Player2, Player3, Player4)) > 0) 
				{
					
					return W;
				} 
				else 
				{
					PlayTurn (1, Player1, Player2, Player3, Player4);
				}
							

				if ((W = Winner (Player1, Player2, Player3, Player4)) > 0) 
				{
					return W;
				} 
				else 
				{	
					PlayTurn (2, Player2, Player3, Player4, Player1);
				}
					

				if ((W = Winner (Player1, Player2, Player3, Player4)) > 0) 
				{
					
					return W;
				}
				else 
				{
					PlayTurn (3, Player3, Player4, Player1, Player2);
				}
										
			}//while

			return W;

		}//end PlayHand()


		public int Winner(Card[] Player1, Card[] Player2, Card[] Player3, Card[] Player4)
		{
	    //determines if there is a winner by seeing which array has 3 cards where 'Played = TRUE' 	
			if (WinnerInArray(Player1) == true) 
			{
				return 1;
			} 
			else if (WinnerInArray(Player2) == true) 
			{
				return 2;
			} 
			else if (WinnerInArray(Player3) == true) 
			{
				return 3;
			} 
			else if (WinnerInArray(Player4) == true) 
			{
				return 4;
			} 
			else 
			{
				return 0;
			}

		}//Winner


		bool WinnerInArray(Card[] aPlayer)
		{
			//determines if the array has 3 cards where 'Played = TRUE' 	
			bool Win = true;

			foreach ( Card C in aPlayer)        //similar to: for (int i = 0; i < 3; i++)
			{
				if ( C.Played == false) 
				{
					Win = false;
					break;
				} 
			}

			return Win;

		}//end aWinner()


		public void PlayTurn(int WhoseTurn, Card[] Array1 , Card[] Array2, Card[] Array3, Card[] Array4 )
		{

			Card Card1, Card2, Card3, Card4; //Card from a Card arrays possibly null

			Random r = new Random (); // r is declared and initialized as a random number generator

			int i = r.Next (3); //a random number in {0, 1, 2}

			int Count = 0;
			int Highest;


			while ((Array1 [i].Played == true) && (Count < 100)) 
			{
				i = r.Next (3);
				Count++;

			}//while



			if ((Count == 100) && (Array1 [i].Played == true))  //still try to see if there are unplayed cards in the player's card array by doing a sequential run through it
			{
				Console.WriteLine ("The first player has made 100 random tries to find a card to play without success...");
				Console.WriteLine ("Then something must be wrong. Perhaps he should have one already...Check your code.....");
				Console.WriteLine ("..But we will now try searching the card array sequentially as a last resort....");

				int j = 0;

				while ((Array1[j].Played == true)&&(j<3))
				{
					j++;
				}
				i = j;
			}//if

			if (Array1[i].Played == true) // if no card to play found, exit the function
			{ 
				Console.WriteLine ("Even after searching the card array sequentially, we have not found any unplayed cards......");
			} 
						
			else 
			{
				Card1 = Array1 [i]; //Card at position i is chosen for playing
				Array1 [i].Played = true; //then set card played status to TRUE

				Console.WriteLine ("\nPlayer {2} has played {0} of {1}", Card1.Value, Card1.Suit, WhoseTurn);

				Highest = ChooseHighestMatchingCard (Array2, Card1.Suit);
				if (Highest != -1)
					Card2 = Array2 [Highest];
				else
					Card2 = Card1; //this is not the most desirable thing. Card2 should be null.
			
				Highest = ChooseHighestMatchingCard (Array3, Card1.Suit);
				if (Highest != -1)
					Card3 = Array3 [Highest];
				else
					Card3 = Card1; //this is not the most desirable thing. Card3 should be null.

				Highest = ChooseHighestMatchingCard (Array4, Card1.Suit);
				if (Highest != -1)
					Card4 = Array4 [Highest];
				else
					Card4 = Card1; //this is not the most desirable thing. Card4 should be null.
			
			
				int[] GreatestCard = Greatest (Card1, Card2, Card3, Card4);

				int WinningPlayer = GreatestCard [0] + WhoseTurn - 1;
				if (WinningPlayer > 4)
					WinningPlayer = WinningPlayer % 4;

				int WinningValue = GreatestCard [1];
			
				Console.WriteLine ("\nPlayer {2} played first and played {0} of {1}", Card1.Value, Card1.Suit, WhoseTurn);
				Console.WriteLine ("Player {0} won that TURN with {1} of {2}.", WinningPlayer, (CardValue)WinningValue, Card1.Suit);
			}//else

		}//end PlayTurn()



		public int [] Greatest(Card C1, Card C2, Card C3, Card C4)
		{
			int GreatestCard = 1;
			CardValue GreatestCardValue = C1.Value;
					 

				//compare with C2
				if ( C2.Value > GreatestCardValue )
				{
					GreatestCard = 2;
					GreatestCardValue = C2.Value;
				}

				//compare with C3
			if ( C3.Value > GreatestCardValue )
				{
					GreatestCard = 3;
					GreatestCardValue = C3.Value;
				}
				
				//compare with C4
			if ( C4.Value > GreatestCardValue )
				{
					GreatestCard = 3;
					GreatestCardValue = C4.Value;
				}

		
			int [] Arr = {GreatestCard, (int)GreatestCardValue};

			return Arr;
				
		}//end of Greatest


		public int ChooseHighestMatchingCard( Card[] CardArray, CardSuit Suit)
		{
			/*in the future we can choose either the highest valued matching
			 card or a random matching card. But for now we choose the 
			 highest valued matching card*/


			int Highest = -1; //this will b returned if no matching card is found

			Console.WriteLine ("\n\nSearching for a matching card found..for {0}\n", Suit);

			for (int i = 0; i < 3; i++) //loop through the array of size 3
			{
				if ((CardArray[i].Suit == Suit) && (CardArray[i].Played == false)) 
				{
					Console.WriteLine ("A matching card found at position {0} in the array..", i+1);

					if (Highest == -1) //that is, if this is the first match..
					{
						Highest = i;
						Console.WriteLine ("...and it is the first matching card found..");
					} 
					else if (CardArray [i].Value > CardArray [Highest].Value) 
					{
						Highest = i;
						Console.WriteLine ("...and it is not the first matching card found..");
					}
					else
						Console.WriteLine ("...but this matching card is lower than the one found in an earlier iteration..");; //Highest remains unchanged
				}//if
			}

			if (Highest > -1) 
			{
				CardArray [Highest].Played = true; //set Played to true for this card
			} 
			else 
			{
				Console.WriteLine ("No matching card found for the SUIT played..");
			}

				return Highest; // is either -1 or some higher value
	
		} //ChooseMatchingCard()


	}//end of class CardGame
}//end of namespace



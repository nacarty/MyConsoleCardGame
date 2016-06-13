using System;

namespace MyConsoleCardGame
{

	class ConsolecardGame
	{


		static void Main(string[] args)
		{
			
			Console.WriteLine("... Beginning of Program....");


			CardGame Game = new CardGame (4, 3);

							
			Console.WriteLine("Nigel Carty says ... End of Program....");

			Console.ReadKey();
		}
	}
}


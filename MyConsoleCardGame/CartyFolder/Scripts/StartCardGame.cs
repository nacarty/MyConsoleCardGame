using System;

namespace MyConsoleCardGame
{

	class ConsolecardGame
	{


		static void Main(string[] args)
		{
			
			Console.WriteLine("... Beginning of Program....");


			PlayTheGame Game = new PlayTheGame (4, 3);

							
			Console.WriteLine("Nigel Carty says ... End of Program....");

			Console.ReadKey();
		}
	}
}


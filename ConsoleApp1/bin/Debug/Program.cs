using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	class Executor
	{
		static String input;

		public static void Main(String[] args)
		{
			if (args.Length >= 1)
			{
				if (File.Exists(args[0]))
				{
					input = File.ReadAllText(args[0]);

					string[] splitbycommands = input.Split(';');

					string[][] splitbywordsIGuess = new string[splitbycommands.Length][];
					
					for (int i = 0; i < splitbywordsIGuess.Length; i++)
					{
						splitbywordsIGuess[i] = splitbycommands[i].Split(null);
					}

					GetDeeperMeaning(splitbywordsIGuess);

					Console.ReadLine();
				}
				else
				{
					Console.WriteLine("You did not launch this program with a valid file. (tip: you can Drag & drop files onto the executable)");
					Console.ReadLine();
				}
			}
			else
			{
				Console.WriteLine("You did not launch this program with a valid file. (tip: you can Drag & drop files onto the executable)");
				Console.ReadLine();
			}
		}

		public static void GetDeeperMeaning	(String[][] words)
		{
			//return 42;
		}

		public static void printarrays(object[] array)
		{
			foreach(object o in array)
			{
				Console.WriteLine(o);
				Console.WriteLine();
				Console.WriteLine();
				Console.WriteLine();

			}
		}
	}
}

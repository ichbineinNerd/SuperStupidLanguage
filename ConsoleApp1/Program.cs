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
		static string[] reservedwords =
		{
			"set", "do", "goto", "to", "be", "now"
		};

		static string[] splitbycommands;

		static String input;

		public static void Main(String[] args)
		{
			if (args.Length >= 1)
			{
				if (File.Exists(args[0]))
				{
					input = File.ReadAllText(args[0]);

					splitbycommands = input.Split(';');	

					GetDeeperMeaning();

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

		public static void GetDeeperMeaning	()
		{
			//return 42;

			Dictionary<string, int> Variables = new Dictionary<string, int>();//maybe at some point there'll be support for something else than ints.

			foreach (string command in splitbycommands)
			{
				string[] words = command.Split(null);

				if (words[0].ToLower().Equals("set"))
				{
					foreach (string word in reservedwords)
					{
						if (words[1].ToLower().Equals(word))
						{
							throw new ReservedException("The variable you're trying to assign a value to is a reserved word.");
						}
					}	
				}
			}	
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

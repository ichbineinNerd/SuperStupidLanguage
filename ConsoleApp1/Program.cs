using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
	class Executor
	{
		static string[] reservedwords =
		{
			"set", "do", "goto", "to", "be", "now"
		};

		static string[] splitbycommands;

		static Dictionary<string, int> Variables = new Dictionary<string, int>();//maybe at some point there'll be support for something else than ints.

		static bool isDone = false;

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

		public static void GetDeeperMeaning()
		{
			//return 42;

			foreach (string command in splitbycommands)
			{
				executecmd(command);
			}

			isDone = true;
		}

		public static void scheduletask(string cmd) {
			if (isDone) {
				executecmd(cmd);
			} else {
				Thread.Sleep(100);
				scheduletask(cmd);
			}
		}

		public static void executecmd(string command)
		{
			string[] words = command.Split(null);

			if (words[words.Length - 1].ToLower() != "now")
			{
				Thread t = new Thread(() => scheduletask(command + " now"));
				return;
			}

			if (words[0].ToLower().Equals("set"))
			{
				foreach (string word in reservedwords)
				{

					if (words[1].ToLower().Equals(word))
						throw new ReservedException("The variable you're trying to assign a value to is a reserved word. (" + word + ")");

				}
					 
				if (!int.TryParse(words[3].ToLower(), out int val))
				{
					throw new NaNException("\"" + words[3].ToLower() + "\" is not a number.");
				}

				if (!words[2].ToLower().Equals("to") && !words[2].ToLower().Equals("="))
				{
					throw new Exception("The third word when setting a variable should be \"=\" or \"to\"");
				}

				if (int.TryParse(words[1], out int stuff))
				{
					throw new Exception("Your Variable Name can't be numeric");
				}

				if (Variables.ContainsKey(words[1]))
				{
					Variables[words[1]] = val;
				}
				else
				{
					Variables.Add(words[1], val);
				}
			}
			else if (words[0].ToLower().Equals("print"))
			{	
				Console.Write(words[1]);
				if (!words[2].ToLower().Equals("and"))
				{
					if (!words[3].ToLower().Equals("nothing"))
					{
						if (!words[4].ToLower().Equals("else"))
						{
							string gibberish = "";

							for (int i = 0; i < words[1].Length; i++)
							{
								gibberish += (char)new Random().Next(128);
							}

							Console.Write(gibberish);
						}
					}
				}
			}
		}

		public static void Printarrays(object[] array)
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

﻿using TouhouFantasiaCheat.Cheats;
using TouhouFantasiaCheat.Commands;

class Program
{
    static void Main(string[] args)
    {
        PrintBanner();

        while (true)
        {
            var command = Console.ReadLine();
            var arguments = command?.Split(' ');

            Setup(command);
            RunCommands(arguments);
            CleanUp();
        }
    }

    private static void RunCommands(string[] arguments)
    {

        for (int i = 0; i < arguments?.Length; i++)
        {
            try
            {
                switch (arguments[i])
                {
                    case "-h":
                    case "--help":
                        HelpCommand.Execute();
                        break;
                    case "-e":
                    case "enable":
                        EnableCommand.Execute(arguments[i + 1]);
                        i++;
                        break;
                    case "-d":
                    case "disable":
                        DisableCommand.Execute(arguments[i + 1]);
                        i++;
                        break;
                    case "-v":
                    case "--verbose":
                        break;
                    case "exit":
                        System.Environment.Exit(0);
                        return;
                    default:
                        if (!string.IsNullOrEmpty(arguments[i]))
                        {
                            Console.WriteLine("This spell is unknow in gensoukyo lands!");
                            Console.WriteLine("Unknown command: " + arguments[i]);
                        }
                        break;
                }
            }
            catch (System.ArgumentException e)
            {
                Console.WriteLine("It wasn't possible execute thet unkonwn command: " + arguments[i]);
                if (VerboseCommand.VerboseEnabled)
                    Console.WriteLine("Unhandled error: " + e.Message);
            }
        }
    }

    private static void Setup(string command)
    {
        if (CheatManager.IsCommandRunning(command))
            return;

        if ((command.Contains("-v") || command.Contains("--verbose")) &&
            !command.Contains("-d") && !command.Contains("disable"))
            VerboseCommand.Execute();
    }

    private static void CleanUp()
    {
        Task.Delay(500);
        VerboseCommand.Disable();
    }

    /// <summary>
    /// Print main console banner.
    /// </summary>
    private static void PrintBanner()
    {
        Console.WriteLine("It's been hard to get through all the bullets, isn't mate!?");
        Console.WriteLine("No problem...");

        Console.WriteLine(@"                                                                                               
 _____         _              _____         _           _        _____ _           _   
|_   _|___ _ _| |_ ___ _ _   |   __|___ ___| |_ ___ ___|_|___   |     | |_ ___ ___| |_ 
  | | | . | | |   | . | | |  |   __| .'|   |  _| .'|_ -| | .'|  |   --|   | -_| .'|  _|
  |_| |___|___|_|_|___|___|  |__|  |__,|_|_|_| |__,|___|_|__,|  |_____|_|_|___|__,|_|                                                                                         

        ");
        Console.WriteLine("TOUHOU FANTASIA - CHEATS");
        Console.WriteLine("Time to kick some youkai asses!");
    }
}

using TouhouFantasiaCheat.Commands;

class Program
{
    static void Main(string[] args)
    {
        PrintBanner();

        while (true)
        {
            var command = Console.ReadLine();
            var argument = command?.Split(' ');

            for (int i = 0; i < argument?.Length; i++)
            {
                try
                {
                    switch (argument[i])
                    {
                        case "-h":
                        case "--help":
                            HelpCommand.Execute();
                            break;
                        case "-e":
                        case "enable":
                            EnableCommand.Execute(argument[i + 1]);
                            i++;
                            break;
                        case "-d":
                        case "disable":
                            DisableCommand.Execute(argument[i + 1]);
                            i++;
                            break;
                        case "-v":
                        case "--verbose":
                            VerboseCommand.Execute();
                            break;
                        case "exit":
                            return;
                        default:
                            Console.WriteLine("This spell is unknow in gensoukyo lands!");
                            Console.WriteLine("Unknown command: " + command);
                            break;
                    }
                }
                catch (System.ArgumentException e)
                {
                    Console.WriteLine("It wasn't possible execute thet unkonwn command: " + command);
                    if (VerboseCommand.VerboseEnabled)
                        Console.WriteLine("Unhandled error: " + e.Message);
                }
            }
        }
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

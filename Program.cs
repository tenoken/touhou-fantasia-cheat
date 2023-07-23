using TouhouFantasiaCheat.Cheats;
using TouhouFantasiaCheat.Commands;
using System.ComponentModel;
using TouhouFantasiaCheat.Cheats.Enums;
using System.Text;
using TouhouFantasiaCheat.Helpers;

class Program
{
    static void Main(string[] args)
    {
        PrintBanner();

        while (true)
        {
            var command = Console.ReadLine();

            try
            {
                switch (command)
                {
                    case "-h":
                    case "--help":
                        new HelpCommand().PrintUsage();
                        break;
                    case "-e":
                    case "enable":
                        new EnableCommand().PrintUsage();
                        break;
                    case "-d":
                    case "disable":
                        new DisableCommand().PrintUsage();
                        break;
                    case "-v":
                    case "--verbose":
                        new VerboseCommand().PrintUsage();
                        break;
                    case "exit":
                        return;
                    default:
                        if (IsEnableArgs(command))
                        {
                            var cmd = command.Split(' ')[1];//the command to be executed
                            var cheat = EnumHelper.GetValueFromDescription<CheatEnum>(cmd);
                            CheatManager.Execute(cheat);
                            break;
                        }

                        if (IsDisableArgs(command))
                        {
                            var cmd = command.Split(' ')[1];//the command to be executed
                            var cheat = EnumHelper.GetValueFromDescription<CheatEnum>(cmd);
                            CheatManager.Stop(cheat);
                            break;
                        }

                        Console.WriteLine("This spell is unknow in gensoukyo lands!");
                        Console.WriteLine("Unknown command: " + command);
                        break;
                }
            }
            catch (System.ArgumentException e)
            {
                Console.WriteLine("It wasn't possible execute thet unkonwn command: " + command);
            }
        }
    }

    /// <summary>
    /// Verify whether argument is a valid one.
    /// </summary>
    /// <param name="argument">Argument to be validated</param>
    /// <returns>True if it is a valid argument or false if it is not</returns>
    public static bool IsEnableArgs(string argument)
    {
        var args = argument.Split(' ');
        if (args is not null && args.FirstOrDefault() == "enable")
            return true;

        return false;
    }

    /// <summary>
    /// Verify whether argument is a valid one.
    /// </summary>
    /// <param name="argument">Argument to be validated</param>
    /// <returns>True if it is a valid argument or false if it is not</returns>
    public static bool IsDisableArgs(string argument)
    {
        var args = argument.Split(' ');
        if (args is not null && args.FirstOrDefault() == "disable")
            return true;

        return false;
    }

    /// <summary>
    /// Print main console banner.
    /// </summary>
    public static void PrintBanner()
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

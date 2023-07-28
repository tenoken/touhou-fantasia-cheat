using TouhouFantasiaCheat.Cheats.Enums;
using TouhouFantasiaCheat.Cheats.Workers;

namespace TouhouFantasiaCheat.Cheats
{
    /// <summary>
    /// Manager of all cheats.
    /// </summary>
    public static class CheatManager
    {
        /// <summary>
        /// Execute a cheat.
        /// </summary>
        /// <param name="cheat">Cheat to be executed</param>
        internal static void Execute(CheatEnum cheat)
        {
            CheatBase.Load();

            try
            {
                switch (cheat)
                {
                    case CheatEnum.FullPower:
                        FullPowerCheatWorker.Run();
                        break;
                    case CheatEnum.FullLife:
                        FullLifeCheatWorker.Run();
                        break;
                    case CheatEnum.FullSpell:
                        FullSpellCheatWorker.Run();
                        break;
                    case CheatEnum.Immortal:
                        ImmortalCheatWorker.Run();
                        break;
                    default:
                        Console.WriteLine("Something went wrong!");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An unexpected error has occurred: {e.Message}");
            }
        }

        /// <summary>
        /// Stop a running cheat.
        /// </summary>
        /// <param name="cheat">Cheat to be stopped</param>
        internal static void Stop(CheatEnum cheat)
        {
            try
            {
                switch (cheat)
                {
                    case CheatEnum.FullPower:
                        FullPowerCheatWorker.Stop();
                        break;
                    case CheatEnum.FullLife:
                        FullLifeCheatWorker.Stop();
                        break;
                    case CheatEnum.FullSpell:
                        FullSpellCheatWorker.Stop();
                        break;
                    case CheatEnum.Immortal:
                        ImmortalCheatWorker.Stop();
                        break;
                    default:
                        Console.WriteLine("Something went wrong!");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An unexpected error has occurred: {e.Message}");
            }
        }
    }
}
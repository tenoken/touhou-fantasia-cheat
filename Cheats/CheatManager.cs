using TouhouFantasiaCheat.Cheats.Enums;
using TouhouFantasiaCheat.Cheats.Workers;
using TouhouFantasiaCheat.Helpers;

namespace TouhouFantasiaCheat.Cheats
{
    /// <summary>
    /// Manager of all cheats.
    /// </summary>
    public static class CheatManager
    {
        private static List<CheatEnum> _runningCheats = new List<CheatEnum>();
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
                if (!_runningCheats.Contains(cheat))
                    _runningCheats.Add(cheat);
            }
            catch (Exception e)
            {
                Console.WriteLine($"An unexpected error has occurred: {e.Message}");
            }
        }

        /// <summary>
        /// Verify whether the command is already running.
        /// </summary>
        /// <param name="command">Command to be searched</param>
        /// <returns>True if command is runing. Otherwise, false</returns>
        internal static bool IsCommandRunning(string command)
        {
            string cheat = "";
            var arguments = command.Split(' ');

            foreach (var item in arguments)
            {
                try
                {
                    cheat = EnumHelper.GetValueFromDescription<CheatEnum>(item).ToString();
                    break;
                }
                catch (System.ArgumentException)
                {
                    continue;
                }
            }

            if (_runningCheats.Count(c => c.ToString() == cheat) > 0)
                return true;


            return false;
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
                _runningCheats.Remove(cheat);
            }
            catch (Exception e)
            {
                Console.WriteLine($"An unexpected error has occurred: {e.Message}");
            }
        }
    }
}
using TouhouFantasiaCheat.Cheats.Enums;

namespace TouhouFantasiaCheat.Cheats
{
    /// <summary>
    /// Manager of all cheats.
    /// </summary>
    public static class CheatManager
    {
        public static bool IsFullLifeCheatEnabled { get; private set; }
        public static bool IsFullSpellCheatEnabled { get; private set; }
        public static bool IsFullPoweCheatEnabled { get; private set; }
        public static bool IsImmortalCheatEnabled { get; private set; }

        /// <summary>
        /// Execute a cheat.
        /// </summary>
        /// <param name="cheat">Cheat to be executed</param>
        internal static void Execute(CheatEnum cheat)
        {
            //Load all addresses
            CheatBase.Load();

            try
            {
                switch (cheat)
                {
                    case CheatEnum.FullPower:
                        if (!IsFullPoweCheatEnabled)
                        {
                            IsFullPoweCheatEnabled = true;
                            Task.Run(() => FullPowerTask());
                        }
                        else
                        {
                            Console.WriteLine($"The command {CheatEnum.FullPower.ToString().ToLower()} is already enabled.");
                            return;
                        }
                        break;
                    case CheatEnum.FullLife:
                        if (!IsFullLifeCheatEnabled)
                        {
                            IsFullLifeCheatEnabled = true;
                            Task.Run(() => FullLifeTask());
                        }
                        else
                        {
                            Console.WriteLine($"The command {CheatEnum.FullLife.ToString().ToLower()} is already enabled.");
                            return;
                        }
                        break;
                    case CheatEnum.FullSpell:
                        if (!IsFullSpellCheatEnabled)
                        {
                            IsFullSpellCheatEnabled = true;
                            Task.Run(() => FullSpellTask());
                        }
                        else
                        {
                            Console.WriteLine($"The command {CheatEnum.FullSpell.ToString().ToLower()} is already enabled.");
                            return;
                        }
                        break;
                    case CheatEnum.Immortal:
                        if (!IsImmortalCheatEnabled)
                        {
                            IsImmortalCheatEnabled = true;
                            Task.Run(() => ImmortalTask());
                        }
                        else
                        {
                            Console.WriteLine($"The command {CheatEnum.Immortal.ToString().ToLower()} is already enabled.");
                            return;
                        }
                        break;
                    default:
                        Console.WriteLine("Something gone wrong!");
                        break;
                }

                Console.WriteLine($"Command {cheat.ToString().ToLower()} is enabled!");
            }
            catch (System.Exception e)
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
            switch (cheat)
            {
                case CheatEnum.FullPower:
                    if (IsFullPoweCheatEnabled)
                        IsFullPoweCheatEnabled = false;
                    else
                    {
                        Console.WriteLine($"The command {cheat.ToString().ToLower()} is already enabled.");
                        return;
                    }
                    break;
                case CheatEnum.FullLife:
                    if (IsFullLifeCheatEnabled)
                        IsFullLifeCheatEnabled = false;
                    else
                    {
                        Console.WriteLine($"The command {cheat.ToString().ToLower()} is already enabled.");
                        return;
                    }
                    break;
                case CheatEnum.FullSpell:
                    if (IsFullSpellCheatEnabled)
                        IsFullSpellCheatEnabled = false;
                    else
                    {
                        Console.WriteLine($"The command {cheat.ToString().ToLower()} is already enabled.");
                        return;
                    }
                    break;
                case CheatEnum.Immortal:
                    if (IsImmortalCheatEnabled)
                        IsImmortalCheatEnabled = false;
                    else
                    {
                        Console.WriteLine($"The command {cheat.ToString().ToLower()} is already enabled.");
                        return;
                    }
                    break;

                default:
                    Console.WriteLine("Something went wrong!");
                    break;
            }

            Console.WriteLine($"Command {cheat.ToString().ToLower()} is disabled!");
        }

        static void FullLifeTask()
        {
            while (IsFullLifeCheatEnabled)
            {
                FullLifeCheat.Execute();
                Task.Delay(100);
            }
        }

        static void FullPowerTask()
        {
            while (IsFullPoweCheatEnabled)
            {
                FullPowerCheat.Execute();
                Task.Delay(100);
            }
        }

        static void FullSpellTask()
        {
            while (IsFullSpellCheatEnabled)
            {
                FullSpellCheat.Execute();
                Task.Delay(100);
            }
        }

        static void ImmortalTask()
        {
            while (IsImmortalCheatEnabled)
            {
                ImmortalCheat.Execute();
                Task.Delay(100);
            }
        }
    }
}
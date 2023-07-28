namespace TouhouFantasiaCheat.Cheats.Workers
{
    /// <summary>
    /// Worker that handles immortal cheat.
    /// </summary>
    public class ImmortalCheatWorker
    {
        /// <summary>
        /// Shows whether there is one running task.
        /// </summary>
        /// <value></value>
        public static bool IsRuning { get; internal set; }
        private static CancellationTokenSource _tokenSource { get; set; }
        private static CancellationToken _token { get; set; }

        /// <summary>
        /// Start a new full spell cheat task.
        /// </summary>
        public static void Run()
        {
            if (!IsRuning)
            {
                _tokenSource = new CancellationTokenSource();
                _token = _tokenSource.Token;
                Task task = Task.Factory.StartNew(() => { ImmortalCheatTask(_token); }, _token);
                IsRuning = true;
                Console.WriteLine($"Command immortal enabled.");
            }
            else
                Console.WriteLine($"The command immortal is already enabled.");
        }

        /// <summary>
        /// Tear down the running task.
        /// </summary>
        public static void Stop()
        {
            if (IsRuning)
            {
                _tokenSource.Cancel();
                IsRuning = false;
                Console.WriteLine($"Command immortal is disabled.");
            }
            else
                Console.WriteLine($"The command immortal is already disabled.");

        }

        static void ImmortalCheatTask(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                ImmortalCheat.Execute();
                Task.Delay(100);
            }
        }
    }
}
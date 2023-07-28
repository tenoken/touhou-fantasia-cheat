namespace TouhouFantasiaCheat.Cheats.Workers
{
    /// <summary>
    /// Worker that handles full power cheat.
    /// </summary>
    public class FullPowerCheatWorker
    {
        /// <summary>
        /// Shows whether there is one running task.
        /// </summary>
        /// <value></value>
        public static bool IsRuning { get; internal set; }
        private static CancellationTokenSource _tokenSource { get; set; }
        private static CancellationToken _token { get; set; }

        /// <summary>
        /// Start a new full power cheat task.
        /// </summary>
        public static void Run()
        {
            if (!IsRuning)
            {
                _tokenSource = new CancellationTokenSource();
                _token = _tokenSource.Token;
                Task task = Task.Factory.StartNew(() => { FullPowerCheatTask(_token); }, _token);
                IsRuning = true;
                Console.WriteLine($"Command fullpower enabled.");
            }
            else
                Console.WriteLine($"The command fullpower is already enabled.");
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
                Console.WriteLine($"Command fullpower is disabled.");
            }
            else
                Console.WriteLine($"The command fullpower is already disabled.");

        }

        static void FullPowerCheatTask(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                FullPowerCheat.Execute();
                Task.Delay(100);
            }
        }
    }
}
namespace TouhouFantasiaCheat.Cheats.Workers
{
    /// <summary>
    /// Worker that handles full life cheat.
    /// </summary>
    public class FullLifeCheatWorker
    {
        /// <summary>
        /// Shows whether there is one running task.
        /// </summary>
        /// <value></value>
        public static bool IsRuning { get; internal set; }
        private static CancellationTokenSource _tokenSource { get; set; }
        private static CancellationToken _token { get; set; }

        /// <summary>
        /// Start a new full life cheat task.
        /// </summary>
        public static void Run()
        {
            if (!IsRuning)
            {
                _tokenSource = new CancellationTokenSource();
                _token = _tokenSource.Token;
                Task task = Task.Factory.StartNew(() => { FullLifeCheatTask(_token); }, _token);
                IsRuning = true;
                Console.WriteLine($"Command fulllife enabled.");
            }
            else
                Console.WriteLine($"The command fulllife is already enabled.");
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
                Console.WriteLine($"Command fulllife is disabled.");
            }
            else
                Console.WriteLine($"The command fulllife is already disabled.");

        }

        static void FullLifeCheatTask(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                FullLifeCheat.Execute();
                Task.Delay(100);
            }
        }
    }
}
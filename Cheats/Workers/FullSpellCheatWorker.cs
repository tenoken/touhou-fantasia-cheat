namespace TouhouFantasiaCheat.Cheats.Workers
{
    /// <summary>
    /// Worker that handles full spell cheat.
    /// </summary>
    public class FullSpellCheatWorker
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
                Task task = Task.Factory.StartNew(() => { FullSpellCheatTask(_token); }, _token);
                IsRuning = true;
                Console.WriteLine($"Command fullspell enabled.");
            }
            else
                Console.WriteLine($"The command fullspell is already enabled.");
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
                Console.WriteLine($"Command fullspell is disabled.");
            }
            else
                Console.WriteLine($"The command fullspell is already disabled.");

        }

        static void FullSpellCheatTask(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                FullSpellCheat.Execute();
                Task.Delay(100);
            }
        }
    }
}
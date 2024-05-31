using KeyboardTrainer;

class Program
{
    private static void Main(string[] args)
    {
        IDict glossary = new GlossaryLoad();
        ConsoleUserInterface cui = new ConsoleUserInterface();
        DifficultySelector difficultySelector = new DifficultySelector(glossary);
        IClickProcessing clickProcessing = new ClickProcessing();
        var statistic = new Statistic();

        var difficulty = cui.GetDifficultyLevel();
        const string filePath = "C:\\Users\\arosl\\RiderProjects\\KeyboardTrainer\\KeyboardTrainer\\glassary.txt";

        Action<string> onTextAvailable = (text) =>
        {
            clickProcessing.LoadText(text);
            var startTime = DateTime.Now;

            while (!clickProcessing.IsCompleted())
            {
                cui.ClearConsole();
                cui.DisplayTextToType(clickProcessing.GetOriginalText());
                cui.DisplayProgress(clickProcessing.GetProgress());

                var key = cui.ReadKey();
                clickProcessing.ProcessKeyPress(key);
            }

            var endTime = DateTime.Now;
            var elapsedTime = (int)(endTime - startTime).TotalMilliseconds;

            statistic.UpdateTime(elapsedTime);
            statistic.UpdateErrorCount(clickProcessing.GetErrorCount());

            cui.ClearConsole();
            cui.DisplayTextToType(clickProcessing.GetOriginalText());
            cui.DisplayProgress(clickProcessing.GetProgress());
            cui.DisplayCompletionMessage();
            cui.DisplayStatistics(statistic.CalculateCharactersPerMinute(clickProcessing.GetOriginalText().Length), statistic.GetErrorCount());
        };

        difficultySelector.SelectDifficulty(filePath, difficulty, onTextAvailable);
    }
}
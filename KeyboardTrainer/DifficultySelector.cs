namespace KeyboardTrainer;

public class DifficultySelector
{
    private readonly IDict _glossary;

    public DifficultySelector(IDict glossary)
    {
        this._glossary = glossary;
    }

    public void SelectDifficulty(string filePath, string difficulty, Action<string> onTextAvailable)
    {
        _glossary.LoadText(filePath);
        string text = _glossary.GetText();

        switch (difficulty.ToLower())
        {
            case "easy":
                onTextAvailable(text);
                break;
            case "normal":
                ProcessTextInChunks(text, 5, onTextAvailable);
                break;
            case "hard":
                ProcessTextInChunks(text, 3, onTextAvailable);
                break;
            default:
                throw new ArgumentException("Invalid difficulty level");
        }
    }

    public void ProcessTextInChunks(string text, int chunkSize, Action<string> onTextAvailable)
    {
        var currentIndex = 0;
        while (currentIndex < text.Length)
        {
            var chunk = text.Substring(currentIndex, Math.Min(chunkSize, text.Length - currentIndex));
            onTextAvailable(chunk);
            currentIndex += chunkSize;
        }
    }
}
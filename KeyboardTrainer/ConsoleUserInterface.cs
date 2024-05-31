namespace KeyboardTrainer;

public class ConsoleUserInterface
{
    public void DisplayTextToType(string text)
    {
        Console.WriteLine("Текст для ввода:");
        Console.WriteLine(text);
    }

    public void DisplayProgress(string progress)
    {
        Console.WriteLine("\nВаш прогресс:");
        Console.WriteLine(progress);
    }

    public void DisplayCompletionMessage()
    {
        Console.WriteLine("\nТекст введен успешно!");
    }

    public void DisplayStatistics(double charactersPerMinute, int errorCount)
    {
        Console.WriteLine($"\nСимволов в секунду: {charactersPerMinute}");
        Console.WriteLine($"Количество ошибок: {errorCount}");
    }

    public char ReadKey()
    {
        return Console.ReadKey(true).KeyChar;
    }

    public void ClearConsole()
    {
        Console.Clear();
    }

    public string GetDifficultyLevel()
    {
        Console.WriteLine("Выберите уровень сложности: easy, normal, hard");
        return Console.ReadLine();
    }
}
namespace KeyboardTrainer;

public interface IDict
{
    void LoadText(string filePath);
    string GetText();
}

public class GlossaryLoad : IDict
{
    private string _text;

    public void LoadText(string filePath)
    {
        try
        {
            _text = File.ReadAllText(filePath);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Файл {filePath} не найден.");
            _text = string.Empty;
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            _text = string.Empty;
        }
    }

    public string GetText()
    {
        return _text;
    }
}
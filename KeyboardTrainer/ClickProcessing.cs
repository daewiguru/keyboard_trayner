namespace KeyboardTrainer;

public interface IClickProcessing
{
    void LoadText(string text);
    void ProcessKeyPress(char key);
    bool IsCompleted();
    string GetProgress();
    string GetOriginalText();
    int GetErrorCount(); // Добавляем метод для получения количества ошибок
}

// Класс ClickProcessing, реализующий интерфейс IClickProcessing
public class ClickProcessing : IClickProcessing
{
    private string _text;
    public int _currentIndex;
    private int _errorCount; // Добавляем поле для хранения количества ошибок

    // Метод для загрузки текста
    public void LoadText(string text)
    {
        _text = text;
        _currentIndex = 0;
        _errorCount = 0; // Инициализируем количество ошибок
    }

    // Метод для обработки нажатия клавиши
    public void ProcessKeyPress(char key)
    {
        if (_currentIndex < _text.Length && _text[_currentIndex] == key)
        {
            _currentIndex++;
        }
        else
        {
            _errorCount++; // Увеличиваем количество ошибок при неверном вводе
        }
    }

    // Метод для проверки завершенности ввода
    public bool IsCompleted()
    {
        return _currentIndex >= _text.Length;
    }

    // Метод для получения текущего прогресса
    public string GetProgress()
    {
        return _text.Substring(0, _currentIndex) + new string('_', _text.Length - _currentIndex);
    }

    // Метод для получения исходного текста
    public string GetOriginalText()
    {
        return _text;
    }

    // Метод для получения количества ошибок
    public int GetErrorCount()
    {
        return _errorCount;
    }
}
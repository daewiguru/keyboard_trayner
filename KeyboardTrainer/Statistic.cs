namespace KeyboardTrainer;

public interface IStatistic
{
    void UpdateErrorCount(int errors);
    void UpdateTime(int milliseconds);
    double CalculateCharactersPerMinute(int totalCharacters);
    int GetErrorCount();
}

public class Statistic : IStatistic
{
    private int _errorCount;
    public int TimeElapsed;

    public void UpdateErrorCount(int errors)
    {
        _errorCount += errors;
    }

    public void UpdateTime(int milliseconds)
    {
        TimeElapsed += milliseconds;
    }

    public double CalculateCharactersPerMinute(int totalCharacters)
    {
        if (TimeElapsed == 0)
            return 0;

        var minutes = TimeElapsed / 60000.0;
        return totalCharacters / minutes;
    }

    public int GetErrorCount()
    {
        return _errorCount;
    }
}
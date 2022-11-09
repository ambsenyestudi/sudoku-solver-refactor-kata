using SudokuSolver.Domain;

namespace SudokuSolver.Infrastructure;
public class OutputService : IOutputService
{
    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }

    public void WriteLine() =>
        Console.WriteLine(string.Empty);

    public void WriteLine(string template, params object[] values) =>
        Console.WriteLine(template, values);
}

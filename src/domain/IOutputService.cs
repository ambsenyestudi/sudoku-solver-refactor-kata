namespace SudokuSolver.Domain;
public interface IOutputService
{
    void WriteLine();
    void WriteLine(string message);
    void WriteLine(string template, params object[] values);
}

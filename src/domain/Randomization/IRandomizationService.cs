namespace SudokuSolver.Domain.Randomization
{
    public interface IRandomizationService
    {
        int Next();
        int Next(int curRemainingDigits);
    }
}

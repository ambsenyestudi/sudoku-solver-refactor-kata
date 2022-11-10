namespace SudokuSolver.Domain.Randomization
{
    public class RandomizationService : IRandomizationService
    {
        private readonly Random rng;

        public RandomizationService()
        {
            rng = new Random();
        }
        public int Next() =>
            rng.Next();
    }
}

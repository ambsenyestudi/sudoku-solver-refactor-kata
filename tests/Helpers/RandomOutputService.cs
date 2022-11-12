using SudokuSolver.Domain.Randomization;

namespace SudokuSolver.Test.Helpers
{
    public class RandomOutputService : IRandomizationService
    {
        private const string FILE_NAME = "Random.txt";
        private readonly Random random = new Random();

        public RandomOutputService()
        {
            if (File.Exists(FILE_NAME))
            {
                File.WriteAllText(FILE_NAME, string.Empty);
            }
        }
        public int Next() =>
            SaveToFile(random.Next());
        public int Next(int maxValue) =>
            SaveToFile(random.Next(maxValue));

        private int SaveToFile(int input)
        {

            using (StreamWriter sw = File.Exists(FILE_NAME) ? File.AppendText(FILE_NAME) : File.CreateText(FILE_NAME))
            {
                sw.WriteLine(input);
            }
            return input;
        }

    }
}

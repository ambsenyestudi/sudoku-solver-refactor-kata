using ApprovalTests;
using ApprovalTests.Reporters;
using Moq;
using SudokuSolver.Domain;
using SudokuSolver.Domain.Randomization;
using SudokuSolver.Infrastructure;

namespace SudokuSolver.Test;

[UseReporter(typeof(DiffReporter))]
public class GoldenMasterTest
{
    private readonly Queue<int> randomQueue;
    private StringWriter consoleOutput = new StringWriter();
    private Mock<IRandomizationService> random = new Mock<IRandomizationService>();
    public GoldenMasterTest()
    {
        var file = File.ReadAllText("Random.txt");
        var listRandom = new List<int>();
        foreach (var rawNumber in file.Split("\r\n", StringSplitOptions.RemoveEmptyEntries))
        {
            if(!int.TryParse(rawNumber, out int parsed))
            {
                throw new ArgumentException("Impossible to parse number " + rawNumber);
            }
            listRandom.Add(parsed);
        }
        randomQueue = new Queue<int>(listRandom);
    }
    
    [Fact]
    public void TestReproductibility()
    {
        Console.SetOut(consoleOutput);
        var sudokuSolver = new SudoSolvingService(new OutputService(), random.Object);
        random.Setup(x => x.Next()).Returns(randomQueue.Dequeue);
        random.Setup(x => x.Next(It.IsAny<int>())).Returns(randomQueue.Dequeue);
        sudokuSolver.Play();
        var output = consoleOutput.ToString();
        Approvals.Verify(output);
    }
    

}
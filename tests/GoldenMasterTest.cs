using ApprovalTests;
using ApprovalTests.Reporters;
using SudokuSolver.Domain;
using SudokuSolver.Infrastructure;

namespace SudokuSolver.Test;

[UseReporter(typeof(DiffReporter))]
public class GoldenMasterTest
{
    
    private StringWriter consoleOutput = new StringWriter();
    
    [Fact]
    public void TestReproductibility()
    {
        Console.SetOut(consoleOutput);
        var sudokuSolver = new SudoSolvingService(new OutputService());
        sudokuSolver.Play();
        var output = consoleOutput.ToString();
        Approvals.Verify(output);
    }
    
}
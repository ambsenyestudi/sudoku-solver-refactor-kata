// See https://aka.ms/new-console-template for more information
using SudokuSolver.Domain;
using SudokuSolver.Domain.Randomization;
using SudokuSolver.Infrastructure;

var sudokuSolving = new SudoSolvingService(new OutputService(), new RandomizationService());

sudokuSolving.Play();

Console.WriteLine();
Console.Write("Press ENTER to exit... ");
Console.ReadLine();

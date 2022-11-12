# sudoku-solver-refactor-kata
this is an attempt to refactor https://github.com/zoran-horvat/sudoku-kata

## Setting up a golden master

Since it is impossible to test anything that is on main (unless you do an overcomplicated setup), we decided to go with [Approval testing](https://approvaltests.com/).<br/>
There is a seccond hidden gem here, this is that there is an extensive use of random all over the Play method that makes it impossible to make your Golden master work. 

## First refactor extract randomness

We need to capture every result genereated by our Random instance. Therefore, we need to extract an interfaces so our random lives outside the play function. Once we extract this dependency, we can now implement a helper service at test project level that can record everything we need.

I called it **RandomOutputService**.

Therefore now if we run the tests passing RandomService as a dependency, copy everything from the [your-test-name].recieved.txt file into [your-test-name].approved.txt and user the created file as a source for our mocks, we have solved our problem.


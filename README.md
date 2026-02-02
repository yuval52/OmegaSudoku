# Omega Sudoku Solver

This is a C# application designed to solve Sudoku puzzles quickly. The application can receive Sudoku boards from the user and solve them, as well as run a speed test including many Sudoku boards taken from a built in dataset.

## How To Use The Application

When opening the program, you will be presented a console screen with instructions, asking you to enter a Sudoku board.

### Solving a single board
---

To solve a single Sudoku board, simply enter the Sudoku board in the correct format. The correct format for a Sudoku board is a sequence of 81 digits, each digit representing a cell on the 9x9 board, row by row from left to right and from top to bottom. Cells with numbers are represented by their corresponding digit from 1 to 9, whille empty cells are represented by zeros.

The main interface of the application:

![The main interface of the application](Images/Main%20interface.png)

Once you enter a board, the application will display that board in a human readable format, and start solving it. When the application solves the board it will display the solved state of the board, as well as the time it took to solve the board.

![The initial and solved board displayed](Images/Solved%20sudoku.png)

After finishing the solving process, the application will ask you to press enter to return to the main menu.

### Running a speed test with many Sudoku boards
---

This application has the ablity to run a speed test, loading a large amount of Sudoku boards from a built in dataset, solving them and messuring the total solving time.

To enter test mode, simply type "test" into the console instead of a Sudoku board. Doing so will present you an interface asking you to choose a test. The application has 2 different modes of tests, "easy" and "difficult". To choose a test type its name into the console.

![The test selection interface](Images/Test%20interface.png)

#### The easy test:
---

The easy speed test allows you to input a number of Sudokus to solve from the dataset. The easy Sudoku dataset contains 100,000 Sudoku boards as well as their solutions.

When you choose the easy speed test you are asked to select an amount of Sudokus to solve. When you input a number, the application loads that number of Sudoku boards from the start of the file and starts solving them while displaying a progress bar. When the test is over the application displays whether the boards were solved correctly, as well as the total solve time for all the boards.

![The easy test interface](Images/Easy%20test.png)

#### The difficult test:
---

The difficult speed test allows you to input a number of Sudokus to solve from the dataset. The difficult Sudoku dataset contains 49,151 Sudoku boards with only 17 cells filled in, the minimum amount for a Sudoku board to be deterministic.

When you choose the difficult you are asked to select an amount of Sudokus to solve. When you input a number, the application loads that number of Sudoku boards from the start of the file and startss solving them while displaying a progress bar. When the test is over the application displays the total solve time forr all the boards.

![The difficult test interface](Images/Difficult%20test.png)

## How The Solver Works

The solver uses a combination of differnt techniques that together can solve Sudokus quickly.

The core of the solver is a simple backtracking algorithm, recursively looking for a possible solution to the board. However backtracking alone is not efficient enough to solve the Sudoku boards fast enough, so in this application I combined the backtracking algorithm with certain human solving techniques, making board solving significantly faster.

### Backtracing
---

The core backtracking algorithm works by choosing an empty cell, placing one of the possible values for it, then moving on recursively to the next cell.

Whenever the algorithm runs into a cell where no option works, it goes back to the previous cell, undoes the latest move, and tries the next option. When the algorithm eventually reaches a solved board, it goes back up the recursion line to the top, keeping all of the changes done to the board.

In order to make the backtracking more efficient, instead of always choosing the next empty cell, it chooses the cell with the least value options on the board. That way the recursion tree is shrunk at the top, leading to less deep branches from the start.

### Strategies
---

The main optimization to the simple backtracking is the addition of solving strategies. These are solving techniques that fill in cells based on deduction from the rest of the board using specific patterns, and are not based on any guessing unlike backtracking, similar to how humans would approach solving Sudokus. These strategies can fill up cells without having to recursively backtrack through them, as well as reduce the options for other empty cells, cutting down a significant amount of branches from the recursion tree.

This application uses 2 solving strategies, both trying to find "singles", cells in the board that have to be a specific value. The 2 strategies used in the application are:

- Naked singles: Naked singles are cells where every single option except for one is not possible (meaning already present in the same row, column or square). In these situations the program will fill in that one value for the cell.

- Hidden singles: Hidden singles are cases where within a certain unit of the board (row, column or square), only one cell has a certain number as a possibility. In these situations the program will fill in the number for the one cell that can have it.

These strategies are applied to the board every time the backtracking function is called, since the cells filled in by the backtracking can crete more singles to be detected. These strategies can also create more instances of these patterns, so the strategies are applied repeatedly to the board until they no longer find cells to fill.

Since the cells filled by backtracking affect these strategies, when a backtracking decision is determined to be wrong and is undone, the decisions following it made by the strategies have to be undone as well. For that reason every cell filled in by the solving strategies is pushed into a stack, and increases a counter of the changes done this iteration of backtracking.

Before undoing a backtracking move, all the changes made to the board by the solving strategies following that move are popped from the stack and undone.
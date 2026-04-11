# TicTacToeNUnit + (Docker + GitHub Actions): Scopecreep Edition

A very simple C# CLI built to demonstrate complete unit test coverage.

## Why TicTacToe?
TicTacToe is a solved game. It's possible to come up with all the possible test cases quickly.
This makes it very well suited to focus on just the unit testing instead of the game or app.
Since the initial scope of this project was so simple. It made it very easy to also demonstrate docker and GitHub actions.

## Projects
- TicTacToeLogic: Just the game logic, fully unit tested.
- TicTacConsole: CLI TicTacToe Game
- TicTacUnitTest: NUnit tests for game logic. Win/draw detection, input validation, turn management. 

## Running The Program
``
git clone https://github.com/PeterSzadurski/TicTacToeNUnit
cd TicTacToeNUnit
docker build -t tictactoe .
docker run -it tictactoe
``

## License
[GNU GPLv3](https://choosealicense.com/licenses/gpl-3.0/)

## CI (GitHub Actions)
Every push automatically runs the 11 NUnit tests, to make sure the rules of tictactoe stay consistent.
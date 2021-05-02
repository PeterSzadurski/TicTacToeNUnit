using System;
using TicTacToeLogic.Classes;

namespace TicTacConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gameWon = false;
            int pos1 = 0;
            int pos2 = 0;
            bool parseResult1 = false;
            bool parseResult2 = false;
            bool validInput = false;
            bool restartGame = false;
            Game game = new Game();
            bool onGoingGame = true;
            while (onGoingGame)
            {

                DrawBoard(game.GetBoard());
                if (gameWon)
                {
                    if (game.GetCurrentPlayer() == 1)
                    {
                        Console.WriteLine("X wins!");
                    }
                    else
                    {
                        Console.WriteLine("O wins!");
                    }
                    Console.WriteLine("Would you like to play another round? y/n");
                    while (!restartGame)
                    {
                        string input = Console.ReadLine();
                        if (input.ToLower() == "y")
                        {
                            pos1 = 0;
                            pos2 = 0;
                            gameWon = false;
                            validInput = false;
                            game = new Game();
                            Console.Clear();
                            break;
                        }
                        else if (input.ToLower() == "n")
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input");
                        }
                    }

                }
                else
                {
                    TurnMessage(game.GetCurrentPlayer());

                    while (!validInput)
                    {
                        string[] input = Console.ReadLine().Split(" ");
                        try {
                            parseResult1 = int.TryParse(input[0], out pos1);
                            parseResult2 = int.TryParse(input[1], out pos2);
                        }
                        catch
                        {

                        }

                        if (!parseResult1 || !parseResult2)
                        {
                            Console.WriteLine("Invalid Input");
                            TutorialMesege();
                        }
                        else if (pos1 > 2 || pos1 < 0 || pos2 > 2 || pos2 < 0)
                        {
                            Console.WriteLine("Requested position out of range, please try again.");
                        }
                        else if (game.GetBoard()[pos1, pos2] != 0)
                        {
                            Console.WriteLine("Requested position has already been taken, please try again.");
                        }
                        else
                        {
                            game.UpdateSquare(pos1, pos2);
                            gameWon = game.DidLastMoveWin();
                            if (!gameWon)
                            {
                                game.SetNextTurn();
                            }
                            validInput = true;
                        }
                    }
                    validInput = false;
                    Console.Clear();
                }

            }
        }

        private static void DrawBoard(int[,] arr)
        {
            Console.WriteLine("   0  1  2");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("{0}  {1}  {2}  {3}",
                    i,
                    CharAssigner(arr[0, i]),
                    CharAssigner(arr[1, i]),
                    CharAssigner(arr[2, i]));
            }
        }
        private static char CharAssigner(int n)
        {
            switch (n)
            {
                case 0:
                    return '#';
                case 1:
                    return 'X';
                case -1:
                    return 'O';
                default:
                    return '#';
            }
        }
        private static void TurnMessage(int n)
        {
            if (n == 1)
            {
                Console.WriteLine("X's Turn..");
            }
            else if (n == -1)
            {
                Console.WriteLine("O's Turn..");
            }
            TutorialMesege();
        }

        private static void TutorialMesege()
        {
            Console.WriteLine("  To make a move, type your position (space seperated) like this:");
            Console.WriteLine("  1 1");
        }
    }
}

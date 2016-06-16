namespace MineSweeper
{
    using System;

    public class MineSweeperMain
    {
        private static void Main(string[] args)
        {
            string[] commands;
            int row = 0;
            int column = 0;

            MineSweeper newGame = new MineSweeper();
            newGame.InitializeNewGame();
            
            do
            {
                if (newGame.WelcomeMessage()) //function that returns true if it is a new game, and prints welcome message
                { 
                    newGame.PrintBoard(newGame.GameField.PlayerBoard); //print the Player board
                }

                Console.Write("Enter row and column (or type command) : ");
                commands = Console.ReadLine().Split(' ');
                if (commands.Length != 0)
                {
                    if (int.TryParse(commands[0], out row)
                        && int.TryParse(commands[1], out column)
                        && (row < GameField.boardRows && row >= 0)
                        && (column < GameField.boardColumns && column >= 0))
                    {
                        commands[0] = "turn"; //play
                    }
                }

                switch (commands[0])
                {
                    case "top":
                        Score.ShowStandings();
                        break;
                    case "restart":
                        newGame.RestartGame();
                        newGame.PrintBoard(newGame.GameField.PlayerBoard);
                        break;
                    case "exit":
                        Console.WriteLine("Bye, bye, bye!");
                        break;
                    case "turn": //default play command
                        newGame.OpenedMine = newGame.OpenCell(newGame.GameField, row, column);
                        if (MineSweeper.maxPoints == newGame.Points)
                        {
                            newGame.MaxPointsReached = true;
                        }
                        else
                        {
                            newGame.PrintBoard(newGame.GameField.PlayerBoard);
                        }
                        break;
                    default:
                        Console.WriteLine("\nInvalid command\n");
                        break;
                }

                if (newGame.OpenedMine) //if player stepped on a mine and game ends
                {
                    newGame.PrintBoard(newGame.GameField.GameBoard); //show the field and the mines
                    Console.Write($"\nHrrrrrr! You died heroic with {newGame.Points} points.\nProvide nickname: ");
                }
                if (newGame.MaxPointsReached) //if player opened all cells without any mines = auto-win
                {
                    Console.WriteLine("\nGood Job! You opened 35 cells without a drop of blood.");
                    newGame.PrintBoard(newGame.GameField.GameBoard);  //show the field and the mines
                    Console.WriteLine("Provide your nickname, Champion ");
                }
                if (newGame.OpenedMine || newGame.MaxPointsReached) //whichever is true, add the player,output the result and initialize new game
                {
                    string nickname = Console.ReadLine();
                    Score.AddPlayer(new Player(nickname, newGame.Points)); //add the player
                    Score.ShowStandings(); //output the result
                    newGame.InitializeNewGame();
                }
            }

            while (commands[0] != "exit");
            Console.WriteLine("Made in Bulgaria - *evil laughter*!");
            Console.WriteLine("*Loud shouting*.");
        }
    }
}
namespace MineSweeper
{
    using System;
    using System.Text;

    public class MineSweeper
    {
        public const int maxPoints = 35;

        public MineSweeper()
        {
            GameField = new GameField();
            InitializeNewGame();
        }

        public int Points { get; protected set; }

        public GameField GameField { get; protected set; }

        public bool NewGameFlag { get; set; } //if it is a new game = then it is true

        public bool OpenedMine { get; set; } //if a mine is opened

        public bool MaxPointsReached { get; set; } //if 35 points are reached

        public static char ShowMinesNearPosition(GameField field, int row, int column) //shows the mines around the opened cell
        {
            int mineCount = 0;

            if (row - 1 >= 0)
            {
                if (field.GameBoard[row - 1, column] == '*')
                {
                    mineCount++;
                }
            }
            if (row + 1 < GameField.boardRows) //check whether you go outside the gameField
            {
                if (field.GameBoard[row + 1, column] == '*')
                {
                    mineCount++;
                }
            }
            if (column - 1 >= 0)
            {
                if (field.GameBoard[row, column - 1] == '*')
                {
                    mineCount++;
                }
            }
            if (column + 1 < GameField.boardColumns) //check whether you go outside the gameField
            {
                if (field.GameBoard[row, column + 1] == '*')
                {
                    mineCount++;
                }
            }
            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (field.GameBoard[row - 1, column - 1] == '*')
                {
                    mineCount++;
                }
            }
            if ((row - 1 >= 0) && (column + 1 < GameField.boardColumns))
            {
                if (field.GameBoard[row - 1, column + 1] == '*')
                {
                    mineCount++;
                }
            }
            if ((row + 1 < GameField.boardRows) && (column - 1 >= 0))
            {
                if (field.GameBoard[row + 1, column - 1] == '*')
                {
                    mineCount++;
                }
            }
            if ((row + 1 < GameField.boardRows) && (column + 1 < GameField.boardColumns))
            {
                if (field.GameBoard[row + 1, column + 1] == '*')
                {
                    mineCount++;
                }
            }

            return char.Parse(mineCount.ToString());
        }

        public bool OpenCell(GameField field, int row, int column) //checking for bombs, assigning points; returns true if you open a bomb
        {
            if (GameField.GameBoard[row, column] != '*')
            {
                if (GameField.GameBoard[row, column] == '-')
                {
                    char mineCount = ShowMinesNearPosition(field, row, column); //get the number of mines around the discovered cell
                    field.GameBoard[row, column] = mineCount; //show the number of mines around the discovered cell
                    field.PlayerBoard[row, column] = mineCount; //show the number of mines around the discovered cell
                    Points++; //player opened a cell without a bomb
                    return false;
                }
            }

            return true; //returns true if the opened cell is a bomb
        }

        public void InitializeNewGame() //initialize a new game
        {
            Points = 0;
            GameField = new GameField();
            NewGameFlag = true;
            OpenedMine = false;
            MaxPointsReached = false;
        }

        public void RestartGame()
        {
            Points = 0;
            GameField = new GameField();
            NewGameFlag = false;
            OpenedMine = false;
            MaxPointsReached = false;
        } //restart the game

        public void PrintBoard(char[,] board) //prints any board (game or player)
        {
            StringBuilder boardState = new StringBuilder();
            boardState.AppendLine("\n    0 1 2 3 4 5 6 7 8 9");
            boardState.AppendLine("   ---------------------");
            for (int i = 0; i < GameField.boardRows; i++)
            {
                boardState.Append(string.Format("{0} | ", i));
                for (int j = 0; j < GameField.boardColumns; j++)
                {
                    boardState.Append(string.Format("{0} ", board[i, j]));
                }
                boardState.Append("|");
                boardState.AppendLine();
            }

            boardState.AppendLine("   ---------------------\n");
            Console.WriteLine(boardState);
        }

        public bool WelcomeMessage()
        {
            if (NewGameFlag)
            {
                Console.WriteLine("Let`s play Mines”. Try your luck to find all fields without mines."
                           + "\n command 'top' shows the standings,"
                           + "\n command 'restart' starts a new game,"
                           + "\n command 'exit' exits the game!");

                NewGameFlag = false;
                return true;
            }

            return false;
        }
    }
}

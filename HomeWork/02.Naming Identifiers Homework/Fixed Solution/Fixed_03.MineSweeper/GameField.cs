namespace MineSweeper
{
    using System;
    using System.Collections.Generic;

    public class GameField
    {
        public const int boardRows = 5;
        public const int boardColumns = 10;
        private const int minesBoard = 15; //can be increased if you want more mines to be added

        public GameField()
        {
            GameBoard = new char[boardRows, boardColumns];
            PlayerBoard = new char[boardRows, boardColumns];
            InitializeGameField();
            InitializeMines();
            InitializePlayerBoard();
        }

        public char[,] GameBoard { get; set; }

        public char[,] PlayerBoard { get; set; }

        public void InitializeGameField()
        {
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    GameBoard[i, j] = '-';
                }
            }
        }

        public void InitializeMines()
        {
            List<int> bombList = new List<int>();
            while (bombList.Count < minesBoard)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);
                if (!bombList.Contains(randomNumber))
                {
                    bombList.Add(randomNumber);
                }
            }

            foreach (int randomNumber in bombList)
            {
                int row = randomNumber / boardColumns; //assign the bomb position row , example : 35/10 = 3
                int col = randomNumber % boardColumns; //asign the bomb position column, example 35%10 = 5
                if (col == 0 && randomNumber != 0)  //cases where you get 0 for the column, example 40%10 = 0
                {
                    col = boardColumns - 1; //assign the maximum column value
                }

                GameBoard[row, col] = '*'; //insert mine
            }
        }

        public void InitializePlayerBoard()
        {

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    PlayerBoard[i, j] = '?';
                }
            }
        }
    }
}

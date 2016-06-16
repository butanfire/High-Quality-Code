namespace MineSweeper
{
    using System;
    using System.Collections.Generic;

    public static class Score
    {
        public const int maxPoints = 35;
        private static List<Player> playerList = new List<Player>();

        public static void ShowStandings()
        {
            playerList.Sort((r1, r2) => r2.Name.CompareTo(r1.Name)); //sort the standing list by Name and Points
            playerList.Sort((r1, r2) => r2.Points.CompareTo(r1.Points));

            Console.WriteLine("\nPoints for the players:");
            if (playerList.Count > 0) //if there are players entered in list
            {
                for (int i = 0; i < playerList.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} cells opened", i + 1, playerList[i].Name, playerList[i].Points);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty standing list!\n");
            }
        }

        public static void AddPlayer(Player one)
        {
            if (playerList.Count < 5)
            {
                playerList.Add(one);
            }
            else
            {
                for (int i = 0; i < playerList.Count; i++)
                {
                    if (playerList[i].Points < one.Points) //if the player has more points than other players
                    {
                        playerList.Insert(i, one); //add the player with the more points
                        playerList.RemoveAt(playerList.Count - 1); //remove the last player
                        break;
                    }
                }
            }
        }
    }
}

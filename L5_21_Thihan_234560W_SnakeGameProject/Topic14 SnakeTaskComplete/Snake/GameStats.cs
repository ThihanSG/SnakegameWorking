using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snake
{
    public class GameStats
    {
        public GameStats() { }
        public GameStats(string playerName, int score, string difficultyLevel)
        {
            PlayerName = playerName;
            Score = score;
            DifficultyLevel = difficultyLevel;
        }
        public static string userName;
        public string PlayerName { get; set; }
        public int Score { get; set; }
        public string DifficultyLevel { get; set; }

        // Rest of the code remains unchanged
    }

    public class GameStatsManager
    {
        public void WriteGameStats(string playerName, int score, string difficultyLevel)
        {
            // Define the file path
            string filePath = Path.Combine(Environment.CurrentDirectory, "debug", "game_stats.txt");

            // Create a new GameStats object
            GameStats gameStats = new GameStats(playerName, score, difficultyLevel);

            // Create a string to store the game statistics
            string gameStatsString = $"{gameStats.PlayerName},{gameStats.Score},{gameStats.DifficultyLevel}";

            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Append the game statistics to the file
                File.AppendAllText(filePath, Environment.NewLine + gameStatsString);
            }
            else
            {
                // Create a new file and write the game statistics to it
                File.WriteAllText(filePath, gameStatsString);
            }
        }

        // Get the top players based on the specified count and difficulty level
        public List<GameStats> GetTopPlayers(int count, string difficultyLevel)
        {
            // Define the file path
            string filePath = Path.Combine(Environment.CurrentDirectory, "debug", "game_stats.txt");

            // Create a list to store the game statistics
            List<GameStats> gameStatsList = new List<GameStats>();

            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Read all lines from the file
                string[] lines = File.ReadAllLines(filePath);

                // Iterate through each line
                foreach (string line in lines)
                {
                    // Split the line by comma
                    string[] data = line.Split(',');

                    // Check if the data has the correct length
                    if (data.Length == 3)
                    {
                        // Extract the player name
                        string playerName = data[0].Trim();

                        // Parse the score
                        int score;
                        if (int.TryParse(data[1].Trim(), out score))
                        {
                            // Extract the difficulty level
                            string level = data[2].Trim();

                            // Check if the difficulty level matches the specified level
                            if (level == difficultyLevel)
                            {
                                // Create a new GameStats object
                                GameStats gameStats = new GameStats
                                {
                                    PlayerName = playerName,
                                    Score = score,
                                    DifficultyLevel = level
                                };

                                // Add the game statistics to the list
                                gameStatsList.Add(gameStats);
                            }
                        }
                    }
                }

                // Sort the game statistics in descending order based on the score
                gameStatsList.Sort((x, y) => y.Score.CompareTo(x.Score));

                // Get the top players based on the specified count
                gameStatsList = gameStatsList.GetRange(0, Math.Min(count, gameStatsList.Count));
            }

            // Return the list of top players
            return gameStatsList;
        }
    }
}

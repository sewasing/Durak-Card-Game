// Group - 4
// Members - Samrat Jayanta Bhurtel, Chirayu Patel, Manansinh Vansia, Kultaran Singh and Niraj Bhandari
// Date - 2025/04/01
// Description - Database class for the Durak card game, handling SQLite database operations for player statistics.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite; // Assuming SQLite is used for the database
using System.IO;
using Dapper;

namespace DurakCardGame
{
    public static class Database
    {
        private static string _dbPath = "Data Source=durak.db";

        public static void Init()
        {
            using var conn = new SQLiteConnection(_dbPath);
            conn.Execute(@"
            CREATE TABLE IF NOT EXISTS stats (
                id INTEGER PRIMARY KEY,
                name TEXT,
                games_played INTEGER,
                games_won INTEGER,
                win_rate REAL
            );
        ");
        }

        public static void SaveResult(string playerName, bool won)
        {
            using var conn = new SQLiteConnection(_dbPath);
            var existing = conn.QueryFirstOrDefault<dynamic>("SELECT * FROM stats WHERE name = @name", new { name = playerName });

            if (existing != null)
            {
                int newGames = existing.games_played + 1;
                int newWins = existing.games_won + (won ? 1 : 0);
                double rate = (double)newWins / newGames;

                conn.Execute("UPDATE stats SET games_played = @newGames, games_won = @newWins, win_rate = @rate WHERE name = @playerName",
                    new { newGames, newWins, rate, playerName });
            }
            else
            {
                conn.Execute("INSERT INTO stats (name, games_played, games_won, win_rate) VALUES (@playerName, 1, @won, @rate)",
                    new { playerName, won = won ? 1 : 0, rate = won ? 1.0 : 0.0 });
            }
        }
    }

}

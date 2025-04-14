// Group - 4
// Members - Samrat Jayanta Bhurtel, Chirayu Patel, Manansinh Vansia, Kultaran Singh and Niraj Bhandari
// Date - 2025/04/01
// Description - Logger class for the Durak card game, responsible for saving game state to JSON format.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Xml;

namespace DurakCardGame
{
    public static class Logger
    {
        public static void SaveGameToJson(Game game, string filePath)
        {
            var json = JsonConvert.SerializeObject(new
            {
                playerHand = game.Human.Hand,
                aiHand = game.AI.Hand,
                trump = game.TrumpCard
            }, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(filePath, json);
        }
    }

}

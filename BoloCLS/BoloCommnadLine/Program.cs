using Bolo.Entities.Models.Players;
using Bolo.Logic.Managers;
using System;
using System.Collections.Generic;

namespace BoloCommnadLine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var gm = GameManager.Instance;
            gm.StartGame(new List<IPlayer> { new Player("Rean"), new Player("Sara") });
            gm.PlayGame();
            Console.WriteLine("");
        }
    }
}

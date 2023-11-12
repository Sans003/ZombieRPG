using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net.Security;
using System.Numerics;
using System.Reflection.Metadata;
using System.Threading;

namespace ZombieRPG
{
    public class Program
    {
        public int posX;
        public int posY;
        public const string symbols = $"O┼^";
        public static void Main(string[] args)
        {
            Entities entities = new Entities();
            Console.CursorVisible = false;
            Player player = new Player();
            Entities spawner = new Entities();
            player.Render();

            var tickSystem = new TickSystem(5000);
            tickSystem.OnTick += () =>
            {
                if (spawner.EnemyList.Count! >= 10)
                {
                    spawner.spawnEntity();
                }
            };
            tickSystem.Start();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    player.Move(player);
                }
                Thread.Sleep(1);
            }
        }
    }

}


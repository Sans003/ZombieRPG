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
                    var command = Console.ReadKey().Key;
                    player.oPos = player.Pos;

                    switch (command)
                    {
                        case ConsoleKey.DownArrow:
                            if (player.Pos[1] < Console.WindowHeight - 1) player.Pos[1]++;
                            break;
                        case ConsoleKey.UpArrow:
                            if (player.Pos[1] > 0) player.Pos[1]--;
                            break;
                        case ConsoleKey.LeftArrow:
                            if (player.Pos[0] > 0) player.Pos[0]--;
                            break;
                        case ConsoleKey.RightArrow:
                            if (player.Pos[0] < Console.WindowWidth - 1) player.Pos[0]++;
                            break;
                    }
                }
                player.DeRender();
                player.Render();
                Thread.Sleep(1);
            }
        }
    }

}


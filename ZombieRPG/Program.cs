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
            Rendering playerchar = new Humanoid();
            Entities spawner = new Entities();
            playerchar.Symbols = symbols;
            playerchar.PosX = Console.WindowWidth / 2;
            playerchar.PosY = Console.WindowHeight / 2;
            entities.spawnEntity("chest");
            entities.spawnEntity("qbitch");
            entities.spawnEntity("giant");
            entities.spawnEntity("spider");
            entities.spawnEntity("athole");

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var command = Console.ReadKey().Key;
                    playerchar.OPosX = playerchar.PosX;
                    playerchar.OPosY = playerchar.PosY;

                    switch (command)
                    {
                        case ConsoleKey.DownArrow:
                            if (playerchar.PosY < Console.WindowHeight - 1) playerchar.PosY++;
                            break;
                        case ConsoleKey.UpArrow:
                            if (playerchar.PosY > 0) playerchar.PosY--;
                            break;
                        case ConsoleKey.LeftArrow:
                            if (playerchar.PosX > 0) playerchar.PosX--;
                            break;
                        case ConsoleKey.RightArrow:
                            if (playerchar.PosX < Console.WindowWidth - 1) playerchar.PosX++;
                            break;
                    }
                }
                playerchar.DeRender();
                playerchar.Render();
                Thread.Sleep(1);
            }
        }
    }


    class Rendering
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int OPosX { get; set; }
        public int OPosY { get; set; }
        public string Symbols { get; set; }
        public virtual void DeRender() { }
        public virtual void Render() { }
    }

    class Humanoid : Rendering
    {

        public override void Render()
        {
            if (PosX >= 0 && PosY >= 0)
            {
                for (int c = 0; c < Symbols.Length; c++)
                {
                    Console.SetCursorPosition(PosX, PosY + c);
                    Console.Write(Symbols[c]);
                }
            }
        }

        public override void DeRender()
        {
            if (PosX >= 0 && PosY >= 0)
            {
                for (int c = 0; c < Symbols.Length; c++)
                {
                    Console.SetCursorPosition(OPosX, OPosY + c);
                    Console.Write(' ');
                }
            }
        }
    }
    class Spider : Rendering
    {
        public override void Render()
        {
            if (PosX >= 0 && PosY >= 0)
            {
                for (int c = 0; c < Symbols.Length; c++)
                {
                    Console.SetCursorPosition(PosX + c, PosY);
                    Console.Write(Symbols[c]);
                }
            }
        }

        public override void DeRender()
        {
            if (PosX >= 0 && PosY >= 0)
            {
                foreach (char c in Symbols.ToCharArray())
                {
                    Console.SetCursorPosition(PosX - c, PosY);
                    Console.Write(' ');
                }
            }
        }
    }
    class Giant : Rendering
    {
        public override void Render()
        {
            if (PosX >= 0 && PosY >= 0)
            {
                for (int c = 0; c < Symbols.Length; c++)
                {
                    Console.SetCursorPosition(PosX, PosY + c);
                    Console.Write(Symbols[c]);
                }
            }
        }

        public override void DeRender()
        {
            if (PosX >= 0 && PosY >= 0)
            {
                for (int c = 0; c < Symbols.Length; c++)
                {
                    Console.SetCursorPosition(OPosX, OPosY + c);
                    Console.Write(' ');
                }
            }
        }
    }
    class Chest : Rendering
    {
        public override void Render()
        {
            if (PosX >= 0 && PosY >= 0)
            {
                int oPosX = PosX;
                for (int c = 0; c < Symbols.Length; c++)
                {
                    if (c >= 3)
                    {
                        Console.SetCursorPosition(oPosX + (c-3), PosY + 1);
                    }
                    else
                    {
                        Console.SetCursorPosition(PosX + c, PosY);
                    }
                    Console.Write(Symbols[c]);
                }
            }
        }

        public override void DeRender()
        {
            if (PosX >= 0 && PosY >= 0)
            {
                for (int c = 0; c < Symbols.Length; c++)
                {
                    int oPosX = PosX;
                    while (c < Symbols.Length - 3)
                    {
                        Console.SetCursorPosition(PosX - c, PosY);
                        Console.Write(' ');
                    }
                    if (c == 2)
                    {
                        Console.SetCursorPosition(oPosX - c, PosY);
                        Console.Write(' ');
                    }
                }
            }
        }
    }
}


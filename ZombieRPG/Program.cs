using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
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
            Console.CursorVisible = false;
            Rendering playerchar = new Humanoid();
            playerchar.symbols = symbols;
            playerchar.posX = Console.WindowWidth / 2;
            playerchar.posY = Console.WindowHeight / 2;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var command = Console.ReadKey().Key;
                    playerchar.oPosX = playerchar.posX;
                    playerchar.oPosY = playerchar.posY;

                    switch (command)
                    {
                        case ConsoleKey.DownArrow:
                            if (playerchar.posY < Console.WindowHeight - 1) playerchar.posY++;
                            break;
                        case ConsoleKey.UpArrow:
                            if (playerchar.posY > 0) playerchar.posY--;
                            break;
                        case ConsoleKey.LeftArrow:
                            if (playerchar.posX > 0) playerchar.posX--;
                            break;
                        case ConsoleKey.RightArrow:
                            if (playerchar.posX < Console.WindowWidth - 1) playerchar.posX++;
                            break;
                    }
                    playerchar.DeRender();
                    playerchar.Render();
                }
                Spawner spawn = new Spawner();
                spawn.spawning();
                playerchar.Render();
                Thread.Sleep(100);
            }
        }
    }
    public class Spawner
    {
        public void spawning()
        {
            Entities giant = new Entities();
            giant.spawnEntity("giant");
            Entities qbitch = new Entities();
            qbitch.spawnEntity("qBitch");
            Entities athole = new Entities();
            athole.spawnEntity("atHole");
            Entities chest = new Entities();
            chest.spawnEntity("chest");
            Entities spider = new Entities();
            spider.spawnEntity("spider");
        }
    }
    public class Entities
    {
        public List<int> bitchId = new List<int>();
        public List<int> holeId = new List<int>();
        public List<int> spiderId = new List<int>();
        public List<int> chestId = new List<int>();
        public List<int> giantId = new List<int>();
        static Random rng = new Random();

        public void spawnEntity(string entity)
        {
            int w = Console.WindowWidth-2;
            int h = Console.WindowHeight-3;
            int x = rng.Next(w);
            int y = rng.Next(h);
            int id = 1;
            if (entity == "giant")
            {
                if (giantId != null)
                {
                    id = giantId.Count() + 1;
                    giantId.Append(id);
                }
                string entitiyName = $"giant{id}";
                Giant entityname = new Giant();
                entityname.posX = x; entityname.posY = y;
                entityname.oPosX = entityname.posX; entityname.oPosY = entityname.posY;
                entityname.symbols = "0││^";
                entityname.Render();
            }
            else if (entity == "spider")
            {
                if (spiderId != null)
                {
                    id = spiderId.Count() + 1;
                    spiderId.Append(id);
                }
                string entitiyName = $"spider{id}";
                Spider entityname = new Spider();
                entityname.posX = x; entityname.posY = y;
                entityname.oPosX = entityname.posX; entityname.oPosY = entityname.posY;
                entityname.symbols = ";m;";
                entityname.Render();

            }
            else if (entity == "qBitch")
            {
                if (bitchId != null)
                {
                    id = bitchId.Count() + 1;
                    bitchId.Append(id);
                }
                string entitiyName = $"bitch{id}";
                Humanoid entityname = new Humanoid();
                entityname.posX = x; entityname.posY = y;
                entityname.oPosX = entityname.posX; entityname.oPosY = entityname.posY;
                entityname.symbols = "Q┼^";
                entityname.Render();

            }
            else if (entity == "atHole")
            {
                if (holeId != null)
                {
                    id = holeId.Count() + 1;
                    holeId.Append(id);
                }
                string entitiyName = $"athole{id}";
                Humanoid entityname = new Humanoid();
                entityname.posX = x; entityname.posY = y;
                entityname.oPosX = entityname.posX; entityname.oPosY = entityname.posY;
                entityname.symbols = "@┼^";
                entityname.Render();

            }
            else if (entity == "chest")
            {
                if (chestId != null)
                {
                    id = chestId.Count() + 1;
                    chestId.Append(id);
                }
                string entitiyName = $"chest{id}";
                Chest entityname = new Chest();
                entityname.posX = x; entityname.posY = y;
                entityname.oPosX = entityname.posX; entityname.oPosY = entityname.posY;
                entityname.symbols = "┌─┐└─┘";
                entityname.Render();

            }


        }

    }
    //public static bool IsDangerSpot(int x, int y)
    //{
    //    foreach (var spot in dangerSpots)
    //    {
    //        if (spot[0] == x && spot[1] == y)
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}


    //public static void saveCoords(int x, int y)
    //{
    //    if (x >= 0 && x < Console.WindowWidth && y >= 0 && y < Console.WindowHeight)
    //    {
    //        List<int> coords = new List<int>
    //        {
    //            x,
    //            y
    //        };
    //        dangerSpots.Add(coords);
    //    }
    //}


    class Rendering
    {
        public int posX { get; set; }
        public int posY { get; set; }
        public int oPosX { get; set; }
        public int oPosY { get; set; }
        public string symbols { get; set; }

        public virtual void DeRender()
        {

        }
        public virtual void Render()
        {

        }
    }

    class Humanoid : Rendering
    {

        public override void Render()
        {
            if (posX >= 0 && posY >= 0)
            {
                for (int c = 0; c < symbols.Length; c++)
                {
                    Console.SetCursorPosition(posX, posY + c);
                    Console.Write(symbols[c]);
                }
            }
        }

        public override void DeRender()
        {
            if (posX >= 0 && posY >= 0)
            {
                for (int c = 0; c < symbols.Length; c++)
                {
                    Console.SetCursorPosition(oPosX, oPosY + c);
                    Console.Write(' ');
                }
            }
        }
    }
    class Spider : Rendering
    {
        public override void Render()
        {
            if (posX >= 0 && posY >= 0)
            {
                for (int c = 0; c < symbols.Length; c++)
                {
                    Console.SetCursorPosition(posX + c, posY);
                    Console.Write(symbols[c]);
                }
            }
        }

        public override void DeRender()
        {
            if (posX >= 0 && posY >= 0)
            {
                foreach (char c in symbols.ToCharArray())
                {
                    Console.SetCursorPosition(posX - c, posY);
                    Console.Write(' ');
                }
            }
        }
    }
    class Giant : Rendering
    {
        public override void Render()
        {
            if (posX >= 0 && posY >= 0)
            {
                for (int c = 0; c < symbols.Length; c++)
                {
                    Console.SetCursorPosition(posX, posY + c);
                    Console.Write(symbols[c]);
                }
            }
        }

        public override void DeRender()
        {
            if (posX >= 0 && posY >= 0)
            {
                for (int c = 0; c < symbols.Length; c++)
                {
                    Console.SetCursorPosition(oPosX, oPosY + c);
                    Console.Write(' ');
                }
            }
        }
    }
    class Chest : Rendering
    {
        public override void Render()
        {
            if (posX >= 0 && posY >= 0)
            {
                for (int c = 0; c < symbols.Length; c++)
                {
                    int oPosX = posX;
                    while (c < symbols.Length - 3)
                    {
                        Console.SetCursorPosition(posX + c, posY);
                        Console.Write(symbols[c]);
                    }
                    if (c == 2)
                    {
                        Console.SetCursorPosition(oPosX + c, posY);
                        Console.Write(symbols[c]);
                    }
                }
            }
        }

        public override void DeRender()
        {
            if (posX >= 0 && posY >= 0)
            {
                for (int c = 0; c < symbols.Length; c++)
                {
                    int oPosX = posX;
                    while (c < symbols.Length - 3)
                    {
                        Console.SetCursorPosition(posX - c, posY);
                        Console.Write(' ');
                    }
                    if (c == 2)
                    {
                        Console.SetCursorPosition(oPosX - c, posY);
                        Console.Write(' ');
                    }
                }
            }
        }
    }
}


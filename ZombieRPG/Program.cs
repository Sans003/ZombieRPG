using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Reflection.Metadata;
using System.Threading;

namespace ZombieRPG
{
    public class Program
    {
        static Random rng = new Random();
        public static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Player.haveExistentialcrisis();
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


    }
    class Rendering
    {
        public int posX { get; set; }
        public int posY { get; set; }
        public string symbols { get; set; }
        public virtual void Render()
        {
        }
        public virtual void DeRender()
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
                    Console.Write(c);
                }
            }
        }

        public override void DeRender()
        {
            if (posX >= 0 && posY >= 0)
            {
                foreach (char c in symbols.ToCharArray())
                {
                    Console.SetCursorPosition(posX, posY + c);
                    Console.Write(c);
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
                    Console.Write(c);
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
                    Console.Write(c);
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
                    Console.Write(c);
                }
            }
        }

        public override void DeRender()
        {
            if (posX >= 0 && posY >= 0)
            {
                foreach (char c in symbols.ToCharArray())
                {
                    Console.SetCursorPosition(posX, posY + c);
                    Console.Write(c);
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
                    Console.SetCursorPosition(posX, posY + c);
                    Console.Write(c);
                }
            }
        }

        public override void DeRender()
        {
            if (posX >= 0 && posY >= 0)
            {
                foreach (char c in symbols.ToCharArray())
                {
                    Console.SetCursorPosition(posX, posY + c);
                    Console.Write(c);
                }
            }
        }
    }
}


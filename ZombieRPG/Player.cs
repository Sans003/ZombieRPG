using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ZombieRPG
{
    public class Player
    {
        public int[] Pos = { Console.WindowWidth / 2, Console.WindowHeight / 2 };
        public int[] oPos = { Console.WindowWidth / 2, Console.WindowHeight / 2 };
        public string chars = "0│^";
        public double health = 50;
        public Inventory Inventory;

        public void Render()
        {
            if (Pos[0] >= 0 && Pos[1] >= 0)
            {
                for (int c = 0; c < chars.Length; c++)
                {
                    Console.SetCursorPosition(Pos[0], Pos[1] + c);
                    Console.Write(chars[c]);
                }
            }
        }

        public void DeRender()
        {
            if (oPos[0] >= 0 && oPos[1] >= 0)
            {
                for (int c = 0; c < chars.Length; c++)
                {
                    Console.SetCursorPosition(oPos[0], oPos[1] + c);
                    Console.Write(' ');
                }
            }
        }
        public void Move(Player player)
        {
            var command = Console.ReadKey(true).Key;
            player.DeRender();
            player.oPos = player.Pos;

            switch (command)
            {
                case ConsoleKey.DownArrow:
                    if (player.Pos[1] < Console.WindowHeight - 10) player.Pos[1]++;
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
            player.Render();
        }

        public void AddHealth(int heal)
        {
            health += heal;
        }
    }
}

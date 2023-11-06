using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ZombieRPG
{
    internal class Player
    {
        public int[] Pos = { Console.WindowWidth / 2, Console.WindowHeight / 2 };
        public int[] oPos = { Console.WindowWidth / 2, Console.WindowHeight / 2 };
        public string chars = "0│^";

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
            if (Pos[0] >= 0 && Pos[1] >= 0)
            {
                for (int c = 0; c < chars.Length; c++)
                {
                    Console.SetCursorPosition(oPos[0], oPos[1] + c);
                    Console.Write(' ');
                }
            }
        }
        public void Move(int posX, int posY)
        {
        }
    }
}

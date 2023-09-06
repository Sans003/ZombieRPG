using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieRPG
{
    internal class Player
    {
        public static void haveExistentialcrisis()
        {
            const string toWrite = $"O┼^";

            int x = Console.WindowWidth / 2, y = Console.WindowHeight / 2;
            int ox = 0, oy = 0;

            Program.Write(toWrite, x, y);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var command = Console.ReadKey().Key;

                    ox = x; // old x
                    oy = y; // old y

                    switch (command)
                    {
                        case ConsoleKey.DownArrow:
                            if (y < Console.WindowHeight - 1) y++;
                            break;
                        case ConsoleKey.UpArrow:
                            if (y > 0) y--;
                            break;
                        case ConsoleKey.LeftArrow:
                            if (x > 0) x--;
                            break;
                        case ConsoleKey.RightArrow:
                            if (x < Console.WindowWidth - 1) x++;
                            break;
                    }

                    Program.Write(toWrite, x, y);
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }
    }
}

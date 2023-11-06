namespace ZombieRPG
{
    public class Entity
    {
        public int[] Pos = { };
        public int[] oPos = { };
        public string chars;
        public virtual void DeRender() { }
        public virtual void Render() { }

        public int[] MoveEntity(int[] pos)
        {
            return pos;
        }
    }
    public class Zombie : Entity
    {
        public Zombie()
        {
            this.oPos = Pos;
            this.Pos = MoveEntity(Pos);
            chars = "0│^";
        }
        public override void Render()
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

        public override void DeRender()
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
    }
    public class Giant : Entity
    {
        public Giant()
        {
            this.oPos = Pos;
            this.Pos = MoveEntity(Pos);
            chars = "0││^";
        }
        public override void Render()
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

        public override void DeRender()
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
    }
    public class Spider : Entity
    {
        public Spider()
        {
            this.oPos = Pos;
            this.Pos = MoveEntity(Pos);
            chars = ";m;";
        }
        public override void Render()
        {
            if (this.Pos[0] >= 0 && this.Pos[1] >= 0)
            {
                for (int c = 0; c < chars.Length; c++)
                {
                    Console.SetCursorPosition(Pos[0] + c, Pos[1]);
                    Console.Write(chars[c]);
                }
            }
        }

        public override void DeRender()
        {
            if (Pos[0] >= 0 && Pos[1] >= 0)
            {
                foreach (char c in chars.ToCharArray())
                {
                    Console.SetCursorPosition(Pos[0] - c, Pos[1]);
                    Console.Write(' ');
                }
            }
        }
    }
    public class Chest : Entity
    {
        public Chest()
        {
            this.oPos = Pos;
            this.Pos = MoveEntity(Pos);
            chars = "┌─┐└─┘";
        }
        public override void Render()
        {
            if (Pos[0] >= 0 && Pos[1] >= 0)
            {
                oPos = Pos;
                for (int c = 0; c < chars.Length; c++)
                {
                    if (c >= 3)
                    {
                        Console.SetCursorPosition(oPos[0] + (c - 3), Pos[1] + 1);
                    }
                    else
                    {
                        Console.SetCursorPosition(Pos[0] + c, Pos[1]);
                    }
                    Console.Write(chars[c]);
                }
            }
        }

        public override void DeRender()
        {
            if (Pos[0] >= 0 && Pos[1] >= 0)
            {
                for (int c = 0; c < chars.Length; c++)
                {
                    oPos = Pos;
                    while (c < chars.Length - 3)
                    {
                        Console.SetCursorPosition(Pos[0] - c, Pos[1]);
                        Console.Write(' ');
                    }
                    if (c == 2)
                    {
                        Console.SetCursorPosition(oPos[0] - c, Pos[1]);
                        Console.Write(' ');
                    }
                }
            }
        }
    }
}

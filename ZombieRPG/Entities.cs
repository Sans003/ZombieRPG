namespace ZombieRPG
{
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
                entityname.PosX = x; entityname.PosY = y;
                entityname.OPosX = entityname.PosX; entityname.OPosY = entityname.PosY;
                entityname.Symbols = "0││^";
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
                entityname.PosX = x; entityname.PosY = y;
                entityname.OPosX = entityname.PosX; entityname.OPosY = entityname.PosY;
                entityname.Symbols = ";m;";
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
                entityname.PosX = x; entityname.PosY = y;
                entityname.OPosX = entityname.PosX; entityname.OPosY = entityname.PosY;
                entityname.Symbols = "Q┼^";
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
                entityname.PosX = x; entityname.PosY = y;
                entityname.OPosX = entityname.PosX; entityname.OPosY = entityname.PosY;
                entityname.Symbols = "@┼^";
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
                entityname.PosX = x; entityname.PosY = y;
                entityname.OPosX = entityname.PosX; entityname.OPosY = entityname.PosY;
                entityname.Symbols = "┌─┐└─┘";
                entityname.Render();

            }


        }

    }
}


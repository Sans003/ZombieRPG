namespace ZombieRPG
{
    public class Entities
    {
        public List<Entity> EnemyList = new List<Entity>();
        static Random rng = new Random();

        public void spawnEntity()
        {
            int w = Console.WindowWidth - 2;
            int h = Console.WindowHeight - 3;
            int x = rng.Next(w);
            int y = rng.Next(h);
            int id = 1;



        }

    }
}


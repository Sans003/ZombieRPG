using Newtonsoft.Json;
using ZombieRPG;

namespace ConsoleApp4
{
    public class Inventory
    {
        public int capacity;
        private int currentCapacity;
        public List<Item> items;

        public void AddItem(Item item)
        {
            if (currentCapacity + item.weight <= capacity)
            {
                items.Add(item);
            }
        }
    }

    public class Item
    {
        public int id;
        public string name;
        public string description;
        public double value;
        public int weight;
        public ItemType type;
        public int? damage;
        public int? durability;
        public int? rof = 1;
        public string? modifier;


        public void UseItem(Item item, Entity? enemy)
        {
            if (item.type is ItemType.Weapon)
            {

            }
            else if (item.type is ItemType.Healing)
            {

            }
            else if (item.type is ItemType.Equipment)
            {

            }
        }

    }
    public enum ItemType
    {
        Weapon,
        Healing,
        Equipment,

    }

    public class WeaponModifier
    {
        public string Name { get; set; }
        public int? WeightModifier { get; set; }
        public int? DamageModifier { get; set; }
        public int? DurabilityModifier { get; set; }
        public int? Rof { get; set; }
        public WeaponModifier()
        {
        }
    }
    public class WeaponDictionary
    {
        public List<WeaponModifier> Sword { get; set; }
        public List<WeaponModifier> Rifle { get; set; }
        public List<WeaponModifier> Gun { get; set; }
        public List<WeaponModifier> Axe { get; set; }
        public List<WeaponModifier> BowAndArrow { get; set; }
    }
    public class WeaponFactory
    {
        public Dictionary<string, List<WeaponModifier>> WeaponModifierDictionary { get; set; }
        public Dictionary<string, List<Item>> ItemDictionary { get; set; }

        public void InitializeWeapons()
        {
            WeaponModifierDictionary = JsonConvert.DeserializeObject<Dictionary<string, List<WeaponModifier>>>(File.ReadAllText(@"C:\Users\vincent.volkmar\source\repos\ConsoleApp4\ConsoleApp4\WeaponModifiers.json"));
            ItemDictionary = JsonConvert.DeserializeObject<Dictionary<string, List<Item>>>(File.ReadAllText(@"C:\Users\vincent.volkmar\source\repos\ZombieRPG\ZombieRPG\WeaponNames.json"));
        }

        public Item CreateWeapon()
        {
            var weaponRandomizer = new WeaponRandomizer(WeaponModifierDictionary, ItemDictionary);
            var (weapon, modifier) = weaponRandomizer.GetRandomWeaponAndModifier();
            if (modifier != null)
            {
                return new Item
                {
                    name = weapon.name,
                    type = ItemType.Weapon,
                    weight = weapon.weight + (int)modifier.WeightModifier,
                    damage = weapon.damage + modifier.DamageModifier,
                    durability = weapon.durability + modifier.DurabilityModifier,
                    rof = weapon.rof + modifier.Rof,
                    modifier = $"WeightModifier: {modifier.WeightModifier.Value}\nDamageModifier: {modifier.DamageModifier.Value}\nDurabilityModifier: {modifier.DurabilityModifier.Value}\nRofModifier: {modifier.Rof.Value}"
                };
            }

            throw new ArgumentException($"No valid modifier found for weapon type '{weapon}'.");
        }
        public class WeaponRandomizer
        {
            private readonly Random _random = new Random();
            private Dictionary<string, List<WeaponModifier>> weaponModifiers;
            private Dictionary<string, List<Item>> itemDictionary;


            public WeaponRandomizer(Dictionary<string, List<WeaponModifier>> weaponModifierDictionary, Dictionary<string, List<Item>> itemDictionary)
            {
                this.weaponModifiers = weaponModifierDictionary;
                this.itemDictionary = itemDictionary;
            }

            public (Item, WeaponModifier) GetRandomWeaponAndModifier()
            {
                if (!itemDictionary.TryGetValue("weapons", out var weapons) || weapons == null)
                {
                    throw new InvalidOperationException("No weapons available for selection.");
                }

                var selectedWeapon = weapons[_random.Next(weapons.Count)];
                var selectedModifier = GetRandomModifier(selectedWeapon.name);

                return (selectedWeapon, selectedModifier);
            }

            private WeaponModifier GetRandomModifier(string weaponType)
            {
                var w = weaponModifiers.TryGetValue(weaponType.ToLower(), out var weaponList);
                if (weaponList == null || !weaponList.Any()) return null;
                var modifier = weaponList[_random.Next(weaponList.Count)];
                Console.WriteLine(modifier.Name);
                return modifier;
            }
        }
    }
}
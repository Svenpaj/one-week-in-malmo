using System;

namespace one_week_in_malmo
{
    public class Item
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }

    }

    public class Weapon : Item
    {
        public int Damage { get; set; }
        public int Durability { get; set; }
        public bool IsBroken { get; set; } = false;
        public bool IsEquipped { get; set; } = false;

        public Weapon(string name, string description, int damage, int durability) : base(name, description)
        {
            Damage = damage;
            Durability = durability;
            IsBroken = false;
            IsEquipped = false;
        }

        public void Equip()
        {
            IsEquipped = true;
        }

        public void Unequip()
        {
            IsEquipped = false;
        }
    }

    public class Consumable : Item
    {
        public int HealthRestore { get; set; }
        public int EnergyRestore { get; set; }
        public Consumable(string name, string description, int healthRestore, int energyRestore) : base(name, description)
        {
            HealthRestore = healthRestore;
            EnergyRestore = energyRestore;
        }

        public List<int> Consume()
        {
            return new List<int> { HealthRestore, EnergyRestore };
        }

    }


}
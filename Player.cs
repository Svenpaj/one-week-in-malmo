using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace one_week_in_malmo
{
    internal class Player(string name)
    {
        private string Name { get; set; } = name;
        private int Experience { get; set; } = 0;
        private int Level { get; set; } = 1;
        private int Money { get; set; } = 0;
        private int CurrentHealth { get; set; } = 100;
        private int MaxHealth { get; set; } = 100;
        private int CurrentEnergy { get; set; } = 100;
        private int MaxEnergy { get; set; } = 100;
        private Weapon EquippedWeapon { get; set; } = null;
        private List<Item> Inventory { get; set; } = new List<Item>();
        private List<Quest> Quests { get; set; } = new List<Quest>();
        private List<Item> Weapons { get; set; } = new List<Item>();

        public void AddItem(Item item)
        {
            Inventory.Add(item);
        }

        public void AddQuest(Quest quest)
        {
            Quests.Add(quest);
        }

        public void AddWeapon(Weapon weapon)
        {
            Weapons.Add(weapon);
        }

        public void RemoveItem(Item item)
        {
            Inventory.Remove(item);
        }

        public void RemoveQuest(Quest quest)
        {
            Quests.Remove(quest);
        }

        public void RemoveWeapon(Weapon weapon)
        {
            Weapons.Remove(weapon);
        }

        public void UseItem(Consumable item)
        {
            int health = item.Consume()[0];
            int energy = item.Consume()[1];

            if (CurrentHealth + health > MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }
            else
            {
                CurrentHealth += health;
            }

            if (CurrentEnergy + energy > MaxEnergy)
            {
                CurrentEnergy = MaxEnergy;
            }
            else
            {
                CurrentEnergy += energy;
            }
        }

        public void DisplayQuests()
        {
            Console.WriteLine("Quests:");
            foreach (Quest quest in Quests)
            {
                Console.WriteLine(quest.Name);
            }
        }
        public void EquipWeapon(Weapon weapon)
        {
            if (Weapons.Contains(weapon))
            {   
                weapon.Equip();
                EquippedWeapon = weapon;
                Console.WriteLine($"You have equipped {weapon.Name}");
            }
            else
            {
                Console.WriteLine("You do not have that weapon.");
            }
        }

        public void DisplayInventory()
        {
            Console.WriteLine("Inventory:");
            foreach (Item item in Inventory)
            {
                Console.WriteLine(item.Name);
            }
        }

        public void LevelUp()
        {
            Level++;
            MaxHealth += 10;
            MaxEnergy += 10;
            CurrentHealth = MaxHealth;
            CurrentEnergy = MaxEnergy;
            Console.WriteLine($"You have leveled up! You are now level {Level}. You feel fully restored.");

        }

        public void GainExperience(int experience)
        {
            Experience += experience;
            if (Experience >= 100)
            {
                LevelUp();
                Experience = 0;
            }
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
            {
                Console.WriteLine("You have died.");
            }
        }

        public void DisplayStats()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"Experience: {Experience}");
            Console.WriteLine($"Health: {CurrentHealth}/{MaxHealth}");
            Console.WriteLine($"Energy: {CurrentEnergy}/{MaxEnergy}");
            Console.WriteLine($"Money: {Money}");
        }

    }
}

using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;
        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = heroes.FindByName(heroName);
            if (hero == null)
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            IWeapon weapon = weapons.FindByName(weaponName);
            if (weapon == null)
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            if (hero.Weapon != null)
                throw new InvalidOperationException($"Hero {weaponName} is well-armed.");           
            
            hero.AddWeapon(weapon);
            return $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            IHero hero;
            if (heroes.FindByName(name) != null)
                throw new InvalidOperationException($"The hero {name} already exists.");

            switch (type)
            {
                case "Knight": hero = new Knight(name, health, armour); break;
                case "Barbarian": hero = new Barbarian(name, health, armour); break;
                default: throw new InvalidOperationException("Invalid hero type.");
            }

            heroes.Add(hero);
            if (hero.GetType().Name == "Knight")
                return $"Successfully added Sir {name} to the collection.";
            else
                return $"Successfully added Barbarian {name} to the collection.";
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (weapons.FindByName(name) != null)
                throw new InvalidOperationException($"The weapon {name} already exists.");

            IWeapon weapon;
            switch (type)
            {
                case "Claymore": weapon = new Claymore(name, durability); break;
                case "Mace": weapon = new Mace(name, durability); break;
                default: throw new InvalidOperationException("Invalid weapon type.");
            }
            weapons.Add(weapon);
            return $"A {type.ToLower()} {name} is added to the collection.";
        }

        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();           
            foreach (var hero in heroes.Models.OrderBy(x => x.GetType().Name)
                .ThenByDescending(x => x.Health).ThenByDescending(x => x.Name))
            {
                string output = hero.Weapon == null ? "Unarmed" : hero.Weapon.Name;
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");
                sb.AppendLine($"--Weapon: {output}");
            }
            return sb.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            IMap map = new Map();
            ICollection<IHero> players = heroes.Models.Where(x => x.IsAlive && x.Weapon != null).ToList();
            return map.Fight(players);
        }
    }
} 

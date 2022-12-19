using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> models;
        public WeaponRepository()
        {
            models = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => models.AsReadOnly();

        public void AddItem(IWeapon model)
        {
            models.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            return models.Find(m => m.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            return models.Remove(FindByName(name));
        }
    }
}

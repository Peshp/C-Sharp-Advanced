﻿using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private List<IVessel> models;
        public VesselRepository()
        {
            models = new List<IVessel>();
        }
        public IReadOnlyCollection<IVessel> Models => models.AsReadOnly();

        public void Add(IVessel model)
        {
            models.Add(model);
        }

        public IVessel FindByName(string name)
        {
            return models.Find(x => x.Name == name);
        }

        public bool Remove(IVessel model)
        {
            return models.Remove(model);
        }
    }
}

﻿using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private List<IFormulaOneCar> models;
        public FormulaOneCarRepository()
        {
            models = new List<IFormulaOneCar>();
        }
        public IReadOnlyCollection<IFormulaOneCar> Models => models.AsReadOnly();

        public void Add(IFormulaOneCar model)
        {
            models.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            return models.Find(m => m.GetType().Name == name);
        }

        public bool Remove(IFormulaOneCar model)
        {
            return models.Remove(model);
        }
    }
}

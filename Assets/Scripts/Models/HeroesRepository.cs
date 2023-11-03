using System;
using System.Collections.Generic;
using System.Linq;
using GourmetsRealm.LastStationDemo.Data;
using GourmetsRealm.LastStationDemo.Views;
using Object = UnityEngine.Object;

namespace GourmetsRealm.LastStationDemo.Models
{
    public class HeroesRepository
    {
        public HeroUnitModel[] HeroModels => _heroModelViewDictionary.Keys.ToArray();

        private readonly Dictionary<HeroUnitModel, HeroView> _heroModelViewDictionary;

        public HeroesRepository(HeroUnitData[] heroUnitsData)
        {
            _heroModelViewDictionary = new Dictionary<HeroUnitModel, HeroView>();

            foreach (var heroUnitData in heroUnitsData)
            {
                _heroModelViewDictionary.Add(new HeroUnitModel(), Object.Instantiate(heroUnitData.UnitView));
            }
        }

        public HeroView GetView(HeroUnitModel heroUnitModel)
        {
            if (!_heroModelViewDictionary.ContainsKey(heroUnitModel))
            {
                throw new Exception("You are trying to get non initialized hero model.");
            }

            return _heroModelViewDictionary[heroUnitModel];
        }
    }
}
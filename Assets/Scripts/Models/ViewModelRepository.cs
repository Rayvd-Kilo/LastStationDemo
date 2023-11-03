using System;
using System.Collections.Generic;
using System.Linq;
using GourmetsRealm.LastStationDemo.Data;
using GourmetsRealm.LastStationDemo.Interfaces;
using UnityEngine;

namespace GourmetsRealm.LastStationDemo.Models
{
    public class ViewModelRepository<TM,TV> 
        where TM : IUnitModel
        where TV : MonoBehaviour, IUnitView
    {
        public TM[] ModelsArray => _viewModelDictionary.Keys.ToArray();

        private readonly Dictionary<TM, TV> _viewModelDictionary;

        public ViewModelRepository(BaseUnitData<TV>[] unitsData)
        {
            _viewModelDictionary = new Dictionary<TM, TV>();

            foreach (var unitData in unitsData)
            {
                _viewModelDictionary.Add((TM)unitData.CreateModel(), unitData.UnitView);
            }
        }

        public TV GetViewPrototype(TM unitModel)
        {
            if (!_viewModelDictionary.ContainsKey(unitModel))
            {
                throw new Exception("You are trying to get prototype by non initialized unit model.");
            }

            return _viewModelDictionary[unitModel];
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using GourmetsRealm.LastStationDemo.Data;
using GourmetsRealm.LastStationDemo.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GourmetsRealm.LastStationDemo.Models
{
    public class ViewModelRepository<TM,TV> 
        where TM : IUnitModel
        where TV : MonoBehaviour, IUnitView
    {
        public TM[] ModelsArray => _prototypeModelDictionary.Keys.ToArray();

        private readonly Dictionary<TM, TV> _viewModelDictionary;

        private readonly Dictionary<TM, TV> _prototypeModelDictionary;

        public ViewModelRepository(BaseUnitData<TV>[] unitsData)
        {
            _viewModelDictionary = new Dictionary<TM, TV>();
            
            _prototypeModelDictionary = new Dictionary<TM, TV>();

            foreach (var unitData in unitsData)
            {
                _prototypeModelDictionary.Add((TM)unitData.CreateModel(), unitData.UnitView);
            }
        }

        public TV InitializeView(TM unitModel)
        {
            var prototype = GetViewPrototype(unitModel);

            var view = Object.Instantiate(prototype);
            
            _viewModelDictionary.Add(unitModel,view);
            
            return view;
        }

        public TV GetInitializedView(TM unitModel)
        {
            return GetView(unitModel, _viewModelDictionary);
        }

        private TV GetViewPrototype(TM unitModel)
        {
            return GetView(unitModel, _prototypeModelDictionary);
        }

        private TV GetView(TM unitModel, IReadOnlyDictionary<TM, TV> viewModelDictionary)
        {
            if (!viewModelDictionary.ContainsKey(unitModel))
            {
                throw new Exception($"You are trying to get {nameof(TV)} by non initialized unit model.");
            }

            return viewModelDictionary[unitModel];
        }
    }
}
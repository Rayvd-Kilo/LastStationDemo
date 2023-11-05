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
        public event Action<TM> ModelAdded;
        
        public TM[] ModelsArray => _viewModelDictionary.Keys.ToArray();

        public TV[] ViewsArray => _viewModelDictionary.Values.ToArray();

        private readonly Dictionary<TM, TV> _viewModelDictionary;

        public ViewModelRepository()
        {
            _viewModelDictionary = new Dictionary<TM, TV>();
        }

        public ViewModelRepository(BaseUnitData<TV>[] unitsData)
        {
            _viewModelDictionary = new Dictionary<TM, TV>();

            foreach (var unitData in unitsData)
            {
                _viewModelDictionary.Add((TM)unitData.CreateModel(), unitData.UnitView);
            }
        }

        public void AddElement(TM model,TV view)
        {
            _viewModelDictionary.Add(model, view);
            
            ModelAdded?.Invoke(model);
        }

        public void RemoveElement(TM model)
        {
            _viewModelDictionary.Remove(model);
        }

        public TM GetModelByView(TV prototype)
        {
            return _viewModelDictionary.First(x => x.Value.Equals(prototype)).Key;
        }

        public TV GetViewByModel(TM unitModel)
        {
            return GetView(unitModel, _viewModelDictionary);
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
using System;
using GourmetsRealm.LastStationDemo.Interfaces;
using UnityEngine;

namespace GourmetsRealm.LastStationDemo.Objects
{
    [Serializable]
    public class UnitCell<T> where T : IUnitModel
    {
        public event Action<Vector2, T> ModelPlaced;

        public event Action<Vector2, T> ModelRemoved;
        
        private T _unitModel;
        private Vector2 _cellPosition;
        private bool _isPlaced;

        public UnitCell(Vector2 cellPosition)
        {
            _cellPosition = cellPosition;
        }

        public void PlaceModel(T unitModel)
        {
            if (_isPlaced) return;
            
            _unitModel = unitModel;

            _isPlaced = false;
            
            ModelPlaced?.Invoke(_cellPosition, _unitModel);
        }

        public void RemoveModel()
        {
            if (!_isPlaced) return;
            
            ModelRemoved?.Invoke(_cellPosition, _unitModel);

            _unitModel = default;

            _isPlaced = false;
        }
    }
}
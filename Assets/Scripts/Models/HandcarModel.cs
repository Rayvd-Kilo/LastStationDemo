using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using GourmetsRealm.LastStationDemo.Interfaces;
using GourmetsRealm.LastStationDemo.Objects;
using UnityEngine;

namespace GourmetsRealm.LastStationDemo.Models
{
    public class HandcarModel : BaseDamageableModel, IResettable
    {
        public event Action<Vector2, IUnitModel> HeroPlaced;

        public event Action<Vector2, IUnitModel> HeroRemoved; 

        private int _defaultHealth;

        private readonly UnitCell<IUnitModel>[] _heroCells;

        public HandcarModel(int health, UnitCell<IUnitModel>[] heroCells)
        {
            Health = new AsyncReactiveProperty<int>(health);
            _heroCells = heroCells;
            
            foreach (var heroCell in _heroCells)
            {
                heroCell.ModelPlaced += OnHeroSet;
                heroCell.ModelRemoved += OnHeroRemoved;
            }
        }

        public void SetHeroToCell(IUnitModel heroModel)
        {
            if (_heroCells.All(x => x.IsPlaced)) return;
            
            _heroCells.First(x => !x.IsPlaced).PlaceModel(heroModel);
        }

        public void ResetToDefault()
        {
            Health.Value = _defaultHealth;
        }
        
        private void OnHeroSet(Vector2 cellPosition, IUnitModel heroModel)
        {
            HeroPlaced?.Invoke(cellPosition, heroModel);
        }
        
        private void OnHeroRemoved(Vector2 cellPosition, IUnitModel heroModel)
        {
            HeroRemoved?.Invoke(cellPosition, heroModel);
        }
    }
}
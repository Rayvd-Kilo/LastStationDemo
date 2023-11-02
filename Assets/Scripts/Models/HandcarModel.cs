using System;
using GourmetsRealm.LastStationDemo.Interfaces;
using GourmetsRealm.LastStationDemo.Objects;
using UnityEngine;

namespace GourmetsRealm.LastStationDemo.Models
{
    public class HandcarModel : IDamageable, IResettable
    {
        public event Action Destroyed;

        public int Health => _health;
        
        private int _health;

        private int _defaultHealth;

        private readonly UnitCell<IUnitModel>[] _heroCells;

        public HandcarModel(int health, Vector2[] cellPositions)
        {
            _health = health;
            _heroCells = new UnitCell<IUnitModel>[cellPositions.Length];

            for (var i = 0; i < cellPositions.Length; i++)
            {
                _heroCells[i] = new UnitCell<IUnitModel>(cellPositions[i]);
            }
        }

        public void TakeDamage(int damageAmount)
        {
            _health -= damageAmount;

            if (_health <= 0)
            {
                Destroyed?.Invoke();
            }
        }

        public void ResetToDefault()
        {
            _health = _defaultHealth;
        }
    }
}
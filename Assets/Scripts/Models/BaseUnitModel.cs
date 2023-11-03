using System;
using GourmetsRealm.LastStationDemo.Enums;
using GourmetsRealm.LastStationDemo.Interfaces;

namespace GourmetsRealm.LastStationDemo.Models
{
    public abstract class BaseUnitModel : IUnitModel
    {
        public event Action<UnitState> StateUpdated;
        
        private readonly int _damagePerHit;
        private readonly int _hitsCount;
        private readonly float _attackRechargeTime;
        private readonly float _hitDistance;

        private UnitState _currentState;

        public BaseUnitModel(int damagePerHit, int hitsCount, float attackRechargeTime, float hitDistance)
        {
            _damagePerHit = damagePerHit;
            _hitsCount = hitsCount;
            _attackRechargeTime = attackRechargeTime;
            _hitDistance = hitDistance;
        }

        protected void SetCurrentState(UnitState newState)
        {
            if (_currentState.Equals(newState)) return;
            
            _currentState = newState;
            
            StateUpdated?.Invoke(_currentState);
        }
    }
}
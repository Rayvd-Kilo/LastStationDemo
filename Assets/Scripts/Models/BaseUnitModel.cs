using System;
using GourmetsRealm.LastStationDemo.Enums;
using GourmetsRealm.LastStationDemo.Interfaces;

namespace GourmetsRealm.LastStationDemo.Models
{
    public abstract class BaseUnitModel : IUnitModel, IResettable
    {
        public event Action<UnitState> StateUpdated;

        public UnitState CurrentState => _currentState;

        public int DamagePerHit => _damagePerHit;

        public int HitsCount => _hitsCount;

        public float AttackRechargeTime => _attackRechargeTime;
        
        public float HitDistance => _hitDistance;
        
        private readonly int _initialDamagePerHit;
        private readonly int _initialHitsCount;
        private readonly float _initialAttackRechargeTime;
        private readonly float _initialHitDistance;

        private int _damagePerHit;
        private int _hitsCount;
        private float _attackRechargeTime;
        private float _hitDistance;
        
        private UnitState _currentState;

        public BaseUnitModel(int damagePerHit, int hitsCount, float attackRechargeTime, float hitDistance)
        {
            _damagePerHit = damagePerHit;
            _hitsCount = hitsCount;
            _attackRechargeTime = attackRechargeTime;
            _hitDistance = hitDistance;

            _initialDamagePerHit = damagePerHit;
            _initialHitsCount = hitsCount;
            _initialAttackRechargeTime = attackRechargeTime;
            _initialHitDistance = hitDistance;
        }

        public void SetCurrentState(UnitState newState)
        {
            if (_currentState.Equals(newState)) return;
            
            _currentState = newState;
            
            StateUpdated?.Invoke(_currentState);
        }

        public virtual void ResetToDefault()
        {
            _damagePerHit = _initialDamagePerHit;
            _hitsCount = _initialHitsCount;
            _attackRechargeTime = _initialAttackRechargeTime;
            _hitDistance = _initialHitDistance;
        }
    }
}
using GourmetsRealm.LastStationDemo.Data;
using GourmetsRealm.LastStationDemo.Interfaces;
using GourmetsRealm.LastStationDemo.Views;
using UnityEngine;

namespace GourmetsRealm.LastStationDemo.Models
{
    public class EnemyUnitModel : BaseUnitModel
    {
        public float MoveSpeed => _moveSpeed;
        
        private int _health;
        private float _moveSpeed;

        private readonly int _initialHealth;
        private readonly float _initialMoveSpeed;

        public EnemyUnitModel(int damagePerHit, int hitsCount, float attackRechargeTime, float hitDistance, int health,
            float moveSpeed) : base(
            damagePerHit, hitsCount, attackRechargeTime, hitDistance)
        {
            _health = health;
            _moveSpeed = moveSpeed;

            _initialHealth = health;
            _initialMoveSpeed = moveSpeed;
        }

        public EnemyUnitModel Clone()
        {
            return (EnemyUnitModel)MemberwiseClone();
        }

        public override void ResetToDefault()
        {
            _health = _initialHealth;
            _moveSpeed = _initialMoveSpeed;
            base.ResetToDefault();
        }
    }
}
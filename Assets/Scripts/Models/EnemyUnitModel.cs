namespace GourmetsRealm.LastStationDemo.Models
{
    public class EnemyUnitModel : BaseUnitModel
    {
        private readonly int _health;
        private readonly float _moveSpeed;

        public EnemyUnitModel(int damagePerHit, int hitsCount, float attackRechargeTime, float hitDistance, int health,
            float moveSpeed) : base(
            damagePerHit, hitsCount, attackRechargeTime, hitDistance)
        {
            _health = health;
            _moveSpeed = moveSpeed;
        }
    }
}
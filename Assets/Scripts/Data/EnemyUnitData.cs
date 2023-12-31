using GourmetsRealm.LastStationDemo.Interfaces;
using GourmetsRealm.LastStationDemo.Models;
using GourmetsRealm.LastStationDemo.Views;
using UnityEngine;

namespace GourmetsRealm.LastStationDemo.Data
{
    [CreateAssetMenu(fileName = nameof(EnemyUnitData), menuName = "GourmetsRealm/LastStationDemo/" + nameof(EnemyUnitData), order = 1)]
    public class EnemyUnitData : BaseUnitData<EnemyView>
    {
        [field:SerializeField] public int HealthPoints { get; private set; }
        
        [field:SerializeField] public float MoveSpeed { get; private set; }
        
        public override IUnitModel CreateModel()
        {
            return new EnemyUnitModel(DamagePerHit, HitsCount, TimeBeforeAttack, HitDistance, HealthPoints, MoveSpeed);
        }
    }
}
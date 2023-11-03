using GourmetsRealm.LastStationDemo.Interfaces;
using GourmetsRealm.LastStationDemo.Models;
using GourmetsRealm.LastStationDemo.Views;
using UnityEngine;

namespace GourmetsRealm.LastStationDemo.Data
{
    [CreateAssetMenu(fileName = nameof(HeroUnitData), menuName = "GourmetsRealm/LastStationDemo/" + nameof(HeroUnitData), order = 0)]
    public class HeroUnitData : BaseUnitData<HeroView>
    {
        public override IUnitModel CreateModel()
        {
            return new HeroUnitModel(DamagePerHit, HitsCount, TimeBeforeAttack, HitDistance);
        }
    }
}
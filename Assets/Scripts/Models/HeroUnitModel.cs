using GourmetsRealm.LastStationDemo.Interfaces;

namespace GourmetsRealm.LastStationDemo.Models
{
    public class HeroUnitModel : BaseUnitModel
    {
        public HeroUnitModel(int damagePerHit, int hitsCount, float attackRechargeTime, float hitDistance) : base(
            damagePerHit, hitsCount, attackRechargeTime, hitDistance)
        {
        }
    }
}
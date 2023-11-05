using System.Linq;
using Cysharp.Threading.Tasks;
using GourmetsRealm.LastStationDemo.Structs;

namespace GourmetsRealm.LastStationDemo.Models
{
    public class HordeModel : BaseDamageableModel
    {
        public int TotalEnemies { get; }

        private readonly EnemiesWaveData[] _enemiesWavesData;

        public HordeModel(EnemiesWaveData[] enemiesWavesData)
        {
            _enemiesWavesData = enemiesWavesData;

            var totalHordeHealth = 0;
            
            foreach (var enemiesWaveData in enemiesWavesData)
            {
                foreach (var enemyUnitData in enemiesWaveData.EnemiesUnitData)
                {
                    totalHordeHealth += enemyUnitData.HealthPoints;
                }

                TotalEnemies += enemiesWaveData.EnemiesCount;
            }
            
            Health = new AsyncReactiveProperty<int>(totalHordeHealth);
        }

        public EnemiesWaveData GetWaveData(float timeAmount)
        {
            return _enemiesWavesData.OrderByDescending(x => x.SpawnTime <= timeAmount).First();
        }
    }
}
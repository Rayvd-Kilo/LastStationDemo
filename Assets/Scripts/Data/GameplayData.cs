using GourmetsRealm.LastStationDemo.Structs;
using UnityEngine;

namespace GourmetsRealm.LastStationDemo.Data
{
    [CreateAssetMenu(fileName = nameof(GameplayData), menuName = "GourmetsRealm/LastStationDemo/" + nameof(GameplayData), order = 0)]
    public class GameplayData : ScriptableObject
    {
        [field:SerializeField] public HeroUnitData[] HeroesUnitData { get; private set; }
        
        [field:SerializeField] public HandcarData HandcarData { get; private set; }
        
        [field:SerializeField] public StageData[] StagesData { get; private set; }
        
        [field:SerializeField] public EnemiesGeneratingData GeneratingData { get; private set; }
    }
}
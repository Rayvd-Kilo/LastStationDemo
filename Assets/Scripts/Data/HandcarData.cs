using GourmetsRealm.LastStationDemo.Views;
using UnityEngine;

namespace GourmetsRealm.LastStationDemo.Data
{
    [CreateAssetMenu(fileName = nameof(HandcarData), menuName = "GourmetsRealm/LastStationDemo/" + nameof(HandcarData), order = 2)]
    public class HandcarData : ScriptableObject
    {
        [field:SerializeField] public HandcarView HandcarView { get; private set; }
        
        [field:SerializeField] public int Health { get; private set; }
        
        [field:SerializeField] public Vector2 CarInitialPosition { get; private set; }
        
        [field:SerializeField] public Vector2[] CellPositions { get; private set; }
    }
}
using System;
using UnityEngine;

namespace GourmetsRealm.LastStationDemo.Structs
{
    [Serializable]
    public struct EnemiesGeneratingData
    {
        public Vector2 HorizontalBounds => _horizontalBounds;

        public Vector2 VerticalBounds => _verticalBounds;
        
        [SerializeField] private Vector2 _horizontalBounds;

        [SerializeField] private Vector2 _verticalBounds;
    }
}
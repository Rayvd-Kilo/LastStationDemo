using GourmetsRealm.LastStationDemo.Interfaces;

namespace GourmetsRealm.LastStationDemo.Models
{
    public class GameplayIterationModel : IResettable
    {
        public bool IsEndgame => _isEndgame;

        public bool IsVictory => _isVictory;

        public float CurrentInGameIterationTime => _currentInGameIterationTime;

        private bool _isEndgame;

        private bool _isVictory;

        private float _currentInGameIterationTime;
        
        public void EndGame(bool winCondition)
        {
            _isVictory = winCondition;

            _isEndgame = true;
        }

        public void ResetToDefault()
        {
            _isVictory = false;

            _isEndgame = false;

            _currentInGameIterationTime = 0;
        }
    }
}
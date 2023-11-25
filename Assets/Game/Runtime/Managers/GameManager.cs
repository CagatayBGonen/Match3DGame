using Game.Runtime.Util;
using StandardSetup.Runtime.Handlers;
using UnityEngine;

namespace Game.Runtime.Managers
{
    public class GameManager : MonoBehaviour
    {
        private LevelStates _currentLevelStates = LevelStates.Gameplay;

        public void SetNewLevelState(LevelStates newLevelStates)
        {
            _currentLevelStates = newLevelStates;
            ActionHandler<LevelStates>.Raise(ActionKey.GameLevelStateChangedKey, _currentLevelStates);
        }
    }
}

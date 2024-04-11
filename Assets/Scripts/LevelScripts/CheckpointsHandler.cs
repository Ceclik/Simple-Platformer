using MenuHandlers.LoseMenu;
using PlatformScripts;
using UnityEngine;

namespace LevelScripts
{
    public class CheckpointsHandler : MonoBehaviour
    {
        [SerializeField] private CheckPoint[] checkPoints;

        private MenuButtonsHandler _buttonsHandler;

        private void Start()
        {
            foreach (var checkPoint in checkPoints)
                checkPoint.OnCheckpointStay += ResetAllCheckpoints;
            
            _buttonsHandler = GameObject.Find("ButtonsHandler").GetComponent<MenuButtonsHandler>();
            _buttonsHandler.OnRestartLevel += ResetAllCheckpoints;
        }

        public void ResetAllCheckpoints()
        {
            foreach (var checkPoint in checkPoints)
                checkPoint.IsCurrentCheckPoint = false;
        }

        private void OnDestroy()
        {
            foreach (var checkPoint in checkPoints)
                checkPoint.OnCheckpointStay -= ResetAllCheckpoints;

            _buttonsHandler.OnRestartLevel -= ResetAllCheckpoints;
        }
    }
}

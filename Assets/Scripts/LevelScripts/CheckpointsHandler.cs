using PlatformScripts;
using UnityEngine;

namespace LevelScripts
{
    public class CheckpointsHandler : MonoBehaviour
    {
        [SerializeField] private CheckPoint[] checkPoints;

        private void Start()
        {
            foreach (var checkPoint in checkPoints)
                checkPoint.OnCheckpointStay += ResetAllCheckpoints;
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
        }
    }
}

using UnityEngine;

namespace EnemyScripts
{
    public class EnemyBehaviourHandler : MonoBehaviour
    {
        private PlatformEffector2D _platform;

        private void Start()
        {
            _platform = GetComponent<PlatformEffector2D>();
        }

        
    }
}

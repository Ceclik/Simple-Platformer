using UnityEngine;

namespace PlatformScripts
{
    public class CameraMovementTrigger : MonoBehaviour
    {
        public bool IsJumped { get; set; }

        private void Start()
        {
            IsJumped = false;
        }
    }
}
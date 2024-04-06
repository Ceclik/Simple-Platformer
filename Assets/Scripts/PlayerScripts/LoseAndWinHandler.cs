using PlatformScripts;
using UnityEngine;

namespace PlayerScripts
{
    public class LoseAndWinHandler : MonoBehaviour
    {
        [SerializeField] private Transform firstPlatform;

        [SerializeField] private Transform platformsParent;
        public bool IsLost { get; set; }
        private GameObject[] _platforms;


        private void Start()
        {
            IsLost = false;
            _platforms = new GameObject[platformsParent.childCount];
            for (int i = 0; i < platformsParent.childCount; i++)
                _platforms[i] = platformsParent.GetChild(i).gameObject;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Win")) Debug.Log("You Win!");
            if (other.gameObject.CompareTag("Lose"))
            {
                IsLost = true;
                transform.position = firstPlatform.position;
                foreach (var item in _platforms)
                    if(item.TryGetComponent(out CameraMovementTrigger trigger))
                        if (trigger.IsJumped)
                            trigger.IsJumped = false;
            }
        }
    }
}
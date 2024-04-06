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

        private int _lifesCounter;
        private HeartsHandler _heartsHandler;
        
        private void Start()
        {
            IsLost = false;
            _lifesCounter = 3;
            _platforms = new GameObject[platformsParent.childCount];
            for (int i = 0; i < platformsParent.childCount; i++)
                _platforms[i] = platformsParent.GetChild(i).gameObject;
            _heartsHandler = GetComponent<HeartsHandler>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Win")) Debug.Log("You Win!");
            if (other.gameObject.CompareTag("Lose") && _lifesCounter > 0)
            {
                _lifesCounter--;
                IsLost = true;
                transform.position = firstPlatform.position;
                foreach (var item in _platforms)
                    if(item.TryGetComponent(out CameraMovementTrigger trigger))
                        if (trigger.IsJumped)
                            trigger.IsJumped = false;
                _heartsHandler.EmptyHeart();
                if (_lifesCounter == 0)
                {
                    /*TODO*/
                    Debug.Log("You lose!");
                }
            }
        }
    }
}
using UnityEngine;

namespace PlayerScripts
{
    public class HeartsPicker : MonoBehaviour
    {
        public delegate void HandlePickedHeart();
        public event HandlePickedHeart OnPickHeart;

        [SerializeField] private Transform heartsObjectsParent;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Heart"))
            {
                other.gameObject.SetActive(false);
                OnPickHeart?.Invoke();
            }
        }

        public void ResetHearts()
        {
            for(var i = 0; i < heartsObjectsParent.childCount; i++)
                heartsObjectsParent.GetChild(i).gameObject.SetActive(true);
        }
    }
}

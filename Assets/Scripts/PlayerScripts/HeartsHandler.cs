using UnityEngine;

namespace PlayerScripts
{
    public class HeartsHandler : MonoBehaviour
    {
        [SerializeField] private RectTransform heartsParent;

        [Space(10)] [SerializeField] private Sprite emptyHeart;
        [SerializeField] private Sprite redHeart;

        private SpriteRenderer[] _heartImages;
        private int _heartIndex;

        private void Start()
        {
            _heartIndex = 2;
            _heartImages = new SpriteRenderer[heartsParent.childCount];
            for (var i = 0; i < heartsParent.childCount; i++)
                _heartImages[i] = heartsParent.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
        }

        public void EmptyHeart()
        {
            _heartImages[_heartIndex].sprite = emptyHeart;
            _heartIndex--;
        }

        public void MakeAllHeartsRed()
        {
            foreach (var image in _heartImages)
                image.sprite = redHeart;
            _heartIndex = 2;
        }
    }
}
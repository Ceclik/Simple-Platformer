using System;
using UnityEngine;

namespace PlayerScripts
{
    public class HeartsHandler : MonoBehaviour
    {
        [SerializeField] private RectTransform heartsParent;

        [Space(10)] [SerializeField] private Sprite emptyHeart;
        [SerializeField] private Sprite redHeart;
        [SerializeField] private Sprite halfHeart;

        private SpriteRenderer[] _heartImages;
        private int _heartIndex;
        private bool _isHalf;

        private HeartsPicker _heartsPicker;

        private void Start()
        {
            _isHalf = false;
            _heartIndex = 2;
            _heartImages = new SpriteRenderer[heartsParent.childCount];
            for (var i = 0; i < heartsParent.childCount; i++)
                _heartImages[i] = heartsParent.GetChild(i).gameObject.GetComponent<SpriteRenderer>();

            _heartsPicker = GetComponent<HeartsPicker>();
            _heartsPicker.OnPickHeart += AddHeart;
        }

        private void OnDestroy()
        {
            _heartsPicker.OnPickHeart -= AddHeart;
        }

        private void AddHeart()
        {
            if (_heartIndex == 2 && !_isHalf) return;

            if (_heartIndex == 2 && _isHalf)
            {
                _heartImages[_heartIndex].sprite = redHeart;
                _isHalf = false;
                return;
            }

            if (_heartIndex < 2 && _isHalf)
            {
                _heartImages[_heartIndex].sprite = redHeart;
                _isHalf = false;
                return;
            }

            if (_heartIndex < 2 && !_isHalf)
            {
                _heartIndex++;
                _heartImages[_heartIndex].sprite = redHeart;
            }
        }

        public void EmptyHalfHeart()
        {
            if (!_isHalf)
            {
                _heartImages[_heartIndex].sprite = halfHeart;
                _isHalf = true;
            }
            else
            {
                _heartImages[_heartIndex].sprite = emptyHeart;
                _isHalf = false;
                _heartIndex--;
            }
        }

        public void EmptyHeart()
        {
            _heartImages[_heartIndex].sprite = emptyHeart;
            if (_isHalf)
                _isHalf = false;
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
using System.Collections;
using PlayerScripts;
using UnityEngine;

namespace MenuHandlers.WinMenu
{
    public class StarsHandler : MonoBehaviour
    {
        [SerializeField] private RectTransform starsParent;
        [SerializeField] private Transform coinsParent;
        [SerializeField] private CoinsHandler coinsHandler;

        private SpriteRenderer[] _starImages;
        
        [Header("Stars Conditions")] 
        [SerializeField] [Range(0, 100)] private int firstStar;
        [SerializeField] [Range(0, 100)] private int secondStar;
        [SerializeField] [Range(0, 100)] private int thirdStar;

        [Space(10)] [SerializeField] private float starAppearDelay;
        [Space(10)][SerializeField] private Sprite fullStarImage;

        private void Start()
        {
            _starImages = new SpriteRenderer[starsParent.childCount];
            for (int i = 0; i < starsParent.childCount; i++)
                _starImages[i] = starsParent.GetChild(i).GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            DrawStars();
        }

        private int CountAmountOfAwardedStars()
        {
            float awardedPart = 100 * coinsHandler.CoinsCount / coinsParent.childCount;

            if (awardedPart < firstStar) return 0;
            if (awardedPart >= firstStar && awardedPart < secondStar) return 1;
            if (awardedPart >= secondStar && awardedPart < thirdStar) return 2;
            return 3;
        }

        private void DrawStars()
        {
            switch (CountAmountOfAwardedStars())
            {
                case 1: 
                    StartCoroutine(DrawStar(1)); 
                    break;
                case 2:
                    StartCoroutine(DrawStar(2));
                    break;
                case 3:
                    StartCoroutine(DrawStar(3));
                    break;
            }
        }

        private IEnumerator DrawStar(int amount)
        {
            int imageIndex = 0;
            while (amount > 0)
            {
                yield return  new WaitForSeconds(starAppearDelay);
                amount--;
                _starImages[imageIndex].sprite = fullStarImage;
                imageIndex++;
            }
        }
    }
}

using System;
using LevelScripts;
using UnityEngine;
using UnityEngine.UI;

namespace Dialogues
{
    public class DialogHandler : MonoBehaviour
    {
        private GameValuesSetter _values;

        [SerializeField] private string[] dialogStrings;
        [Space(10)] [SerializeField] private GameObject dialogPanel;
        [SerializeField] private Text dialogText;

        private DialogPanelSpaceWaiter _spaceWaiter;

        private int _index = 0;
        private bool _isEntered;

        private void Start()
        {
            _values = GameObject.Find("GameValues").GetComponent<GameValuesSetter>();
            _spaceWaiter = dialogPanel.GetComponent<DialogPanelSpaceWaiter>();
            _spaceWaiter.OnSpaceButtonEnter += UpdateText;
        }

        private void OnDestroy()
        {
            _spaceWaiter.OnSpaceButtonEnter -= UpdateText;
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _isEntered = true;
                _values.isInDialog = true;
                dialogPanel.SetActive(true);
                UpdateText();
            }
        }

        private void UpdateText()
        {
            if (_isEntered)
            {
                if (_index < dialogStrings.Length)
                {
                    dialogText.text = dialogStrings[_index];
                    _index++;
                }
                else
                {
                    _isEntered = false;
                    _values.isInDialog = false;
                    _index = 0;
                    dialogPanel.SetActive(false);
                }
            }
        }

    }
}

using System;
using MenuHandlers.LoseMenu;
using UnityEngine;

namespace Dialogues
{
    public class DialogResetter : MonoBehaviour
    {
        private DialogHandler[] _dialogues;

        [SerializeField] private MenuButtonsHandler _buttonsHandler;

        private void Start()
        {
            _dialogues = new DialogHandler[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
                _dialogues[i] = transform.GetChild(i).GetComponent<DialogHandler>();
            }

            _buttonsHandler.OnRestartLevel += ResetDialogues;
        }

        private void OnDestroy()
        {
            _buttonsHandler.OnRestartLevel -= ResetDialogues;
        }

        private void ResetDialogues()
        {
            foreach (var dialog in _dialogues)
            {
                dialog.IsEntered = false;
            }
        }
    }
}

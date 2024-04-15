using System;
using UnityEngine;

namespace Dialogues
{
    public class DialogPanelSpaceWaiter : MonoBehaviour
    {
        public delegate void ShowNewText();
        public event ShowNewText OnSpaceButtonEnter;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnSpaceButtonEnter?.Invoke();
            }
        }
    }
}

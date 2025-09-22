using System;
using UnityEngine;

namespace Shafir
{
    public class UserInput : MonoBehaviour
    {
        public event Action LeftMouseButtonClicked;
        public event Action CancelButtonPressed;
        public event Action SwitchModePressed;
        public Vector2 MousePosition => _mousePosition;

        private Vector2 _mousePosition;

        private void Update()
        {
            _mousePosition = Input.mousePosition;

            if (Input.GetMouseButtonDown(0) == true)
            {
                LeftMouseButtonClicked?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Escape) == true)
            {
                CancelButtonPressed?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Tab) == true)
            {
                SwitchModePressed?.Invoke();
            }
        }
    }
}
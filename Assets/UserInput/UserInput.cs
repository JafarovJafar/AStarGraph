using System;
using UnityEngine;

namespace Shafir
{
    public class UserInput : MonoBehaviour
    {
        public event Action LeftMouseButtonClicked;
        public event Action CancelButtonPressed;
        public event Action SelectMode1Pressed;
        public event Action SelectMode2Pressed;
        public event Action SelectMode3Pressed;
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

            if (Input.GetKeyDown(KeyCode.Alpha1) == true)
            {
                SelectMode1Pressed?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) == true)
            {
                SelectMode2Pressed?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Alpha3) == true)
            {
                SelectMode3Pressed?.Invoke();
            }
        }
    }
}
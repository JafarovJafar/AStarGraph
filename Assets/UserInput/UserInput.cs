using System;
using UnityEngine;

namespace Shafir
{
    public class UserInput : MonoBehaviour
    {
        public event Action LeftMouseButtonClicked;
        public Vector2 MousePosition => _mousePosition;

        private Vector2 _mousePosition;

        private void Update()
        {
            _mousePosition = Input.mousePosition;

            if (Input.GetMouseButtonDown(0) == true)
            {
                LeftMouseButtonClicked?.Invoke();
            }
        }
    }
}
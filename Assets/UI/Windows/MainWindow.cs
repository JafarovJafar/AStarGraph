using System;
using UnityEngine;
using UnityEngine.UI;

namespace Shafir.UI
{
    public class MainWindow : Window
    {
        public event Action StartClicked;

        [SerializeField] private Button startButton;

        public void Initialize()
        {
            startButton.onClick.AddListener(OnStartClicked);
        }

        private void OnStartClicked()
        {
            StartClicked?.Invoke();
        }
    }
}
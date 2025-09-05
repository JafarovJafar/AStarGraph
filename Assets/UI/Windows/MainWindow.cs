using System;
using UnityEngine;
using UnityEngine.UI;

namespace Shafir.UI
{
    public class MainWindow : Window
    {
        public event Action StartClicked;

        [SerializeField] private Button startButton;
        [SerializeField] private Label timeLabel;

        public void Initialize()
        {
            startButton.onClick.AddListener(OnStartClicked);
        }

        private void OnStartClicked()
        {
            StartClicked?.Invoke();
        }

        public void SetTime(float time)
        {
            timeLabel.SetText($"Elapsed time: {time}");
        }
    }
}
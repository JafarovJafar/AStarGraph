using System;
using UnityEngine;
using UnityEngine.UI;

namespace Shafir.UI
{
    public class MainWindow : Window
    {
        public event Action SearchModeClicked;
        public event Action ConstructorModeClicked;

        [SerializeField] private Button searchModeButton;
        [SerializeField] private Button constructorModeButton;

        public void Initialize()
        {
            searchModeButton.onClick.AddListener(OnSearchModeButtonClicked);
            constructorModeButton.onClick.AddListener(OnConstructorModeButtonClicked);
        }

        private void OnSearchModeButtonClicked()
        {
            SearchModeClicked?.Invoke();
        }

        private void OnConstructorModeButtonClicked()
        {
            ConstructorModeClicked?.Invoke();
        }
    }
}
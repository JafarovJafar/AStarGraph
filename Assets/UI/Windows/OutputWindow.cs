using UnityEngine;

namespace Shafir.UI
{
    public class OutputWindow : Window
    {
        [SerializeField] private string prefix = "Время поиска: ";
        [SerializeField] private Label timeLabel;

        public void SetTime(float time)
        {
            timeLabel.SetText($"{prefix}{time}");
        }

        public void Clear()
        {
            timeLabel.SetText("");
        }
    }
}
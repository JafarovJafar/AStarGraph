using UnityEngine;

namespace Shafir.UI
{
    public class OutputWindow : Window
    {
        [SerializeField] private Label timeLabel;

        public void SetTime(float time)
        {
            timeLabel.SetText($"Elapsed time: {time}");
        }
    }
}
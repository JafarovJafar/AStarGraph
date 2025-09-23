using UnityEngine;

namespace Shafir.UI
{
    public class LegendWindow : Window
    {
        [SerializeField] private Label legendLabel;

        public void SetLegend(string legend)
        {
            legendLabel.SetText(legend);
        }
    }
}
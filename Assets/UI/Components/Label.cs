using TMPro;
using UnityEngine;

namespace Shafir.UI
{
    public class Label : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI label;

        public void SetText(string text)
        {
            label.text = text;
        }
    }
}
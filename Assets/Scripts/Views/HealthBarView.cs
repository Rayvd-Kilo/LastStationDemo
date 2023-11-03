using TMPro;
using UnityEngine;

namespace GourmetsRealm.LastStationDemo.Views
{
    public class HealthBarView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _tmp;

        public void UpdateHealthValue(string value)
        {
            _tmp.text = value;
        }
    }
}
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TopDown
{
    public class GameUI : BaseUI
    {
        [SerializeField] private TextMeshProUGUI waveText;
        [SerializeField] private TextMeshProUGUI killText;
        [SerializeField] private Slider hpSlider;

        private void Start()
        {
            UpdateHPSlider(1);
        }

        public void UpdateHPSlider(float percentage)
        {
            hpSlider.value = percentage;
        }

        public void UpdateWaveText(int wave)
        {
            waveText.text = wave.ToString();
        }

        public void UpdateKillText(int kill)
        {
            killText.text = kill.ToString();
        }

        protected override UIState GetUIState()
        {
            return UIState.Game;
        }
    }
}
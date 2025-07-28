using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TopDown
{
    public class HomeUI : BaseUI
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button exitButton;

        public override void Init(UIManager uiManager)
        {
            base.Init(uiManager);

            startButton.onClick.AddListener(OnClickStartButton);
            exitButton.onClick.AddListener(OnClickExitButton);
        }

        public void OnClickStartButton()
        {
            GameManager.Instance.StartGame();
        }

        public void OnClickExitButton()
        {
            SceneManager.LoadScene(0);
        }

        protected override UIState GetUIState()
        {
            return UIState.Home;
        }
    }
}

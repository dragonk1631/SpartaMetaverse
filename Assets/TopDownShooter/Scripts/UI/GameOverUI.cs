using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TopDown
{
    public class GameOverUI : BaseUI
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button exitButton;

        public override void Init(UIManager uiManager)
        {
            base.Init(uiManager);

            restartButton.onClick.AddListener(OnClickRestartButton);
            exitButton.onClick.AddListener(OnClickExitButton);
        }

        public void OnClickRestartButton()
        {
            SceneManager.LoadScene(3);
        }

        public void OnClickExitButton()
        {
            SceneManager.LoadScene(0);
        }

        protected override UIState GetUIState()
        {
            return UIState.GameOver;
        }
    }
}

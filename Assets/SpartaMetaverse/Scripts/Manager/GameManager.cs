using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpartaMetaverse
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        private UIManager uiManager;

        public int SelectedSceneIndex { get; set; }
        public string SelectedSceneName { get; set; }

        private void Awake()
        {
            if (Instance == null) Instance = this;
            uiManager = FindAnyObjectByType<UIManager>();
        }

        public void PopupWindow(bool toggleSwitch) 
        {
            uiManager.MiniGamePopup(SelectedSceneName, toggleSwitch);
        }
        public void ChangeScene() 
        {
            SceneManager.LoadScene(SelectedSceneIndex);
        }
    }
}
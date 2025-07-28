using UnityEngine;

namespace TopDown
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public PlayerController player { get; private set; }
        private ResouceController playerResouceController;

        [SerializeField] private int currentWaveIndex = 0;

        private EnemyManager enemyManager;

        private UIManager uiManager;

        public static bool isFirstLoading = true;

        public int monsterKillCount = 0;

        private void Awake()
        {
            Instance = this;

            player = FindObjectOfType<PlayerController>();
            player.Init(this);

            uiManager = FindAnyObjectByType<UIManager>();

            enemyManager = GetComponentInChildren<EnemyManager>();
            enemyManager.Init(this);

            playerResouceController = player.GetComponent<ResouceController>();
            playerResouceController.RemoveHealthChangeEvent(uiManager.ChangePlayerHP);
            playerResouceController.AddHealthChangeEvent(uiManager.ChangePlayerHP);
        }

        private void Start()
        {
            if (!isFirstLoading)
            {
                StartGame();
            }
            else
            {
                isFirstLoading = false;
            }
        }

        public void StartGame()
        {
            uiManager.SetPlayGame();
            StartNextWave();
        }

        void StartNextWave()
        {
            currentWaveIndex += 1;
            enemyManager.StartWave(1 + currentWaveIndex / 5);
            uiManager.ChangeWave(currentWaveIndex);
        }

        public void EndOfWave()
        {
            StartNextWave();
        }

        public void GameOver()
        {
            enemyManager.StopWave();
            uiManager.SetGameOver();
        }
    }
}

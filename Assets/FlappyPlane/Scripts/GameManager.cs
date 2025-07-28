using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlappyPlane
{
    public class GameManager : MonoBehaviour
    {
        static GameManager gameManager;
        public static GameManager Instance { get { return gameManager; } }

        private int currentScore = 0;

        UIManager uiManager;
        public UIManager UIManager { get { return uiManager; } }
        private void Awake()
        {
            gameManager = this;
            uiManager = FindObjectOfType<UIManager>();
            uiManager.startWindow.SetActive(true);
        }

        public void StartGame() 
        {
            Player player = FindAnyObjectByType<Player>();
            player.isDead = false;
            uiManager.StartGame();
        }

        public void ExitGame() 
        {
            SceneManager.LoadScene(0);
        }

        public void GameOver()
        {
            //Debug.Log("Game Over");
            uiManager.SetReStart();
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(1);
        }

        public void AddScore(int score)
        {
            currentScore += score;
            //Debug.Log($"Score: {currentScore}");
            uiManager.UpdateScore(currentScore);
        }
    }
}

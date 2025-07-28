using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FlappyPlane
{
    public class UIManager : MonoBehaviour
    {
        public TextMeshProUGUI scoreText;
        public GameObject startWindow;
        // Start is called before the first frame update
        void Start()
        {
            startWindow.gameObject.SetActive(true);
        }

        public void StartGame() 
        {
            startWindow.gameObject.SetActive(false);
        }

        public void SetReStart()
        {
            startWindow.gameObject.SetActive(true);
        }

        public void UpdateScore(int score)
        {
            scoreText.text = score.ToString();
        }
    }
}


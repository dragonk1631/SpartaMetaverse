using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpartaMetaverse
{
    public class PlayerInteraction : MonoBehaviour
    {
        private SpriteRenderer PlayerSprite;

        private void Start()
        {
            // 플레이어의 스프라이트 컴퍼넌트의 정보를 취득
            PlayerSprite = GetComponentInChildren<SpriteRenderer>();
        }

        // 플레이어의 자식에 붙어있는 이벤트 감지용 콜라이더의 처리(들어갔을때)
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision != null)
            {
                // 그림자존에 들어갔을 때의 처리
                if (collision.CompareTag("ShadowZone"))
                {
                    Color color = PlayerSprite.color;
                    color.a = 0.5f;
                    PlayerSprite.color = color;
                }

                // 이벤트가 일어나는 지역에 들어갔을때
                else if (collision.CompareTag("EventZone"))
                {
                    switch (collision.gameObject.name)
                    {
                        case "FlappyZone":
                            GameManager.Instance.SelectedSceneIndex = 1;
                            GameManager.Instance.SelectedSceneName = "FlappyZone";
                            
                            break;
                        case "StackZone":
                            GameManager.Instance.SelectedSceneIndex = 2;
                            GameManager.Instance.SelectedSceneName = "StackZone";
                            break;
                        case "TopdownZone":
                            GameManager.Instance.SelectedSceneIndex = 3;
                            GameManager.Instance.SelectedSceneName = "TopdownZone";
                            break;
                    }
                    GameManager.Instance.PopupWindow(true);
                }
            }
        }

        // 플레이어의 자식에 붙어있는 이벤트 감지용 콜라이더의 처리(나갔을때)
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision != null)
            {
                if (collision.CompareTag("ShadowZone"))
                {
                    Color color = PlayerSprite.color;
                    color.a = 1f;
                    PlayerSprite.color = color;
                }
                // 이벤트가 일어나는 지역에서 나갈때
                else if (collision.CompareTag("EventZone")) 
                {
                    GameManager.Instance.PopupWindow(false);
                }
            }
        }
    }
}

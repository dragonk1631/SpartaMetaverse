using TMPro;
using UnityEngine;

namespace SpartaMetaverse
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject popupWindow;
        public void MiniGamePopup(string gameName, bool toggleSwitch) 
        {
            if (popupWindow != null) 
            {
                popupWindow.SetActive(toggleSwitch);
                popupWindow.GetComponentInChildren<TextMeshProUGUI>().text = gameName;
            }
        }
    }
}

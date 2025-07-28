using UnityEngine;

namespace TopDown
{
    public class StatHandler : MonoBehaviour
    {
        [Range(1, 100)][SerializeField] private int health = 10;

        public int Health
        {
            get => health;
            set => health = Mathf.Clamp(value, 0, 100);
        }

        [Range(1f, 20f)][SerializeField] private float speed = 3f;

        public float Speed
        {
            get => speed;
            set => Mathf.Clamp(value, 0, 20);
        }
    }
}

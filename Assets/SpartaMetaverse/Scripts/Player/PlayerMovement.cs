using UnityEngine;
using UnityEngine.InputSystem;

namespace SpartaMetaverse
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D rb;
        private PlayerAnimation animator;

        [field: SerializeField] public float MoveSpeed { get; private set; } = 5f; // 이동속도(에디터에서 값조정가능)
        private Vector2 direction;  // 이동방향 벡터값

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<PlayerAnimation>();
        }

        // 사용자의 입력은 Update에서 처리하고 실제 이동은 FixedUpdate에서 처리하는 방식이 일반적이라고 한다
        private void FixedUpdate()
        {
            // 리지드바디의 속도 값을 바꾸는 방식으로 이동을 구현(다른 충돌체와의 상호작용에 유리)
            rb.velocity = direction * MoveSpeed;    // 이동방향에 속력를 곱한값을 속도에 대입
        }

        // 사용자의 입력값을 받아서 오브젝트의 이동을 처리하는 메소드
        public void OnMove(InputValue value)    // value값은 (0.01, 0.00)과 같은 형태로 들어온다
        {
            direction = value.Get<Vector2>().normalized;    // 입력받은 값을 Vector2의 형태로 변환해서 이동방향으로 사용한다
            animator.MoveAnimation(direction);  // 애니메이션을 처리하는 메소드에 Vector2값을 넘겨준다
        }
    }
}
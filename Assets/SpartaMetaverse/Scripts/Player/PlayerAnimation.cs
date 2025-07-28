using UnityEngine;

namespace SpartaMetaverse { 

    public class PlayerAnimation : MonoBehaviour
    {
        private Animator animator;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }

        // 이동하는 모션을 처리하는 메소드
        public void MoveAnimation(Vector2 Input)
        {
            if (Input != Vector2.zero)      // 이동입력이 있을때만 처리
            {
                animator.SetFloat("XInput", Input.x);
                animator.SetFloat("YInput", Input.y);
                animator.SetBool("IsMove", true);
            }
            else                            // 이동하지 않을 때는 이동플레그를 끈다
            {
                animator.SetBool("IsMove", false);
            }
        }
    }
}

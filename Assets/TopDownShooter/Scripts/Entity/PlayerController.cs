using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace TopDown
{
    public class PlayerController : BaseController
    {
        private Camera camera;
        private GameManager GM;

        public void Init(GameManager gm)
        {
            this.GM = gm;
            camera = Camera.main;
        }

        protected override void HandleAction()
        {
        }

        public override void Death()
        {
            base.Death();
            GM.GameOver();
        }

        void OnMove(InputValue inputValue)
        {
            movementDirection = inputValue.Get<Vector2>();
            movementDirection = movementDirection.normalized;
        }

        void OnLook(InputValue inputValue)
        {
            Vector2 mousePosition = inputValue.Get<Vector2>();
            Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
            lookDirection = (worldPos - (Vector2)transform.position);

            if (lookDirection.magnitude < 0.9f)
            {
                lookDirection = Vector2.zero;
            }
            else
            {
                lookDirection = lookDirection.normalized;
            }
        }

        void OnFire(InputValue inputValue)
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;
            isAttacking = inputValue.isPressed;
        }
    }
}

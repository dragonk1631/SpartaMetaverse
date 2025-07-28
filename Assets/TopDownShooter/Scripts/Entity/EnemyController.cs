using TMPro;
using UnityEngine;

namespace TopDown
{
    public class EnemyController : BaseController
    {
        private EnemyManager enemyManager;
        private Transform target;

        [SerializeField] private float followRange = 1f;

        public void Init(EnemyManager enemyManager, Transform target)
        {
            this.enemyManager = enemyManager;
            this.target = target;
        }

        protected float DistacnToTaget()
        {
            return Vector3.Distance(transform.position, target.position);
        }

        protected Vector2 DirectionToTarget()
        {
            return (target.position - transform.position).normalized;
        }

        protected override void HandleAction()
        {
            base.HandleAction();

            if (weaponHandler == null || target == null)
            {
                if (!movementDirection.Equals(Vector2.zero)) movementDirection = Vector2.zero;
                return;
            }

            float distance = DistacnToTaget();
            Vector2 direction = DirectionToTarget();

            isAttacking = false;

            if (distance <= followRange)
            {
                lookDirection = direction;

                if (distance < weaponHandler.AttackRange)
                {
                    int layerMaskTarget = weaponHandler.target;
                    RaycastHit2D hit = Physics2D.Raycast(
                        transform.position, direction,
                        weaponHandler.AttackRange * 1.5f,
                        (1 << LayerMask.NameToLayer("Level1")) | layerMaskTarget);

                    if (hit.collider != null && layerMaskTarget == (layerMaskTarget | (1 << hit.collider.gameObject.layer)))
                    {
                        isAttacking = true;
                    }

                    movementDirection = Vector2.zero;
                    return;
                }

                movementDirection = direction;
            }
        }

        public override void Death()
        {
            base.Death();
            GameManager.Instance.monsterKillCount++;
            GameObject gameUI = GameObject.FindGameObjectWithTag("KillText");
            gameUI.GetComponent<TextMeshProUGUI>().text = GameManager.Instance.monsterKillCount.ToString();
            enemyManager.RemoveEnemyOnDeath(this);
        }
    }
}


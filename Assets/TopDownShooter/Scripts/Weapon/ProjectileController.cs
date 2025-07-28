using UnityEngine;

namespace TopDown
{
    public class ProjectileController : MonoBehaviour
    {
        [SerializeField] private LayerMask levelCollisionLayer;

        private RangeWeaponHandler rangeWeaponHandler;

        private float currentDuration;
        private Vector2 direction;
        private bool isReady;
        private Transform pivot;

        private Rigidbody2D rb;
        private SpriteRenderer spriteRenderer;

        public bool fxOnDestroy = true;

        ProjectileManager projectileManager;
        private void Awake()
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            rb = GetComponent<Rigidbody2D>();
            pivot = transform.GetChild(0);
        }

        private void Update()
        {
            if (!isReady) return;

            currentDuration += Time.deltaTime;

            if (currentDuration > rangeWeaponHandler.Duration)
            {
                DestroyProjectile(transform.position, false);
            }

            rb.velocity = direction * rangeWeaponHandler.Speed;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (levelCollisionLayer.value == (levelCollisionLayer.value | (1 << collision.gameObject.layer)))
            {
                DestroyProjectile(collision.ClosestPoint(transform.position) - direction * 2f, fxOnDestroy);
            }
            else if (rangeWeaponHandler.target.value == (rangeWeaponHandler.target.value | (1 << collision.gameObject.layer)))
            {
                ResouceController resouceController = collision.GetComponent<ResouceController>();
                if (resouceController != null)
                {
                    resouceController.ChangeHealth(-rangeWeaponHandler.power);
                    if (rangeWeaponHandler.IsOnKnockBack)
                    {
                        BaseController controller = collision.GetComponent<BaseController>();
                        if (controller != null)
                        {
                            controller.ApplyKnockBack(
                                transform,
                                rangeWeaponHandler.KnockBackPower,
                                rangeWeaponHandler.KnockBackTime
                                );
                        }
                    }
                }

                DestroyProjectile(collision.ClosestPoint(transform.position), fxOnDestroy);
            }
        }

        public void Init(Vector2 direction, RangeWeaponHandler weaponHandler, ProjectileManager pr)
        {
            this.projectileManager = pr;
            rangeWeaponHandler = weaponHandler;

            this.direction = direction;
            currentDuration = 0;
            transform.localScale = Vector3.one * weaponHandler.BulletSize;
            spriteRenderer.color = weaponHandler.ProjectileColor;

            transform.right = this.direction;

            if (direction.x < 0)
                pivot.localRotation = Quaternion.Euler(0, 0, 0);
            else
                pivot.localRotation = Quaternion.Euler(0, 0, 0);

            isReady = true;
        }

        private void DestroyProjectile(Vector3 position, bool createFx)
        {
            if (createFx)
            {
                projectileManager.CreateImpactParticleAtPosition(position, rangeWeaponHandler);
            }
            Destroy(this.gameObject);
        }
    }
}

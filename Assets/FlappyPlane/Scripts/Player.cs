using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FlappyPlane
{
    public class Player : MonoBehaviour
    {
        Animator animator;
        Rigidbody2D rigidBody;

        public float flapForce = 6f;
        public float forwardSpeed = 3f;
        public bool isDead = false;
        float deathCooldown = 0f;

        public bool isFlap = false;

        public bool godMode = false;

        GameManager gm;

        // Start is called before the first frame update
        void Start()
        {
            gm = GameManager.Instance;
            animator = GetComponentInChildren<Animator>();
            rigidBody = GetComponent<Rigidbody2D>();

            if (animator == null)
                Debug.LogError("Not Founded Animator");

            if (GetComponent<Rigidbody2D>() == null)
                Debug.LogError("Not  Founded RigidBody2D");

            isDead = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (isDead)
            {
                if (deathCooldown <= 0)
                {
                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                    {
                        gm.RestartGame();
                    }
                }
                else
                {
                    deathCooldown -= Time.deltaTime;
                }
            }
            else
            {
                // 마우스 0번은 스마트폰의 터치기능
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    isFlap = true;
                }
            }
        }
        private void FixedUpdate()
        {
            if (isDead) return;
            Vector3 velocity = rigidBody.velocity;
            velocity.x = forwardSpeed;
            if (isFlap)
            {
                velocity.y += flapForce;
                isFlap = false;
            }

            rigidBody.velocity = velocity;

            float angle = Mathf.Clamp((rigidBody.velocity.y * 10f), -90, 90);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (godMode) return;

            if (isDead) return;

            isDead = true;
            deathCooldown = 1f;

            animator.SetInteger("IsDie", 1);
            gm.GameOver();
        }
    }
}

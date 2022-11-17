using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyBaseMovement : MonoBehaviour
    {
        [Header("Health and Damage Stats")]
        [SerializeField] float health;
        [SerializeField] float damage = 10;

        public float moveSpeed;
        Rigidbody2D myRigidbody;
        //[SerializeField] GameObject charge;

        // Start is called before the first frame update
        void Start()
        {
            myRigidbody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            //myRigidbody.velocity = new Vector2(moveSpeed, 0f);
        }

        public void FlipEnemyFacing()
        {
            transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), 1f);
            moveSpeed = -moveSpeed;
        }

        public void BopEnemy()
        {
            Destroy(gameObject);
        }

        public void CurseMode()
        {
            //charge.SetActive(true);
            gameObject.layer = LayerMask.NameToLayer("Deadly");
            gameObject.tag = "Deadly";
        }
    }
}

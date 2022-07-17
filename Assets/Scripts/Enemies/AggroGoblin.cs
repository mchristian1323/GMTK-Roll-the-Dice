using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class AggroGoblin : MonoBehaviour
    {
        [SerializeField] Transform playerTarget;
        [SerializeField] Transform currentTarget;
        [SerializeField] float agroRange;
        [SerializeField] float moveSpeed;
        float jumpCounter = 5;
        [SerializeField] float jumpForce = 5;
        [SerializeField] GameObject dice;
        [SerializeField] Transform diceSpawner;
        [SerializeField] float throwkick;

        GameObject theDice;
        Transform tempTransform;

        Rigidbody2D myRigidbody;
        CircleCollider2D myCircleCollider;
 
        // Start is called before the first frame update
        void Start()
        {
            myRigidbody = GetComponent<Rigidbody2D>();
            myCircleCollider = GetComponent<CircleCollider2D>();
            currentTarget = playerTarget;
        }

        // Update is called once per frame
        void Update()
        {
            float distToPlayer = Vector2.Distance(transform.position, currentTarget.position);

            if(distToPlayer < agroRange)
            {
                ChasePlayer();
            }
            else
            {
                StopChasingPlayer();
            }

            DiceChuck();
        }

        private void ChasePlayer()
        {
            if(jumpCounter > 0)
            {
                jumpCounter -= 1 * Time.deltaTime;
            }
            else
            {
                myRigidbody.velocity += new Vector2(0, jumpForce);
                jumpCounter = 5;
            }

            if (myRigidbody.velocity.y == 0)
            {
                if (transform.position.x < currentTarget.position.x)
                {
                    myRigidbody.velocity = new Vector2(moveSpeed, 0);
                    transform.localScale = new Vector2(1, 1);
                }
                else if (transform.position.x > currentTarget.position.x)
                {
                    myRigidbody.velocity = new Vector2(-moveSpeed, 0);
                    transform.localScale = new Vector2(-1, 1);
                }
            }
        }

        private void DiceChuck()
        {
            if(myCircleCollider.IsTouchingLayers(LayerMask.GetMask("Dice")))
            {
                currentTarget.transform.position = diceSpawner.position;
                theDice.GetComponent<Dice.Cursed.CursedDice>().ResetDice();
                theDice.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                theDice.GetComponent<Rigidbody2D>().velocity = new Vector2(throwkick * transform.localScale.x, throwkick);
            }
        }

        private void StopChasingPlayer()
        {
            if(myRigidbody.velocity.x != 0)
            {
                myRigidbody.velocity = Vector2.zero;
            }
        }

        public void SetCurrentTarget(GameObject dice)
        {
            theDice = dice;
            currentTarget = theDice.transform;
        }

        public void SetPlayerTarget()
        {
            currentTarget = playerTarget;
        }

        /*
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Dice")
            {
                Destroy(collision.gameObject);
                GameObject newDice = Instantiate(dice, diceSpawner.position, Quaternion.identity);
                Rigidbody2D thisRigidBody = newDice.GetComponent<Rigidbody2D>();
                thisRigidBody.velocity = new Vector2(throwkick * transform.localScale.x, throwkick);
            }
        }
        */
        public void BopEnemy()
        {
            Destroy(gameObject);
        }
    }
}

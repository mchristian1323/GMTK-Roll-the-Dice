using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceMechanics
{
    public class DiceHolder : MonoBehaviour
    {
        //Serialized
        [SerializeField] GameObject dicePrefab;
        [SerializeField] float diceKick;
        [SerializeField] Transform throwPoint;
        [SerializeField] float throwkick;

        //private
        bool isHoldingDice;

        GameObject yourDice;

        private void Start()
        {
            isHoldingDice = true;
        }

        private void HoldCheck()
        {
            isHoldingDice = !isHoldingDice;

            if(!isHoldingDice)
            {
                //need to set velocity
                yourDice = Instantiate(dicePrefab, transform.position, Quaternion.identity);
                Rigidbody2D thisRigidBody = yourDice.GetComponent<Rigidbody2D>();
                thisRigidBody.AddRelativeForce(new Vector2(0f + Random.Range(-5, 5), 1f) * diceKick);
            }
            else
            {
                //pick up anim
                Debug.Log("dice get");
                Destroy(yourDice);
            }
        }

        //pick up dice
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Dice" && !isHoldingDice)
            {
                HoldCheck();
            }
        }

        //drop dice on damage
        public void DropDice()
        {
            if(isHoldingDice)
            {
                HoldCheck();
            }
        }

        public void ThrowHeldDice()
        {
            if(isHoldingDice)
            {
                isHoldingDice = false;
                yourDice = Instantiate(dicePrefab, throwPoint.position, Quaternion.identity);
                Rigidbody2D thisRigidBody = yourDice.GetComponent<Rigidbody2D>();
                thisRigidBody.velocity = new Vector2(throwkick * transform.localScale.x, throwkick);
            }
        }
    }
}

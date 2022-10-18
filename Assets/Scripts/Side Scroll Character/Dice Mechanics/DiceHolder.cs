using Dice.Cursed;
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

        //public
        public bool isHoldingDice;

        //private
        GameObject yourDice;
        //IEnumerator animationTime;

        private void Start()
        {
            isHoldingDice = true;
        }

        public void HoldCheck()
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
                FindObjectOfType<Audio.AudioManager>().Play("Dice Pickup");
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
                //animationTime = AnimSlowDown();
                //StartCoroutine(animationTime);
                StartCoroutine(AnimSlowDown());
                yourDice = Instantiate(dicePrefab, throwPoint.position, Quaternion.identity);
                Rigidbody2D thisRigidBody = yourDice.GetComponent<Rigidbody2D>();
                //thisRigidBody.velocity = new Vector2(throwkick * transform.localScale.x, throwkick); //old toss
                yourDice.GetComponent<Dice.Cursed.CursedDice>().GraviturgyAvoidance();
                thisRigidBody.velocity = new Vector2(throwkick * transform.localScale.x, 0);
                

                //throw properties-
                    //need sound effect and maybe some burning animss
                    //need to delay movement during animation (yield return)
                    //maybe have float time settled here
                    
                //dice properties-
                    //after a short amount of time the dice will decend
                    //when colliding with an enemy, the dice will pop up and create a random number to store
                    //dice is locked to player so player can tounge grab to retrieve it
                    //if dice drops on the ground, player auto stores a bad number
                
            }
        }

        IEnumerator AnimSlowDown()
        {
            GetComponent<SideScrollControl.PlayerSideScrollControls>().SetVelocityForAnimation(0, false);
            yield return new WaitForSeconds(.5f);
            GetComponent<SideScrollControl.PlayerSideScrollControls>().SetVelocityForAnimation(10, true);
        }

        public bool GetDiceHoldInfo()
        {
            return isHoldingDice;
        }
    }
}

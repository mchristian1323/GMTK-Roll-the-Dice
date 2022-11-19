using Dice.Cursed;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
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
        public bool isHoldingDice; //need to make this a get

        //
        NumberCaster myNumberCaster;

        //private
        GameObject yourDice;
        private bool canThrow;
        //IEnumerator animationTime;

        private void Start()
        {
            isHoldingDice = true;
            canThrow = true;
            myNumberCaster = GetComponent<NumberCaster>();
        }

        public void HoldCheck()
        {
            isHoldingDice = !isHoldingDice;

            if(!isHoldingDice)
            {
                //need to set velocity
                yourDice = Instantiate(dicePrefab, transform.position, Quaternion.identity);
                yourDice.GetComponent<CursedDice>().DropDicePhysics();
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

        public void ThrowHeldDice(float power)
        {
            if(isHoldingDice && canThrow)
            {
                isHoldingDice = false;

                StartCoroutine(AnimSlowDown());

                yourDice = Instantiate(dicePrefab, throwPoint.position, Quaternion.identity);
                Rigidbody2D thisRigidBody = yourDice.GetComponent<Rigidbody2D>();
                yourDice.GetComponent<CursedDice>().SetOwner(this);

                power = Mathf.Round(power);

                if(power < 1)
                {
                    power = 1;
                }

                yourDice.GetComponent<Dice.Cursed.CursedDice>().GraviturgyAvoidance();
                thisRigidBody.velocity = new Vector2((throwkick * power) * transform.localScale.x, 0);

                //throw properties-
                    //need sound effect and maybe some burning animss (burning animes display power level
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

        public void numberStorage(int newNumber)
        {
            myNumberCaster.NumberEnter(newNumber);
        }

        public void PauseMove()
        {
            canThrow = false;
            StartCoroutine(PauseReset());
        }

        IEnumerator PauseReset()
        {
            yield return new WaitForSeconds(1.5f);
            canThrow = true;
        }

        public bool GetDiceHoldInfo()
        {
            return isHoldingDice;
        }
    }
}

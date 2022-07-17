using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dice.Cursed
{
    public class CursedDice : MonoBehaviour
    {
        RandomNumber myRandomNumber;
        Animator myAnimator;
        BoxCollider2D myBoxCollider;

        int rollCount;

        void Start()
        {
            rollCount = 1;
            myAnimator = GetComponent<Animator>();
            myRandomNumber = GetComponent<RandomNumber>();
            StartCoroutine(CollideDelay());
        }

        IEnumerator CollideDelay()
        {
            GetComponent<BoxCollider2D>().enabled = false;
            yield return new WaitForSeconds(.5f);
            GetComponent<BoxCollider2D>().enabled = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Ground" || collision.tag == "Wall")
            {
                FindObjectOfType<Audio.AudioManager>().Play("Dice Bounce");
            }
            if(collision.tag == "Ground" && rollCount > 0)
            {
                rollCount--;
                CursedEffects(myRandomNumber.RandomGenerate());
            }
        }
        
        private void CursedEffects(int numberRolled)
        {
            switch(numberRolled)
            {
                case 1:
                    myAnimator.SetTrigger("1");
                    break;

                case 2:
                    myAnimator.SetTrigger("2");
                    break;

                case 3:
                    myAnimator.SetTrigger("3");
                    break;

                case 4:
                    myAnimator.SetTrigger("4");
                    break;

                case 5:
                    myAnimator.SetTrigger("5");
                    break;

                case 6:
                    myAnimator.SetTrigger("6");
                    break;

                case 7:
                    myAnimator.SetTrigger("7");
                    break;

                case 8:
                    myAnimator.SetTrigger("8");
                    break;

                case 9:
                    myAnimator.SetTrigger("9");
                    break;

                default:
                    myAnimator.SetTrigger("3");
                    Debug.Log("too high");
                    break;
            }
        }

        public void ResetDice()
        {
            myAnimator.ResetTrigger(myRandomNumber.ToString());
            rollCount = 1;
            myAnimator.Play("Roll Dice");
        }
    }
}

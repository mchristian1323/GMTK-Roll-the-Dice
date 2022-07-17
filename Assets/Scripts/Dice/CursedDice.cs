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
                    Debug.Log(numberRolled);
                    break;

                case 2:
                    myAnimator.SetTrigger("2");
                    Debug.Log(numberRolled);
                    break;

                case 3:
                    myAnimator.SetTrigger("3");
                    Debug.Log(numberRolled);
                    break;

                case 4:
                    myAnimator.SetTrigger("4");
                    Debug.Log(numberRolled);
                    break;

                case 5:
                    myAnimator.SetTrigger("5");
                    Debug.Log(numberRolled);
                    break;

                case 6:
                    myAnimator.SetTrigger("6");
                    Debug.Log(numberRolled);
                    break;

                case 7:
                    myAnimator.SetTrigger("7");
                    Debug.Log(numberRolled);
                    break;

                case 8:
                    myAnimator.SetTrigger("8");
                    Debug.Log(numberRolled);
                    break;

                case 9:
                    myAnimator.SetTrigger("9");
                    Debug.Log(numberRolled);
                    break;

                default:
                    myAnimator.SetTrigger("3");
                    Debug.Log(numberRolled);
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

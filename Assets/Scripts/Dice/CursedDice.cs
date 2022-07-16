using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dice.Cursed
{
    public class CursedDice : MonoBehaviour
    {
        RandomNumber myRandomNumber;

        void Start()
        {
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
            if(collision.tag == "Ground")
            {
                CursedEffects(myRandomNumber.RandomGenerate());
            }
        }
        
        private void CursedEffects(int numberRolled)
        {
            switch(numberRolled)
            {
                case 1:
                    Debug.Log(numberRolled);
                    break;

                case 2:
                    Debug.Log(numberRolled);
                    break;

                case 3:
                    Debug.Log(numberRolled);
                    break;

                case 4:
                    Debug.Log(numberRolled);
                    break;

                case 5:
                    Debug.Log(numberRolled);
                    break;

                case 6:
                    Debug.Log(numberRolled);
                    break;

                default:
                    Debug.Log(numberRolled);
                    break;
            }
        }
    }
}

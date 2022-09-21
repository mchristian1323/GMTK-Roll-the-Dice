using System.Collections;
using UnityEngine;

namespace Dice.Cursed
{
    public class CursedDice : MonoBehaviour
    {
        RandomNumber myRandomNumber;
        Animator myAnimator;
        BoxCollider2D myBoxCollider;

        [Header("Curses")]
        [SerializeField] GameObject monBomb;
        [SerializeField] GameObject airBlast;
        [SerializeField] GameObject deadlyAura;
        [SerializeField] GameObject bigSlime;

        [Header("Results")]
        [SerializeField] Sprite one;
        [SerializeField] Sprite two;
        [SerializeField] Sprite three;
        [SerializeField] Sprite four;
        [SerializeField] Sprite five;
        [SerializeField] Sprite six;

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
            if(collision.tag == "Deadly")
            {
                //BreakDice();
            }
        }
        
        private void CursedEffects(int numberRolled)
        {
            switch(numberRolled)
            {
                case 1:
                    myAnimator.SetTrigger("1");
                    ExplosionOfEnemies();
                    //GameObject.Find("Player").GetComponent<SideScrollControl.SideScrollControls >().DisplayDice(one);
                    break;

                case 2:
                    myAnimator.SetTrigger("2");
                    //GameObject.Find("Player").GetComponent<SideScrollControl.SideScrollControls>().DisplayDice(two);
                    AirBlast();
                    break;

                case 3:
                    myAnimator.SetTrigger("3");
                    //GameObject.Find("Player").GetComponent<SideScrollControl.SideScrollControls>().DisplayDice(three);
                    DeadlyEnemies();
                    break;

                case 4:
                    myAnimator.SetTrigger("4");
                    //GameObject.Find("Player").GetComponent<SideScrollControl.SideScrollControls>().DisplayDice(four);
                    OverChargeMoves();
                    break;

                case 5:
                    myAnimator.SetTrigger("5");
                    //GameObject.Find("Player").GetComponent<SideScrollControl.SideScrollControls>().DisplayDice(five);
                    BigSlime();
                    break;

                case 6:
                    myAnimator.SetTrigger("6");
                    //GameObject.Find("Player").GetComponent<SideScrollControl.SideScrollControls>().DisplayDice(six);
                    Gun();
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

        public void BreakDice()
        {
            FindObjectOfType<Audio.AudioManager>().Play("Big Damage");
            FindObjectOfType<SideScrollControl.SideScrollControls>().BreakBernie();
            GetComponent<SpriteRenderer>().enabled = false;
        }

        public void ResetDice()
        {
            StartCoroutine(CollideDelay());
            myAnimator.ResetTrigger(myRandomNumber.ToString());
            rollCount = 1;
            myAnimator.Play("Roll Dice");
        }

        private void ExplosionOfEnemies()
        {
            /*
            for(int i = 0; i < 10; i++)
            {
                GameObject mon = Instantiate(monBomb, transform.position, Quaternion.identity);
                mon.GetComponent<Enemy.GoblinBombDelay>().DelayGoblin();
                Rigidbody2D rigidbody2D = mon.GetComponent<Rigidbody2D>();
                rigidbody2D.velocity += new Vector2(Random.Range(-5, 5), Random.Range(6, 20));
            }*/
        }

        private void AirBlast()
        {
            //Instantiate(airBlast, transform.position, Quaternion.identity);
        }

        private void DeadlyEnemies()
        {
            //Instantiate(deadlyAura, transform.position, Quaternion.identity);
        }

        private void OverChargeMoves()
        {
            //GameObject.Find("Player").GetComponent<SideScrollControl.SideScrollControls>().PowerMove();
        }

        private void FireBomb()
        {
            //Shoot out explosives that kill what they touch
        }

        private void Gun()
        {
            //GameObject.Find("Player").GetComponent<SideScrollControl.SideScrollControls>().Arm();
        }

        private void BulletHell()
        {
            //shoot random magic shots from the side of the camera
        }

        private void EnemyChageGravity()
        {
            //
        }

        private void BigSlime()
        {
            //Instantiate(bigSlime, transform.position, Quaternion.identity);
            //drop the big slime on top of the dice
        }
    }
}

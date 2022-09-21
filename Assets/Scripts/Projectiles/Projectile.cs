using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Projectile
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] bool player;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            FindObjectOfType<Audio.AudioManager>().Play("Magic Impact");
            StartCoroutine(Destruction());
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Soft Enemy" || collision.tag == "Hard Enemy")
            {
                collision.GetComponent<Enemy.EnemyBaseMovement>().BopEnemy();
            }

            if (collision.tag == "Goblin")
            {
                collision.GetComponent<Enemy.AggroGoblin>().BopEnemy();
            }

            if(collision.tag == "Dice")
            {
                collision.GetComponent<Dice.Cursed.CursedDice>().BreakDice();
            }
        }

        IEnumerator Destruction()
        {
            yield return new WaitForSeconds(.3f);
            Destroy(gameObject);
        }
    }
}

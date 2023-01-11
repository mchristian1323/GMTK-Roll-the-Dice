using System.Collections;
using UnityEngine;

namespace Projectile
{
    public class Projectile : MonoBehaviour
    {
        float damage;
        bool playerSide;

        public void SetPhysics(float speed, float direction, float damage, bool playerSide)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed * direction, 0);
            transform.localScale = new Vector2(Mathf.Sign(direction), 1f);
            this.damage = damage;
            this.playerSide = playerSide;
            //physics needs: up and down
            //damage
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            FindObjectOfType<Audio.AudioManager>().Play("Magic Impact");
            if(playerSide)
            {
                if(collision.gameObject.tag == "Enemy")
                {
                    //do damage
                }
            }
            else
            {
                if(collision.gameObject.tag == "Player")
                {
                    //do damage
                }
            }
            StartCoroutine(Destruction());
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            /*
            if (collision.tag == "Soft Enemy" || collision.tag == "Hard Enemy")
            {
                collision.GetComponent<Enemy.EnemyBaseMovement>().BopEnemy();
            }
            */
        }

        IEnumerator Destruction()
        {
            yield return new WaitForSeconds(.3f);
            Destroy(gameObject);
        }
    }
}

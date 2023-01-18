using System.Collections;
using UnityEngine;
using UnityEngine.Windows.Speech;
using Enemy;
using SideScrollControl;

namespace Projectile
{
    public class Projectile : MonoBehaviour
    {
        float damage;
        bool playerSide;
        Vector3 shootDir;
        float speed;

        public void SetPhysics(float speed, float direction, Vector3 shootDir, float damage, bool playerSide)
        {
            transform.localScale = new Vector2(Mathf.Sign(direction), 1f);

            //GetComponent<Rigidbody2D>().velocity = new Vector2(speed * direction, 0);
            this.shootDir = shootDir;
            this.speed = speed;

            this.damage = damage;
            this.playerSide = playerSide;
            //physics needs: up and down
            //damage
        }

        private void Update()
        {
            transform.position += shootDir * speed * Time.deltaTime;
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
                    collision.gameObject.GetComponent<EnemyStatus>().TakeDamage(damage);
                }
            }
            else
            {
                if(collision.gameObject.tag == "Player")
                {
                    //do damage
                    collision.gameObject.GetComponent<SideScrollStatus>().TakeDamage(damage);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Projectile
{
    public class DeadlyAura : MonoBehaviour
    {
        void Start()
        {
            GetComponent<CircleCollider2D>().enabled = false;
            StartCoroutine(CurseBomb());
        }

        IEnumerator CurseBomb()
        {
            yield return new WaitForSeconds(1f);
            GetComponent<CircleCollider2D>().enabled = true;
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if(collision.tag == "Soft Enemy" || collision.tag == "Hard Enemy")
            {
                collision.GetComponent<Enemy.EnemyBaseMovement>().CurseMode();
            }

            if(collision.tag == "Goblin")
            {
                collision.GetComponent<Enemy.AggroGoblin>().CurseMode();
            }
        }
    }
}

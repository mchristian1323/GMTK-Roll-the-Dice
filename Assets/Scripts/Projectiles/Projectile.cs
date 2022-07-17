using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Projectile
{
    public class Projectile : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(Destruction());
        }

        IEnumerator Destruction()
        {
            yield return new WaitForSeconds(.3f);
            Destroy(gameObject);
        }
    }
}

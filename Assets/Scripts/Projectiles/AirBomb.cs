using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Projectile
{
    public class AirBomb : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            GetComponent<CircleCollider2D>().enabled = false;
            StartCoroutine(BlastBomb());
        }

        IEnumerator BlastBomb()
        {
            yield return new WaitForSeconds(1f);
            GetComponent<CircleCollider2D>().enabled = true;
            yield return new WaitForSeconds(.5f);
            Destroy(gameObject);
        }
    }

}
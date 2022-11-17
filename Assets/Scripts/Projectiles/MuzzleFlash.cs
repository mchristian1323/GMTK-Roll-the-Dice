using System.Collections;
using UnityEngine;

namespace Projectile
{
    public class MuzzleFlash : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Flash());
        }

        IEnumerator Flash()
        {
            yield return new WaitForSeconds(.5f);
            Destroy(gameObject);
        }
    }
}

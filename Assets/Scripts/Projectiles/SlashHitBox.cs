using System.Collections;
using UnityEngine;

namespace Projectile
{
    public class SlashHitBox : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Destruction());
        }

        IEnumerator Destruction()
        {
            yield return new WaitForSeconds(.25f);
            Destroy(gameObject);
        }
    }
}

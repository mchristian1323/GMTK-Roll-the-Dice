using System.Collections;
using UnityEngine;

namespace Projectile
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] GameObject bullet;
        [SerializeField] Transform businessEnd;
        [SerializeField] Transform directionPoint;
        [SerializeField] float bulletForce;

        // Start is called before the first frame update
        public void StartShooting()
        {
            StartCoroutine(BigIron());
        }

        IEnumerator BigIron()
        {
            GetComponent<SpriteRenderer>().enabled = true;
            for(int i = 0; i < 6; i++)
            {
                FindObjectOfType<Audio.AudioManager>().Play("Gun");
                GameObject shell = Instantiate(bullet, businessEnd.position, Quaternion.identity);
                //Vector2 direction = businessEnd.position - directionPoint.position;

                Rigidbody2D bulletRB = shell.GetComponent<Rigidbody2D>();
                bulletRB.velocity = (Vector2.right * bulletForce) * transform.parent.localScale;

                yield return new WaitForSeconds(1f);
            }

            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}

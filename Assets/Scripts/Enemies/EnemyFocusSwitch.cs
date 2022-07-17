using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyFocusSwitch : MonoBehaviour
    {
        [SerializeField] EnemyBaseMovement myEnemyBaseMovement;
        [SerializeField] GameObject myParascope;
        [SerializeField] Transform target;
        [SerializeField] Transform partToRotate;
        [SerializeField] GameObject projectile;
        [SerializeField] Transform barrel;
        [SerializeField] float bulletForce = 1;
        [SerializeField] Animator myAnimator;
        [SerializeField] float counter = 2;

        // Start is called before the first frame update
        void Awake()
        {
            //myEnemyBaseMovement = GetComponent<EnemyBaseMovement>();
            //myCircleCollider = GetComponent<CircleCollider2D>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            //PlayerDetection();
            if(target != null)
            {
                FollowTarget();
                ShootTarget();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Player")
            {
                target = collision.transform;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                target = null;
                myAnimator.SetBool("Shoot", false);
            }
        }

        private void FollowTarget()
        {
            Vector3 direction = target.position - partToRotate.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            partToRotate.rotation = Quaternion.Euler(0, 0, angle);
        }

        private void ShootTarget()
        {

            if(counter > 0)
            {
                counter -= 1 * Time.deltaTime;
            }
            else
            {
                StartCoroutine(SetAnim());
                Vector2 direction = target.position - partToRotate.position;
                GameObject bullet = Instantiate(projectile, barrel.position, barrel.rotation);
                Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
                //bulletRB.velocity += new Vector2(bulletForce, 0);
                bulletRB.velocity = direction * bulletForce;
                counter = 2;
            }
        }

        IEnumerator SetAnim()
        {
            myAnimator.SetBool("Shoot", true);
            yield return new WaitForSeconds(.25f);
            myAnimator.SetBool("Shoot", false);
        }
    }
}

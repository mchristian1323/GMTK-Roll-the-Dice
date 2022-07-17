using UnityEngine;

namespace Projectile
{
    public class ProjectileRotate : MonoBehaviour
    {
        [SerializeField] float rotationSpeed;

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
    }
}

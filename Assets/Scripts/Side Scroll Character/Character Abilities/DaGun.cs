using UnityEngine;

namespace SideScrollControl.CharacterAbilities.Gun
{
    public class DaGun : MonoBehaviour
    {
        //need position and direction
        [SerializeField] Transform businessEnd;
        [SerializeField] Transform businessDirection;
        bool spread = false;

        public void Fire(GameObject bullet, float speed, float direction, float damage, GameObject flash)
        {
            GameObject shot = Instantiate(bullet, businessEnd.position, businessEnd.rotation);
            Vector3 shootDir = businessDirection.position - businessEnd.position;
            shot.GetComponent<Projectile.Projectile>().SetPhysics(speed, direction, shootDir, damage, true);
            GameObject muzzleFlash = Instantiate(flash, businessEnd.position, Quaternion.identity);

            if(spread) //in order for this to work, bullet must accomodate for angle direction
            {
                GameObject shot2 = Instantiate(bullet, businessEnd.position, Quaternion.identity * Quaternion.Euler(0, 0, 35f));
                shot2.GetComponent<Projectile.Projectile>().SetPhysics(speed, direction, shootDir, damage, true);
                //GameObject muzzleFlash2 = Instantiate(flash, businessEnd.position, Quaternion.identity);

                GameObject shot3 = Instantiate(bullet, businessEnd.position, Quaternion.identity * Quaternion.Euler(0, 0, -35f));
                shot3.GetComponent<Projectile.Projectile>().SetPhysics(speed, direction, shootDir, damage, true);
                //GameObject muzzleFlash3 = Instantiate(flash, businessEnd.position, Quaternion.identity);
            }
        }
    }
}
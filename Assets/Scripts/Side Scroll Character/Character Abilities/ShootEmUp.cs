using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SideScrollControl.CharacterAbilities
{
    public class ShootEmUp : MonoBehaviour
    {
        //Serialized
        [Header("Bullet Prefabs")]
        [SerializeField] GameObject Bullet;

        [Header("Gun Anim")]
        [SerializeField]SpriteRenderer gunSpriteRenderer;

        [Header("Bullet Physics")]
        [SerializeField] int baseAmmoCount = 6;
        [SerializeField] int baseDamage = 10;
        [SerializeField] float baseShotSpeed = 10f;

        [Header("Gun Physics")]
        [SerializeField] float baseReloadTime;
        [SerializeField] Transform businessEnd;

        //Initialized
        PlayerInput myPlayerInput;

        //private
        int chamberAmmo;
        int chamberDamage;
        float chamberShotSpeed;

        bool canShoot;
        float reloadBuffer;

        float direction;

        //have a bool that changes the launch point depending on if the player is holding up or down

        // Start is called before the first frame update
        void Awake()
        {
            myPlayerInput = GetComponent<PlayerInput>();

            //controller actions
            myPlayerInput.actions["Shoot"].started += OnShoot;
        }

        void Start()
        {
            chamberAmmo = baseAmmoCount;
            chamberDamage = baseDamage;
            chamberShotSpeed = baseShotSpeed;
            canShoot = true;
            reloadBuffer = baseReloadTime;
        }

        // Update is called once per frame
        void Update()
        {
            direction = gameObject.transform.localScale.x;

            if(chamberAmmo < baseAmmoCount)
            {
                TimedReload();
            }
        }

        //controller
        public void OnShoot(InputAction.CallbackContext context)
        {
            //if can shoot and has ammo
            if(canShoot)
            {
                if (chamberAmmo > 0)
                {
                    //activate animation -> consider shot stance cycle
                    gunSpriteRenderer.enabled = true; //this will change
                    //fire gun and play anim
                    GameObject shot = Instantiate(Bullet, businessEnd.position, Quaternion.identity);
                    shot.GetComponent<Projectile.Projectile>().SetPhysics(chamberShotSpeed, direction);
                    //play sound

                    //reduce ammo
                    chamberAmmo--;

                    //reset reload timer
                    reloadBuffer = baseReloadTime;
                }
            }
            //consider the ability to change shooting styles
            //possibly have if/switch statements that go through different options under can shoot
            //beyond change of ammo count and bullet physics
        }

        //private
        private void TimedReload()
        {
            if(reloadBuffer < baseReloadTime - .5f)
            {
                gunSpriteRenderer.enabled = false; //this will changes
            }

            //reloadbuffer += time.DeltaTime;
            if(reloadBuffer > 0)
            {
                reloadBuffer -= Time.deltaTime;
            }
            else
            {
                reloadBuffer = baseReloadTime;
                chamberAmmo++;
            }

            UnityEngine.Debug.Log(chamberAmmo + " " + reloadBuffer);

            //idea two
            //if reload is pressed, add a bullet every .25 seconds until full
        }

        //getters and setters
        public int GetChamgerAmmo()
        {
            return chamberAmmo;
        }
    }
}

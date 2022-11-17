using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace SideScrollControl.CharacterAbilities
{
    public class ShootEmUp : MonoBehaviour
    {
        //Serialized
        [Header("Bullet Prefabs")]
        [SerializeField] GameObject Bullet;

        [Header("Gun Anim")]
        [SerializeField] SpriteRenderer gunSpriteRenderer;

        [Header("Bullet Physics")]
        [SerializeField] int baseAmmoCount = 6; //how much
        [SerializeField] int baseDamage = 10; //how hard
        [SerializeField] float baseShotSpeed = 10f; //how fast
        //how far
        //how big
        //color
        //sprite

        [Header("Gun Physics")]
        [SerializeField] float baseReloadTime;
        [SerializeField] Transform businessEnd;
        [SerializeField] GameObject muzzleFlash;

        //Initialized
        PlayerInput myPlayerInput;

        //private
        int chamberAmmo;
        int chamberDamage;
        float chamberShotSpeed;

        bool canShoot;
        float reloadBuffer;

        float direction;

        //events
        public event EventHandler OnBulletInteraction;

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
                    GameObject flash = Instantiate(muzzleFlash, businessEnd.position, Quaternion.identity);
                    //play sound

                    //reduce ammo
                    chamberAmmo--;

                    //reset reload timer
                    reloadBuffer = baseReloadTime;

                    //update animation
                    OnBulletInteraction?.Invoke(this, EventArgs.Empty);
                }
            }
            //consider the ability to change shooting styles
            //possibly have if/switch statements that go through different options under can shoot
            //beyond change of ammo count and bullet physics
        }

        public void PauseMove()
        {
            canShoot = false;
            StartCoroutine(PauseReset());
        }

        IEnumerator PauseReset()
        {
            yield return new WaitForSeconds(1.5f);
            canShoot = true;
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
                OnBulletInteraction?.Invoke(this, EventArgs.Empty);
            }

            //idea two
            //if reload is pressed, add a bullet every .25 seconds until full
        }

        //getters and setters
        public int GetChamberAmmo()
        {
            return chamberAmmo;
        }

        //possibly have a second variable that gets effected so that the bases never change
        public void SetBaseAmmo(int newAmmoCount)
        {
            baseAmmoCount = newAmmoCount;
        }

        public void SetDamage(int newDamage)
        {
            baseDamage = newDamage;
        }

        public void SetSpeed(float newSpeed)
        {
            baseShotSpeed = newSpeed;
        }
    }
}

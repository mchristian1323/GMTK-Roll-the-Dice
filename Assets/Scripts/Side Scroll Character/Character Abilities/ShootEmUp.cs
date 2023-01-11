using SideScrollControl.CharacterAbilities.Gun;
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
        [SerializeField] GameObject bullet;

        [Header("Bullet Physics")]
        [SerializeField] int baseAmmoCount = 6; //how much
        [SerializeField] float baseDamage = 10; //how hard
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
        DaGun[] guns;
        Animator myAnimator;

        //private
        int chamberAmmo;
        int gunCount = 1;
        int shotStanceCounter = 1;
        float chamberDamage;
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
            myAnimator = GetComponent<Animator>();

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
            guns = transform.GetComponentsInChildren<DaGun>();
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
                    for(int i = 0; i < gunCount; i++)
                    {
                        guns[i].Fire(bullet, chamberShotSpeed, direction, chamberDamage, muzzleFlash);
                    }
                    //reduce ammo
                    chamberAmmo--;

                    //reset reload timer
                    reloadBuffer = baseReloadTime;

                    //update animation
                    OnBulletInteraction?.Invoke(this, EventArgs.Empty);

                    myAnimator.SetInteger("GunStance", shotStanceCounter);
                    myAnimator.SetTrigger("ShootGun");
                    shotStanceCounter++;
                    if (shotStanceCounter > 4)
                        shotStanceCounter = 1;
                }
            }
            //consider the ability to change shooting styles
            //possibly have if/switch statements that go through different options under can shoot
            //beyond change of ammo count and bullet physics

            //idea 2
                //make the shooting its own script and have an array of guns to work with.
                //make the ammo type something made and changed from here
                //have each one of them have a spread shot option

            //might need to make the reload like time crisis
                //have the "Damage level" Be something that evolves more with everything. more ammo, bigger shot, more damage, ect.
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

        public void ChangeAmmo(GameObject newAmmo)
        {
            //apply new ammo and then start a timer to revert back to original
        }

        public void MultiShot()
        {
            //add in more projectiles to the gun blast
        }

        public void CastSpell(GameObject projectile, int amount)
        {
            //need to freeze bernadetta when she casts

            for(int i = 0; i < amount; i++)
            {
                Instantiate(projectile, businessEnd.position, Quaternion.identity); //need to change business end
            }
        }

        public void CancelGunEffects()
        {
            //turn off the gun effects on reset
        }

        //private
        private void TimedReload()
        {
            if(reloadBuffer < baseReloadTime - .5f)
            {
                //gunSpriteRenderer.enabled = false; //this will changes
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
            chamberDamage += newDamage;
        }

        public void SetSpeed(float newSpeed)
        {
            baseShotSpeed = newSpeed;
        }

        //activators
        public void ActivateMultiShot()
        {
            gunCount = 3;
            StartCoroutine(MultishotCountdown());
        }

        IEnumerator MultishotCountdown()
        {
            yield return new WaitForSeconds(10f);
            gunCount = 1;

        }
    }
}

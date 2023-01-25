using DiceMechanics;
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
        [SerializeField] float gunKnockBackForce = 5f;

        //Initialized
        PlayerInput myPlayerInput;
        DaGun[] guns;
        Animator myAnimator;
        Rigidbody2D myRigidBody;

        //private
        int gunCount = 1;
        int shotStanceCounter = 1;
        float chamberDamage;
        float chamberShotSpeed;

        bool canShoot;

        float direction;

        //events
        //public event EventHandler OnBulletInteraction;

        //have a bool that changes the launch point depending on if the player is holding up or down

        // Start is called before the first frame update
        void Awake()
        {
            myPlayerInput = GetComponent<PlayerInput>();
            myAnimator = GetComponent<Animator>();
            myRigidBody = GetComponent<Rigidbody2D>();

            //controller actions
            myPlayerInput.actions["Shoot"].started += OnShoot;
        }

        void Start()
        {
            chamberDamage = baseDamage;
            chamberShotSpeed = baseShotSpeed;
            canShoot = true;
            guns = transform.GetComponentsInChildren<DaGun>();
        }

        // Update is called once per frame
        void Update()
        {
            direction = gameObject.transform.localScale.x;
        }

        //controller
        public void OnShoot(InputAction.CallbackContext context)
        {
            //if can shoot and has ammo
            if(canShoot)
            {
                //have if in air and if pointing up or down
                    //if down, then shoot down business end
                    // bump the rigid body so you fall slower
                //gun 4 is down
                if(GetComponent<PlayerSideScrollControls>().GetAimingDownData())
                {
                    guns[3].Fire(bullet, chamberShotSpeed, direction, chamberDamage, muzzleFlash);
                    myRigidBody.velocity += new Vector2(0, gunKnockBackForce); //not consistent?
                    //right direction
                    //speed
                    //push back
                    //anim
                } //gun 5 is up
                else if(GetComponent<PlayerSideScrollControls>().GetAimingUpData())
                {
                    guns[4].Fire(bullet, chamberShotSpeed, direction, chamberDamage, muzzleFlash);
                    myRigidBody.velocity += new Vector2(0, -gunKnockBackForce); //not consistent?
                }
                else
                {
                    for (int i = 0; i < gunCount; i++)
                    {
                        guns[i].Fire(bullet, chamberShotSpeed, direction, chamberDamage, muzzleFlash);
                    }

                    //update animation
                    //OnBulletInteraction?.Invoke(this, EventArgs.Empty);

                    myAnimator.SetInteger("GunStance", shotStanceCounter);
                    myAnimator.SetTrigger("ShootGun");
                    //GetComponentInChildren<HeldDice>().DiceGunSwitching();
                    shotStanceCounter++;
                    if (shotStanceCounter > 4)
                        shotStanceCounter = 1;
                }
                //if up then shoot up business end
                //bump rigid body to fall faster
                PauseMove(.1f);
            }
        }

        public void PauseMove(float x)
        {
            canShoot = false;
            StartCoroutine(PauseReset( x));
        }

        IEnumerator PauseReset(float x)
        {
            yield return new WaitForSeconds(x);
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
        //getters and setters
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

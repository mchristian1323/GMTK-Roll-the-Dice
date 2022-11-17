using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DiceMechanics;
using SideScrollControl.CharacterAbilities;

namespace SideScrollControl
{
    public class SideScrollStatus : MonoBehaviour
    {
        [Header("Health")]
        [SerializeField] float health = 100;
        [Header("Knockback")]
        [SerializeField] float damageVerticalKick;
        [SerializeField] float damageHorizontalKick;

        //Initializers
        BoxCollider2D myBoxCollider;
        Rigidbody2D myRigidbody;
        DiceHolder myDiceHolder;
        PlayerSideScrollControls mySideScrollControls;
        Animator myAnimator;

        bool landed;

        // Start is called before the first frame update
        void Start()
        {
            myBoxCollider = GetComponent<BoxCollider2D>();
            myRigidbody = GetComponent<Rigidbody2D>();
            myDiceHolder = GetComponent<DiceHolder>();
            mySideScrollControls = GetComponent<PlayerSideScrollControls>();
            myAnimator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            DamageCheck();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.collider.tag == "Enemy")
            {
                health -= collision.gameObject.GetComponent<Enemy.EnemyStatus>().GetEnemyDamage();
            }
        }

        private void DamageCheck()
        {
            if (myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Hazard")))
            {
                //audio
                FindObjectOfType<Audio.AudioManager>().Play("Damage");
                //animation
                myAnimator.SetBool("Damage", true);
                //mechanical
                myDiceHolder.DropDice();
                    //possibly move this to a seperate script that has authority over the other scripts
                mySideScrollControls.PauseMove();
                GetComponent<ShootEmUp>().PauseMove();
                //movement
                myRigidbody.velocity = Vector2.zero;
                myRigidbody.velocity = new Vector2(damageHorizontalKick * transform.localScale.x, damageVerticalKick);
                //take damage

                mySideScrollControls.ResetIdleTime();
                //release
                landed = true;
            }

            if(myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) && landed)
            {
                StartCoroutine(DamageOff());
                landed = false;
            }
        }

        IEnumerator DamageOff()
        {
            yield return new WaitForSeconds(.5f);
            myAnimator.SetBool("Damage", false);
        }
    }
}
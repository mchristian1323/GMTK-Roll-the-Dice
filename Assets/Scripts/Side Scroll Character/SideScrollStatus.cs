using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DiceMechanics;

namespace SideScrollControl
{
    public class SideScrollStatus : MonoBehaviour
    {
        [SerializeField] float damageVerticalKick;
        [SerializeField] float damageHorizontalKick;

        //Initializers
        BoxCollider2D myBoxCollider;
        Rigidbody2D myRigidbody;
        DiceHolder myDiceHolder;
        PlayerSideScrollControls mySideScrollControls;
        Animator myAnimator;

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

        private void DamageCheck()
        {
            if (myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Hazard")))
            {
                FindObjectOfType<Audio.AudioManager>().Play("Damage");
                myAnimator.SetBool("Damage", true);
                myDiceHolder.DropDice();
                mySideScrollControls.PauseMove();
                myRigidbody.velocity = Vector2.zero;
                myRigidbody.velocity = new Vector2(damageHorizontalKick + transform.localScale.x, damageVerticalKick);
                StartCoroutine(DamageOff());
            }

            IEnumerator DamageOff()
            {
                yield return new WaitForSeconds(.5f);
                myAnimator.SetBool("Damage", false);
            }

            if(myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Deadly")))
            {
                //mySideScrollControls.BreakBernie();
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceMechanics
{
    public class HeldDice : MonoBehaviour
    {
        [SerializeField] GameObject hands;
        [SerializeField] GameObject dice;
        [SerializeField] GameObject diceChargeAnim;

        Animator diceAnimator;
        DiceHolder myDiceHolder;
        SideScrollControl.PlayerSideScrollControls mySideScrollControls;
        bool haveHands = true;

        // Start is called before the first frame update
        void Start()
        {
            diceAnimator = dice.gameObject.GetComponent<Animator>();
            myDiceHolder = GetComponentInParent<DiceHolder>();
            mySideScrollControls = GetComponentInParent<SideScrollControl.PlayerSideScrollControls>();
        }

        // Update is called once per frame
        void Update()
        {
            VisableHands();
            MovingHands();
            DiceChargeThrow();
        }

        private void VisableHands()
        {
            if(!myDiceHolder.isHoldingDice || mySideScrollControls.GetDiceThrowActive() || mySideScrollControls.GetIdleStatusAnim())
            {
                hands.SetActive(false);
                dice.SetActive(false);
                haveHands = false;
            }
            else
            {
                hands.SetActive(true);
                dice.SetActive(true);
                haveHands = true;
            }
        }

        private void MovingHands()
        {
            if (mySideScrollControls.GetMoveStatusAnim() && haveHands)
            {
                diceAnimator.SetBool("Moving", true);
            }
            else
            {
                diceAnimator.SetBool("Moving", false);
            }
        }

        private void DiceChargeThrow()
        {
            //add another animation and speed it up depending on the power of the dice
            if(mySideScrollControls.GetDiceThrowActive())
            {
                diceChargeAnim.SetActive(true);
                diceChargeAnim.GetComponent<Animator>().speed = Mathf.Round(mySideScrollControls.GetDicePowerLevel());
            }
            else
            {
                diceChargeAnim.SetActive(false);
            }
        }

        public void DiceGunSwitching()
        {
            //when gun is shootng move dice to proper locations
            //diceAnimator.SetTrigger("GunStance");
            //make hand disapear
        }
    }
}

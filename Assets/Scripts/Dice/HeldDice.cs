using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceMechanics
{
    public class HeldDice : MonoBehaviour
    {
        [SerializeField] GameObject hands;
        [SerializeField] GameObject dice;

        Animator diceAnimator;
        DiceHolder myDiceHolder;
        SideScrollControl.SideScrollControls mySideScrollControls;
        bool haveHands = true;

        // Start is called before the first frame update
        void Start()
        {
            diceAnimator = dice.gameObject.GetComponent<Animator>();
            myDiceHolder = GetComponentInParent<DiceHolder>();
            mySideScrollControls = GetComponentInParent<SideScrollControl.SideScrollControls>();
        }

        // Update is called once per frame
        void Update()
        {
            VisableHands();
            MovingHands();
        }

        private void VisableHands()
        {
            if(!myDiceHolder.isHoldingDice)
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
            if (mySideScrollControls.isMoving && haveHands)
            {
                diceAnimator.SetBool("Moving", true);
            }
            else
            {
                diceAnimator.SetBool("Moving", false);
            }
        }
    }
}

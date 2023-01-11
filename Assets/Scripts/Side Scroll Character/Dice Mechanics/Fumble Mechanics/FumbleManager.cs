using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SideScrollControl;

namespace DiceMechanics.FumbleMechanics
{
    public class FumbleManager : MonoBehaviour
    {
        [SerializeField] int fumbles;

        const int regularMaxFumbles = 3;

        SideScrollStatus mySideScrollStatus;

        //const int lowMaxFumbles = 1;
        //const int highMaxFumbles = 5;
        //a way to switch max's?

        //this goes on player
        //everytime the dice drops, this script gets activated
        //upon activation it will do 2 things.
        //one: it will reset all soft abilities (anything timed, damage up, extra hp, ect)
        //the it will add a point to the fumble counter
        //two: it will then check the fumble counter and compare it to the dice limit (3) if it is equal (or somehow greater)
        //then it will perform a hard reset (turn off all active abilities and dump all numbers) then apply a dark effect by random
        //need number two to pause the game and roll an animation for the dark effect

        private void Start()
        {
            mySideScrollStatus = GetComponent<SideScrollStatus>();
        }

        //public
        public void ActivateFumble()
        {
            fumbles++;
            //update ui
            SoftReset();

            if(fumbles >= regularMaxFumbles)
            {
                HardReset();
            }
            
        }

        //private
        private void SoftReset()
        {
            //access status and turn off all soft effects
            mySideScrollStatus.SoftReset();
        }

        private void HardReset()
        {
            //access status and turn off all effects and dump all numbers
            mySideScrollStatus.HardReset();

            fumbles = 0;
            //update ui
        }
    }
}

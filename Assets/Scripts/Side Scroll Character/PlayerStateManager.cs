using DiceMechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SideScrollControl
{
    public class PlayerStateManager : MonoBehaviour
    {
        PlayerSideScrollControls myPlayerSideScrollControl;
        DiceHolder myDiceThrower;

        // Start is called before the first frame update
        void Start()
        {
            myPlayerSideScrollControl = GetComponent<PlayerSideScrollControls>();
            myDiceThrower = GetComponent<DiceHolder>();
        }

        public void PauseMovement()
        {
            myPlayerSideScrollControl.SetMovementState(false);
        }

        public void ResumeMovement()
        {
            myPlayerSideScrollControl.SetMovementState(true);
        }

        public void PauseDiceThrow()
        {

        }

        public void ResumeDiceThrow()
        {

        }
    }

}
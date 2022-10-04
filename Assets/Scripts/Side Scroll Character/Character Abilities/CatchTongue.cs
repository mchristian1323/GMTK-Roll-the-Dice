using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DiceMechanics;

namespace SideScrollControl.CharacterAbilities
{
    public class CatchTongue : MonoBehaviour
    {
        [Header("Objects")]
        [SerializeField] GameObject tongueObject;
        //[SerializeField] GameObject berny; //for renderer

        [Header("Tongue Stats")]
        [SerializeField] float tongueSpeed = 10f;

        //serialized
        PlayerInput myPlayerInput;
        TongueRenderer myTongueRenderer;
        DiceHolder myDiceHolder;

        private void Awake()
        {
            myPlayerInput = GetComponent<PlayerInput>();

            myPlayerInput.actions["Tongue"].started += TongueActivate;
        }

        private void Start()
        {
            myTongueRenderer = GetComponentInChildren<TongueRenderer>();
            myDiceHolder = GetComponent<DiceHolder>();
            
        }

        private void Update()
        {
            if(!myDiceHolder.GetDiceHoldInfo())
            {
                TongueAimRotation();
            }
        }

        public void TongueActivate(InputAction.CallbackContext context)
        {
            //constantly rotate to look at dice.
            //when activated start the tongue line and delay activation time
            //once active see if dice is in hitbox and if so move it back with tongue

            if(!myDiceHolder.GetDiceHoldInfo()) //switch to false
            {
                myTongueRenderer.RenderTongue(tongueSpeed, tongueObject.transform.position);
            }//need camera point position for positions
        }
        
        private void TongueAimRotation()
        {

        }
        //rotate to watch for dice
        //check to see if dice is out
    }
}

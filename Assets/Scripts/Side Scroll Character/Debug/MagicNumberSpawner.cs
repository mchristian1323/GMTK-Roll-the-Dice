using UnityEngine;
using DiceMechanics;
using UnityEngine.InputSystem;

namespace SideScrollControl.Debug
{
    public class MagicNumberSpawner : MonoBehaviour
    {
        PlayerInput myPlayerInput;
        NumberCaster myNumberCaster;

        // Start is called before the first frame update
        void Start()
        {
            myPlayerInput = GetComponent<PlayerInput>();
            myNumberCaster = GetComponent<NumberCaster>();

            myPlayerInput.actions["One"].started += OnOne;
            myPlayerInput.actions["Two"].started += OnTwo;
            myPlayerInput.actions["Three"].started += OnThree;
            myPlayerInput.actions["Four"].started += OnFour;
            myPlayerInput.actions["Five"].started += OnFive;
            myPlayerInput.actions["Six"].started += OnSix;
        }

        private void OnOne(InputAction.CallbackContext context)
        {
            myNumberCaster.NumberEnter(1);
        }

        private void OnTwo(InputAction.CallbackContext context)
        {
            myNumberCaster.NumberEnter(2);
        }

        private void OnThree(InputAction.CallbackContext context)
        {
            myNumberCaster.NumberEnter(3);
        }

        private void OnFour(InputAction.CallbackContext context)
        {
            myNumberCaster.NumberEnter(4);
        }

        private void OnFive(InputAction.CallbackContext context)
        {
            myNumberCaster.NumberEnter(5);
        }

        private void OnSix(InputAction.CallbackContext context)
        {
            myNumberCaster.NumberEnter(6);
        }
    }

}
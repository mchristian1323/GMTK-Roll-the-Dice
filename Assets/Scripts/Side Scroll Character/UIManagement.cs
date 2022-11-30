﻿using UnityEngine;
using UI.Player;
using SideScrollControl.CharacterAbilities;
using DiceMechanics;

namespace SideScrollControl
{
    public class UIManagement : MonoBehaviour
    {
        [SerializeField] AmmoUI myAmmoUI;
        [SerializeField] NumberSpellUI myNumberSpellUI;

        //this script sets up the ui without clogging up other scripts on the player character
        private void Start()
        {
            myAmmoUI.SetShootEmUp(GetComponent<ShootEmUp>());
            myNumberSpellUI.SetUpNumberSpellBook(GetComponent<NumberCaster>());
        }
    }
}
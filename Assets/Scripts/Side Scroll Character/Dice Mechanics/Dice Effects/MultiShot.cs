using SideScrollControl;
using SideScrollControl.CharacterAbilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceMechanics.DiceEffects
{
    public class MultiShot : UniqueEffect
    {
        ShootEmUp myShootEmUp;
        public override void NewEffect()
        {
            myShootEmUp = GetComponentInParent<ShootEmUp>();
            myShootEmUp.ActivateMultiShot();
        }
    }
}

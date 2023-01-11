using UnityEngine;
using SideScrollControl;

namespace DiceMechanics.DiceEffects
{
    public class IncreaseHealth : UniqueEffect
    {
        [SerializeField] float healthIncrease = 2f;
        SideScrollStatus mySideScrollStatus;

        public override void NewEffect()
        {
            mySideScrollStatus = GetComponentInParent<SideScrollStatus>();
            mySideScrollStatus.Heal(healthIncrease);
        }
    }
}
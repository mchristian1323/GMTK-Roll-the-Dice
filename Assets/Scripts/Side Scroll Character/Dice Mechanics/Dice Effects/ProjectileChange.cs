using UnityEngine;
using SideScrollControl.CharacterAbilities;

namespace DiceMechanics.DiceEffects
{
    public class ProjectileChange : UniqueEffect
    {
        [SerializeField] GameObject newProjectile;

        ShootEmUp myShootEmUp;

        public override void NewEffect()
        {
            myShootEmUp = GetComponentInParent<ShootEmUp>();
            if(newProjectile != null)
            {
                myShootEmUp.ChangeAmmo(newProjectile);
            }
        }
    }
}
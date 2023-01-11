using UnityEngine;
using SideScrollControl.CharacterAbilities;

namespace DiceMechanics.DiceEffects
{
    public class LaunchProjectile : UniqueEffect
    {
        [SerializeField] GameObject projectile;
        [SerializeField] int count;
        //possible launch point

        ShootEmUp myShootEmUp;

        public override void NewEffect()
        {
            //send projectile to bernadetta and launche the amount based on the number indicated
            if(projectile != null)
            {
                myShootEmUp = GetComponentInParent<ShootEmUp>();
                if (count < 1)
                {
                    myShootEmUp.CastSpell(projectile, 1);
                }
                else
                {
                    myShootEmUp.CastSpell(projectile, count);
                }
            }
        }
    }
}
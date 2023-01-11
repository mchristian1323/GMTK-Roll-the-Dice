using SideScrollControl.CharacterAbilities;

namespace DiceMechanics.DiceEffects
{
    public class IncreaseDamage : UniqueEffect
    {
        ShootEmUp myShootemup;
        public override void NewEffect()
        {
            //find the player
            //increase its damage temp
            myShootemup = GetComponentInParent<ShootEmUp>();
            myShootemup.SetDamage(1);
        }
    }
}
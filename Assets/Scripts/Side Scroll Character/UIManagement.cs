using UnityEngine;
using UI.Player;
using SideScrollControl.CharacterAbilities;

namespace SideScrollControl
{
    public class UIManagement : MonoBehaviour
    {
        [SerializeField] AmmoUI myAmmoUI;

        private void Start()
        {
            myAmmoUI.SetShootEmUp(GetComponent<ShootEmUp>());
        }
    }

}
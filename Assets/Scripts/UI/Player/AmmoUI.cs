using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SideScrollControl.CharacterAbilities;

namespace UI.Player
{
    public class AmmoUI : MonoBehaviour
    {
        ShootEmUp myShootEmUp;
        Transform bulletSlot;
        Transform bulletContainer;

        bool startup = false;

        private void Awake()
        {
            bulletContainer = transform.Find("Bullet Container");
            bulletSlot = bulletContainer.Find("Bullet Slot");
        }
        
        public void SetShootEmUp(ShootEmUp myShootEmUp)
        {
            this.myShootEmUp = myShootEmUp;

            myShootEmUp.OnBulletInteraction += AmmoUI_OnBulletInteraction;
            RefreshAmmoBelt();

            startup = true;
        }

        private void AmmoUI_OnBulletInteraction(object sender, System.EventArgs e)
        {
            RefreshAmmoBelt();
        }

        private void RefreshAmmoBelt()
        {
            //upon start up check the ammo count max and set up all the bullets using cell size
            if (!startup)
            {
                float bulletSlotCellsize = 75f;

                foreach (Transform child in bulletContainer)
                {
                    Destroy(child.gameObject);
                }

                for(int i = 0; i < 6; i++)
                {
                    RectTransform bulletSlotRectTransfrom = Instantiate(bulletSlot, bulletContainer).GetComponent<RectTransform>();

                    bulletSlotRectTransfrom.anchoredPosition = new Vector2(i * bulletSlotCellsize, 0);

                    if(!bulletSlotRectTransfrom.Find("Loaded").GetComponent<Image>().enabled)
                    {
                        bulletSlotRectTransfrom.Find("Loaded").GetComponent<Image>().enabled = true;
                    }

                    if (bulletSlotRectTransfrom.Find("Unloaded").GetComponent<Image>().enabled)
                    {
                        bulletSlotRectTransfrom.Find("Unloaded").GetComponent<Image>().enabled = false;
                    }

                    bulletSlotRectTransfrom.gameObject.GetComponent<AmmoSlotData>().SetNumber(i + 1);
                }
            }
            else
            {
                foreach(Transform child in bulletContainer)
                {
                    if(myShootEmUp.GetChamberAmmo() >= child.gameObject.GetComponent<AmmoSlotData>().GetNumber())
                    {
                        if (!child.Find("Loaded").GetComponent<Image>().enabled)
                        {
                            child.Find("Loaded").GetComponent<Image>().enabled = true;
                        }

                        if (child.Find("Unloaded").GetComponent<Image>().enabled)
                        {
                            child.Find("Unloaded").GetComponent<Image>().enabled = false;
                        }
                    }
                    else
                    {
                        if (child.Find("Loaded").GetComponent<Image>().enabled)
                        {
                            child.Find("Loaded").GetComponent<Image>().enabled = false;
                        }

                        if (!child.Find("Unloaded").GetComponent<Image>().enabled)
                        {
                            child.Find("Unloaded").GetComponent<Image>().enabled = true;
                        }
                    }
                    
                }
            }
            //for each child in the container check
                //check to see if the childs number is equal to the count
                //if true set the big inner child to true and the smaller to false
                //else
                //do the reverse

            
        }
    }
}

using SideScrollControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Player
{
    public class HealthAndCollectableUI : MonoBehaviour
    {
        SideScrollStatus mySideScrollStatus;
        [SerializeField] Slider healthBar; //countainer?
        Transform collectCounter; //will not need container

        bool startup = false;
        bool healthAdjust = false;
        float tempHealth;

        //action system
            //call the action
            //get current health
            //lerp health
            //round

        public void SetUpStats(SideScrollStatus playerSideScrollStatus)
        {
            mySideScrollStatus = playerSideScrollStatus;

            mySideScrollStatus.OnHealthInteraction += StatUI_OnHealthInteractions;
            mySideScrollStatus.OnCoinInteraction += StatUI_OnCoinInteractions;

            startup = true;
        }

        private void Update()
        {
            if(healthAdjust)
            {
                healthBar.value = Mathf.Lerp(healthBar.value, tempHealth, Time.deltaTime);
            }
        }

        private void StatUI_OnHealthInteractions(object sender, System.EventArgs e)
        {
            /*
            if(!startup)
            {
                healthBar.value = mySideScrollStatus.GetHealth();
            }
            else
            {
                tempHealth = healthBar.value - mySideScrollStatus.GetHealth();
                StopAllCoroutines();
                StartCoroutine(HealthChangeTimer());
            }
            */
            healthBar.value = mySideScrollStatus.GetHealth();

        }

        private void StatUI_OnCoinInteractions(object sender, System.EventArgs e)
        {
            //access stored value?
            //set to 0

        }

        private void RefreshHealth()
        {

        }

        private void RefreshCoin()
        {

        }

        IEnumerator HealthChangeTimer()
        {
            healthAdjust = true;
            yield return new WaitForSeconds(1f);

            healthAdjust = false;
            healthBar.value = tempHealth;
        }
    }
}

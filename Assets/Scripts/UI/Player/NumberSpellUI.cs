using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DiceMechanics;
using PixelCrushers.DialogueSystem;
using TMPro;
using DiceMechanics.DiceEffects;
using System.Linq;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

namespace UI.Player
{
    public class NumberSpellUI : MonoBehaviour
    {
        //serialized
        //for numbers
        [SerializeField] GameObject numberSlot;
        Transform numberSlotContainer;

        //for spells
        [SerializeField] GameObject spellSlot;
        Transform spellSlotContainer;
        Transform spellSlotReadyContainer;
        SpellSlotData[] readySpells;

        //for selector
        [SerializeField] GameObject selector;
        Transform selectorContainer;
        GameObject currentSelector;

        //private
        NumberCaster myNumberCaster;

        DiceEffects[] retrievedDiceEffectList;

        bool startup = false;

        int activeSpellCount = 0;
        int selectableRegion;
        int currentSelection = 0;

        private void Awake()
        {
            numberSlotContainer = transform.Find("Number Slot Container");
            spellSlotContainer = transform.Find("Spell Slot Container");
            selectorContainer = transform.Find("Selector Container");
            spellSlotReadyContainer = transform.Find("Spell Slot Ready Container");
            //numberSlot = numberSlotContainer.Find("Number Slot");
        }

        public void SetUpNumberSpellBook(NumberCaster myNumberCaster)
        {
            this.myNumberCaster = myNumberCaster;

            myNumberCaster.OnNumberInteraction += NumberUI_OnNumberInteraction;
            myNumberCaster.OnSpellInteraction += SpellUI_OnSpellInteraction;
            myNumberCaster.UpSelection += SelectorUI_OnSelectorInteractionUp;
            myNumberCaster.DownSelection += SelectorUI_OnSelectorInteractionDown;

            RefreshNumberSpellbook();
            RefreshSpellList();

            currentSelector = Instantiate(selector, selectorContainer);
            currentSelector.GetComponent<RectTransform>().anchoredPosition = spellSlotContainer.position;

            RefreshSelector();

            startup = true;
        }

        private void NumberUI_OnNumberInteraction(object sender, System.EventArgs e)
        {
            RefreshNumberSpellbook();
            RefreshSelector();
        }

        private void SpellUI_OnSpellInteraction(object sender, System.EventArgs e)
        {
            RefreshSpellList();
        }

        private void SelectorUI_OnSelectorInteractionUp(object sender, System.EventArgs e)
        {
            currentSelection++;
            RefreshSelector();
        }

        private void SelectorUI_OnSelectorInteractionDown(object sender, System.EventArgs e)
        {
            currentSelection--;
            RefreshSelector();
        }

        //possible neutral selector refresh

        private void RefreshNumberSpellbook()
        {
            float numberSlotSize = 75f;

            if (!startup)
            {
                foreach (Transform child in numberSlotContainer)
                {
                    Destroy(child.gameObject);
                }
            }
            else
            {
                foreach (Transform child in numberSlotContainer)
                {
                    Destroy(child.gameObject);
                }

                //have a for loop that cycles through the list size
                for (int i = 0; i < myNumberCaster.GetNumberListCount(); i++)
                {
                    RectTransform newNumberSlot = Instantiate(numberSlot, numberSlotContainer).GetComponent<RectTransform>();

                    newNumberSlot.anchoredPosition = new Vector2(i * numberSlotSize, 0);

                    newNumberSlot.Find("Number Text").GetComponent<TextMeshProUGUI>().text = myNumberCaster.GetSpecifiedNumberSlot(i);
                }
            }
        }

        private void RefreshSpellList()
        {
            float spellSlotSize = 34f;
            //generate spells equal to the list
            if(!startup)
            {
                retrievedDiceEffectList = myNumberCaster.GetDiceEffectArray();
                readySpells = new SpellSlotData[retrievedDiceEffectList.Length];

                foreach (Transform child in spellSlotContainer)
                {
                    Destroy(child.gameObject);
                }

                //for loop that generates the object by passing the name and assigning it a number.
                for(int i = 0; i < retrievedDiceEffectList.Length; i++)
                {
                    //instantiates the slot ->in the unready slot
                    RectTransform newSpellSlot = Instantiate(spellSlot, spellSlotContainer).GetComponent<RectTransform>();

                    //set position
                    newSpellSlot.anchoredPosition = new Vector2(0, i * -spellSlotSize);

                    //set text
                    newSpellSlot.Find("Spell Text").GetComponent<TextMeshProUGUI>().text = retrievedDiceEffectList[i].GetSpellName();

                    //set its number
                    newSpellSlot.GetComponent<SpellSlotData>().SetOriginalPlacing(i);
                    //set color
                    //when setting up color, make it a backing color
                    //set dullness
                    //dim and possibly no backing color?

                    //refreshing the spells- the information is in the 
                    myNumberCaster.SetSpellNumberListPosition(i, i);

                }

                selectableRegion = retrievedDiceEffectList.Length;
            }
            else
            {
                //sets a temporary spot
                GameObject[] tempHold = new GameObject[retrievedDiceEffectList.Length];

                //collects and deletes
                foreach (Transform child in spellSlotContainer)
                {
                    tempHold[child.GetComponent<SpellSlotData>().GetOriginalPlacing()] = child.gameObject;

                    Destroy(child.gameObject);
                }

                foreach(Transform child in spellSlotReadyContainer)
                {
                    tempHold[child.GetComponent<SpellSlotData>().GetOriginalPlacing()] = child.gameObject;

                    Destroy(child.gameObject);
                }

                activeSpellCount = 0;
                int unready = 0;
                int ready = 0;

                //resets text, number, and position while still keeping everything in order
                for(int i = 0; i < tempHold.Length; i++)
                {
                    if (retrievedDiceEffectList[i].GetNumberMatch())
                    {
                        //spawn
                        RectTransform refreshedSpellSlot = Instantiate(tempHold[i].gameObject, spellSlotReadyContainer).GetComponent<RectTransform>();
                        
                        //position
                        refreshedSpellSlot.anchoredPosition = new Vector2(0, ready * -spellSlotSize);

                        //gain spell from other list and set text
                        refreshedSpellSlot.Find("Spell Text").GetComponent<TextMeshProUGUI>().text = retrievedDiceEffectList[i].GetSpellName();
                        refreshedSpellSlot.Find("Spell Text").GetComponent<TextMeshProUGUI>().enabled = true;

                        //set menu number
                        refreshedSpellSlot.GetComponent<SpellSlotData>().SetOriginalPlacing(i);

                        //active spells for retrieval
                        readySpells[activeSpellCount] = refreshedSpellSlot.GetComponent<SpellSlotData>(); //null?

                        ready++;
                        activeSpellCount++;
                    }
                    else
                    {
                        //same but for unreadied spells
                        RectTransform refreshedSpellSlot = Instantiate(tempHold[i].gameObject, spellSlotContainer).GetComponent<RectTransform>();
                        
                        refreshedSpellSlot.anchoredPosition = new Vector2(0, unready * -spellSlotSize);

                        refreshedSpellSlot.Find("Spell Text").GetComponent<TextMeshProUGUI>().text = retrievedDiceEffectList[i].GetSpellName();
                        refreshedSpellSlot.Find("Spell Text").GetComponent<TextMeshProUGUI>().enabled = true;

                        refreshedSpellSlot.GetComponent<SpellSlotData>().SetOriginalPlacing(i);

                        unready++;
                    }
                }

                //activeSpellCount--;
                RefreshSelector();
            }
        }

        private void RefreshSelector()
        {
            Debug.Log(activeSpellCount);
            if(activeSpellCount == 0)
            {
                currentSelector.GetComponent<Image>().enabled = false;
            }
            else
            {
                currentSelector.GetComponent<Image>().enabled = true;
            }

            if(currentSelection > activeSpellCount)
            {
                currentSelection = 0;
            }

            if(currentSelection < 0 )
            {
                currentSelection = activeSpellCount;
            }

            currentSelector.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, currentSelection * -34f);
        }

        public int GetCurrentSelectionNumber()
        {
            return readySpells[currentSelection].GetOriginalPlacing();
        }

        public bool AreThereActiveSpells()
        {
            if(activeSpellCount >0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //need a selector ui
            //have it update when the player uses controls
            //only update the highlight and nothing else
            //store the selection and number and send it when player pushes button
            //have the selector only show or change numbers to active spells to avoid cycling through nonsensically

        //does this need to be in a different sctipt /\
            //i feel its better here because of info but maybe it would be to cluttered
    }
}

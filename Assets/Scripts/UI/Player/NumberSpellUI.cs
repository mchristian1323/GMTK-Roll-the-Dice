using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DiceMechanics;
using PixelCrushers.DialogueSystem;
using TMPro;
using DiceMechanics.DiceEffects;
using System.Linq;
using UnityEngine.InputSystem.HID;

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

        //for selector
        [SerializeField] GameObject selector;
        Transform selectorContainer;

        //private
        NumberCaster myNumberCaster;

        DiceEffects[] retrievedDiceEffectList;

        bool startup = false;
        int activeSpellCount = 0;

        // Start is called before the first frame update
        private void Awake()
        {
            numberSlotContainer = transform.Find("Number Slot Container");
            spellSlotContainer = transform.Find("Spell Slot Container");
            selectorContainer = transform.Find("SelectorContainer");
            spellSlotReadyContainer = transform.Find("Spell Slot Ready Container");
            //numberSlot = numberSlotContainer.Find("Number Slot");
        }

        public void SetUpNumberSpellBook(NumberCaster myNumberCaster)
        {
            this.myNumberCaster = myNumberCaster;

            myNumberCaster.OnNumberInteraction += NumberUI_OnNumberInteraction;
            myNumberCaster.OnSpellInteraction += SpellUI_OnSpellInteraction;

            RefreshNumberSpellbook();
            RefreshSpellList();

            startup = true;
        }

        private void NumberUI_OnNumberInteraction(object sender, System.EventArgs e)
        {
            RefreshNumberSpellbook();
        }

        private void SpellUI_OnSpellInteraction(object sender, System.EventArgs e)
        {
            RefreshSpellList();
        }

        private void SelectorUI_OnSelectorInteraction(object sender, System.EventArgs e)
        {
            RefreshSelector();
        }

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

                }
            }
            else
            {
                //reorganize the list depending on the numbers based on active 

                //upon update->
                //check the spells and move them to the proper list.
                //organize the spells in proper order
                //move the unready list down below the ready list(one spell length down)

                //a foreach that transfers all the read spells

                GameObject[] tempHold = new GameObject[retrievedDiceEffectList.Length];

                foreach (Transform child in spellSlotContainer)
                {
                    tempHold[child.GetComponent<SpellSlotData>().GetOriginalPlacing()] = child.gameObject;

                    Debug.Log(child.GetComponent<SpellSlotData>().GetOriginalPlacing());

                    Destroy(child.gameObject);
                }

                foreach(Transform child in spellSlotReadyContainer)
                {
                    tempHold[child.GetComponent<SpellSlotData>().GetOriginalPlacing()] = child.gameObject;

                    Debug.Log(child.GetComponent<SpellSlotData>().GetOriginalPlacing());

                    Destroy(child.gameObject);
                }

                int unready = 0;
                int ready = 0;

                for(int i = 0; i < tempHold.Length; i++)
                {
                    if (retrievedDiceEffectList[i].GetNumberMatch())
                    {
                        RectTransform refreshedSpellSlot = Instantiate(tempHold[i].gameObject, spellSlotReadyContainer).GetComponent<RectTransform>();
                        
                        refreshedSpellSlot.anchoredPosition = new Vector2(0, ready * -spellSlotSize);

                        refreshedSpellSlot.Find("Spell Text").GetComponent<TextMeshProUGUI>().text = retrievedDiceEffectList[i].GetSpellName();
                        refreshedSpellSlot.Find("Spell Text").GetComponent<TextMeshProUGUI>().enabled = true;

                        refreshedSpellSlot.GetComponent<SpellSlotData>().SetOriginalPlacing(i);

                        ready++;
                    }
                    else
                    {
                        RectTransform refreshedSpellSlot = Instantiate(tempHold[i].gameObject, spellSlotContainer).GetComponent<RectTransform>();
                        
                        refreshedSpellSlot.anchoredPosition = new Vector2(0, unready * -spellSlotSize);

                        refreshedSpellSlot.Find("Spell Text").GetComponent<TextMeshProUGUI>().text = retrievedDiceEffectList[i].GetSpellName();
                        refreshedSpellSlot.Find("Spell Text").GetComponent<TextMeshProUGUI>().enabled = true;

                        refreshedSpellSlot.GetComponent<SpellSlotData>().SetOriginalPlacing(i);

                        unready++;
                    }
                }
            }
        }

        private void RefreshSelector()
        {
            //have the selector be generated under the spell listing
            //have it rather access the number or have an even count
                //if spell is unavailable or unselectable then selector can't move
                //if at the bottom wrap around
                //if none are selectable don't appear, if there are some then appear
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

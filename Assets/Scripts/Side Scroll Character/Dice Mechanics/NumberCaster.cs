using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UI.Player;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DiceMechanics
{
    public class NumberCaster : MonoBehaviour
    {
        [SerializeField] DiceEffects.DiceEffects[] activeEffects;

        List<int> numberSpellBook = new List<int>();

        public event EventHandler OnNumberInteraction;
        public event EventHandler OnSpellInteraction;
        public event EventHandler UpSelection;
        public event EventHandler DownSelection;

        int numberCounter;

        int storedPosition;

        private void Start()
        {
            //need to set the arrays to dictionaries and reset the number counter
            numberCounter = 0;
            foreach (DiceEffects.DiceEffects effect in activeEffects)
            {
                effect.SetUpSpell();
            }
        }

        public void NumberEnter(int newNumber)
        {
            if(numberCounter < 6) //can't add more than limit
            {
                //adds numbers
                numberSpellBook.Add(newNumber);
                OnNumberInteraction?.Invoke(this, EventArgs.Empty);
                numberCounter++;

                //figures out 
                foreach(DiceEffects.DiceEffects effect in activeEffects)
                {
                    effect.TestTheNumbers(newNumber);
                    //Debug.Log(effect.GetSpellName() + " " + effect.GetNumberMatch().ToString());
                }
                OnSpellInteraction?.Invoke(this, EventArgs.Empty);
            }
        }
        //take all of the effects and add them to the ui
            //possible colors and greyed out for not ready -> need color options with scriptable objects
            //also need to display numbers that it uses -> need number get/catagory get

        //when spell is ready, move to the top of the list and ligt up
            //need a way to activate the spell without clicking -> have controls and slot change depending on number and/or bool
            //once spell is used put back in the original part of the list under ready spells -> have a set number and a current number
                //order it in the list depending on that number

        public void MoveSelectionUp()
        {
            UpSelection?.Invoke(this, EventArgs.Empty);
        }
        public void MoveSelectionDown()
        {
            DownSelection?.Invoke(this, EventArgs.Empty);
        }

        public void ActivateCurrentSpell()
        {
            NumberSpellUI tempNumberSpellUI = FindObjectOfType<NumberSpellUI>();


            if(tempNumberSpellUI.AreThereActiveSpells())
            {
                //get the selection number
                int[] numbersToDelete = activeEffects[tempNumberSpellUI.GetCurrentSelectionNumber()].GetOriginalArray();

                if (activeEffects[tempNumberSpellUI.GetCurrentSelectionNumber()].AreAllNumbersNeeded())
                {
                    //if all numbers are to be deleted
                    //scan the bank for all the numbers and delete them
                    //int storedPosition; //don't know why it wants it here

                    foreach (int number in numbersToDelete)
                    {
                        int duplicates = 0;
                        bool success = false;

                        //if havent deleted delete
                        //if have then start counting

                        for (int i = 0; i < numberSpellBook.Count; i++)
                        {
                            if(number == numberSpellBook[i])
                            {
                                if(!success)
                                {
                                    storedPosition = i;
                                }
                                else
                                {
                                    duplicates++;
                                }
                            }
                        }
                        numberSpellBook.RemoveAt(storedPosition);
                        numberCounter--;

                        if (duplicates == 0)
                        {
                            activeEffects[tempNumberSpellUI.GetCurrentSelectionNumber()].TestTheReset(number);
                        }
                    }
                }
                else
                {
                    //if only one number is needed
                    //scan the numbers and delete whats there. if the number is a singleton unready the number in the dictionary
                    bool success = false;
                    int duplicates = 0;
                    int cachedDeletedNumber = 0;
                    foreach(int number in numbersToDelete)
                    {
                        //focus on counting, delete the first number you meet. if count is bigger send the deleted number
                        for(int i = 0; i < numberSpellBook.Count; i++)
                        {
                            if(number == numberSpellBook[i])
                            {
                                if(!success)
                                {
                                    storedPosition = i;
                                    success = true;
                                    cachedDeletedNumber = numberSpellBook[i];
                                }
                                else
                                {
                                    duplicates++;
                                }
                            }
                            //need to find a way to cancel the other numbers if they are not there.
                            if(duplicates == 0)
                            {
                                activeEffects[tempNumberSpellUI.GetCurrentSelectionNumber()].TestTheReset(cachedDeletedNumber);
                            }
                        }
                    }

                    numberSpellBook.RemoveAt(storedPosition);
                    numberCounter--;
                }

                foreach(DiceEffects.DiceEffects effect in activeEffects)
                {
                    if(effect.GetNumberMatch())
                    {
                        effect.CheckCurrentStatus(numberSpellBook);
                    }
                }

                //test every other active effect
                    //send the used numbers and activate,

                //maybe check if there are no numbers and run through the dict

                //instantiates and activates then apply ui. doesnt do all of the effects yet
                GameObject newEffect = activeEffects[tempNumberSpellUI.GetCurrentSelectionNumber()].GetEffect();

                Instantiate(newEffect, gameObject.transform);
                OnNumberInteraction?.Invoke(this, EventArgs.Empty);
                OnSpellInteraction?.Invoke(this, EventArgs.Empty);
            }
            //check to see if there are active spells

            //get current number and if can cast

            //activate spell

            foreach (DiceEffects.DiceEffects effect in activeEffects)
            {
                //Debug.Log(effect.GetSpellName() + " " + effect.GetNumberMatch());
                //Debug.Log(effect.GetSpellName() + " " + effect.GetNumberMatch().ToString());
            }
        }

        public void FumbleEnter()
        {
            //when all 3 bad effect slots are full, a bad effect happens
            //animation, what effects,

            //increment bad effects
            //need a way to decrement
            //when at 3 cause one of the random bad effects
        }

        //getters and setters
        public void SetSpellNumberListPosition(int spell, int position)
        {
            activeEffects[spell].SetListPosition(position);
        }

        public int GetNumberListCount()
        {
            return numberSpellBook.Count;
        }

        public string GetSpecifiedNumberSlot(int slot)
        {
            if(slot < 0 || slot > 5)
            {
                return "0";
            }
            else
            {
                return numberSpellBook[slot].ToString();
            }
        }

        public int GetDiceEffectListLength()
        {
            return activeEffects.Length;
        }

        public DiceEffects.DiceEffects[] GetDiceEffectArray()
        {
            return activeEffects;
        }
    }
}
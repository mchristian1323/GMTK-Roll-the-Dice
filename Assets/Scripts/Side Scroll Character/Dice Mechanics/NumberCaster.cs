using System;
using System.Collections;
using System.Collections.Generic;
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

        int numberCounter;

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
        
        public void FumbleEnter()
        {
            //when all 3 bad effect slots are full, a bad effect happens
            //animation, what effects,

            //increment bad effects
            //need a way to decrement
            //when at 3 cause one of the random bad effects
        }

        //getters and setters
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
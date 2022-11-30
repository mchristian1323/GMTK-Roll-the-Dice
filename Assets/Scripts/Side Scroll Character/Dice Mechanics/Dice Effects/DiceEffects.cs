using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DiceMechanics.DiceEffects
{
    [CreateAssetMenu(fileName = "Dice Spell", menuName = "Dice Spell", order = 1)]
    public class DiceEffects : ScriptableObject
    {
        //need this to be an arrray
        [SerializeField] string spellName;
        [SerializeField] int[] enteredNumbers;
        [SerializeField] bool areAllNumbersNeeded;
        //spell description

        Dictionary<int, bool> number;
        int numberSuccessCount;
        bool numberMatch;

        public void SetUpSpell()
        {
            number = new Dictionary<int, bool>();
            numberMatch= false;
            foreach(int num in enteredNumbers)
            {
                number.Add(num, false);
            }
        }

        public void TestTheNumbers(int acheivedNumber)
        {
            if(!numberMatch) //skips if good to go
            {
                foreach(int key in number.Keys.ToList()) //checks the numbers
                {
                    if(acheivedNumber == key) //if bool is not set then just activate and break
                    {
                        number[key] = true;

                        if(!areAllNumbersNeeded)
                        {
                            numberMatch = true;
                            break;
                        }
                        else //if bool is true then cycle through all numbers and up the counter, if counter is full then activate and break
                        {
                            numberSuccessCount = 0;
                            foreach(bool value in number.Values.ToList())
                            {
                                if (value)
                                {
                                    numberSuccessCount++;
                                }
                            }
                            if(numberSuccessCount == number.Count)
                            {
                                numberMatch = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        //can be done in script to check if the numbers again ->need to grab the number list
        private void ResetSpell()
        {
            foreach(int key in number.Keys)
            {
                number[key] = false;
                numberMatch = false;

                //check if spell has more of the same number before reseting
            }
        }

        //getters
        public int GetNumberArraySize()
        {
            return number.Count;
        }

        public bool GetNumberMatch()
        {
            return numberMatch;
        }

        public string GetSpellName()
        {
            return spellName;
        }

        public int[] GetOriginalArray()
        {
            return enteredNumbers;
        }

        //do we need a system for doubles or 3 of a kind
            //could be an if statement to avoid the first formula all together to get weight off the system

        //effects
        //four ideas
            //have effects be in this script
                //still need to figure out how to do it

            //have effects be in other sctript and this script just looks for them or is matched to them

            //have effects be single scripts that are held in this and are given an object and activate then destroy themselves
                //might not work for the discard effects
                //this might work well if the objects are invisible and delete quickly. almost like projectiles

            //have all the effects in here and have the inspector decide which one the SO passes.
                //this one might be kind of over encoumbering

            //have an effect script/projectile that this sends a string or number to then that script activates the effects from there.
                //if its a discard spell, then have it the player and change something

        //after effect is cast reset the spell
    }
}

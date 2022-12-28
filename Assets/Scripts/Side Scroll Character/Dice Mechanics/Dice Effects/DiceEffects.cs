using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DiceMechanics.DiceEffects
{
    [CreateAssetMenu(fileName = "Dice Spell", menuName = "Dice Spell", order = 1)]
    public class DiceEffects : ScriptableObject
    {
        //need this to be an arrray
        [SerializeField] string spellName;
        [SerializeField] int[] enteredNumbers;
        [SerializeField] bool areAllNumbersNeeded;
        [SerializeField] GameObject effect;
        //spell description

        Dictionary<int, bool> number;
        int numberSuccessCount;
        bool numberMatch;

        int listPosition;

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
            if(!numberMatch || !areAllNumbersNeeded) //skips if good to go
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

        public void TestTheReset(int usedNumber)
        {
            //run throug the dict and turn off the numbers bool
            //if all numbers are needed then numbermatch is false

            foreach(int key in number.Keys.ToList())
            {
                if(key == usedNumber)
                {
                    number[key] = false;
                    if(areAllNumbersNeeded)
                    {
                        if(numberMatch)
                        {
                            numberMatch= false;
                        }
                    }
                }
            }

            if(!areAllNumbersNeeded)
            {
                int count = 0;
                foreach(int key in number.Keys.ToList())
                {
                    if (number[key] == true)
                    {
                        count++;
                    }
                }
                if(count == 0)
                {
                    numberMatch = false;
                }
            }
        }
        
        public void CheckCurrentStatus(List<int> listToCompare)
        {
            if(listToCompare.Count == 0)
            {
                numberMatch = false;
                foreach(int key in number.Keys.ToList())
                {
                    number[key] = false;
                }

                return;
            }
            if(numberMatch)
            {
                int failCount = 0;
                foreach(int key in number.Keys.ToList())
                {
                    int duplicates = 0;
                    for(int i = 0; i < listToCompare.Count; i++)
                    {
                        if (key == listToCompare[i])
                        {
                            duplicates++;
                        }
                    }

                    if(duplicates == 0)
                    {
                        number[key] = false;
                        failCount++;

                        if(areAllNumbersNeeded || failCount == number.Count)
                        {
                            numberMatch = false;
                        }
                    }
                }
            }
        }

        //getters and setters
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

        public bool AreAllNumbersNeeded()
        {
            return areAllNumbersNeeded;
        }

        public void SetListPosition(int newPosition)
        {
            listPosition = newPosition;
        }

        public int GetListPosition()
        {
            return listPosition;
        }

        public GameObject GetEffect()
        {
            return effect;
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

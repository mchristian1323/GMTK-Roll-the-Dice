using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceMechanics
{
    public class NumberCaster : MonoBehaviour
    {
        //this script calculates options based on number combo
            //how do i make the ui respond to the available functions/numbers
            //what do i do with duplicates? 2 of a kind, 3 of a kind, 4 of a kind?
            //number limit, numbers full, messing with these values
        

        List<int> numberSpellBook = new List<int>();
        //->ui for each number
        //->take out and insert new numbers

        //serialized field of a list of scriptable objects. enter in those scriptable objects in inspector and prefabbed
            //the scriptable objects have numbers and a name, then transfer an effect somehow

        public void NumberEnter(int newNumber)
        {
            //make a list
            //have a list of scriptable objects
            //scan the numbers from the SO
            //then scan the numbers and see if you have matches
        }

        //when all 3 bad effect slots are full, a bad effect happens
        //animation, what effects,
        public void FumbleEnter()
        {
            //increment bad effects
                //need a way to decrement
            //when at 3 cause one of the random bad effects
        }
    }
}

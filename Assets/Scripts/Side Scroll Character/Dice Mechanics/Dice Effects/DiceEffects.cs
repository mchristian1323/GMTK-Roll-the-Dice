using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceMechanics.DiceEffects
{
    public class DiceEffects : ScriptableObject
    {
        //need this to be an arrray
        [SerializeField] int number;

        public int GetNumber()
        {
            return number;
        }
    }
}
